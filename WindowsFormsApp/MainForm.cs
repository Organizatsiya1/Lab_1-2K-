using BusinessLogic;
using BusinessLogicModels;
using Models;
using Ninject;
using System;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        private Facade facade;
        IKernel ninjectKernel;

        public MainForm()
        {
            InitializeComponent();

            // Инициализируем с репозиторием по умолчанию (Entity)
            ninjectKernel = new StandardKernel(new SimpleConfigModule(false));
            facade = ninjectKernel.Get<Facade>();

            radioButtonEntityRepository.Checked = true; // по умолчанию EF
            InitializeDataGridView();
            RefreshGrid(); // таблица пустая при запуске
        }


        /// <summary>
        /// Объявление шаблона таблицы, наполняет фильтры
        /// значениями перечислений оружия и школ магии
        /// </summary>
        private void InitializeDataGridView()
        {
            dataGridViewCharacters.AutoGenerateColumns = false;

            // Включим авторазмер строк по содержимому (чтобы многострочные описания показывались)
            dataGridViewCharacters.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCharacters.RowTemplate.Height = 50;

            // Небольшие косметические настройки
            dataGridViewCharacters.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCharacters.AllowUserToAddRows = false;
            dataGridViewCharacters.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCharacters.MultiSelect = true;

            // фильтры
            comboBoxFilterWeapon.Items.Clear();
            comboBoxFilterWeapon.Items.AddRange(Displays.WeaponsNames.Values.ToArray());
            comboBoxFilterWeapon.SelectedIndex = 0;

            comboBoxFilterSchool.Items.Clear();
            comboBoxFilterSchool.Items.AddRange(Displays.MagicNames.Values.ToArray());
            comboBoxFilterSchool.SelectedIndex = 0;
        }

        /// <summary>
        /// Добавляет персонажа в таблицу
        /// </summary>
        /// <param name="index">Номер по порядку</param>
        /// <param name="c">Объект персонажа</param>
        private void AddCharacterRow(int index, Character c)
        {
            string type = Displays.CharacterTypes[c.GetType()];
            string name = c.Name ?? "";
            int hp = c.HP;
            int str = c.Strength;

            // значения по умолчанию
            int stamina = 0;
            int mana = 0;
            string weapon = "—";
            string school = "—";
            string desc = c.Description ?? "";

            if (c is Fighter f)
            {
                stamina = f.Stamina;
                weapon = Displays.WeaponsNames[f.Weapon];
            }
            else if (c is Mage m)
            {
                mana = m.Mana;
                school = Displays.MagicNames[m.School];
            }

            dataGridViewCharacters.Rows.Add(
                index, type, name, hp, str, stamina, mana, weapon, school, desc
            );
        }

        /// <summary>
        /// Заполнение таблица текущими юнитами и обновление таблицы
        /// </summary>
        private void RefreshGrid()
        {
            dataGridViewCharacters.Rows.Clear();
            var list = facade.GetUnits(); // берем список из логики

            for (int i = 0; i < list.Count; i++)
            {
                AddCharacterRow(i, list[i]);
            }
        }

        /// <summary>
        /// Возвращает объест персонажа, соответствующей выбранной строки таблицы 
        /// </summary>
        /// <returns>Выбранный объект персонажа, или же значение null при ошибке выбора</returns>
        private Character GetSelectedCharacter()
        {
            if (dataGridViewCharacters.CurrentRow == null || dataGridViewCharacters.CurrentRow.Index < 0)
            {
                MessageBox.Show("Выберите персонажа!");
                return null;
            }

            // вычисляем индекс выбранной строки и сопоставляем с логикой
            int rowIndex = dataGridViewCharacters.CurrentRow.Index;
            var list = facade.GetUnits();
            if (rowIndex >= 0 && rowIndex < list.Count)
                return list[rowIndex];

            MessageBox.Show("Неверный выбор.");
            return null;
        }

        /// <summary>
        /// Открывает форму создания персонажа
        /// После успешного создания передаёт данные в слой логики (Logic) 
        /// для добавления в список юнитов и обновляет таблицу
        /// </summary>
        /// <param name="sender">Ссылка на объект</param>
        /// <param name="e">Аргументы события</param>
        private void buttonAddHero_Click(object sender, EventArgs e)
        {
            using (AddHeroForm form = new AddHeroForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Character hero = form.CreatedHero;
                    // используем методы логики (не внутренний список формы)
                    if (hero is Fighter f)
                        facade.AddFighter(f.Name, f.Description, f.HP, f.Strength, f.Stamina, f.Weapon);
                    else if (hero is Mage m)
                        facade.AddMage(m.Name, m.Description, m.HP, m.Strength, m.Mana, m.School);

                    RefreshGrid();
                }
            }
        }

        /// <summary>
        /// Удаляет выбранного персонажа через логику и обновляет таблицу
        /// Если ничего не выбрано — ничего не делает
        /// </summary>
        /// <param name="sender">Ссылка на объект</param>
        /// <param name="e">Аргументы события</param>
        private void buttonDeleteHero_Click(object sender, EventArgs e)
        {
            Character selected = GetSelectedCharacter();
            if (selected == null) return;

            facade.DeleteUnit(selected);
            RefreshGrid();
            MessageBox.Show("Персонаж удалён!");
        }

        /// <summary>
        /// Открывает форму редактирования для выбранного персонажа
        /// По подтверждении обновляет данные через методы логики и обновляет интерфейс
        /// </summary>
        /// <param name="sender">Ссылка на объект</param>
        /// <param name="e">Аргументы события</param>
        private void buttonEditHero_Click(object sender, EventArgs e)
        {
            Character selected = GetSelectedCharacter();
            if (selected == null) return;

            using (AddHeroForm form = new AddHeroForm(selected))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var newValues = form.CreatedHero;

                    if (selected is Fighter oldF && newValues is Fighter newF)
                    {
                        facade.ChangeFighter(oldF, newF.Name, newF.Description, newF.HP, newF.Strength, newF.Stamina, newF.Weapon);
                    }
                    else if (selected is Mage oldM && newValues is Mage newM)
                    {
                        facade.ChangeMage(oldM, newM.Name, newM.Description, newM.HP, newM.Strength, newM.Mana, newM.School);
                    }
                    else
                    {
                        // тип изменён: удаляем старый и добавляем новый через логику
                        facade.DeleteUnit(selected);
                        if (newValues is Fighter nf)
                            facade.AddFighter(nf.Name, nf.Description, nf.HP, nf.Strength, nf.Stamina, nf.Weapon);
                        else if (newValues is Mage nm)
                            facade.AddMage(nm.Name, nm.Description, nm.HP, nm.Strength, nm.Mana, nm.School);
                    }

                    RefreshGrid();
                    MessageBox.Show("Персонаж обновлён.");
                }
            }
        }

        /// <summary>
        /// Отображает в таблице только воинов с выбранным типом оружия
        /// </summary>
        /// <param name="sender">Ссылка на объект</param>
        /// <param name="e">Аргументы события</param>
        private void buttonFilterFighters_Click(object sender, EventArgs e)
        {
            if (comboBoxFilterWeapon.SelectedItem == null) return;

            var selectedWeapon = Displays.WeaponsNames.FirstOrDefault(
                kv => kv.Value == comboBoxFilterWeapon.SelectedItem.ToString()
            ).Key;

            var filtered =  facade.ChooseMarked(selectedWeapon);
            if (!filtered.Any())
            {
                MessageBox.Show("Нет воинов с выбранным оружием!");
                return;
            }

            // показываем результат (заменим RefreshGrid -> временно показываем отфильтрованное)
            dataGridViewCharacters.Rows.Clear();
            for (int i = 0; i < filtered.Count; i++)
            {
                AddCharacterRow(i, filtered[i]);
            }
        }

        /// <summary>
        /// Отображает в таблице только магов с выбранной школой магии
        /// </summary>
        /// <param name="sender">Ссылка на объект</param>
        /// <param name="e">Аргументы события</param>
        private void buttonFilterMages_Click(object sender, EventArgs e)
        {
            if (comboBoxFilterSchool.SelectedItem == null) return;

            var selectedSchool = Displays.MagicNames.FirstOrDefault(
                kv => kv.Value == comboBoxFilterSchool.SelectedItem.ToString()
            ).Key;

            var filtered = facade.ChooseMarked(selectedSchool);
            if (!filtered.Any())
            {
                MessageBox.Show("Нет магов с выбранной школой!");
                return;
            }

            dataGridViewCharacters.Rows.Clear();
            for (int i = 0; i < filtered.Count; i++)
            {
                AddCharacterRow(i, filtered[i]);
            }
        }

        /// <summary>
        /// Обрабатывает событие нажатия кнопки "Поединок", имитируя бой между двумя выбранными персонажами
        /// </summary>
        /// <param name="sender">Ссылка на объект</param>
        /// <param name="e">Аргументы события</param>
        private void buttonSort_Click(object sender, EventArgs e)
        {
            var selRows = dataGridViewCharacters.SelectedRows;
            if (selRows.Count != 2)
            {
                MessageBox.Show("Выберите ровно двух персонажей (держите Ctrl и кликните по строкам).");
                return;
            }

            // Получаем индексы строк
            int idx1 = selRows[0].Index;
            int idx2 = selRows[1].Index;

            var list = facade.GetUnits();
            if (idx1 < 0 || idx1 >= list.Count || idx2 < 0 || idx2 >= list.Count)
            {
                MessageBox.Show("Ошибка выбора персонажей.");
                return;
            }

            var ch1 = list[idx1];
            var ch2 = list[idx2];

            string result = facade.Fight(ch1, ch2);
            RefreshGrid();
            MessageBox.Show(result, "Результат поединка");
        }

        /// <summary>
        /// Восстанавливает полный список юнитов в таблице (сброс фильтров)
        /// </summary>
        /// <param name="sender">Ссылка на объект</param>
        /// <param name="e">Аргументы события</param>
        private void buttonShowAll_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        /// <summary>
        /// Обрабатывает изменение состояния радиокнопки выбора репозитория Entity
        /// </summary>
        /// <param name="sender">Ссылка на объект</param>
        /// <param name="e">Аргументы события</param>
        private void radioButtonEntityRepository_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEntityRepository.Checked)
            {
                ninjectKernel = new StandardKernel(new SimpleConfigModule(false));
                facade = ninjectKernel.Get<Facade>();
                RefreshGrid();
            }
        }

        /// <summary>
        /// Обрабатывает изменение состояния радиокнопки выбора репозитория Dapper
        /// </summary>
        /// <param name="sender">Ссылка на объект</param>
        /// <param name="e">Аргументы события</param>
        private void radioButtonDapperRepository_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDapperRepository.Checked)
            {
                ninjectKernel = new StandardKernel(new SimpleConfigModule(true));
                facade = ninjectKernel.Get<Facade>();
                RefreshGrid();
            }
        }
    }
}