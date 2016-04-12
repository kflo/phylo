using System;
using Phylogen.Classes.@enum;
using Phylogen.Classes.Options;
using Xamarin.Forms;

namespace Phylogen.Pages
{
     public partial class TabbedCreatePage : TabbedPage
     {
          Options _options = Options.GetOptions();

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
                         _options.NumberOfCharacters = Convert.ToInt32(e.PropertyName);
                         OptionsPage optPage2 = (OptionsPage)Children[1];
                         optPage2.Tracer2 = e.PropertyName;
                         break;
                    case "DataType":
                         _options.DataType = (SequenceTypeEnum)Convert.ToInt32(e.PropertyName);
                         break;
                    case "GapChar":
                         _options.GapCharacter = Convert.ToChar(e.PropertyName);
                         break;
                    case "MissChar":
                         _options.MissingCharacter = Convert.ToChar(e.PropertyName);
                         break;
                    case "InterleaveBool":
                         _options.InterleaveMatrix = Convert.ToBoolean(e.PropertyName);
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
