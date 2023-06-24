using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kr4.Model.Entities;
using Kr4.Services.Interface;
using Kr4.View;
using Kr4.View.Interface;
using Kr4.ViewModel.EditViewModels;

namespace Kr4.Services
{
    public  class EditWindowFactory : IEditWindowsFactory
    {
       

        public IEditWindow CreateEditWindow(IAstronomicalObject item)
        {
           
            if (item is Planet)
            {
                var window = new EditPlanetView();
                var viewModel = new EditPlanetViewModel(item as Planet, window.Close);
                window.DataContext = viewModel;
                return window;

            }
            else if (item is Star)
            {
                var window = new EditStarView();
                var viewModel = new EditStarViewModel(item as Star, window.Close);
                window.DataContext = viewModel;
                return window;
            }
            else if (item is Galaxy)
            {
                var window = new EditGalaxyView();
                var viewModel = new EditGalaxyViewModel(item as Galaxy, window.Close);
                window.DataContext = viewModel;
                return window;
            }

            return new EditPlanetView();
        }

       
    }
}
