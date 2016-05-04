using System;
using Phylogen.Classes.@enum;
using Phylogen.Classes.Options;
using Xamarin.Forms;

namespace Phylogen.Pages
{
     public partial class DataPage : ContentPage
     {
          private Options Opt { get; set; }

          public DataPage(string title) {
               
               Title = title;
               ToolbarItem doneItem = new ToolbarItem { Text = "DONE" };
               ToolbarItems.Add(doneItem);
               doneItem.Clicked += DoneItem_Clicked;
               Opt = Options.GetOptions();
               //InitializeComponent();



               ListView listView = new ListView {
                    ItemsSource = Application.TaxaList,
                    ItemTemplate = new DataTemplate(typeof(TextCell))
               };
               listView.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");
               listView.ItemTemplate.SetBinding(TextCell.TextColorProperty, "Color");
               listView.ItemTemplate.SetBinding(TextCell.DetailProperty, "Data");
               listView.HasUnevenRows = true;

               Button outNexusBtn = new Button {BackgroundColor = Color.Accent, HorizontalOptions = LayoutOptions.FillAndExpand, Text = "OUTPUT NEXUS FILE", FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button))};
               outNexusBtn.Clicked += OutNexusBtn_Clicked;

               Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
               Content = new StackLayout {Children = {listView, outNexusBtn}, Orientation = StackOrientation.Vertical, VerticalOptions = LayoutOptions.FillAndExpand, Spacing=10, HeightRequest = 50};

          }

          private void OutNexusBtn_Clicked(object sender, EventArgs e)
          {
               Navigation.PushAsync(new NexusPage());
          }

          private void DoneItem_Clicked(object sender, EventArgs e)
          {
               Navigation.PopAsync(true);
          }

          private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
          {
               ListView lv = (ListView) sender;
               if (e.SelectedItem == null)
               {
                    return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
               }
               DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
               //((ListView)sender).SelectedItem = null; //uncomment
          }
     }
}