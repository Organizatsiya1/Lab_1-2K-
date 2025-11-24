using BusinessLogicModels; // не зависим
using Shared;
using System;

namespace Presenter
{
    public class MainPresenter
    {
        private readonly IView view;
        private readonly IModel model;

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
        }

        private void OnEditData()
        {
            throw new NotImplementedException();
        }

        private void OnAddData()
        {
            throw new NotImplementedException();
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
