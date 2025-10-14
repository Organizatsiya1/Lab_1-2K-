using System.Drawing;
using System.Windows.Forms;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewCharacters = new System.Windows.Forms.DataGridView();
            this.ColIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColHP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStamina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWeapon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSchool = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAddHero = new System.Windows.Forms.Button();
            this.buttonDeleteHero = new System.Windows.Forms.Button();
            this.buttonEditHero = new System.Windows.Forms.Button();
            this.buttonFilterMages = new System.Windows.Forms.Button();
            this.buttonFilterFighters = new System.Windows.Forms.Button();
            this.comboBoxFilterSchool = new System.Windows.Forms.ComboBox();
            this.comboBoxFilterWeapon = new System.Windows.Forms.ComboBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelMage = new System.Windows.Forms.Label();
            this.labelFighter = new System.Windows.Forms.Label();
            this.buttonShowAll = new System.Windows.Forms.Button();
            this.buttonSort = new System.Windows.Forms.Button();
            this.LabelRepo = new System.Windows.Forms.Label();
            this.radioButtonEntityRepository = new System.Windows.Forms.RadioButton();
            this.radioButtonDapperRepository = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCharacters)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCharacters
            // 
            this.dataGridViewCharacters.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewCharacters.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dataGridViewCharacters.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewCharacters.ColumnHeadersHeight = 32;
            this.dataGridViewCharacters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColIndex,
            this.ColType,
            this.ColName,
            this.ColHP,
            this.ColStr,
            this.ColStamina,
            this.ColMana,
            this.ColWeapon,
            this.ColSchool,
            this.ColDesc});
            this.dataGridViewCharacters.Cursor = System.Windows.Forms.Cursors.PanEast;
            this.dataGridViewCharacters.GridColor = System.Drawing.SystemColors.Menu;
            this.dataGridViewCharacters.Location = new System.Drawing.Point(12, 386);
            this.dataGridViewCharacters.Name = "dataGridViewCharacters";
            this.dataGridViewCharacters.RowHeadersWidth = 51;
            this.dataGridViewCharacters.Size = new System.Drawing.Size(1900, 657);
            this.dataGridViewCharacters.TabIndex = 1;
            // 
            // ColIndex
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColIndex.DefaultCellStyle = dataGridViewCellStyle13;
            this.ColIndex.HeaderText = "№";
            this.ColIndex.MinimumWidth = 6;
            this.ColIndex.Name = "ColIndex";
            this.ColIndex.ReadOnly = true;
            this.ColIndex.Width = 60;
            // 
            // ColType
            // 
            this.ColType.HeaderText = "Тип";
            this.ColType.MinimumWidth = 6;
            this.ColType.Name = "ColType";
            this.ColType.ReadOnly = true;
            this.ColType.Width = 125;
            // 
            // ColName
            // 
            this.ColName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColName.HeaderText = "Имя";
            this.ColName.MinimumWidth = 6;
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            this.ColName.Width = 97;
            // 
            // ColHP
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColHP.DefaultCellStyle = dataGridViewCellStyle14;
            this.ColHP.HeaderText = "Здоровье";
            this.ColHP.MinimumWidth = 6;
            this.ColHP.Name = "ColHP";
            this.ColHP.ReadOnly = true;
            this.ColHP.Width = 140;
            // 
            // ColStr
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColStr.DefaultCellStyle = dataGridViewCellStyle15;
            this.ColStr.HeaderText = "Сила";
            this.ColStr.MinimumWidth = 6;
            this.ColStr.Name = "ColStr";
            this.ColStr.ReadOnly = true;
            this.ColStr.Width = 130;
            // 
            // ColStamina
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColStamina.DefaultCellStyle = dataGridViewCellStyle16;
            this.ColStamina.HeaderText = "Выносливость";
            this.ColStamina.MinimumWidth = 6;
            this.ColStamina.Name = "ColStamina";
            this.ColStamina.ReadOnly = true;
            this.ColStamina.Width = 205;
            // 
            // ColMana
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColMana.DefaultCellStyle = dataGridViewCellStyle17;
            this.ColMana.HeaderText = "Мана";
            this.ColMana.MinimumWidth = 6;
            this.ColMana.Name = "ColMana";
            this.ColMana.ReadOnly = true;
            this.ColMana.Width = 130;
            // 
            // ColWeapon
            // 
            this.ColWeapon.HeaderText = "Оружие";
            this.ColWeapon.MinimumWidth = 6;
            this.ColWeapon.Name = "ColWeapon";
            this.ColWeapon.ReadOnly = true;
            this.ColWeapon.Width = 250;
            // 
            // ColSchool
            // 
            this.ColSchool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColSchool.HeaderText = "Школа магии";
            this.ColSchool.MinimumWidth = 6;
            this.ColSchool.Name = "ColSchool";
            this.ColSchool.ReadOnly = true;
            this.ColSchool.Width = 215;
            // 
            // ColDesc
            // 
            this.ColDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColDesc.DefaultCellStyle = dataGridViewCellStyle18;
            this.ColDesc.HeaderText = "Описание";
            this.ColDesc.MinimumWidth = 6;
            this.ColDesc.Name = "ColDesc";
            this.ColDesc.ReadOnly = true;
            this.ColDesc.Width = 166;
            // 
            // buttonAddHero
            // 
            this.buttonAddHero.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonAddHero.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.buttonAddHero.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAddHero.Font = new System.Drawing.Font("Ink Free", 19.8F, System.Drawing.FontStyle.Bold);
            this.buttonAddHero.ForeColor = System.Drawing.Color.Gold;
            this.buttonAddHero.Location = new System.Drawing.Point(273, 131);
            this.buttonAddHero.Name = "buttonAddHero";
            this.buttonAddHero.Size = new System.Drawing.Size(256, 58);
            this.buttonAddHero.TabIndex = 2;
            this.buttonAddHero.Text = "➕ Добавить героя";
            this.buttonAddHero.UseVisualStyleBackColor = false;
            this.buttonAddHero.Click += new System.EventHandler(this.buttonAddHero_Click);
            // 
            // buttonDeleteHero
            // 
            this.buttonDeleteHero.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonDeleteHero.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.buttonDeleteHero.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDeleteHero.Font = new System.Drawing.Font("Ink Free", 19.8F, System.Drawing.FontStyle.Bold);
            this.buttonDeleteHero.ForeColor = System.Drawing.Color.Gold;
            this.buttonDeleteHero.Location = new System.Drawing.Point(273, 279);
            this.buttonDeleteHero.Name = "buttonDeleteHero";
            this.buttonDeleteHero.Size = new System.Drawing.Size(256, 58);
            this.buttonDeleteHero.TabIndex = 3;
            this.buttonDeleteHero.Text = "🗑 Удалить героя";
            this.buttonDeleteHero.UseVisualStyleBackColor = false;
            this.buttonDeleteHero.Click += new System.EventHandler(this.buttonDeleteHero_Click);
            // 
            // buttonEditHero
            // 
            this.buttonEditHero.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonEditHero.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.buttonEditHero.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonEditHero.Font = new System.Drawing.Font("Ink Free", 19.8F, System.Drawing.FontStyle.Bold);
            this.buttonEditHero.ForeColor = System.Drawing.Color.Gold;
            this.buttonEditHero.Location = new System.Drawing.Point(273, 204);
            this.buttonEditHero.Name = "buttonEditHero";
            this.buttonEditHero.Size = new System.Drawing.Size(256, 58);
            this.buttonEditHero.TabIndex = 4;
            this.buttonEditHero.Text = "✏ Изменить героя";
            this.buttonEditHero.UseVisualStyleBackColor = false;
            this.buttonEditHero.Click += new System.EventHandler(this.buttonEditHero_Click);
            // 
            // buttonFilterMages
            // 
            this.buttonFilterMages.BackColor = System.Drawing.Color.DarkBlue;
            this.buttonFilterMages.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.buttonFilterMages.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonFilterMages.Font = new System.Drawing.Font("Ink Free", 19.8F, System.Drawing.FontStyle.Bold);
            this.buttonFilterMages.ForeColor = System.Drawing.Color.White;
            this.buttonFilterMages.Location = new System.Drawing.Point(873, 235);
            this.buttonFilterMages.Name = "buttonFilterMages";
            this.buttonFilterMages.Size = new System.Drawing.Size(75, 53);
            this.buttonFilterMages.TabIndex = 10;
            this.buttonFilterMages.Text = "🔮";
            this.buttonFilterMages.UseVisualStyleBackColor = false;
            this.buttonFilterMages.Click += new System.EventHandler(this.buttonFilterMages_Click);
            // 
            // buttonFilterFighters
            // 
            this.buttonFilterFighters.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.buttonFilterFighters.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.buttonFilterFighters.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonFilterFighters.Font = new System.Drawing.Font("Ink Free", 19.8F, System.Drawing.FontStyle.Bold);
            this.buttonFilterFighters.ForeColor = System.Drawing.Color.White;
            this.buttonFilterFighters.Location = new System.Drawing.Point(873, 171);
            this.buttonFilterFighters.Name = "buttonFilterFighters";
            this.buttonFilterFighters.Size = new System.Drawing.Size(75, 54);
            this.buttonFilterFighters.TabIndex = 7;
            this.buttonFilterFighters.Text = "🛡";
            this.buttonFilterFighters.UseVisualStyleBackColor = false;
            this.buttonFilterFighters.Click += new System.EventHandler(this.buttonFilterFighters_Click);
            // 
            // comboBoxFilterSchool
            // 
            this.comboBoxFilterSchool.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFilterSchool.Font = new System.Drawing.Font("Ink Free", 19.8F, System.Drawing.FontStyle.Bold);
            this.comboBoxFilterSchool.Location = new System.Drawing.Point(686, 239);
            this.comboBoxFilterSchool.Name = "comboBoxFilterSchool";
            this.comboBoxFilterSchool.Size = new System.Drawing.Size(181, 49);
            this.comboBoxFilterSchool.TabIndex = 9;
            // 
            // comboBoxFilterWeapon
            // 
            this.comboBoxFilterWeapon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFilterWeapon.Font = new System.Drawing.Font("Ink Free", 19.8F, System.Drawing.FontStyle.Bold);
            this.comboBoxFilterWeapon.Location = new System.Drawing.Point(686, 175);
            this.comboBoxFilterWeapon.Name = "comboBoxFilterWeapon";
            this.comboBoxFilterWeapon.Size = new System.Drawing.Size(181, 49);
            this.comboBoxFilterWeapon.TabIndex = 6;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Ink Free", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.ForeColor = System.Drawing.Color.Gold;
            this.labelTitle.Location = new System.Drawing.Point(339, 23);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(855, 58);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "⚔ Гильдия искателей приключений ⚔";
            // 
            // labelMage
            // 
            this.labelMage.AutoSize = true;
            this.labelMage.Font = new System.Drawing.Font("Ink Free", 19.8F, System.Drawing.FontStyle.Bold);
            this.labelMage.ForeColor = System.Drawing.Color.White;
            this.labelMage.Location = new System.Drawing.Point(580, 242);
            this.labelMage.Name = "labelMage";
            this.labelMage.Size = new System.Drawing.Size(85, 41);
            this.labelMage.TabIndex = 8;
            this.labelMage.Text = "Маг:";
            // 
            // labelFighter
            // 
            this.labelFighter.AutoSize = true;
            this.labelFighter.Font = new System.Drawing.Font("Ink Free", 19.8F, System.Drawing.FontStyle.Bold);
            this.labelFighter.ForeColor = System.Drawing.Color.White;
            this.labelFighter.Location = new System.Drawing.Point(580, 178);
            this.labelFighter.Name = "labelFighter";
            this.labelFighter.Size = new System.Drawing.Size(100, 41);
            this.labelFighter.TabIndex = 5;
            this.labelFighter.Text = "Воин:";
            // 
            // buttonShowAll
            // 
            this.buttonShowAll.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonShowAll.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.buttonShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonShowAll.Font = new System.Drawing.Font("Ink Free", 19.8F, System.Drawing.FontStyle.Bold);
            this.buttonShowAll.ForeColor = System.Drawing.Color.Gold;
            this.buttonShowAll.Location = new System.Drawing.Point(1008, 99);
            this.buttonShowAll.Name = "buttonShowAll";
            this.buttonShowAll.Size = new System.Drawing.Size(256, 102);
            this.buttonShowAll.TabIndex = 11;
            this.buttonShowAll.Text = "Показать всех героев";
            this.buttonShowAll.UseVisualStyleBackColor = false;
            this.buttonShowAll.Click += new System.EventHandler(this.buttonShowAll_Click);
            // 
            // buttonSort
            // 
            this.buttonSort.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonSort.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.buttonSort.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSort.Font = new System.Drawing.Font("Ink Free", 19.8F, System.Drawing.FontStyle.Bold);
            this.buttonSort.ForeColor = System.Drawing.Color.Gold;
            this.buttonSort.Location = new System.Drawing.Point(1008, 222);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(256, 144);
            this.buttonSort.TabIndex = 12;
            this.buttonSort.Text = "⚔ Устроить поединок";
            this.buttonSort.UseVisualStyleBackColor = false;
            this.buttonSort.Click += new System.EventHandler(this.buttonSort_Click);
            // 
            // LabelRepo
            // 
            this.LabelRepo.AutoSize = true;
            this.LabelRepo.Font = new System.Drawing.Font("Ink Free", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelRepo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LabelRepo.Location = new System.Drawing.Point(21, 83);
            this.LabelRepo.Name = "LabelRepo";
            this.LabelRepo.Size = new System.Drawing.Size(212, 41);
            this.LabelRepo.TabIndex = 13;
            this.LabelRepo.Text = "Репозиторий:";
            // 
            // radioButtonEntityRepository
            // 
            this.radioButtonEntityRepository.AutoSize = true;
            this.radioButtonEntityRepository.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.radioButtonEntityRepository.Location = new System.Drawing.Point(27, 131);
            this.radioButtonEntityRepository.Name = "radioButtonEntityRepository";
            this.radioButtonEntityRepository.Size = new System.Drawing.Size(118, 38);
            this.radioButtonEntityRepository.TabIndex = 15;
            this.radioButtonEntityRepository.TabStop = true;
            this.radioButtonEntityRepository.Text = "Entity";
            this.radioButtonEntityRepository.UseVisualStyleBackColor = true;
            this.radioButtonEntityRepository.CheckedChanged += new System.EventHandler(this.radioButtonEntityRepository_CheckedChanged);
            // 
            // radioButtonDapperRepository
            // 
            this.radioButtonDapperRepository.AutoSize = true;
            this.radioButtonDapperRepository.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.radioButtonDapperRepository.Location = new System.Drawing.Point(28, 186);
            this.radioButtonDapperRepository.Name = "radioButtonDapperRepository";
            this.radioButtonDapperRepository.Size = new System.Drawing.Size(130, 38);
            this.radioButtonDapperRepository.TabIndex = 16;
            this.radioButtonDapperRepository.TabStop = true;
            this.radioButtonDapperRepository.Text = "Dapper";
            this.radioButtonDapperRepository.UseVisualStyleBackColor = true;
            this.radioButtonDapperRepository.CheckedChanged += new System.EventHandler(this.radioButtonDapperRepository_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 34F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.radioButtonDapperRepository);
            this.Controls.Add(this.radioButtonEntityRepository);
            this.Controls.Add(this.LabelRepo);
            this.Controls.Add(this.buttonShowAll);
            this.Controls.Add(this.buttonSort);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.dataGridViewCharacters);
            this.Controls.Add(this.buttonAddHero);
            this.Controls.Add(this.buttonDeleteHero);
            this.Controls.Add(this.buttonEditHero);
            this.Controls.Add(this.labelFighter);
            this.Controls.Add(this.comboBoxFilterWeapon);
            this.Controls.Add(this.buttonFilterFighters);
            this.Controls.Add(this.labelMage);
            this.Controls.Add(this.comboBoxFilterSchool);
            this.Controls.Add(this.buttonFilterMages);
            this.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.Font = new System.Drawing.Font("Ink Free", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Гильдия искателей приключений";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCharacters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private DataGridViewTextBoxColumn ColType;
        private DataGridViewTextBoxColumn ColName;
        private DataGridViewTextBoxColumn ColHP;
        private DataGridViewTextBoxColumn ColStr;
        private DataGridViewTextBoxColumn ColStamina;
        private DataGridViewTextBoxColumn ColMana;
        private DataGridViewTextBoxColumn ColWeapon;
        private DataGridViewTextBoxColumn ColSchool;
        private DataGridViewTextBoxColumn ColDesc;
        private Label LabelRepo;
        private RadioButton radioButtonEntityRepository;
        private RadioButton radioButtonDapperRepository;
    }
}