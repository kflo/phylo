using System;
using Phylogen.Classes.Data;
using Phylogen.Classes.@enum;
using Phylogen.Classes.Options;
using Xamarin.Forms;

namespace Phylogen.Pages
{
     public partial class OptionsPage : ContentPage
     {
          public int NumOfChar { get; set; } = 0;
          public SequenceTypeEnum DataTypeSelected { get; set; } = SequenceTypeEnum.Dna;
          public char GapChar { get; set; } = '-';
          public char MissChar { get; set; } = '?';
          public bool InterleaveBool { get; set; } = false;
          private Options Opt { get; set; }

          public OptionsPage(string title) {
               Title = title;
               Opt = Options.GetOptions();
               InitializeComponent();
               PostInitialize();
          }

          private void PostInitialize() {
               DataTypePicker.Items.Add("DNA");
               DataTypePicker.Items.Add("RNA");
               DataTypePicker.Items.Add("Protein");
               DataTypePicker.Items.Add("Nucleotide");
               InterleaveSwitch.WidthRequest = 100;
               Opt.MissingCharacter = MissChar;
               Opt.GapCharacter = GapChar;
               NumCharsEntry.Keyboard = Keyboard.Numeric;
               NumCharsEntry.SetBinding(Entry.TextProperty, "NumEntries");
               GapCharEntry.SetBinding(Entry.TextProperty, "SingleChar");
               MissCharEntry.SetBinding(Entry.TextProperty, "SingleChar");
               DataTypePicker.SetBinding(Picker.SelectedIndexProperty, "DataType", BindingMode.TwoWay);
               NumCharsEntry.BindingContext = new Taxon();
               GapCharEntry.BindingContext = new EntryRestrictions();
               MissCharEntry.BindingContext = new EntryRestrictions();
               BindingContext = Opt;
          }

          public string Tracer2 {
               get { return Tracer.Text; }
               set { Tracer.Text = value; }
          }

          private void Switch_OnToggled(object sender, ToggledEventArgs e) {
               InterleaveBool = InterleaveSwitch.IsToggled;
               Opt.InterleaveMatrix = InterleaveBool;
               Tracer2 = Opt.InterleaveMatrix.ToString();
          }

          private void DataTypePicker_OnSelectedIndexChanged(object sender, EventArgs e) {
               DataTypeSelected = (SequenceTypeEnum)DataTypePicker.SelectedIndex;
               Opt.DataType = DataTypeSelected;
               Tracer2 = Opt.DataType.ToString();
          }

          private void MissCharEntry_OnCompleted(object sender, EventArgs e) {
               if (MissCharEntry.Text != null) {
                    MissChar = Convert.ToChar(MissCharEntry.Text);
                    Opt.MissingCharacter = MissChar;
               }
               Tracer2 = Opt.MissingCharacter.ToString();
          }

          private void GapCharEntry_OnCompleted(object sender, EventArgs e) {
               if (GapCharEntry.Text != null){
                    GapChar = Convert.ToChar(GapCharEntry.Text);
                    Opt.GapCharacter = GapChar;
               }
               Tracer2 = Opt.GapCharacter.ToString();
          }

          private void NumCharsEntry_OnCompleted(object sender, EventArgs e) {
               if (NumCharsEntry.Text != null){
                    NumOfChar = Convert.ToInt32(NumCharsEntry.Text);
                    Opt.NumberOfCharacters = NumOfChar;
               }
               Tracer2 = Opt.NumberOfCharacters.ToString();
          }
     }
}
