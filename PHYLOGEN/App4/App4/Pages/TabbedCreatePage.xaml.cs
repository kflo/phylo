using System;
using System.Diagnostics;
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
               //InitializeComponent();
               Title = "CREATE NEXUS FILE";

               Children.Add(new AddTaxaPage("Add Taxa"));
               AddTaxaPage addPage = (AddTaxaPage)Children[0];
               addPage.Ready += TaxaEntered;

               Children.Add(new OptionsPage("Options"));
               OptionsPage optPage = (OptionsPage)Children[1];
               optPage.PropertyChanged += OptPage_PropertyChanged;

               Children.Add(new TaxaListPage("Taxa List"));
               TaxaListPage tListPage = (TaxaListPage) Children[2];

               Children.Add(new DataPage("Data"));

               if (Application.TaxaList.Count == 0)
               {
                    Children[1].IsEnabled = false;
                    Children[1].IsVisible = false;
                    Children[2].IsEnabled = false;
                    Children[2].IsVisible = false;
                    Children[3].IsEnabled = false;
                    Children[3].IsVisible = false;
               }

               // Start with only 1st page accessible
               var previousPage = Children[0];
               CurrentPageChanged += (sender, e) =>
                    {
                         if (!CurrentPage.IsEnabled)
                         {
                              CurrentPage = previousPage;
                              DisplayAlert("NOTE:", "This tab will be available once you have entered taxa in the 1st tab.", "OK");
                              // not refocusing tab...
                              Children[0].Focus();
                         }
                         else
                              previousPage = CurrentPage;
                    };
          }





          // COMMENT THIS OUT..!
          
          private void OptPage_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
          {
               OptionsPage optPage2 = (OptionsPage)Children[1];
               switch (e.PropertyName)
               {
                    case "NumOfChar":
                         _options.NumberOfCharacters = Convert.ToInt32(e.PropertyName);
                         optPage2.Tracer2 = e.ToString();
                         break;
                    case "DataType":
                         _options.DataType = (SequenceTypeEnum)Convert.ToInt32(e.PropertyName);
                         optPage2.Tracer2 = e.PropertyName;
                         break;
                    case "GapChar":
                         _options.GapCharacter = Convert.ToChar(e.PropertyName);
                         optPage2.Tracer2 = e.PropertyName;
                         break;
                    case "MissChar":
                         _options.MissingCharacter = Convert.ToChar(e.PropertyName);
                         optPage2.Tracer2 = e.PropertyName;
                         break;
                    case "InterleaveBool":
                         _options.InterleaveMatrix = Convert.ToBoolean(e.PropertyName);
                         optPage2.Tracer2 = e.PropertyName;
                         break;
               }
          }

          private void TaxaEntered(object sender, EventArgs e)
          {
               Children[1].IsEnabled = true;
               Children[1].IsVisible = true;
               Children[2].IsEnabled = true;
               Children[2].IsVisible = true;
               Children[3].IsEnabled = true;
               Children[3].IsVisible = true;
               CurrentPage = Children[1];
          }

     }
}
