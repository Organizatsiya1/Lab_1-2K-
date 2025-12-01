using BusinessLogicModels; // не зависим
using Models;
using Shared;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Presenter
{
    public class MainPresenter
    {
        private readonly IView view;
        private readonly IModel model;
        private readonly IAddHeroView addHeroView;
        public MainPresenter(IView view, IModel model, IAddHeroView addHeroView)
        {
            this.view = view;
            this.model = model;
            this.addHeroView = addHeroView;

            BindViewEvents();

            model.DataChanged += OnModelDataChanged;

            RedrawAll();
        }

        private void BindViewEvents()
        {
            view.AddDataEvent += OnAdd;
            view.DeleteDataEvent += OnDelete;
            view.EditDataEvent += OnEdit;
            view.LoadDataEvent += RedrawAll;

            view.FilterFightersEvent += OnFilterFighters;
            view.FilterMagesEvent += OnFilterMages;

            view.FightEvent += OnFight;

            view.ChangeRepositoryEvent += OnChangeRepository;
        }

        private void RedrawAll()
        {
            view.Redraw(model.GetUnits());
        }

        private void OnModelDataChanged()
        {
            RedrawAll();
        }

        private void OnAdd()
        {
            
            if (addHeroView.ShowDialog() == Shared.DialogResult.OK)
            {
                Character c = addHeroView.CreatedHero;

                if (c is Fighter f)
                {
                    model.AddFighter(f.Name, f.Description, f.HP, f.Strength, f.Stamina, f.Weapon);
                }
                else if (c is Mage m)
                {
                    model.AddMage(m.Name, m.Description, m.HP, m.Strength, m.Mana, m.School);
                }
            }
        }

        private void OnDelete()
        {
            Character selected = view.GetSelectedCharacter();
            if (selected == null) return;

            model.DeleteUnit(selected);
        }

        private void OnEdit()
        {
            Character selected = view.GetSelectedCharacter();
            if (selected == null) return;

            addHeroView.LoadCharacter(selected);

            if (addHeroView.ShowDialog() == Shared.DialogResult.OK)
            {
                Character updated = addHeroView.CreatedHero;

                if (selected is Fighter oldF && updated is Fighter f)
                {
                    model.ChangeFighter(oldF, f.Name, f.Description, f.HP, f.Strength, f.Stamina, f.Weapon);
                }
                else if (selected is Mage oldM && updated is Mage m)
                {
                    model.ChangeMage(oldM, m.Name, m.Description, m.HP, m.Strength, m.Mana, m.School);
                }
            }
        }

        private void OnFilterFighters(string weaponName)
        {
            Weapons weapon = Displays.WeaponsNames
                .First(x => x.Value == weaponName).Key;

            var list = model.ChooseMarked(weapon);
            view.Redraw(list);
        }

        private void OnFilterMages(string schoolName)
        {
            MagicSchools school = Displays.MagicNames
                .First(x => x.Value == schoolName).Key;

            var list = model.ChooseMarked(school);
            view.Redraw(list);
        }

        private void OnFight(int index1, int index2)
        {
            var units = model.GetUnits();
            if (index1 >= units.Count || index2 >= units.Count) return;

            var result = model.Fight(units[index1], units[index2]);
            view.ShowMessage(result);

            RedrawAll();
        }

        private void OnChangeRepository(bool useDapper)
        {
            // Здесь ты сам реализуешь логику переключения DI контейнера
            view.ShowMessage($"Репозиторий переключён: {(useDapper ? "Dapper" : "Entity")}");
        }
    }
}
