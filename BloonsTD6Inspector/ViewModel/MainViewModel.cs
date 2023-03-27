using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BloonsTD6Inspector.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public RelayCommand SwitchPageCommand { get; private set; }
        public string CommandText { get; private set; }
        //public OverviewPage MainPage { get; private set; } = new OverviewPage();
        //public DetailedPage PokePage { get; private set; } = new DetailedPage();
        public Page CurrentPage { get; private set; }

        public MainViewModel()
        {
            //CurrentPage = MainPage;
            SwitchPageCommand = new RelayCommand(SwitchPage);
            CommandText = "SHOW DETAILS";
        }

        public void SwitchPage()
        {
            //check the current visisble page type
            //if (CurrentPage is OverviewPage)
            //{
            //    // Get the selected pokemon
            //    Pokemon selectedPokemon = (MainPage.DataContext as OverviewVM).SelectedPokemon;
            //    if (selectedPokemon == null) return;

            //    //TODO: Set the currentPokemon of the DetailPageVM to the selected pokemon
            //    //Hint: use the same principle as above to access the datacontext of the detailpage
            //    DetailPageVM dpVM = (PokePage.DataContext as DetailPageVM);
            //    dpVM.CurrentPokemon = selectedPokemon;

            //    // Set the current page TODO: notify the view of the change!
            //    CurrentPage = PokePage;
            //    CommandText = "GO BACK";
            //    OnPropertyChanged(nameof(CommandText));
            //    OnPropertyChanged(nameof(CurrentPage));
            //}
            //else
            //{
            //    CurrentPage = MainPage;
            //    CommandText = "SHOW DETAILS";
            //    OnPropertyChanged(nameof(CommandText));
            //    OnPropertyChanged(nameof(CurrentPage));
            //}
        }
    }
}
