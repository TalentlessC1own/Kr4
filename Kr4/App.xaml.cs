using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Kr4.Model;
using Kr4.Services;

namespace Kr4
{
   
    public partial class App 
    {
        private Bootstrapper.Bootstrapper? _bootstrapper;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var context = new AstronomicalContext();
            context.Database.EnsureCreated();
            _bootstrapper = new Bootstrapper.Bootstrapper();

            DatabaseLocator.Context = context;

            MainWindow = _bootstrapper.Run();
        }
    }
}
