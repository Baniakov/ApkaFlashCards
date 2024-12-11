using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContentPage1 : ContentPage
    {
        public ContentPage1()
        {
            InitializeComponent();
        }

        private void OnAddFiszkaClicked(object sender, EventArgs e)
        {
            string jezykObcy = entryJezykObcy.Text;
            string jezykRodzinny = entryJezykRodzinny.Text;

            if (string.IsNullOrWhiteSpace(jezykObcy) || string.IsNullOrWhiteSpace(jezykRodzinny))
            {
                DisplayAlert("Błąd", "Wszystkie pola muszą być wypełnione.", "OK");
                return;
            }

            // Dodaj fiszkę do listy DoNauki
            MainPage.DoNauki.Add(new Fiszka
            {
                JezykObcy = jezykObcy,
                JezykRodzinny = jezykRodzinny
            });

            // Wyczyść pola
            entryJezykObcy.Text = string.Empty;
            entryJezykRodzinny.Text = string.Empty;
        }
    }

}
