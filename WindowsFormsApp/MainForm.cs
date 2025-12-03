using Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class MainForm : Form, IView
    {
        public event Action AddDataEvent;
        public event Action DeleteDataEvent;
        public event Action EditDataEvent;
        public event Action LoadDataEvent;

        public event Action FightEvent;
        public event Action<string> FilterFightersEvent;
        public event Action<string> FilterMagesEvent;

        public event Action<bool> ChangeRepositoryEvent;

        public MainForm()
        {
            InitializeComponent();
            InitializeDataGridView();
            BindEvents();
        }

        /// <summary>
        /// Подписка на собития
        /// </summary>
        private void BindEvents()
        {
            buttonFilterFighters.Click += ButtonFilterFighters_Click;
            buttonFilterMages.Click += ButtonFilterMages_Click;

            // Подписка на кнопку поединка
            buttonFight.Click += ButtonFight_Click;

            // Подписка на радиокнопки выбора репозитория
            radioButtonEntityRepository.CheckedChanged += RadioButtonRepository_CheckedChanged;
            radioButtonDapperRepository.CheckedChanged += RadioButtonRepository_CheckedChanged;
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

            int rowIndex = dataGridViewCharacters.Rows.Add(index, type, name, hp, str, stamina, mana, weapon, school, desc);

            dataGridViewCharacters.Rows[rowIndex].Tag = c;
        }

        /// <summary>
        /// Обновление таблицы
        /// </summary>
        /// <param name="units">Список персонаж</param>
        public void Redraw(List<Character> units)
        {
            dataGridViewCharacters.Rows.Clear();
            for (int i = 0; i < units.Count; i++)
            {
                AddCharacterRow(i, units[i]);
            }
        }

        /// <summary>
        /// Возвращает объест персонажа, соответствующей выбранной строки таблицы 
        /// </summary>
        /// <returns>Выбранный объект персонажа, или же значение null при ошибке выбора</returns>
        public Character GetSelectedCharacter()
        {
            if (dataGridViewCharacters.CurrentRow == null || dataGridViewCharacters.CurrentRow.Index < 0)
            {
                MessageBox.Show("Выберите персонажа!");
                return null;
            }

            return dataGridViewCharacters.CurrentRow.Tag as Character;
        }

        /// <summary>
        /// Показ сообщения пользователю
        /// </summary>
        /// <param name="text">Сообщение</param>
        public void ShowMessage(string text)
        {
            MessageBox.Show(text, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Показ сообщения ошибки пользователю
        /// </summary>
        /// <param name="text">Сообщение ошибки</param>
        public void ShowError(string text)
        {
            MessageBox.Show(text, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            AddDataEvent?.Invoke();
        }

        /// <summary>
        /// Удаляет выбранного персонажа через логику и обновляет таблицу
        /// Если ничего не выбрано — ничего не делает
        /// </summary>
        /// <param name="sender">Ссылка на объект</param>
        /// <param name="e">Аргументы события</param>
        private void buttonDeleteHero_Click(object sender, EventArgs e)
        {
            DeleteDataEvent?.Invoke();
        }

        /// <summary>
        /// Открывает форму редактирования для выбранного персонажа
        /// По подтверждении обновляет данные через методы логики и обновляет интерфейс
        /// </summary>
        /// <param name="sender">Ссылка на объект</param>
        /// <param name="e">Аргументы события</param>
        private void buttonEditHero_Click(object sender, EventArgs e)
        {
            EditDataEvent?.Invoke();
        }

        /// <summary>
        /// Восстанавливает полный список юнитов в таблице (сброс фильтров)
        /// </summary>
        /// <param name="sender">Ссылка на объект</param>
        /// <param name="e">Аргументы события</param>
        private void buttonShowAll_Click(object sender, EventArgs e)
        {
            LoadDataEvent?.Invoke();
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Фильтр воинов"
        /// </summary>
        private void ButtonFilterFighters_Click(object sender, EventArgs e)
        {
            string selectedWeapon = comboBoxFilterWeapon.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedWeapon))
                FilterFightersEvent?.Invoke(selectedWeapon);
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Фильтр магов"
        /// </summary>
        private void ButtonFilterMages_Click(object sender, EventArgs e)
        {
            string selectedSchool = comboBoxFilterSchool.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedSchool))
                FilterMagesEvent?.Invoke(selectedSchool);
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Поединок"
        /// </summary>
        private void ButtonFight_Click(object sender, EventArgs e)
        {
            var selectedRows = dataGridViewCharacters.SelectedRows;

            if (selectedRows.Count == 2)
                FightEvent?.Invoke();
            else
                ShowMessage("Для поединка необходимо выбрать ровно двух персонажей!");
        }

        /// <summary>
        /// Обработчик изменения состояния радиокнопок репозитория
        /// </summary>
        private void RadioButtonRepository_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEntityRepository.Checked)
            {
                // выбран Entity Framework 
                ChangeRepositoryEvent?.Invoke(false);
            }
            else if (radioButtonDapperRepository.Checked)
            {
                ChangeRepositoryEvent?.Invoke(true);
            }
        }
    }
}