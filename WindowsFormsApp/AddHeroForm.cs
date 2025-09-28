using System;
using System.Windows.Forms;
using BusinessLogicModels;

namespace WinFormsApp
{
    public partial class AddHeroForm : Form
    {
        public Character CreatedHero { get; private set; } // результат

        /// <summary>
        /// Конструктор по умолчанию: инициализирует компоненты формы и безопасно
        /// заполняет комбобоксы значениями перечислений, если дизайнер этого не сделал.
        /// </summary>
        public AddHeroForm()
        {
            InitializeComponent();

            comboBoxWeapon.Items.Clear();
            foreach (var v in Displays.WeaponsNames.Values)
                comboBoxWeapon.Items.Add(v);

            comboBoxSchool.Items.Clear();
            foreach (var v in Displays.MagicNames.Values)
                comboBoxSchool.Items.Add(v);

            if (comboBoxType.Items.Count > 0 && comboBoxType.SelectedIndex < 0)
                comboBoxType.SelectedIndex = 0;
        }

        /// <summary>
        /// Переключает видимость полей формы в зависимости от выбранного типа персонажа
        /// </summary>
        /// <param name="isFighter">true — воин, false — маг</param>
        private void ToggleFields(bool isFighter)
        {
            // Блок для воина
            comboBoxWeapon.Visible = isFighter;
            labelWeapon.Visible = isFighter;
            numericStamina.Visible = isFighter;
            labelStamina.Visible = isFighter;

            // Блок для мага
            comboBoxSchool.Visible = !isFighter;
            labelSchool.Visible = !isFighter;
            numericMana.Visible = !isFighter;
            labelMana.Visible = !isFighter;
        }

        /// <summary>
        /// Конструктор для редактирования существующего персонажа: заполняет
        /// поля формы значениями из переданного объекта
        /// Дизайнер видимости определенных полей для война и мага
        /// </summary>
        /// <param name="exist">Существующий персонаж для отображения в форме. Если null — ничего не делает</param>
        public AddHeroForm(Character exist) : this()
        {
            if (exist == null) return;

            textBoxName.Text = exist.Name;
            textBoxDesc.Text = exist.Description;
            numericHP.Value = Math.Max(numericHP.Minimum, Math.Min(numericHP.Maximum, exist.HP));
            numericStrength.Value = Math.Max(numericStrength.Minimum, Math.Min(numericStrength.Maximum, exist.Strength));

            if (exist is Fighter f)
            {
                comboBoxType.SelectedItem = "Воин";
                comboBoxWeapon.SelectedItem = Displays.WeaponsNames.ContainsKey(f.Weapon) ? Displays.WeaponsNames[f.Weapon] : Displays.WeaponsNames[Weapons.None];
                numericStamina.Value = Math.Max(numericStamina.Minimum, Math.Min(numericStamina.Maximum, f.Stamina));
                ToggleFields(true);
            }
            else if (exist is Mage m)
            {
                comboBoxType.SelectedItem = "Маг";
                comboBoxSchool.SelectedItem = Displays.MagicNames.ContainsKey(m.School) ? Displays.MagicNames[m.School] : Displays.MagicNames[MagicSchools.Fire];
                numericMana.Value = Math.Max(numericMana.Minimum, Math.Min(numericMana.Maximum, m.Mana));
                ToggleFields(false);
            }
        }

        /// <summary>
        /// Обработчик изменения выбранного типа персонажа
        /// Переключает видимость аборов полей между набором для воина и набором для мага
        /// </summary>
        /// <param name="sender">Ссылка на объект</param>
        /// <param name="e">Аргументы события</param>
        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedItem == null) return;

            var sel = comboBoxType.SelectedItem.ToString();
            ToggleFields(sel == "Воин");
        }

        /// <summary>
        /// Обработчик нажатия на кнопку сохранения персонажа, 
        /// собирает объект персонажа из заполняемых полей и сохраняет его, 
        /// после чего закрывает форму
        /// </summary>
        /// <param name="sender">Ссылка на объект</param>
        /// <param name="e">Аргументы события</param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text.Trim();
            string desc = textBoxDesc.Text.Trim();
            int hp = (int)numericHP.Value;
            int str = (int)numericStrength.Value;

            if (comboBoxType.SelectedItem == null)
            {
                MessageBox.Show("Выберите тип персонажа!");
                return;
            }

            var typeString = comboBoxType.SelectedItem.ToString();

            if (typeString == "Воин")
            {
                Weapons weapon = Weapons.None;
                if (comboBoxWeapon.SelectedItem != null)
                {
                    var sel = comboBoxWeapon.SelectedItem.ToString();
                    foreach (var kv in Displays.WeaponsNames)
                    {
                        if (kv.Value == sel)
                        {
                            weapon = kv.Key;
                            break;
                        }
                    }
                    if (!Enum.IsDefined(typeof(Weapons), weapon))
                        Enum.TryParse(sel, true, out weapon);
                }

                int stamina = (int)numericStamina.Value;
                CreatedHero = new Fighter(name, desc, hp, str, stamina, weapon);
            }
            else // Маг
            {
                MagicSchools school = MagicSchools.Fire;
                if (comboBoxSchool.SelectedItem != null)
                {
                    var sel = comboBoxSchool.SelectedItem.ToString();
                    foreach (var kv in Displays.MagicNames)
                    {
                        if (kv.Value == sel)
                        {
                            school = kv.Key;
                            break;
                        }
                    }
                    if (!Enum.IsDefined(typeof(MagicSchools), school))
                        Enum.TryParse(sel, true, out school);
                }

                int mana = (int)numericMana.Value;
                CreatedHero = new Mage(name, desc, hp, str, mana, school);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Событие нажатия на кнопку "Отмена" с возвращением в главное меню
        /// </summary>
        /// <param name="sender">Ссылка на объект</param>
        /// <param name="e">Аргументы события</param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}