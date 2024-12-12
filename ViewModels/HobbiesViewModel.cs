using HobbiesWPF.Command;
using HobbiesWPF.Models;
using System.Collections.ObjectModel;
/* 
  Johan Ahlqvist
 */
namespace HobbiesWPF.ViewModels
{
    public class HobbiesViewModel : ViewModelBase
    {
        private ObservableCollection<HobbyItemViewModel> _Hobbies = [];

        public ObservableCollection<HobbyItemViewModel> Hobbies
        {
            get { return _Hobbies; }
            set { _Hobbies = value; RaisePropertyChanged(); }
        }

        private HobbyItemViewModel? _SelectedHobby;

        public HobbyItemViewModel SelectedHobby
        {
            get { return _SelectedHobby; }
            set { _SelectedHobby = value; RaisePropertyChanged(); DeleteCommand.RaiseCanExecuteChanged(); }
        }

        public DelegateCommand AddCommand { get; }
        public DelegateCommand DeleteCommand { get; }

        public HobbiesViewModel() 
        { 
            _Hobbies.Add(new HobbyItemViewModel(new Hobby() { Name = "Fishing", Cost = 2000 }));
            _Hobbies.Add(new HobbyItemViewModel(new Hobby() { Name = "Cars", Cost = 30000 }));
            _Hobbies.Add(new HobbyItemViewModel(new Hobby() { Name = "Music", Cost = 500 }));

            AddCommand = new DelegateCommand(AddHobby);
            DeleteCommand = new DelegateCommand(DeleteHobby, CanDelete);
        }

        private void AddHobby(object? parameter)
        {
            Hobby hobby = new Hobby() { Name = "New Hobby" };
            var hobbyViewModel = new HobbyItemViewModel(hobby);
            _Hobbies.Add(hobbyViewModel);
            _SelectedHobby = hobbyViewModel;
        }

        private void DeleteHobby(object? parameter)
        {
            if (_SelectedHobby is not null)
            {
                _Hobbies.Remove(_SelectedHobby);
                _SelectedHobby = null;
            }
        }

        private bool CanDelete(object? parameter) => _SelectedHobby is not null;
    }
}
