using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Kr4.Model.Entities;
using Kr4.Services;
using System.Windows.Input;

namespace Kr4.ViewModel
{
    public class AddViewModel : ViewModelBase
    {
        
        private const int AddPlanet = 0;
        private const int AddStar = 1;
        private const int AddSpectralClass = 2;
        private const int AddGalaxy = 3;
        private const int AddGalaxyType = 4;

        private IEventAgregator eventAgregator;

        private string ChangedList = "";

        public int SelectedTab { get; set; }
        public string Name { get; set; }
        public double Size { get; set; }

        public double OrbitalPeriod { get; set; }

        public double DistanceFromEarth { get; set; }

        public double Age { get; set; }

        public double Luminosity { get; set; }

        public SpectralClass SpectralClass { get; set; }

        public GalaxyType GalaxyType { get; set; }

        public AddViewModel(IEventAgregator eventAgregator)
        {
            this.eventAgregator = eventAgregator;
        }

        private void clearFields()
        {
            Name = string.Empty;
            Size = 0;
            OrbitalPeriod = 0;
            DistanceFromEarth = 0;
            Age = 0;
            Luminosity = 0;
            SpectralClass = new SpectralClass() { Name = "none" };
            GalaxyType = new GalaxyType() { Name = "none" };
        }
        public List<GalaxyType> GalaxyTypes
        {
            get
            {
                var galaxyType = DatabaseLocator.Context.GalaxysTypes.ToList();
                galaxyType.Insert(0, new GalaxyType() { Name = "none" });
                return galaxyType;
            }
            
        }

        public List<SpectralClass> SpectralClasses
        {
            get
            {
                var spectralClasses = DatabaseLocator.Context.SpectralClasses.ToList();
                spectralClasses.Insert(0, new SpectralClass() { Name = "none" });
                return spectralClasses;
            }
        }

        public ICommand Add
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    switch (SelectedTab)
                    {

                        case AddPlanet:
                            if (Name != "")
                            {
                                DatabaseLocator.Context.Planets.Add(new Planet()
                                {
                                    Name = this.Name, DistanceFromEarth = this.DistanceFromEarth, Age = this.Age,
                                    OrbitalPeriod = this.OrbitalPeriod, Size = this.Size
                                });
                            }
                            else
                            {
                                Xceed.Wpf.Toolkit.MessageBox.Show("Fill out the required field Name", "",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }

                            break;
                        case AddStar:
                            if (Name != "" && SpectralClasses != null)
                            {
                                DatabaseLocator.Context.Stars.Add(new Star()
                                {
                                    Name = this.Name, Age = this.Age, DistanceFromEarth = this.DistanceFromEarth,
                                    Class = this.SpectralClass, Luminosity = this.Luminosity
                                });
                            }
                            else
                            {
                                Xceed.Wpf.Toolkit.MessageBox.Show("Fill out the required field Name and Spectral Class",
                                    "", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }

                            break;
                        case AddSpectralClass:
                            if (Name != "")
                            {
                                DatabaseLocator.Context.SpectralClasses.Add(new SpectralClass() { Name = this.Name });
                                ChangedList = nameof(SpectralClasses);
                            }
                            else
                            {
                                Xceed.Wpf.Toolkit.MessageBox.Show("Fill out the required field Name", "",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                                return;

                            }

                            break;
                        case AddGalaxy:
                            if (Name != "" && GalaxyType != null)
                            {
                                DatabaseLocator.Context.Galaxy.Add(new Galaxy()
                                {
                                    Name = this.Name, Type = GalaxyType, DistanceFromEarth = this.DistanceFromEarth,
                                    Age = this.Age
                                });
                            }
                            else
                            {
                                Xceed.Wpf.Toolkit.MessageBox.Show("Fill out the required field Name and Type", "",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }

                            break;
                        case AddGalaxyType:
                            if (Name != "")
                            {
                                ChangedList = nameof(GalaxyTypes);
                                DatabaseLocator.Context.GalaxysTypes.Add(new GalaxyType() { Name = this.Name });
                            }
                            else
                            {
                                Xceed.Wpf.Toolkit.MessageBox.Show("Fill out the required field Name", "",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }

                            break;
                    }
                 //   eventAgregator.NotifyDBChanged();
                   
                    DatabaseLocator.Context.SaveChanges();
                 if(ChangedList != "")
                    RaisePropertiesChanged(ChangedList);
                 clearFields();
                });
            }

        }

       
    }
}
