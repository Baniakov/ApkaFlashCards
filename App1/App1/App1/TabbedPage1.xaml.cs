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
    public partial class TabbedPage1 : TabbedPage
    {
        public TabbedPage1()
        {
            var page1 = new NavigationPage(new Page1())
            {
                Title = "Słowa Do Nauki",
            };

            var page2 = new NavigationPage(new Page2())
            {
                Title = "Słowa Poznane",
            };

            Children.Add(page1);
            Children.Add(page2);
        }
    }
}