using Android.App;
using Android.Content.PM;
/*using Android.Runtime;
using Android.Views;
using Android.Widget;
*/
using Android.OS;
using Phylogen;

namespace App4.Droid
{
     [Activity(Label = "PHYLOGEN", Icon = "@drawable/icon", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)] 
     public class MainActivity : Xamarin.Forms.Platform.Android.FormsApplicationActivity
     {
          protected override void OnCreate(Bundle bundle)
          {
               base.OnCreate(bundle);

               Xamarin.Forms.Forms.Init(this, bundle);
               LoadApplication(new Phylogen.Application());
          }
     }
}

