using System;
using System.Linq;
using Xamarin.Forms;

namespace App4.Pages
{
     public partial class TabbedCreatePage : TabbedPage
     {
          public TabbedCreatePage()
          {
               InitializeComponent();
               Title = "CREATE NEXUS FILE";
               Children.Add(new AddTaxaPage("Add Taxa"));
               Children.Add(new OptionsPage("Options"));
               Children.Add(new TaxaListPage("Taxa List"));
               Children.Add(new DataPage("Data"));

               Children[1].IsEnabled = false;
               Children[1].BackgroundColor = Color.Accent;
               Children[2].IsEnabled = false;
               Children[3].IsEnabled = false;

               var previousPage = Children[0];



               CurrentPageChanged += (sender, e) =>
               {
                    if (!CurrentPage.IsEnabled)
                         CurrentPage = previousPage;
                    else
                         previousPage = CurrentPage;
               };

               
          }
     }
}
