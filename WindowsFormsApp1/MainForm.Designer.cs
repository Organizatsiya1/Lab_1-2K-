namespace WinFormApp
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewCharacters = new System.Windows.Forms.DataGridView();
            this.buttonAddHero = new System.Windows.Forms.Button();
            this.buttonDeleteHero = new System.Windows.Forms.Button();
            this.buttonEditHero = new System.Windows.Forms.Button();
            this.buttonOpenMageForm = new System.Windows.Forms.Button();
            this.buttonOpenFighterForm = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCharacters)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCharacters
            // 
            this.dataGridViewCharacters.ColumnHeadersHeight = 29;
            this.dataGridViewCharacters.Location = new System.Drawing.Point(42, 79);
            this.dataGridViewCharacters.Name = "dataGridViewCharacters";
            this.dataGridViewCharacters.RowHeadersWidth = 51;
            this.dataGridViewCharacters.Size = new System.Drawing.Size(612, 330);
            this.dataGridViewCharacters.TabIndex = 1;
            // 
            // buttonAddHero
            // 
            this.buttonAddHero.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonAddHero.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.buttonAddHero.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAddHero.Font = new System.Drawing.Font("Papyrus", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddHero.ForeColor = System.Drawing.Color.Gold;
            this.buttonAddHero.Location = new System.Drawing.Point(697, 79);
            this.buttonAddHero.Name = "buttonAddHero";
            this.buttonAddHero.Size = new System.Drawing.Size(250, 50);
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
            this.buttonDeleteHero.Font = new System.Drawing.Font("Papyrus", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteHero.ForeColor = System.Drawing.Color.Gold;
            this.buttonDeleteHero.Location = new System.Drawing.Point(697, 139);
            this.buttonDeleteHero.Name = "buttonDeleteHero";
            this.buttonDeleteHero.Size = new System.Drawing.Size(250, 50);
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
            this.buttonEditHero.Font = new System.Drawing.Font("Papyrus", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditHero.ForeColor = System.Drawing.Color.Gold;
            this.buttonEditHero.Location = new System.Drawing.Point(697, 199);
            this.buttonEditHero.Name = "buttonEditHero";
            this.buttonEditHero.Size = new System.Drawing.Size(250, 50);
            this.buttonEditHero.TabIndex = 4;
            this.buttonEditHero.Text = "✏ Изменить героя";
            this.buttonEditHero.UseVisualStyleBackColor = false;
            this.buttonEditHero.Click += new System.EventHandler(this.buttonEditHero_Click);
            // 
            // buttonOpenMageForm
            // 
            this.buttonOpenMageForm.BackColor = System.Drawing.Color.DarkBlue;
            this.buttonOpenMageForm.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.buttonOpenMageForm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonOpenMageForm.Font = new System.Drawing.Font("Papyrus", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOpenMageForm.ForeColor = System.Drawing.Color.White;
            this.buttonOpenMageForm.Location = new System.Drawing.Point(697, 299);
            this.buttonOpenMageForm.Name = "buttonOpenMageForm";
            this.buttonOpenMageForm.Size = new System.Drawing.Size(250, 50);
            this.buttonOpenMageForm.TabIndex = 5;
            this.buttonOpenMageForm.Text = "🔮 Маги";
            this.buttonOpenMageForm.UseVisualStyleBackColor = false;
            this.buttonOpenMageForm.Click += new System.EventHandler(this.buttonOpenMageForm_Click);
            // 
            // buttonOpenFighterForm
            // 
            this.buttonOpenFighterForm.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.buttonOpenFighterForm.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.buttonOpenFighterForm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonOpenFighterForm.Font = new System.Drawing.Font("Papyrus", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOpenFighterForm.ForeColor = System.Drawing.Color.White;
            this.buttonOpenFighterForm.Location = new System.Drawing.Point(697, 359);
            this.buttonOpenFighterForm.Name = "buttonOpenFighterForm";
            this.buttonOpenFighterForm.Size = new System.Drawing.Size(250, 50);
            this.buttonOpenFighterForm.TabIndex = 6;
            this.buttonOpenFighterForm.Text = "🛡 Воины";
            this.buttonOpenFighterForm.UseVisualStyleBackColor = false;
            this.buttonOpenFighterForm.Click += new System.EventHandler(this.buttonOpenFighterForm_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Papyrus", 22F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.Gold;
            this.labelTitle.Location = new System.Drawing.Point(89, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(814, 58);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "⚔ Гильдия искателей приключений ⚔";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(982, 453);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.dataGridViewCharacters);
            this.Controls.Add(this.buttonAddHero);
            this.Controls.Add(this.buttonDeleteHero);
            this.Controls.Add(this.buttonEditHero);
            this.Controls.Add(this.buttonOpenMageForm);
            this.Controls.Add(this.buttonOpenFighterForm);
            this.Font = new System.Drawing.Font("Papyrus", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Гильдия искателей приключений";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCharacters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCharacters;
        private System.Windows.Forms.Button buttonAddHero;
        private System.Windows.Forms.Button buttonDeleteHero;
        private System.Windows.Forms.Button buttonEditHero;
        private System.Windows.Forms.Button buttonOpenMageForm;
        private System.Windows.Forms.Button buttonOpenFighterForm;
        private System.Windows.Forms.Label labelTitle;
    }
}

