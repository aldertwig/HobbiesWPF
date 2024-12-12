using HobbiesWPF.ViewModels;
using System.Windows;
/* 
  Johan Ahlqvist
 */
namespace HobbiesWPF
{
    public partial class MainWindow : Window
    {
        private HobbiesViewModel _ViewModel;

        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Hobbies";
            _ViewModel = new HobbiesViewModel();
            DataContext = _ViewModel;
        }
    }
}