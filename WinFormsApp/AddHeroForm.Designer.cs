using System.Windows.Forms;

namespace WinFormsApp
{
    partial class AddHeroForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelTitle = new Label();
            labelName = new Label();
            textBoxName = new TextBox();
            labelDesc = new Label();
            textBoxDesc = new TextBox();
            labelHP = new Label();
            numericHP = new NumericUpDown();
            labelStrength = new Label();
            numericStrength = new NumericUpDown();
            comboBoxType = new ComboBox();
            labelType = new Label();
            comboBoxWeapon = new ComboBox();
            labelWeapon = new Label();
            comboBoxSchool = new ComboBox();
            labelSchool = new Label();
            buttonSave = new Button();
            buttonCancel = new Button();
            labelStamina = new Label();
            numericStamina = new NumericUpDown();
            labelMana = new Label();
            numericMana = new NumericUpDown();

            ((System.ComponentModel.ISupportInitialize)numericHP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericStrength).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericStamina).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericMana).BeginInit();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Papyrus", 20F, FontStyle.Bold);
            labelTitle.ForeColor = Color.Gold;
            labelTitle.Location = new Point(120, 10);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(377, 54);
            labelTitle.TabIndex = 16;
            labelTitle.Text = "✨ Новый герой ✨";
            // 
            // labelName
            // 
            labelName.ForeColor = Color.Gold;
            labelName.Location = new Point(50, 70);
            labelName.Name = "labelName";
            labelName.Size = new Size(100, 23);
            labelName.TabIndex = 15;
            labelName.Text = "Имя:";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(200, 70);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(300, 39);
            textBoxName.TabIndex = 14;
            // 
            // labelDesc
            // 
            labelDesc.ForeColor = Color.Gold;
            labelDesc.Location = new Point(50, 120);
            labelDesc.Name = "labelDesc";
            labelDesc.Size = new Size(134, 23);
            labelDesc.TabIndex = 13;
            labelDesc.Text = "Описание:";
            // 
            // textBoxDesc
            // 
            textBoxDesc.Location = new Point(200, 120);
            textBoxDesc.Name = "textBoxDesc";
            textBoxDesc.Size = new Size(300, 39);
            textBoxDesc.TabIndex = 12;
            // 
            // labelHP
            // 
            labelHP.ForeColor = Color.Gold;
            labelHP.Location = new Point(50, 170);
            labelHP.Name = "labelHP";
            labelHP.Size = new Size(100, 23);
            labelHP.TabIndex = 11;
            labelHP.Text = "HP:";
            // 
            // numericHP
            // 
            numericHP.Location = new Point(200, 170);
            numericHP.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            numericHP.Name = "numericHP";
            numericHP.Size = new Size(120, 39);
            numericHP.TabIndex = 10;
            numericHP.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // labelStrength
            // 
            labelStrength.ForeColor = Color.Gold;
            labelStrength.Location = new Point(50, 218);
            labelStrength.Name = "labelStrength";
            labelStrength.Size = new Size(100, 23);
            labelStrength.TabIndex = 9;
            labelStrength.Text = "Сила:";
            // 
            // numericStrength
            // 
            numericStrength.Location = new Point(200, 218);
            numericStrength.Name = "numericStrength";
            numericStrength.Size = new Size(120, 39);
            numericStrength.TabIndex = 8;
            numericStrength.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // comboBoxType
            // 
            comboBoxType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxType.Items.AddRange(new object[] { "Воин", "Маг" });
            comboBoxType.Location = new Point(200, 318);
            comboBoxType.Name = "comboBoxType";
            comboBoxType.Size = new Size(173, 39);
            comboBoxType.TabIndex = 6;
            comboBoxType.SelectedIndexChanged += comboBoxType_SelectedIndexChanged;
            // 
            // labelType
            // 
            labelType.ForeColor = Color.Gold;
            labelType.Location = new Point(50, 318);
            labelType.Name = "labelType";
            labelType.Size = new Size(100, 23);
            labelType.TabIndex = 7;
            labelType.Text = "Тип:";
            // 
            // comboBoxWeapon
            // 
            comboBoxWeapon.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxWeapon.Items.AddRange(new object[] { "None", "Mace", "Sword", "Axe" });
            comboBoxWeapon.Location = new Point(200, 368);
            comboBoxWeapon.Name = "comboBoxWeapon";
            comboBoxWeapon.Size = new Size(121, 39);
            comboBoxWeapon.TabIndex = 4;
            comboBoxWeapon.Visible = false;
            // 
            // labelWeapon
            // 
            labelWeapon.ForeColor = Color.Gold;
            labelWeapon.Location = new Point(50, 368);
            labelWeapon.Name = "labelWeapon";
            labelWeapon.Size = new Size(100, 23);
            labelWeapon.TabIndex = 5;
            labelWeapon.Text = "Оружие:";
            labelWeapon.Visible = false;
            // 
            // comboBoxSchool
            // 
            comboBoxSchool.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSchool.Items.AddRange(new object[] { "Fire", "Ice", "Light" });
            comboBoxSchool.Location = new Point(200, 368);
            comboBoxSchool.Name = "comboBoxSchool";
            comboBoxSchool.Size = new Size(173, 39);
            comboBoxSchool.TabIndex = 2;
            comboBoxSchool.Visible = false;
            // 
            // labelSchool
            // 
            labelSchool.ForeColor = Color.Gold;
            labelSchool.Location = new Point(50, 368);
            labelSchool.Name = "labelSchool";
            labelSchool.Size = new Size(100, 23);
            labelSchool.TabIndex = 3;
            labelSchool.Text = "Магия:";
            labelSchool.Visible = false;
            // 
            // labelStamina
            // 
            labelStamina.ForeColor = Color.Gold;
            labelStamina.Location = new Point(50, 270);
            labelStamina.Name = "labelStamina";
            labelStamina.Size = new Size(140, 23);
            labelStamina.TabIndex = 18;
            labelStamina.Text = "Выносливость:";
            labelStamina.Visible = false;
            // 
            // numericStamina
            // 
            numericStamina.Location = new Point(200, 270);
            numericStamina.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            numericStamina.Name = "numericStamina";
            numericStamina.Size = new Size(120, 39);
            numericStamina.TabIndex = 17;
            numericStamina.Value = new decimal(new int[] { 20, 0, 0, 0 });
            numericStamina.Visible = false;
            // 
            // labelMana
            // 
            labelMana.ForeColor = Color.Gold;
            labelMana.Location = new Point(50, 270);
            labelMana.Name = "labelMana";
            labelMana.Size = new Size(140, 23);
            labelMana.TabIndex = 20;
            labelMana.Text = "Мана:";
            labelMana.Visible = false;
            // 
            // numericMana
            // 
            numericMana.Location = new Point(200, 270);
            numericMana.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericMana.Name = "numericMana";
            numericMana.Size = new Size(120, 39);
            numericMana.TabIndex = 19;
            numericMana.Value = new decimal(new int[] { 50, 0, 0, 0 });
            numericMana.Visible = false;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.MidnightBlue;
            buttonSave.FlatStyle = FlatStyle.Popup;
            buttonSave.Font = new Font("Papyrus", 10F, FontStyle.Bold);
            buttonSave.ForeColor = Color.Gold;
            buttonSave.Location = new Point(120, 486);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(150, 40);
            buttonSave.TabIndex = 1;
            buttonSave.Text = "💾 Сохранить";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.Maroon;
            buttonCancel.FlatStyle = FlatStyle.Popup;
            buttonCancel.Font = new Font("Papyrus", 10F, FontStyle.Bold);
            buttonCancel.ForeColor = Color.White;
            buttonCancel.Location = new Point(320, 486);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(150, 40);
            buttonCancel.TabIndex = 0;
            buttonCancel.Text = "❌ Отмена";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // AddHeroForm
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateGray;
            ClientSize = new Size(600, 558);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(comboBoxSchool);
            Controls.Add(labelSchool);
            Controls.Add(comboBoxWeapon);
            Controls.Add(labelWeapon);
            Controls.Add(comboBoxType);
            Controls.Add(labelType);
            Controls.Add(numericStrength);
            Controls.Add(labelStrength);
            Controls.Add(numericHP);
            Controls.Add(labelHP);
            Controls.Add(textBoxDesc);
            Controls.Add(labelDesc);
            Controls.Add(textBoxName);
            Controls.Add(labelName);
            Controls.Add(labelTitle);
            Controls.Add(labelStamina);
            Controls.Add(numericStamina);
            Controls.Add(labelMana);
            Controls.Add(numericMana);
            Font = new Font("Papyrus", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "AddHeroForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Создание героя";
            ((System.ComponentModel.ISupportInitialize)numericHP).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericStrength).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericStamina).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericMana).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label labelName;
        private TextBox textBoxName;
        private Label labelDesc;
        private TextBox textBoxDesc;
        private Label labelHP;
        private NumericUpDown numericHP;
        private Label labelStrength;
        private NumericUpDown numericStrength;
        private Label labelType;
        private ComboBox comboBoxType;
        private Label labelWeapon;
        private ComboBox comboBoxWeapon;
        private Label labelSchool;
        private ComboBox comboBoxSchool;
        private Button buttonSave;
        private Button buttonCancel;
        private Label labelStamina;
        private NumericUpDown numericStamina;
        private Label labelMana;
        private NumericUpDown numericMana;
    }
}