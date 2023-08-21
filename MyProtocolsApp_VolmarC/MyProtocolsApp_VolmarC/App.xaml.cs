using MyProtocolsApp_VolmarC.Services;
using MyProtocolsApp_VolmarC.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyProtocolsApp_VolmarC
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            //DependencyService.Register<MockDataStore>();
            //definimos la forma de apilar páginas en la pantalla 
            //y cuál es la primera página que mostraremos
            MainPage = new NavigationPage(new AppLoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
