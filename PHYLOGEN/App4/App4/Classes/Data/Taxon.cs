using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Phylogen.Annotations;
using Phylogen.Classes.@enum;
using Phylogen.Classes.Options;
using Xamarin.Forms;
using static Phylogen.Classes.@enum.SequenceTypeEnum;

namespace Phylogen.Classes.Data
{
     public class Taxon : BindableObject
     {
          public static BindableProperty BoundNameProperty = BindableProperty.Create("Name", typeof(string), typeof(Taxon), default(string));
          public static BindableProperty BoundDataProperty = BindableProperty.Create("Data", typeof(string), typeof(Taxon), default(string));
          public static BindableProperty BoundNumEntriesProperty = BindableProperty.Create("NumEntries", typeof(int), typeof(Taxon), default(int));

          private Options.Options _opt;
          public Options.Options Opt { get { return _opt; } set { _opt = value; } }

          public string Alias { get; set; }
          public Color Color { get; set; }

          private List<int> ACGT = new List<int> { 65, 67, 71, 84, 97, 99, 103, 116 }; //A C G T a c g t
          private List<int> ACGU = new List<int> { 65, 67, 71, 85, 97, 99, 103, 117 }; //A C G U a c g u
          private List<int> Proteins = new List<int> { 72, 74, 79, 85, 104, 106, 111, 117 }; //NOT(!) H J O U h j o u
          private List<int> Nucleotides = new List<int> { 65, 67, 71, 84, 85, 97, 99, 103, 116, 117 }; //A C G T U a c g t u

          private bool Validate(string input) {
               if (input.Length > Opt.NumberOfCharacters) {
                    Application.Current.MainPage.Navigation.NavigationStack[Application.Current.MainPage.Navigation.NavigationStack.Count-1].DisplayAlert("VALIDATION",
                         $"Your entry would be longer than the character length you designated: \n\nOPTIONS > # of Characters: {Opt.NumberOfCharacters}", "OK");
                    return false;
               }
               char lastChar = input[input.Length - 1];

               switch (Opt.DataType) {
                    case Dna:
                         if (ACGT.Contains(lastChar) || lastChar.Equals(Opt.GapCharacter) || lastChar.Equals(Opt.MissingCharacter))
                              return true;
                         break;
                    case Rna:
                         if (ACGU.Contains(lastChar) || lastChar.Equals(Opt.GapCharacter) || lastChar.Equals(Opt.MissingCharacter))
                              return true;
                         break;
                    case Protein:
                         if (!Proteins.Contains(lastChar) && (lastChar.Equals(Opt.GapCharacter) || lastChar.Equals(Opt.MissingCharacter) || (lastChar >= 65 && lastChar <= 90) || (lastChar >= 97 && lastChar <= 122)))
                              return true;
                         break;

                    case Nucleotide:
                         if (Nucleotides.Contains(lastChar) || lastChar.Equals(Opt.GapCharacter) || lastChar.Equals(Opt.MissingCharacter))
                              return true;
                         break;
               }
               return false;
          }


          public string Name {
               get { return (string) GetValue(BoundNameProperty); }
               set { //RUNS VALUE INPUT THROUGH VALIDATION
                    if (value.Length > 0) {
                         char lastChar = value[value.Length - 1];
                         if ((lastChar >= 65 && lastChar <= 90) || (lastChar >= 97 && lastChar <= 122))
                              SetValue(BoundNameProperty, value.ToUpper());
                    }
                    else
                         SetValue(BoundNameProperty, value);
                    OnPropertyChanged();
               }
          }

          public string Data {
               get { return (string) GetValue(BoundDataProperty); }
               set {
                    if (value.Length > 0) {
                         if (Validate(value))
                              SetValue(BoundDataProperty, value.ToUpper());
                    }
                    else
                         SetValue(BoundDataProperty, value);
                    OnPropertyChanged();
               }
          }

          public int NumEntries {
               get { return (int) GetValue(BoundNumEntriesProperty); }
               set {
                    if (value.ToString().Length < 5 && value > 0)
                         SetValue(BoundNumEntriesProperty, value);
                    OnPropertyChanged();
               }
          }

          public Taxon() { }

          public Taxon(string name, Color color) {
               Name = name;
               Color = color;
               Opt = Options.Options.GetOptions();
          }

          public void TaxonDataInitialize(string data) {
               Data = data;
          }

     }
}