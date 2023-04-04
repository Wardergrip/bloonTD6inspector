using BloonsTD6Inspector.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloonsTD6Inspector.ViewModel
{
    public class DetailedPageVM : ObservableObject
    {
        public static MainViewModel MainVM { get; set; }

        private Tower _inspectedObject;
        public Tower InspectedObject
        {
            get
            {
                return _inspectedObject;
            }
            set
            {
                _inspectedObject = value;
                OnPropertyChanged(nameof(InspectedObject));
            }
        }

        public RelayCommand GoBackCommand { get; set; }
        public RelayCommand SeePathsCommand { get; set; }

        public DetailedPageVM() 
        {
            InspectedObject = new Tower()
            {
                ObjectType = "tower",
                Name = "Dart Monkey",
                Description = "Placeholder text for dart monkey",
                Id = "dart-monkey",
                DefaultHotkey = "f"
            };
            GoBackCommand = new RelayCommand(GoBack);
            SeePathsCommand = new RelayCommand(SeePaths);
        }

        private void GoBack()
        {
            MainVM.SwitchPage();
        }

        private void SeePaths() 
        {
            MainVM.SeePaths();
        }
    }
}
