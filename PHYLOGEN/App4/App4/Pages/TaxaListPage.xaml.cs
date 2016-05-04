using System;
using Xamarin.Forms;

namespace Phylogen.Pages
{
     public partial class TaxaListPage : ContentPage
     {
          public TaxaListPage(string title)
          {
               Title = title;
               //InitializeComponent();
               ToolbarItem editItem = new ToolbarItem { Text = "EDIT" };
               ToolbarItems.Add(editItem);
               editItem.Clicked += EditItem_Clicked;

               ListView listView = new ListView
               {
                    ItemsSource = Application.TaxaList,
                    ItemTemplate = new DataTemplate(() =>
                    {
                         
                         Label taxonNameLbl = new Label();
                         taxonNameLbl.SetBinding(Label.TextProperty, "Name");
                         taxonNameLbl.HorizontalTextAlignment = TextAlignment.Start;

                         Editor taxonEditor = new Editor();
                         taxonEditor.SetBinding(Editor.TextProperty, "Data", BindingMode.TwoWay);
                         taxonEditor.Keyboard = Keyboard.Text;
                         taxonEditor.Focused += TaxonEditor_Focused;
                         taxonEditor.Completed += TaxonEditor_Completed;
                         taxonEditor.HorizontalOptions = LayoutOptions.FillAndExpand;
                         taxonEditor.VerticalOptions = LayoutOptions.FillAndExpand;
                         taxonEditor.HeightRequest = 75;
                         //taxonEditor.WidthRequest = ;

                         BoxView colorBox = new BoxView();
                         colorBox.WidthRequest = 10;
                         colorBox.HeightRequest = 75;
                         //colorBox.VerticalOptions = LayoutOptions.FillAndExpand;
                         colorBox.SetBinding(BoxView.ColorProperty, "Color");

                         return new ViewCell
                         {
                              View = new StackLayout
                              {
                                   Padding = new Thickness(0, 5),
                                   Spacing = 5,
                                   //HeightRequest = 300,
                                   IsClippedToBounds = true,
                                   Orientation = StackOrientation.Horizontal,
                                   VerticalOptions = LayoutOptions.FillAndExpand,
                                   Children = {
                                        colorBox,
                                        new StackLayout {
                                             Orientation = StackOrientation.Vertical,
                                             //HeightRequest = 200,
                                             HorizontalOptions = LayoutOptions.FillAndExpand,
                                             VerticalOptions = LayoutOptions.FillAndExpand,
                                             Spacing = 5,
                                             
                                             Children = { taxonNameLbl, taxonEditor }
                                        }
                                   }
                              }
                         };
                    })
               };
               //listView.VerticalOptions = LayoutOptions.FillAndExpand;
               listView.HasUnevenRows = true;
               listView.IsPullToRefreshEnabled = true;
               listView.Refreshing += ListView_Refreshing;
               Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
               Content = new StackLayout { Children = { listView } };

          }

          private void ListView_Refreshing(object sender, EventArgs e)
          {
               UpdateChildrenLayout();
               ListView lv = (ListView)sender;
               lv.EndRefresh();
          }

          private void TaxonEditor_Completed(object sender, EventArgs e)
          {
               var thisEditor = sender as Editor;
               //ViewCell viewCell = (ViewCell)thisEditor.Parent.Parent.Parent;
               thisEditor.BackgroundColor = Color.Default;
               UpdateChildrenLayout();
               //if (thisEditor.HeightRequest > 100) {
               //     thisEditor.HeightRequest -= 100;
               //     viewCell.ForceUpdateSize();
               //}
          }

          private void TaxonEditor_Focused(object sender, FocusEventArgs e)
          {
               var thisEditor = sender as Editor;
               ViewCell viewCell = (ViewCell)thisEditor.Parent.Parent.Parent;
               if (thisEditor.IsFocused) {
                    thisEditor.BackgroundColor = Color.Accent;
                    viewCell.ForceUpdateSize();
               }
               //if (thisEditor.HeightRequest < 90) {
               //     thisEditor.HeightRequest += 100;
               //     viewCell.ForceUpdateSize();
               //}
          }

          private void EditItem_Clicked(object sender, EventArgs e)
          {
               this.Navigation.PushAsync(new DataPage("Data"));
          }

     }
}
