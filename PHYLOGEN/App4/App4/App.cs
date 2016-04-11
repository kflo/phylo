using App4.Pages;

namespace App4
{
     using Xamarin.Forms;
     using System.Collections.Generic;
     using System.Linq;
     using App4.Classes;

     public class App : Application
     {
          public static List<Color> ColorList { get; set; }
          public static List<Taxon> TaxaList { get; set; }
          public static List<string> TaxaList2 { get; set; }
          public static List<string> DataTypeList { get; set; }
          public App()
          {
               // The root page of your application
               TaxaList = new List<Taxon>();
               TaxaList2 = new List<string>();
               ColorList = new List<Color>();
               DataTypeList = new List<string> { "DNA", "RNA", "Protein", "Nucleotide", "Continuous", "Standard" };
               MainPage = new NavigationPage(new StartPage());
               //NavigationPage.SetHasNavigationBar(MainPage,false);
          }

          protected override void OnStart()
          {
               // Handle when your app starts
          }

          protected override void OnSleep()
          {
               // Handle when your app sleeps
          }

          protected override void OnResume()
          {
               // Handle when your app resumes
          }
     }
}
