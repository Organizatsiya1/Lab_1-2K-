using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Business_Logic;
using Model;


namespace WinFormApp
{
    public partial class MainForm : Form
    {
        private Logic logic = new Logic();
        private List<Character> units = new List<Character>();

        public MainForm()
        {
            InitializeComponent();
            RefreshGrid(units); // при запуске таблица пустая
        }

        private void RefreshGrid(List<Character> list)
        {
            dataGridViewCharacters.DataSource = null;
            dataGridViewCharacters.DataSource = list;
        }

        private void buttonAddHero_Click(object sender, System.EventArgs e)
        {
            // Пример: добавим тестового воина
            logic.Add_Fighter(units, "Рагнар", "Северный воин", 120, 20, 15, Weapons.Sword);
            logic.Add_Mage(units, "Мерлин", "Старый мудрец", 80, 10, 50, Magic_Schools.Fire);

            RefreshGrid(units);
            MessageBox.Show("Добавлены тестовые персонажи!");
        }

        private void buttonDeleteHero_Click(object sender, System.EventArgs e)
        {

        }

        private void buttonEditHero_Click(object sender, System.EventArgs e)
        {

        }

        private void buttonOpenMageForm_Click(object sender, System.EventArgs e)
        {

        }

        private void buttonOpenFighterForm_Click(object sender, System.EventArgs e)
        {

        }
    }
}
