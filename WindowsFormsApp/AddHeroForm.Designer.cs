using System.Drawing;
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelDesc = new System.Windows.Forms.Label();
            this.textBoxDesc = new System.Windows.Forms.TextBox();
            this.labelHP = new System.Windows.Forms.Label();
            this.numericHP = new System.Windows.Forms.NumericUpDown();
            this.labelStrength = new System.Windows.Forms.Label();
            this.numericStrength = new System.Windows.Forms.NumericUpDown();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.labelType = new System.Windows.Forms.Label();
            this.comboBoxWeapon = new System.Windows.Forms.ComboBox();
            this.labelWeapon = new System.Windows.Forms.Label();
            this.comboBoxSchool = new System.Windows.Forms.ComboBox();
            this.labelSchool = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelStamina = new System.Windows.Forms.Label();
            this.numericStamina = new System.Windows.Forms.NumericUpDown();
            this.labelMana = new System.Windows.Forms.Label();
            this.numericMana = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericHP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStrength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStamina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMana)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Calibri", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.ForeColor = System.Drawing.Color.Gold;
            this.labelTitle.Location = new System.Drawing.Point(147, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(364, 49);
            this.labelTitle.TabIndex = 16;
            this.labelTitle.Text = "✨ Новый герой ✨";
            // 
            // labelName
            // 
            this.labelName.Font = new System.Drawing.Font("Calibri", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.ForeColor = System.Drawing.Color.Gold;
            this.labelName.Location = new System.Drawing.Point(30, 157);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(195, 46);
            this.labelName.TabIndex = 15;
            this.labelName.Text = "Имя:";
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxName.Location = new System.Drawing.Point(284, 155);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(342, 40);
            this.textBoxName.TabIndex = 14;
            // 
            // labelDesc
            // 
            this.labelDesc.Font = new System.Drawing.Font("Calibri", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDesc.ForeColor = System.Drawing.Color.Gold;
            this.labelDesc.Location = new System.Drawing.Point(30, 210);
            this.labelDesc.Name = "labelDesc";
            this.labelDesc.Size = new System.Drawing.Size(234, 46);
            this.labelDesc.TabIndex = 13;
            this.labelDesc.Text = "Описание:";
            // 
            // textBoxDesc
            // 
            this.textBoxDesc.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDesc.Location = new System.Drawing.Point(284, 210);
            this.textBoxDesc.Multiline = true;
            this.textBoxDesc.Name = "textBoxDesc";
            this.textBoxDesc.Size = new System.Drawing.Size(342, 129);
            this.textBoxDesc.TabIndex = 12;
            // 
            // labelHP
            // 
            this.labelHP.Font = new System.Drawing.Font("Calibri", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHP.ForeColor = System.Drawing.Color.Gold;
            this.labelHP.Location = new System.Drawing.Point(30, 355);
            this.labelHP.Name = "labelHP";
            this.labelHP.Size = new System.Drawing.Size(195, 46);
            this.labelHP.TabIndex = 11;
            this.labelHP.Text = "Здоровье:";
            // 
            // numericHP
            // 
            this.numericHP.Font = new System.Drawing.Font("Ink Free", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericHP.Location = new System.Drawing.Point(284, 355);
            this.numericHP.Name = "numericHP";
            this.numericHP.Size = new System.Drawing.Size(120, 41);
            this.numericHP.TabIndex = 10;
            this.numericHP.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // labelStrength
            // 
            this.labelStrength.Font = new System.Drawing.Font("Calibri", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStrength.ForeColor = System.Drawing.Color.Gold;
            this.labelStrength.Location = new System.Drawing.Point(30, 414);
            this.labelStrength.Name = "labelStrength";
            this.labelStrength.Size = new System.Drawing.Size(195, 46);
            this.labelStrength.TabIndex = 9;
            this.labelStrength.Text = "Сила:";
            // 
            // numericStrength
            // 
            this.numericStrength.Font = new System.Drawing.Font("Ink Free", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericStrength.Location = new System.Drawing.Point(284, 414);
            this.numericStrength.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericStrength.Name = "numericStrength";
            this.numericStrength.Size = new System.Drawing.Size(120, 41);
            this.numericStrength.TabIndex = 8;
            this.numericStrength.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxType.Items.AddRange(new object[] {
            "Воин",
            "Маг"});
            this.comboBoxType.Location = new System.Drawing.Point(284, 98);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(227, 41);
            this.comboBoxType.TabIndex = 6;
            // 
            // labelType
            // 
            this.labelType.Font = new System.Drawing.Font("Calibri", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelType.ForeColor = System.Drawing.Color.Gold;
            this.labelType.Location = new System.Drawing.Point(30, 100);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(195, 46);
            this.labelType.TabIndex = 7;
            this.labelType.Text = "Тип:";
            // 
            // comboBoxWeapon
            // 
            this.comboBoxWeapon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWeapon.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxWeapon.Items.AddRange(new object[] {
            "Нет",
            "Булава",
            "Меч",
            "Топор"});
            this.comboBoxWeapon.Location = new System.Drawing.Point(285, 531);
            this.comboBoxWeapon.Name = "comboBoxWeapon";
            this.comboBoxWeapon.Size = new System.Drawing.Size(226, 41);
            this.comboBoxWeapon.TabIndex = 4;
            this.comboBoxWeapon.Visible = false;
            // 
            // labelWeapon
            // 
            this.labelWeapon.Font = new System.Drawing.Font("Calibri", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWeapon.ForeColor = System.Drawing.Color.Gold;
            this.labelWeapon.Location = new System.Drawing.Point(30, 531);
            this.labelWeapon.Name = "labelWeapon";
            this.labelWeapon.Size = new System.Drawing.Size(195, 46);
            this.labelWeapon.TabIndex = 5;
            this.labelWeapon.Text = "Оружие:";
            this.labelWeapon.Visible = false;
            // 
            // comboBoxSchool
            // 
            this.comboBoxSchool.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSchool.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxSchool.Items.AddRange(new object[] {
            "Огонь",
            "Лед",
            "Свет"});
            this.comboBoxSchool.Location = new System.Drawing.Point(285, 531);
            this.comboBoxSchool.Name = "comboBoxSchool";
            this.comboBoxSchool.Size = new System.Drawing.Size(226, 41);
            this.comboBoxSchool.TabIndex = 2;
            this.comboBoxSchool.Visible = false;
            // 
            // labelSchool
            // 
            this.labelSchool.Font = new System.Drawing.Font("Calibri", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSchool.ForeColor = System.Drawing.Color.Gold;
            this.labelSchool.Location = new System.Drawing.Point(30, 531);
            this.labelSchool.Name = "labelSchool";
            this.labelSchool.Size = new System.Drawing.Size(195, 46);
            this.labelSchool.TabIndex = 3;
            this.labelSchool.Text = "Магия:";
            this.labelSchool.Visible = false;
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonSave.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSave.Font = new System.Drawing.Font("Ink Free", 16.2F, System.Drawing.FontStyle.Bold);
            this.buttonSave.ForeColor = System.Drawing.Color.Gold;
            this.buttonSave.Location = new System.Drawing.Point(110, 599);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(214, 46);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "💾 Сохранить";
            this.buttonSave.UseVisualStyleBackColor = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.Maroon;
            this.buttonCancel.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCancel.Font = new System.Drawing.Font("Ink Free", 16.2F, System.Drawing.FontStyle.Bold);
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.Location = new System.Drawing.Point(339, 599);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(214, 46);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "❌ Отмена";
            this.buttonCancel.UseVisualStyleBackColor = false;
            // 
            // labelStamina
            // 
            this.labelStamina.Font = new System.Drawing.Font("Calibri", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStamina.ForeColor = System.Drawing.Color.Gold;
            this.labelStamina.Location = new System.Drawing.Point(30, 473);
            this.labelStamina.Name = "labelStamina";
            this.labelStamina.Size = new System.Drawing.Size(234, 46);
            this.labelStamina.TabIndex = 18;
            this.labelStamina.Text = "Выносливость:";
            this.labelStamina.Visible = false;
            // 
            // numericStamina
            // 
            this.numericStamina.Font = new System.Drawing.Font("Ink Free", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericStamina.Location = new System.Drawing.Point(284, 473);
            this.numericStamina.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericStamina.Name = "numericStamina";
            this.numericStamina.Size = new System.Drawing.Size(120, 41);
            this.numericStamina.TabIndex = 17;
            this.numericStamina.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericStamina.Visible = false;
            // 
            // labelMana
            // 
            this.labelMana.Font = new System.Drawing.Font("Calibri", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMana.ForeColor = System.Drawing.Color.Gold;
            this.labelMana.Location = new System.Drawing.Point(30, 468);
            this.labelMana.Name = "labelMana";
            this.labelMana.Size = new System.Drawing.Size(241, 46);
            this.labelMana.TabIndex = 20;
            this.labelMana.Text = "Мана:";
            this.labelMana.Visible = false;
            // 
            // numericMana
            // 
            this.numericMana.Font = new System.Drawing.Font("Ink Free", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericMana.Location = new System.Drawing.Point(285, 473);
            this.numericMana.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericMana.Name = "numericMana";
            this.numericMana.Size = new System.Drawing.Size(120, 41);
            this.numericMana.TabIndex = 19;
            this.numericMana.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericMana.Visible = false;
            // 
            // AddHeroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 34F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(662, 667);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxSchool);
            this.Controls.Add(this.labelSchool);
            this.Controls.Add(this.comboBoxWeapon);
            this.Controls.Add(this.labelWeapon);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.numericStrength);
            this.Controls.Add(this.labelStrength);
            this.Controls.Add(this.numericHP);
            this.Controls.Add(this.labelHP);
            this.Controls.Add(this.textBoxDesc);
            this.Controls.Add(this.labelDesc);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelStamina);
            this.Controls.Add(this.numericStamina);
            this.Controls.Add(this.labelMana);
            this.Controls.Add(this.numericMana);
            this.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.Font = new System.Drawing.Font("Ink Free", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddHeroForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Создание героя";
            ((System.ComponentModel.ISupportInitialize)(this.numericHP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStrength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStamina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMana)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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