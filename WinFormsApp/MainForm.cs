using Business_Logic;
using Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        private Logic logic = new Logic();

        public MainForm()
        {
            InitializeComponent();
            InitializeDataGridView();
            RefreshGrid(); // таблица пустая при запуске
        }

        private void InitializeDataGridView()
        {
            dataGridViewCharacters.AutoGenerateColumns = false;
            dataGridViewCharacters.Columns.Clear();

            dataGridViewCharacters.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Тип", Width = 80 });
            dataGridViewCharacters.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Имя", Width = 150 });
            dataGridViewCharacters.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Описание", Width = 300 });
            dataGridViewCharacters.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "HP", Width = 60 });
            dataGridViewCharacters.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Сила", Width = 60 });
            dataGridViewCharacters.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Выносливость / Мана", Width = 120 });
            dataGridViewCharacters.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Оружие / Школа", Width = 120 });

            // фильтры
            comboBoxFilterWeapon.Items.Clear();
            comboBoxFilterWeapon.Items.AddRange(Enum.GetNames(typeof(Weapons)));
            comboBoxFilterWeapon.SelectedIndex = 0;

            comboBoxFilterSchool.Items.Clear();
            comboBoxFilterSchool.Items.AddRange(Enum.GetNames(typeof(Magic_Schools)));
            comboBoxFilterSchool.SelectedIndex = 0;
        }

        private void RefreshGrid()
        {
            dataGridViewCharacters.Rows.Clear();
            var list = logic.GetUnits(); // берем список из логики

            foreach (var c in list)
            {
                string type = c is Fighter ? "Воин" : c is Mage ? "Маг" : c.GetType().Name;
                string secondary = "";
                string classExtra = "";

                if (c is Fighter f)
                {
                    secondary = f.Stamina.ToString();
                    classExtra = f.Weapon.ToString();
                }
                else if (c is Mage m)
                {
                    secondary = m.Mana.ToString();
                    classExtra = m.School.ToString();
                }

                dataGridViewCharacters.Rows.Add(type, c.Name, c.Description, c.HP, c.Strength, secondary, classExtra);
            }
        }

        private Character GetSelectedCharacter()
        {
            if (dataGridViewCharacters.CurrentRow == null || dataGridViewCharacters.CurrentRow.Index < 0)
            {
                MessageBox.Show("Выберите персонажа!");
                return null;
            }

            // вычисляем индекс выбранной строки и сопоставляем с логикой
            int rowIndex = dataGridViewCharacters.CurrentRow.Index;
            var list = logic.GetUnits();
            if (rowIndex >= 0 && rowIndex < list.Count)
                return list[rowIndex];

            MessageBox.Show("Неверный выбор.");
            return null;
        }

        private void buttonAddHero_Click(object sender, EventArgs e)
        {
            using (AddHeroForm form = new AddHeroForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Character hero = form.CreatedHero;
                    // используем методы логики (не внутренний список формы)
                    if (hero is Fighter f)
                        logic.Add_Fighter(f.Name, f.Description, f.HP, f.Strength, f.Stamina, f.Weapon);
                    else if (hero is Mage m)
                        logic.Add_Mage(m.Name, m.Description, m.HP, m.Strength, m.Mana, m.School);

                    RefreshGrid();
                }
            }
        }

        private void buttonDeleteHero_Click(object sender, EventArgs e)
        {
            Character selected = GetSelectedCharacter();
            if (selected == null) return;

            logic.Delete_Unit(selected);
            RefreshGrid();
            MessageBox.Show("Персонаж удалён!");
        }

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
                        logic.Change_Fighter(oldF, newF.Name, newF.Description, newF.HP, newF.Strength, newF.Stamina, newF.Weapon);
                    }
                    else if (selected is Mage oldM && newValues is Mage newM)
                    {
                        logic.Change_Mage(oldM, newM.Name, newM.Description, newM.HP, newM.Strength, newM.Mana, newM.School);
                    }
                    else
                    {
                        // тип изменён: удаляем старый и добавляем новый через логику
                        logic.Delete_Unit(selected);
                        if (newValues is Fighter nf)
                            logic.Add_Fighter(nf.Name, nf.Description, nf.HP, nf.Strength, nf.Stamina, nf.Weapon);
                        else if (newValues is Mage nm)
                            logic.Add_Mage(nm.Name, nm.Description, nm.HP, nm.Strength, nm.Mana, nm.School);
                    }

                    RefreshGrid();
                    MessageBox.Show("Персонаж обновлён.");
                }
            }
        }

        private void buttonFilterFighters_Click(object sender, EventArgs e)
        {
            if (comboBoxFilterWeapon.SelectedItem == null) return;
            if (!Enum.TryParse<Weapons>(comboBoxFilterWeapon.SelectedItem.ToString(), out var selectedWeapon)) return;

            var filtered = logic.Choose_Marked(selectedWeapon);
            if (!filtered.Any())
            {
                MessageBox.Show("Нет воинов с выбранным оружием!");
                return;
            }

            // показываем результат (заменим RefreshGrid -> временно показываем отфильтрованное)
            dataGridViewCharacters.Rows.Clear();
            foreach (var c in filtered)
            {
                string type = c is Fighter ? "Воин" : c is Mage ? "Маг" : c.GetType().Name;
                string secondary = c is Fighter f ? f.Stamina.ToString() : c is Mage m ? m.Mana.ToString() : "";
                string classExtra = c is Fighter ff ? ff.Weapon.ToString() : c is Mage mm ? mm.School.ToString() : "";
                dataGridViewCharacters.Rows.Add(type, c.Name, c.Description, c.HP, c.Strength, secondary, classExtra);
            }
        }

        private void buttonFilterMages_Click(object sender, EventArgs e)
        {
            if (comboBoxFilterSchool.SelectedItem == null) return;
            if (!Enum.TryParse<Magic_Schools>(comboBoxFilterSchool.SelectedItem.ToString(), out var selectedSchool)) return;

            var filtered = logic.Choose_Marked(selectedSchool);
            if (!filtered.Any())
            {
                MessageBox.Show("Нет магов с выбранной школой!");
                return;
            }

            dataGridViewCharacters.Rows.Clear();
            foreach (var c in filtered)
            {
                string type = c is Fighter ? "Воин" : c is Mage ? "Маг" : c.GetType().Name;
                string secondary = c is Fighter f ? f.Stamina.ToString() : c is Mage m ? m.Mana.ToString() : "";
                string classExtra = c is Fighter ff ? ff.Weapon.ToString() : c is Mage mm ? mm.School.ToString() : "";
                dataGridViewCharacters.Rows.Add(type, c.Name, c.Description, c.HP, c.Strength, secondary, classExtra);
            }
        }

        private void buttonShowAll_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }
    }
}