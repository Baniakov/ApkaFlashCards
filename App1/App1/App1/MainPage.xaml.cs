using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public static List<Fiszka> DoNauki = new List<Fiszka>();
        public static List<Fiszka> DoPowtorki = new List<Fiszka>();

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnAddFiszkaClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContentPage1());
        }

        private async void OnStartLearningClicked(object sender, EventArgs e)
        {
            if (DoNauki.Count == 0)
            {
                await DisplayAlert("Brak fiszek", "Nie możesz rozpocząć nauki bez fiszek", "OK");
                return;
            }
            await Navigation.PushAsync(new ContentPage2());
        }
        private async void OnReviseClicked(object sender, EventArgs e)
        {
            if(DoPowtorki.Count == 0)
            {
                await DisplayAlert("Brak fiszek", "Nie możesz rozpocząć powtórki bez fiszek", "OK");
                return;
            }
            await Navigation.PushAsync(new ContentPage3());
        }

        private async void OnListClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TabbedPage1());
        }
    }

}