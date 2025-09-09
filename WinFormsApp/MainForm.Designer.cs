
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
            dataGridViewCharacters = new DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)dataGridViewCharacters).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewCharacters
            // 
            dataGridViewCharacters.ColumnHeadersHeight = 32;
            dataGridViewCharacters.Location = new Point(42, 79);
            dataGridViewCharacters.Name = "dataGridViewCharacters";
            dataGridViewCharacters.RowHeadersWidth = 51;
            dataGridViewCharacters.Size = new Size(1045, 487);
            dataGridViewCharacters.TabIndex = 1;
            // 
            // buttonAddHero
            // 
            buttonAddHero.BackColor = Color.MidnightBlue;
            buttonAddHero.Cursor = Cursors.PanNW;
            buttonAddHero.FlatStyle = FlatStyle.Popup;
            buttonAddHero.Font = new Font("Papyrus", 10.2F, FontStyle.Bold);
            buttonAddHero.ForeColor = Color.Gold;
            buttonAddHero.Location = new Point(1108, 79);
            buttonAddHero.Name = "buttonAddHero";
            buttonAddHero.Size = new Size(250, 50);
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
            buttonDeleteHero.Font = new Font("Papyrus", 10.2F, FontStyle.Bold);
            buttonDeleteHero.ForeColor = Color.Gold;
            buttonDeleteHero.Location = new Point(1108, 135);
            buttonDeleteHero.Name = "buttonDeleteHero";
            buttonDeleteHero.Size = new Size(250, 50);
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
            buttonEditHero.Font = new Font("Papyrus", 10.2F, FontStyle.Bold);
            buttonEditHero.ForeColor = Color.Gold;
            buttonEditHero.Location = new Point(1108, 191);
            buttonEditHero.Name = "buttonEditHero";
            buttonEditHero.Size = new Size(250, 50);
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
            buttonFilterMages.Font = new Font("Papyrus", 10.2F, FontStyle.Bold);
            buttonFilterMages.ForeColor = Color.White;
            buttonFilterMages.Location = new Point(1315, 362);
            buttonFilterMages.Name = "buttonFilterMages";
            buttonFilterMages.Size = new Size(57, 38);
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
            buttonFilterFighters.Font = new Font("Papyrus", 10.2F, FontStyle.Bold);
            buttonFilterFighters.ForeColor = Color.White;
            buttonFilterFighters.Location = new Point(1315, 310);
            buttonFilterFighters.Name = "buttonFilterFighters";
            buttonFilterFighters.Size = new Size(57, 38);
            buttonFilterFighters.TabIndex = 7;
            buttonFilterFighters.Text = "🛡";
            buttonFilterFighters.UseVisualStyleBackColor = false;
            buttonFilterFighters.Click += buttonFilterFighters_Click;
            // 
            // comboBoxFilterSchool
            // 
            comboBoxFilterSchool.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFilterSchool.Location = new Point(1185, 362);
            comboBoxFilterSchool.Name = "comboBoxFilterSchool";
            comboBoxFilterSchool.Size = new Size(120, 45);
            comboBoxFilterSchool.TabIndex = 9;
            // 
            // comboBoxFilterWeapon
            // 
            comboBoxFilterWeapon.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFilterWeapon.Location = new Point(1185, 307);
            comboBoxFilterWeapon.Name = "comboBoxFilterWeapon";
            comboBoxFilterWeapon.Size = new Size(120, 45);
            comboBoxFilterWeapon.TabIndex = 6;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Papyrus", 22F, FontStyle.Bold);
            labelTitle.ForeColor = Color.Gold;
            labelTitle.Location = new Point(161, 9);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(814, 58);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "⚔ Гильдия искателей приключений ⚔";
            // 
            // labelMage
            // 
            labelMage.AutoSize = true;
            labelMage.ForeColor = Color.White;
            labelMage.Location = new Point(1093, 370);
            labelMage.Name = "labelMage";
            labelMage.Size = new Size(71, 37);
            labelMage.TabIndex = 8;
            labelMage.Text = "Маг:";
            // 
            // labelFighter
            // 
            labelFighter.AutoSize = true;
            labelFighter.ForeColor = Color.White;
            labelFighter.Location = new Point(1093, 310);
            labelFighter.Name = "labelFighter";
            labelFighter.Size = new Size(86, 37);
            labelFighter.TabIndex = 5;
            labelFighter.Text = "Воин:";
            // 
            // buttonShowAll
            // 
            buttonShowAll.BackColor = Color.MidnightBlue;
            buttonShowAll.Cursor = Cursors.PanNW;
            buttonShowAll.FlatStyle = FlatStyle.Popup;
            buttonShowAll.Font = new Font("Papyrus", 10.2F, FontStyle.Bold);
            buttonShowAll.ForeColor = Color.Gold;
            buttonShowAll.Location = new Point(1122, 426);
            buttonShowAll.Name = "buttonShowAll";
            buttonShowAll.Size = new Size(250, 50);
            buttonShowAll.TabIndex = 11;
            buttonShowAll.Text = "Показать всех героев";
            buttonShowAll.UseVisualStyleBackColor = false;
            buttonShowAll.Click += buttonShowAll_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(17F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateGray;
            ClientSize = new Size(1403, 607);
            Controls.Add(buttonShowAll);
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
            Font = new Font("Papyrus", 13.8F, FontStyle.Bold);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Гильдия искателей приключений";
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
    }
}