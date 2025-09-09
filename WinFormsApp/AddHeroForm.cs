using System;
using System.Windows.Forms;
using Model;

namespace WinFormsApp
{
    public partial class AddHeroForm : Form
    {
        public Character CreatedHero { get; private set; } // результат

        public AddHeroForm()
        {
            InitializeComponent();
            // безопасно заполним combobox'ы (на случай, если дизайнер не заполнял enum'ы)
            if (comboBoxWeapon.Items.Count == 0)
                comboBoxWeapon.Items.AddRange(Enum.GetNames(typeof(Weapons)));
            if (comboBoxSchool.Items.Count == 0)
                comboBoxSchool.Items.AddRange(Enum.GetNames(typeof(Magic_Schools)));

            if (comboBoxType.Items.Count > 0 && comboBoxType.SelectedIndex < 0)
                comboBoxType.SelectedIndex = 0;
        }

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
                comboBoxWeapon.SelectedItem = f.Weapon.ToString();
                numericStamina.Value = Math.Max(numericStamina.Minimum, Math.Min(numericStamina.Maximum, f.Stamina));

                comboBoxWeapon.Visible = true;
                labelWeapon.Visible = true;
                numericStamina.Visible = true;
                labelStamina.Visible = true;

                comboBoxSchool.Visible = false;
                labelSchool.Visible = false;
                numericMana.Visible = false;
                labelMana.Visible = false;
            }
            else if (exist is Mage m)
            {
                comboBoxType.SelectedItem = "Маг";
                comboBoxSchool.SelectedItem = m.School.ToString();
                numericMana.Value = Math.Max(numericMana.Minimum, Math.Min(numericMana.Maximum, m.Mana));

                comboBoxSchool.Visible = true;
                labelSchool.Visible = true;
                numericMana.Visible = true;
                labelMana.Visible = true;

                comboBoxWeapon.Visible = false;
                labelWeapon.Visible = false;
                numericStamina.Visible = false;
                labelStamina.Visible = false;
            }
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedItem == null) return;

            var sel = comboBoxType.SelectedItem.ToString();
            if (sel == "Воин")
            {
                comboBoxWeapon.Visible = true;
                labelWeapon.Visible = true;
                numericStamina.Visible = true;
                labelStamina.Visible = true;

                comboBoxSchool.Visible = false;
                labelSchool.Visible = false;
                numericMana.Visible = false;
                labelMana.Visible = false;
            }
            else if (sel == "Маг")
            {
                comboBoxWeapon.Visible = false;
                labelWeapon.Visible = false;
                numericStamina.Visible = false;
                labelStamina.Visible = false;

                comboBoxSchool.Visible = true;
                labelSchool.Visible = true;
                numericMana.Visible = true;
                labelMana.Visible = true;
            }
        }

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
                    Enum.TryParse(comboBoxWeapon.SelectedItem.ToString(), true, out weapon);

                int stamina = (int)numericStamina.Value;
                CreatedHero = new Fighter(name, desc, hp, str, stamina, weapon);
            }
            else // Маг
            {
                Magic_Schools school = Magic_Schools.Fire;
                if (comboBoxSchool.SelectedItem != null)
                    Enum.TryParse(comboBoxSchool.SelectedItem.ToString(), true, out school);

                int mana = (int)numericMana.Value;
                CreatedHero = new Mage(name, desc, hp, str, mana, school);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}