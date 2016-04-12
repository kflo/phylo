using System;
using Xamarin.Forms;

namespace Phylogen.Pages
{
     public partial class DataPage : ContentPage
     {
          //private StackLayout taxaDataStack;
          //private Button outputBtn;
          //private StackLayout[] stackArray;
          //private ScrollView scrollView;
          //private Label[] labelArray;
          //private Entry[] entryArray;
          //private Entry numEntry;
          //private Label numLabel;
          //private readonly Label _tempLabel;

          public DataPage(string title)
          {
               //outputBtn = new Button();
               //scrollView = new ScrollView();
               //taxaDataStack = new StackLayout
               //{
               //     VerticalOptions = LayoutOptions.StartAndExpand,
               //     HorizontalOptions = LayoutOptions.FillAndExpand
               //};
               //stackArray = new StackLayout[App.TaxaList2.Count];
               //entryArray = new Entry[App.TaxaList2.Count];
               //labelArray = new Label[App.TaxaList2.Count];
               //for (int i=0; i < App.TaxaList2.Count; i++)
               //{
               //     labelArray[i] = new Label { Text = "Taxon"+i};
               //     entryArray[i] = new Entry();
               //     stackArray[i].Children.Add(labelArray[i]);
               //     stackArray[i].Children.Add(entryArray[i]);
               //     taxaDataStack.Children.Add(stackArray[i]);
               //}
               //outputBtn.Text = "OUTPUT FILE";
               //outputBtn.Clicked += onClick;
               //taxaDataStack.Children.Add(outputBtn);
               //scrollView.Content = taxaDataStack;
               //Content = scrollView;
               Title = title;
          }

          private void onClick(object sender, EventArgs e)
          {
               ;
          }

          
     }
}