using System;
using Xamarin.Forms;

namespace App4.Pages
{
     public partial class OpenFilePage : ContentPage
     {
          public OpenFilePage()
          {
               InitializeComponent();
          }

          private void OnFileSelected(object sender, EventArgs e)
          {
               FileOpenBtn.BorderColor= Color.Aqua;
          }
     }
}
