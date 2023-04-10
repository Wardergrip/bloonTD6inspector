using BloonsTD6Inspector.Model;
using BloonsTD6Inspector.Repository;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BloonsTD6Inspector.ViewModel
{
    public class OverviewPageVM : ObservableObject
    {
        public static MainViewModel MainVM { get; set; }

        private IRepos _repository;
        private IRepos Repository
        {
            get
            {
                return _repository;
            }
            set
            {
                _repository = value;
                LoadGameObjects();
            }
        }
        private IRepos LocalRepos { get; set; }
        private IRepos APIRepos { get; set; }
        public List<Tower> GameObjects { get; private set; }

        public List<string> TowerTypes { get; private set; }
        private string _selectedType;
        public string SelectedType
        {
            get { return _selectedType; }
            set
            {
                _selectedType = value;
                LoadTypedGameObjects(_selectedType);
                OnPropertyChanged(nameof(SelectedType));
            }
        }

        private Tower _selectedGameObject;
        public Tower SelectedGameObject
        {
            get { return _selectedGameObject; }
            set 
            { 
                _selectedGameObject = value;
                MainVM.SwitchPage();
            }
        }

        public RelayCommand SwitchReposCommand { get; private set; }
        public string SwitchReposButtonText { get; private set; } = "Switch to local repos";

        public OverviewPageVM()
        {
            APIRepos = new APIRepos();
            LocalRepos = new LocalRepos();
            Repository = APIRepos;

            SwitchReposCommand = new RelayCommand(SwitchRepos);
        }
        public async void LoadGameObjects()
        {
            GameObjects = await Repository.GetTowersAsync();
            var towers = await Repository.GetTowersAsync();
            TowerTypes = towers.Select(x => x.Type).Distinct().ToList();
            TowerTypes.Add("All");
            OnPropertyChanged(nameof(GameObjects));
            OnPropertyChanged(nameof(TowerTypes));
        }

        public async void LoadTypedGameObjects(string type)
        {
            GameObjects = await Repository.GetTowersAsync(type);
            OnPropertyChanged(nameof(GameObjects));
        }

        public void SwitchRepos()
        {
            Repository = (Repository == APIRepos) ? LocalRepos : APIRepos;
            SwitchReposButtonText = (Repository == APIRepos) ? "Switch to local repos" : "Switch to API repos";
            OnPropertyChanged(nameof(SwitchReposButtonText));
        }
    }
}
