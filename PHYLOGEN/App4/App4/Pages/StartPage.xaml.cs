using System;
using Xamarin.Forms;

namespace App4.Pages
{
     public partial class StartPage : ContentPage
     {
          public StartPage()
          {
               InitializeComponent();
          }

          private void OnOpenFile(object sender, EventArgs e)
          {
               Navigation.PushAsync(new OpenFilePage());
          }

          private void OnCreateFile(object sender, EventArgs e)
          {
               Navigation.PushAsync(new TabbedCreatePage());
          }
     }
}
