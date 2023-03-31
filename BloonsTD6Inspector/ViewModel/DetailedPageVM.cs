using BloonsTD6Inspector.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloonsTD6Inspector.ViewModel
{
    public class DetailedPageVM : ObservableObject
    {
        private GameObject _inspectedObject;
        public GameObject InspectedObject
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

        public DetailedPageVM() 
        {
            InspectedObject = new GameObject()
            {
                ObjectType = "hero",
                Name = "quincy",
                Description = "Proud, strong and intelligent, Quincy uses his bow to perform feats of amazing skill.",
                Id = "quincy"
            };
        }
    }
}
