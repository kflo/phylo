using System.Collections.Generic;
using Phylogen.Classes;
using Phylogen.Classes.Data;
using Phylogen.Pages;
using Xamarin.Forms;

namespace Phylogen
{
     public class Application : Xamarin.Forms.Application
     {
          public static List<Color> ColorList { get; set; }
          public static List<Taxon> TaxaList { get; set; }
          public static List<string> TaxaList2 { get; set; }
          public static List<string> DataTypeList { get; set; }

          public Application()
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
