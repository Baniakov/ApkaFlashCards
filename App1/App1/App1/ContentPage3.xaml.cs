using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{


    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContentPage3 : ContentPage
    {
        private List<Fiszka> shuffledFiszki;
        private int currentIndex = 0;
        private int MaxFiszki = MainPage.DoPowtorki.Count;
        public bool toCheckForeignLanguage;

        public ContentPage3()
        {
            InitializeComponent();
            if (MainPage.DoPowtorki.Count < 20)
            {
                MaxFiszki = 20;
            }

            // Losowanie fiszek
            shuffledFiszki = MainPage.DoPowtorki.OrderBy(x => Guid.NewGuid()).Take(MaxFiszki).ToList();
            var isForeignLanguage = new Random().Next(2) == 0;
            toCheckForeignLanguage = isForeignLanguage;
            DisplayNextFiszka(toCheckForeignLanguage);
        }
        private void DisplayNextFiszka(bool isForeignLanguage)
        {
            if (currentIndex < shuffledFiszki.Count)
            {

                var fiszka = shuffledFiszki[currentIndex];
                // Pokazanie wylosowanej fiszki w odpowiednim języku
                fiszkaLabel.Text = isForeignLanguage ? fiszka.JezykObcy : fiszka.JezykRodzinny;
            }
            else
            {
                DisplayAlert("Gratulacje!", "Zakończyłeś naukę.", "OK");
            }
        }

        private void NextClicked(object sender, EventArgs e)
        {
            if (MainPage.DoPowtorki.Count > 0)
            {
                MainPage.DoPowtorki.RemoveAt(currentIndex);
                MainPage.DoPowtorki.Add(shuffledFiszki[currentIndex]);
                currentIndex++;
                var isForeignLanguage = new Random().Next(2) == 0;
                toCheckForeignLanguage = isForeignLanguage;
                DisplayNextFiszka(toCheckForeignLanguage);
            }
            else
            {
                DisplayAlert("Gratulacje!", "Zakończyłeś naukę.", "OK");
                b1.IsEnabled = false;
            }
        }

        private void fiszkaLabel_Clicked(object sender, EventArgs e)
        {
            var fiszka = shuffledFiszki[currentIndex];
            var isForeignLanguage = toCheckForeignLanguage;
            bool counter = true;
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