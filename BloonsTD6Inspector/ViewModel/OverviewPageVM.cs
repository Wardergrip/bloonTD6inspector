using BloonsTD6Inspector.Model;
using BloonsTD6Inspector.Repository;
using CommunityToolkit.Mvvm.ComponentModel;
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

        private APIRepos Repository { get; set; }
        public List<GameObject> GameObjects { get; private set; }
        private string _selectedType;

        private GameObject _selectedGameObject;
        public GameObject SelectedGameObject
        {
            get { return _selectedGameObject; }
            set 
            { 
                _selectedGameObject = value;
                MainVM.SwitchPage();
            }
        }

        public string SelectedType
        {
            get { return _selectedType; }
            set
            {
                _selectedType = value;
                //GameObjects = Repository.GetPokemons(value);
                //OnPropertyChanged(nameof(SelectedType));
                //OnPropertyChanged(nameof(GameObjects));
            }
        }

        public OverviewPageVM()
        {
            Repository = new APIRepos();
            LoadGameObjects();
        }
        public async void LoadGameObjects()
        {
            GameObjects = await Repository.GetTowersAsync();
            OnPropertyChanged(nameof(GameObjects));
        }
    }
}
