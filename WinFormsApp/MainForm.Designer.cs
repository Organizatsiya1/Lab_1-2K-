
namespace WinFormsApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            dataGridViewCharacters = new DataGridView();
            ColIndex = new DataGridViewTextBoxColumn();
            ColName = new DataGridViewTextBoxColumn();
            ColType = new DataGridViewTextBoxColumn();
            ColHP = new DataGridViewTextBoxColumn();
            ColStr = new DataGridViewTextBoxColumn();
            ColStamina = new DataGridViewTextBoxColumn();
            ColMana = new DataGridViewTextBoxColumn();
            ColWeapon = new DataGridViewTextBoxColumn();
            ColSchool = new DataGridViewTextBoxColumn();
            ColDesc = new DataGridViewTextBoxColumn();
            buttonAddHero = new Button();
            buttonDeleteHero = new Button();
            buttonEditHero = new Button();
            buttonFilterMages = new Button();
            buttonFilterFighters = new Button();
            comboBoxFilterSchool = new ComboBox();
            comboBoxFilterWeapon = new ComboBox();
            labelTitle = new Label();
            labelMage = new Label();
            labelFighter = new Label();
            buttonShowAll = new Button();
            buttonSort = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCharacters).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewCharacters
            // 
            dataGridViewCharacters.BackgroundColor = SystemColors.InactiveCaption;
            dataGridViewCharacters.ColumnHeadersHeight = 32;
            dataGridViewCharacters.Columns.AddRange(new DataGridViewColumn[] { ColIndex, ColName, ColType, ColHP, ColStr, ColStamina, ColMana, ColWeapon, ColSchool, ColDesc });
            dataGridViewCharacters.GridColor = SystemColors.Menu;
            dataGridViewCharacters.Location = new Point(12, 73);
            dataGridViewCharacters.Name = "dataGridViewCharacters";
            dataGridViewCharacters.RowHeadersWidth = 51;
            dataGridViewCharacters.Size = new Size(1505, 970);
            dataGridViewCharacters.TabIndex = 1;
            // 
            // ColIndex
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColIndex.DefaultCellStyle = dataGridViewCellStyle7;
            ColIndex.HeaderText = "№";
            ColIndex.MinimumWidth = 6;
            ColIndex.Name = "ColIndex";
            ColIndex.ReadOnly = true;
            ColIndex.Width = 60;
            // 
            // ColName
            // 
            ColName.HeaderText = "Имя";
            ColName.MinimumWidth = 6;
            ColName.Name = "ColName";
            ColName.ReadOnly = true;
            ColName.Width = 180;
            // 
            // ColType
            // 
            ColType.HeaderText = "Тип";
            ColType.MinimumWidth = 6;
            ColType.Name = "ColType";
            ColType.ReadOnly = true;
            ColType.Width = 125;
            // 
            // ColHP
            // 
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColHP.DefaultCellStyle = dataGridViewCellStyle8;
            ColHP.HeaderText = "Здоровье";
            ColHP.MinimumWidth = 6;
            ColHP.Name = "ColHP";
            ColHP.ReadOnly = true;
            ColHP.Width = 140;
            // 
            // ColStr
            // 
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColStr.DefaultCellStyle = dataGridViewCellStyle9;
            ColStr.HeaderText = "Сила";
            ColStr.MinimumWidth = 6;
            ColStr.Name = "ColStr";
            ColStr.ReadOnly = true;
            ColStr.Width = 90;
            // 
            // ColStamina
            // 
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColStamina.DefaultCellStyle = dataGridViewCellStyle10;
            ColStamina.HeaderText = "Выносливость";
            ColStamina.MinimumWidth = 6;
            ColStamina.Name = "ColStamina";
            ColStamina.ReadOnly = true;
            ColStamina.Width = 205;
            // 
            // ColMana
            // 
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColMana.DefaultCellStyle = dataGridViewCellStyle11;
            ColMana.HeaderText = "Мана";
            ColMana.MinimumWidth = 6;
            ColMana.Name = "ColMana";
            ColMana.ReadOnly = true;
            ColMana.Width = 90;
            // 
            // ColWeapon
            // 
            ColWeapon.HeaderText = "Оружие";
            ColWeapon.MinimumWidth = 6;
            ColWeapon.Name = "ColWeapon";
            ColWeapon.ReadOnly = true;
            ColWeapon.Width = 140;
            // 
            // ColSchool
            // 
            ColSchool.HeaderText = "Школа магии";
            ColSchool.MinimumWidth = 6;
            ColSchool.Name = "ColSchool";
            ColSchool.ReadOnly = true;
            ColSchool.Width = 140;
            // 
            // ColDesc
            // 
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
            ColDesc.DefaultCellStyle = dataGridViewCellStyle12;
            ColDesc.HeaderText = "Описание";
            ColDesc.MinimumWidth = 6;
            ColDesc.Name = "ColDesc";
            ColDesc.ReadOnly = true;
            ColDesc.Width = 280;
            // 
            // buttonAddHero
            // 
            buttonAddHero.BackColor = Color.MidnightBlue;
            buttonAddHero.Cursor = Cursors.PanNW;
            buttonAddHero.FlatStyle = FlatStyle.Popup;
            buttonAddHero.Font = new Font("Ink Free", 19.7999973F, FontStyle.Bold);
            buttonAddHero.ForeColor = Color.Gold;
            buttonAddHero.Location = new Point(1601, 229);
            buttonAddHero.Name = "buttonAddHero";
            buttonAddHero.Size = new Size(256, 58);
            buttonAddHero.TabIndex = 2;
            buttonAddHero.Text = "➕ Добавить героя";
            buttonAddHero.UseVisualStyleBackColor = false;
            buttonAddHero.Click += buttonAddHero_Click;
            // 
            // buttonDeleteHero
            // 
            buttonDeleteHero.BackColor = Color.MidnightBlue;
            buttonDeleteHero.Cursor = Cursors.PanNW;
            buttonDeleteHero.FlatStyle = FlatStyle.Popup;
            buttonDeleteHero.Font = new Font("Ink Free", 19.7999973F, FontStyle.Bold);
            buttonDeleteHero.ForeColor = Color.Gold;
            buttonDeleteHero.Location = new Point(1601, 377);
            buttonDeleteHero.Name = "buttonDeleteHero";
            buttonDeleteHero.Size = new Size(256, 58);
            buttonDeleteHero.TabIndex = 3;
            buttonDeleteHero.Text = "🗑 Удалить героя";
            buttonDeleteHero.UseVisualStyleBackColor = false;
            buttonDeleteHero.Click += buttonDeleteHero_Click;
            // 
            // buttonEditHero
            // 
            buttonEditHero.BackColor = Color.MidnightBlue;
            buttonEditHero.Cursor = Cursors.PanNW;
            buttonEditHero.FlatStyle = FlatStyle.Popup;
            buttonEditHero.Font = new Font("Ink Free", 19.7999973F, FontStyle.Bold);
            buttonEditHero.ForeColor = Color.Gold;
            buttonEditHero.Location = new Point(1601, 302);
            buttonEditHero.Name = "buttonEditHero";
            buttonEditHero.Size = new Size(256, 58);
            buttonEditHero.TabIndex = 4;
            buttonEditHero.Text = "✏ Изменить героя";
            buttonEditHero.UseVisualStyleBackColor = false;
            buttonEditHero.Click += buttonEditHero_Click;
            // 
            // buttonFilterMages
            // 
            buttonFilterMages.BackColor = Color.DarkBlue;
            buttonFilterMages.Cursor = Cursors.PanNW;
            buttonFilterMages.FlatStyle = FlatStyle.Popup;
            buttonFilterMages.Font = new Font("Ink Free", 19.7999973F, FontStyle.Bold);
            buttonFilterMages.ForeColor = Color.White;
            buttonFilterMages.Location = new Point(1833, 514);
            buttonFilterMages.Name = "buttonFilterMages";
            buttonFilterMages.Size = new Size(75, 53);
            buttonFilterMages.TabIndex = 10;
            buttonFilterMages.Text = "🔮";
            buttonFilterMages.UseVisualStyleBackColor = false;
            buttonFilterMages.Click += buttonFilterMages_Click;
            // 
            // buttonFilterFighters
            // 
            buttonFilterFighters.BackColor = Color.DarkOliveGreen;
            buttonFilterFighters.Cursor = Cursors.PanNW;
            buttonFilterFighters.FlatStyle = FlatStyle.Popup;
            buttonFilterFighters.Font = new Font("Ink Free", 19.7999973F, FontStyle.Bold);
            buttonFilterFighters.ForeColor = Color.White;
            buttonFilterFighters.Location = new Point(1833, 450);
            buttonFilterFighters.Name = "buttonFilterFighters";
            buttonFilterFighters.Size = new Size(75, 54);
            buttonFilterFighters.TabIndex = 7;
            buttonFilterFighters.Text = "🛡";
            buttonFilterFighters.UseVisualStyleBackColor = false;
            buttonFilterFighters.Click += buttonFilterFighters_Click;
            // 
            // comboBoxFilterSchool
            // 
            comboBoxFilterSchool.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFilterSchool.Font = new Font("Ink Free", 19.7999973F, FontStyle.Bold);
            comboBoxFilterSchool.Location = new Point(1646, 518);
            comboBoxFilterSchool.Name = "comboBoxFilterSchool";
            comboBoxFilterSchool.Size = new Size(181, 41);
            comboBoxFilterSchool.TabIndex = 9;
            // 
            // comboBoxFilterWeapon
            // 
            comboBoxFilterWeapon.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFilterWeapon.Font = new Font("Ink Free", 19.7999973F, FontStyle.Bold);
            comboBoxFilterWeapon.Location = new Point(1646, 454);
            comboBoxFilterWeapon.Name = "comboBoxFilterWeapon";
            comboBoxFilterWeapon.Size = new Size(181, 41);
            comboBoxFilterWeapon.TabIndex = 6;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Ink Free", 28.1999989F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelTitle.ForeColor = Color.Gold;
            labelTitle.Location = new Point(314, 9);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(752, 45);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "⚔ Гильдия искателей приключений ⚔";
            // 
            // labelMage
            // 
            labelMage.AutoSize = true;
            labelMage.Font = new Font("Ink Free", 19.7999973F, FontStyle.Bold);
            labelMage.ForeColor = Color.White;
            labelMage.Location = new Point(1540, 521);
            labelMage.Name = "labelMage";
            labelMage.Size = new Size(72, 34);
            labelMage.TabIndex = 8;
            labelMage.Text = "Маг:";
            // 
            // labelFighter
            // 
            labelFighter.AutoSize = true;
            labelFighter.Font = new Font("Ink Free", 19.7999973F, FontStyle.Bold);
            labelFighter.ForeColor = Color.White;
            labelFighter.Location = new Point(1540, 457);
            labelFighter.Name = "labelFighter";
            labelFighter.Size = new Size(89, 34);
            labelFighter.TabIndex = 5;
            labelFighter.Text = "Воин:";
            // 
            // buttonShowAll
            // 
            buttonShowAll.BackColor = Color.MidnightBlue;
            buttonShowAll.Cursor = Cursors.PanNW;
            buttonShowAll.FlatStyle = FlatStyle.Popup;
            buttonShowAll.Font = new Font("Ink Free", 19.7999973F, FontStyle.Bold);
            buttonShowAll.ForeColor = Color.Gold;
            buttonShowAll.Location = new Point(1601, 584);
            buttonShowAll.Name = "buttonShowAll";
            buttonShowAll.Size = new Size(256, 102);
            buttonShowAll.TabIndex = 11;
            buttonShowAll.Text = "Показать всех героев";
            buttonShowAll.UseVisualStyleBackColor = false;
            buttonShowAll.Click += buttonShowAll_Click;
            // 
            // buttonSort
            // 
            buttonSort.BackColor = Color.MidnightBlue;
            buttonSort.Cursor = Cursors.PanNW;
            buttonSort.FlatStyle = FlatStyle.Popup;
            buttonSort.Font = new Font("Ink Free", 19.7999973F, FontStyle.Bold);
            buttonSort.ForeColor = Color.Gold;
            buttonSort.Location = new Point(1601, 707);
            buttonSort.Name = "buttonSort";
            buttonSort.Size = new Size(256, 144);
            buttonSort.TabIndex = 12;
            buttonSort.Text = "⚔ Устроить поединок";
            buttonSort.UseVisualStyleBackColor = false;
            buttonSort.Click += buttonSort_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.DarkSlateGray;
            ClientSize = new Size(1924, 1055);
            Controls.Add(buttonShowAll);
            Controls.Add(buttonSort);
            Controls.Add(labelTitle);
            Controls.Add(dataGridViewCharacters);
            Controls.Add(buttonAddHero);
            Controls.Add(buttonDeleteHero);
            Controls.Add(buttonEditHero);
            Controls.Add(labelFighter);
            Controls.Add(comboBoxFilterWeapon);
            Controls.Add(buttonFilterFighters);
            Controls.Add(labelMage);
            Controls.Add(comboBoxFilterSchool);
            Controls.Add(buttonFilterMages);
            Font = new Font("Ink Free", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Гильдия искателей приключений";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dataGridViewCharacters).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewCharacters;
        private Button buttonAddHero;
        private Button buttonDeleteHero;
        private Button buttonEditHero;
        private Button buttonFilterMages;
        private Button buttonFilterFighters;
        private ComboBox comboBoxFilterSchool;
        private ComboBox comboBoxFilterWeapon;
        private Label labelTitle;
        private Label labelMage;
        private Label labelFighter;
        private Button buttonShowAll;
        private Button buttonSort;
        private DataGridViewTextBoxColumn ColIndex;
        private DataGridViewTextBoxColumn ColName;
        private DataGridViewTextBoxColumn ColType;
        private DataGridViewTextBoxColumn ColHP;
        private DataGridViewTextBoxColumn ColStr;
        private DataGridViewTextBoxColumn ColStamina;
        private DataGridViewTextBoxColumn ColMana;
        private DataGridViewTextBoxColumn ColWeapon;
        private DataGridViewTextBoxColumn ColSchool;
        private DataGridViewTextBoxColumn ColDesc;
    }
}