using System;
using System.Linq;
using App4.Classes.@enum;
using App4.Classes.Options;
using Xamarin.Forms;

namespace App4.Pages
{
     public partial class TabbedCreatePage : TabbedPage
     {
          Options _options = Options.Instance;

          public TabbedCreatePage()
          {
               InitializeComponent();
               Title = "CREATE NEXUS FILE";
               Children.Add(new AddTaxaPage("Add Taxa"));
               AddTaxaPage addPage = (AddTaxaPage)Children[0];
               Children.Add(new OptionsPage("Options"));
               OptionsPage optPage = (OptionsPage)Children[1];
               Children.Add(new TaxaListPage("Taxa List"));
               Children.Add(new DataPage("Data"));

               Children[1].IsEnabled = true;
               Children[2].IsEnabled = false;
               Children[3].IsEnabled = true;

               addPage.Ready += TaxaEntered;
               optPage.PropertyChanged += OptPage_PropertyChanged;

               var previousPage = Children[0];
               CurrentPageChanged += (sender, e) =>
                    {
                         if (!CurrentPage.IsEnabled)
                              CurrentPage = previousPage;
                         else
                              previousPage = CurrentPage;
                    };
          }


          private void OptPage_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
          {
               switch (e.PropertyName)
               {
                    case "NumOfChar":
                         Options.NumberOfCharacters = Convert.ToInt32(e.PropertyName);
                         OptionsPage optPage2 = (OptionsPage)Children[1];
                         optPage2.Tracer2 = e.PropertyName;
                         break;
                    case "DataType":
                         Options.DataType = (SequenceTypeEnum)Convert.ToInt32(e.PropertyName);
                         break;
                    case "GapChar":
                         Options.GapCharacter = Convert.ToChar(e.PropertyName);
                         break;
                    case "MissChar":
                         Options.MissingCharacter = Convert.ToChar(e.PropertyName);
                         break;
                    case "InterleaveBool":
                         Options.InterleaveMatrix = Convert.ToBoolean(e.PropertyName);
                         break;
               }
          }

          private void TaxaEntered(object sender, EventArgs e)
          {
               Children[1].IsEnabled = true;
               CurrentPage = Children[1];
               Children[2].IsEnabled = true;
          }

     }
}
