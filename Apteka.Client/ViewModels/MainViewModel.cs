using Apteka.Client.Commands;
using Apteka.Client.Models;
using Apteka.Client.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Apteka.Client
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _error { get; set; } = "Hurmatli mijoz, tizimga kirish uchun login va parolingizni kiriting.";

        public string Error 
        { 
            get 
            { 
                return _error; 
            } 
            
            set 
            { 
                _error = value;
                OnPropertyChanged(nameof(Error));
            }
        }

        public string Email { get; set; }

        public string Password { get; set; }

        public ICommand ClickCommand { get; set; }

        public MainViewModel()
        {
            ClickCommand = new RelayCommand(async () => await Signin());
        }

        public async Task Signin()
        {
            IApiService<Login> service = new LoginService();

            var result = await service.Post(new Login { email = Email, password = Password});

            if (result is null)
                Error = "Login yoki parol noto'g'ri kitildi";
            else
            {
                Dashboard dashboardWindow = new Dashboard();

                dashboardWindow.ShowDialog();
            }
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
