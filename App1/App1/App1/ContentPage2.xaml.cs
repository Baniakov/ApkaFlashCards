using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContentPage2 : ContentPage
    {
        private List<Fiszka> shuffledFiszki;
        private int currentIndex = 0;
        private int MaxFiszki = MainPage.DoNauki.Count;
        public bool toCheckForeignLanguage;

        public ContentPage2()
        {
            InitializeComponent();
            if (MainPage.DoNauki.Count < 20) {
                MaxFiszki = 20;
            }

            // Losowanie fiszek
            shuffledFiszki = MainPage.DoNauki.OrderBy(x => Guid.NewGuid()).Take(MaxFiszki).ToList();
            var isForeignLanguage = new Random().Next(2)==0;
            toCheckForeignLanguage = isForeignLanguage;
            DisplayNextFiszka(toCheckForeignLanguage);
        }
        private void DisplayNextFiszka(bool isForeignLanguage)
        {
            if (currentIndex < (shuffledFiszki.Count-1))
            {

                var fiszka = shuffledFiszki[currentIndex];
                // Pokazanie wylosowanej fiszki w odpowiednim języku
                fiszkaLabel.Text = isForeignLanguage ? fiszka.JezykObcy : fiszka.JezykRodzinny;
            }
            else
            {
                DisplayAlert("Gratulacje!", "Dodaj więcej fiszkek aby się uczyć lub przejdź do opcji powtórka.", "OK");
                b1.IsEnabled = false;
                b2.IsEnabled = false;
                fiszkaFrame.IsEnabled = false;
            }
        }

        private async void OnKnowClicked(object sender, EventArgs e)
        {
            if (MainPage.DoNauki.Count > 0)
            {
                MainPage.DoPowtorki.Add(shuffledFiszki[currentIndex]);
                MainPage.DoNauki.RemoveAt(currentIndex);
                currentIndex++;
                var isForeignLanguage = new Random().Next(2) == 0;
                toCheckForeignLanguage = isForeignLanguage;
                DisplayNextFiszka(toCheckForeignLanguage);
            }
            else
            {
                DisplayAlert("Gratulacje!", "Zakończyłeś naukę.", "OK");
            }
        }

        private void OnDontKnowClicked(object sender, EventArgs e)
        {
            currentIndex++;
            var isForeignLanguage = new Random().Next(2) == 0;
            toCheckForeignLanguage = isForeignLanguage;
            DisplayNextFiszka(toCheckForeignLanguage);
        }

        private void fiszkaLabel_Clicked(object sender, EventArgs e)
        {
            var fiszka = shuffledFiszki[currentIndex];
            var isForeignLanguage = toCheckForeignLanguage;
            bool counter=true;
            if (counter) { }
            var flipAnimation = new Animation(v => fiszkaFrame.RotationY = v, 0, 360);
            flipAnimation.Commit(this, "FlipFiszka", 16, 500, Easing.Linear, (v, c) =>
            {
                if (isForeignLanguage)
                {
                    fiszkaLabel.Text = fiszka.JezykRodzinny;
                    toCheckForeignLanguage = false;
                }
                else
                {
                    fiszkaLabel.Text = fiszka.JezykObcy;
                    toCheckForeignLanguage = true;
                }

                fiszkaFrame.IsEnabled = true;
                
            });
        }
    }


}