using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Kr4.Model;
using Kr4.Services;
using NLog;

namespace Kr4
{
   
    public partial class App 
    {
        private Bootstrapper.Bootstrapper? _bootstrapper;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        protected override void OnStartup(StartupEventArgs e)
        {
          

            LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration("NLog.config");


            this.DispatcherUnhandledException += App_DispatcherUnhandledException;

            
            LogManager.LoadConfiguration("NLog.config");
            base.OnStartup(e);
            var context = new AstronomicalContext();
            context.Database.EnsureCreated();
            _bootstrapper = new Bootstrapper.Bootstrapper();

            DatabaseLocator.Context = context;
            logger.Error("234");

            MainWindow = _bootstrapper.Run();
          
        }
        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
           
            logger.Error(e.Exception, "Unhandled exception occurred");

            e.Handled = true;
        }
    }
}
