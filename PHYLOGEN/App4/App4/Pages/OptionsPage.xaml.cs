using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App4.Classes;
using Xamarin.Forms;

namespace App4.Pages
{
     public partial class OptionsPage : ContentPage
     {
          private bool interleaveBool;

          public OptionsPage(string title)
          {
               Title = title;
               //DataTypePicker.IsEnabled = true;
               //dataTypePicker.Items.Add("RNA");
               //dataTypePicker.Items.Add("Protein");
               //dataTypePicker.Items.Add("Continous");
               InitializeComponent();
          }

          

          public Picker DataTypePicker
          {
               get { return dataTypePicker; }
               set { dataTypePicker = value; }
          }

          private void OptionsPage_OnAppearing(object sender, EventArgs e)
          {
               DataTypePicker.BindingContext = App.DataTypeList;
               //DataTypePicker.Items.Add("Continuous");
               //DataTypePicker.Items.Add("DNA");
               //DataTypePicker.Items.Add("RNA");
               //DataTypePicker.Items.Add("Protein");
          }

          private void Switch_OnToggled(object sender, ToggledEventArgs e)
          {
               interleaveBool = true;
          }
     }
}
