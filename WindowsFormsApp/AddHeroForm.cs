using Models;
using Shared;
using System;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class AddHeroForm : Form, IAddHeroView
    {
        public Character CreatedHero { get; private set; } // результат
        public event Action SaveEvent;
        public event Action CancelEvent;
        public event Action TypeChangedEvent;

        // Свойства с приведением к нужному виду данных
        public string HeroName { 
            get => textBoxName.Text; 
            set => textBoxName.Text = value; }

        public string HeroDescription { 
            get => textBoxDesc.Text; 
            set => textBoxDesc.Text = value; }

        public int HeroHP { 
            get => (int)numericHP.Value; 
            set => numericHP.Value = value; }

        public int HeroStrength { 
            get => (int)numericStrength.Value; 
            set => numericStrength.Value = value; }

        public bool IsFighter { 
            get => comboBoxType.SelectedItem?.ToString() == "Воин"; 
            set => comboBoxType.SelectedItem = value ? "Воин" : "Маг"; }

        public bool IsMage { 
            get => comboBoxType.SelectedItem?.ToString() == "Маг"; 
            set => comboBoxType.SelectedItem = value ? "Маг" : "Воин"; }

        public int HeroStamina { 
            get => (int)numericStamina.Value; 
            set => numericStamina.Value = value; }

        public int HeroMana { 
            get => (int)numericMana.Value; 
            set => numericMana.Value = value; }

        /// <summary>
        /// Перебор выбора оружия для воина с приведением к нужному виду
        /// </summary>
        public Weapons SelectedWeapon
        {
            get
            {
                if (comboBoxWeapon.SelectedItem == null) return Weapons.None;
                var sel = comboBoxWeapon.SelectedItem.ToString();
                foreach (var kv in Displays.WeaponsNames)
                    if (kv.Value == sel) return kv.Key;
                return Weapons.None;
            }
            set
            {
                if (Displays.WeaponsNames.ContainsKey(value))
                    comboBoxWeapon.SelectedItem = Displays.WeaponsNames[value];
            }
        }

        /// <summary>
        /// Перебор выбора школы магии для мага с приведением к нужному виду
        /// </summary>
        public MagicSchools SelectedSchool
        {
            get
            {
                if (comboBoxSchool.SelectedItem == null) return MagicSchools.Fire;
                var sel = comboBoxSchool.SelectedItem.ToString();
                foreach (var kv in Displays.MagicNames)
                    if (kv.Value == sel) return kv.Key;
                return MagicSchools.Fire;
            }
            set
            {
                if (Displays.MagicNames.ContainsKey(value))
                    comboBoxSchool.SelectedItem = Displays.MagicNames[value];
            }
        }

        /// <summary>
        /// Свойство для хранения результата с диалоговым окном
        /// </summary>
        public new object DialogResult
        {
            get => base.DialogResult;
            set => base.DialogResult = (DialogResult)value;
        }

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
        /// Загрузить данные персонажа для редактирования
        /// </summary>
        /// <param name="character">Персонаж для отредактирования</param>
        public void LoadCharacter(Character character)
        {
            SetFormForEdit(character);
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
        /// Метод показа формы
        /// </summary>
        public new void Show() => base.Show();

        /// <summary>
        /// Метод закрытия формы
        /// </summary>
        public new void Close() => base.Close();


        /// <summary>
        /// Очистка формы, приведение к призентабельному виду формы (обозначение начальных данных)
        /// </summary>
        public void SetCreateMode()
        {
            textBoxName.Text = "";
            textBoxDesc.Text = "";
            numericHP.Value = 50;
            numericStrength.Value = 5;
            numericStamina.Value = 50;
            numericMana.Value = 100;
            comboBoxType.SelectedIndex = 0;
            comboBoxWeapon.SelectedIndex = 0;
            comboBoxSchool.SelectedIndex = 0;
            CreatedHero = null;
        }

        /// <summary>
        /// заполняет поля формы значениями из переданного объекта
        /// Дизайнер видимости определенных полей для война и мага
        /// </summary>
        /// <param name="character">Существующий персонаж для отображения в форме. Если null — ничего не делает</param>
        public void SetFormForEdit(Character character)
        {
            if (character == null) return;

            textBoxName.Text = character.Name;
            textBoxDesc.Text = character.Description;
            numericHP.Value = Math.Max(numericHP.Minimum, Math.Min(numericHP.Maximum, character.HP));
            numericStrength.Value = Math.Max(numericStrength.Minimum, Math.Min(numericStrength.Maximum, character.Strength));

            if (character is Fighter f)
            {
                comboBoxType.SelectedItem = "Воин";
                comboBoxWeapon.SelectedItem = Displays.WeaponsNames.ContainsKey(f.Weapon) ? Displays.WeaponsNames[f.Weapon] : Displays.WeaponsNames[Weapons.None];
                numericStamina.Value = Math.Max(numericStamina.Minimum, Math.Min(numericStamina.Maximum, f.Stamina));
                ToggleFields(true);
            }
            else if (character is Mage m)
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
            TypeChangedEvent?.Invoke();
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

            SaveEvent?.Invoke();

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Событие нажатия на кнопку "Отмена" с возвращением в главное меню
        /// </summary>
        /// <param name="sender">Ссылка на объект</param>
        /// <param name="e">Аргументы события</param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            CancelEvent?.Invoke();

            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
    }
}