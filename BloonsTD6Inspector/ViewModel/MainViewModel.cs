using BloonsTD6Inspector.Model;
using BloonsTD6Inspector.View;
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
        public string ButtonVisibility { get; private set; }
        public OverviewPage MainPage { get; private set; } = new OverviewPage();
        public DetailPage DetailedPage { get; private set; } = new DetailPage();
        public PathPage PathPage { get; private set; } = new PathPage();
        public Page CurrentPage { get; private set; }
        
        public MainViewModel()
        {
            OverviewPageVM.MainVM = this;
            DetailedPageVM.MainVM = this;
            CurrentPage = MainPage;
            SwitchPageCommand = new RelayCommand(SwitchPage);
            ButtonVisibility = "Hidden";
            OnPropertyChanged(nameof(ButtonVisibility));
        }

        public void SwitchPage()
        {
            if (CurrentPage is OverviewPage)
            {
                Tower selectedGameObject = (MainPage.DataContext as OverviewPageVM).SelectedGameObject;
                if (selectedGameObject == null) return;

                DetailedPageVM dpVM = (DetailedPage.DataContext as DetailedPageVM);
                dpVM.InspectedObject = selectedGameObject;

                CurrentPage = DetailedPage;
                ButtonVisibility = "Visible";
                OnPropertyChanged(nameof(ButtonVisibility));
                OnPropertyChanged(nameof(CurrentPage));
            }
            else if (CurrentPage is PathPage)
            {
                CurrentPage = DetailedPage;
                ButtonVisibility = "Visible";
                OnPropertyChanged(nameof(ButtonVisibility));
                OnPropertyChanged(nameof(CurrentPage));
            }
            else
            {
                CurrentPage = MainPage;
                ButtonVisibility = "Hidden";
                OnPropertyChanged(nameof(ButtonVisibility));
                OnPropertyChanged(nameof(CurrentPage));
            }
        }

        public void SeePaths()
        {
            CurrentPage = PathPage;
            ButtonVisibility = "Visible";
            OnPropertyChanged(nameof(ButtonVisibility));
            OnPropertyChanged(nameof(CurrentPage));
        }
    }
}
