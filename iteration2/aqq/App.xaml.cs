using Xamarin.Forms;
using Microsoft.WindowsAzure.MobileServices;
namespace aqq
{
	
    
    public partial class App : Application
    {
		
        public App()
        {
            
            InitializeComponent();
            Application.Current.Properties.Clear();
            MainPage = new NavigationPage(new Login());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
