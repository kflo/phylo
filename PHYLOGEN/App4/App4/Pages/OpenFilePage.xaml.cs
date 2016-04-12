using System;
using Xamarin.Forms;

namespace Phylogen.Pages
{
     public partial class OpenFilePage : ContentPage
     {
          public OpenFilePage()
          {
               InitializeComponent();
               Title = "  OPEN Existing File";
          }


          private void FileOpenBtn_OnClicked(object sender, EventArgs e)
          {
               if (true)
               {
                    Navigation.PopAsync();
                    Navigation.PushAsync(new TabbedCreatePage());
               }
          }

          private void FileBrowseBtn_OnClicked(object sender, EventArgs e)
          {
               FilenameEntryBox.Text = "NexusFile100.nex";
               //FileBrowseBtn.BackgroundColor = Color.Gray;
               FileOpenBtn.IsEnabled = true;
               FileOpenBtn.BackgroundColor = Color.Accent;
          }
     }
}
