using System;
using Phylogen.Classes.@enum;
using Phylogen.Classes.Options;
using Xamarin.Forms;

namespace Phylogen.Pages
{
     public partial class OptionsPage : ContentPage
     {
          public int NumOfChar { get; set; } = 0;
          public SequenceTypeEnum DataType { get; set; } = SequenceTypeEnum.Dna;
          public char GapChar { get; set; } = Char.MinValue;
          public char MissChar { get; set; } = Char.MinValue;
          public bool InterleaveBool { get; set; } = false;

          public OptionsPage(string title)
          {
               Title = title;
               //DataTypePicker.IsEnabled = true;
               //dataTypePicker.Items.Add("RNA");
               //dataTypePicker.Items.Add("Protein");
               //dataTypePicker.Items.Add("Continous");
               InitializeComponent();
               PostInitialize();
          }

          private void PostInitialize()
          {
               DataTypePicker.BindingContext = App.DataTypeList;
               NumCharsEntry.Keyboard = Keyboard.Numeric;
               NumCharsEntry.SetBinding(Entry.TextProperty, "Num1To9999");
               NumCharsEntry.BindingContext = new EntryRestrictions();
               //Tracer.SetBinding(Entry.TextProperty, "Num1To9999");
          }

          public string Tracer2
          {
               get { return Tracer.Text; }
               set { Tracer.Text = value; }
          }


          private void OptionsPage_OnAppearing(object sender, EventArgs e)
          {
               DataTypePicker.BindingContext = App.DataTypeList;

          }

          private void Switch_OnToggled(object sender, ToggledEventArgs e)
          {
               InterleaveBool = InterleaveSwitch.IsToggled;
          }
     }
}
