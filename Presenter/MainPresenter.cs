using BusinessLogicModels; // не зависим
using Shared;
using System;

namespace Presenter
{
    public class MainPresenter
    {
        private readonly IView view;
        private readonly IModel model;
        private readonly IAddHeroView addHeroView;
        public MainPresenter(IView view, IModel model)
        {
            this.view = view;
            this.model = model;

            // Подписка на события View
            this.view.AddDataEvent += OnAddData;
            this.view.DeleteDataEvent += OnDeleteData;
            this.view.EditDataEvent += OnEditData;
            this.view.LoadDataEvent += OnLoadData;

            // Подписка на событие Model
            this.model.DataChanged += OnDataChanged;
            OnLoadData();
        }

        private void OnEditData()
        {
            throw new NotImplementedException();
        }

        private void OnAddData()
        {
            try
            {
                addHeroView.SetCreateMode();
                if (addHeroView.ShowDialog())
                {
                    view.ShowMessage("Персонаж успешно добавлен!");
                }
            }
            catch (Exception ex)
            {
                view.ShowError($"Ошибка при добавлении: {ex.Message}");
            }
        }

        private void OnDataChanged()
        {
            OnLoadData(); // Автообновление
        }

        private void OnLoadData()
        {
            var units = model.GetUnits();
            view.Redraw(units);
        }

        private void OnDeleteData()
        {
            var selected = view.GetSelectedCharacter();
            if (selected == null) return;

            model.DeleteUnit(selected);
        }
    }
}
