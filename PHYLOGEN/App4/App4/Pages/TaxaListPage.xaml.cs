using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace App4.Pages
{
     public partial class TaxaListPage : ContentPage
     {
          public TaxaListPage(string title)
          {
               Title = title;
               //InitializeComponent();

               ListView listView = new ListView
               {
                    ItemsSource = App.TaxaList,

                    ItemTemplate = new DataTemplate(() =>
                    {
                         Label taxonNameLbl = new Label();
                         taxonNameLbl.SetBinding(Label.TextProperty, "Name", BindingMode.TwoWay);

                         BoxView colorBox = new BoxView();
                         colorBox.WidthRequest = 60;
                         colorBox.SetBinding(BoxView.ColorProperty, "Color");

                         return new ViewCell
                         {
                              View = new StackLayout
                              {
                                   Padding = new Thickness(0, 5),
                                   HeightRequest = 90,
                                   Orientation = StackOrientation.Horizontal,
                                   Children =
                                   {
                                        colorBox,
                                        new StackLayout
                                        {
                                             HorizontalOptions = LayoutOptions.CenterAndExpand,
                                             VerticalOptions = LayoutOptions.CenterAndExpand,
                                             Spacing = 60,
                                             Children = { taxonNameLbl }
                                        }
                                   }
                              }
                         };
                    })
               };

               Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
               Content = new StackLayout
               {
                    Children =
                    {
                         listView
                    }
               };

          }

     }
}
