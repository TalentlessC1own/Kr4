using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Kr4.Model;
using Kr4.Services;
using Kr4.ViewModel;

namespace Kr4.Bootstrapper
{
    class Bootstrapper
    {
        public Window Run()
        {
          
            var mainWindow = new MainWindow();
            mainWindow.DataContext = new MainViewModel(new EditWindowFactory());
            mainWindow.Show();

            return mainWindow;
        }
    }
}
