using HobbiesWPF.Models;
/* 
  Johan Ahlqvist
 */
namespace HobbiesWPF.ViewModels
{
    public class HobbyItemViewModel : ViewModelBase
    {
        private readonly Hobby _Model;

        public HobbyItemViewModel(Hobby model)
        {
            _Model = model;
        }

        public string Name
        {
            get { return _Model.Name; }
            set { _Model.Name = value; RaisePropertyChanged(); }
        }

        public int Cost
        {
            get { return _Model.Cost; }
            set { _Model.Cost = value; RaisePropertyChanged(); }
        }
    }
}
