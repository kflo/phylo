using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace App4.Classes.Options
{
     public class EntryRestrictions : INotifyPropertyChanged
     {



          private string _num1To99;
          public string Num1To99
          {
               get { return _num1To99; }
               set
               {
                    if (value.Length < 3 && !value.Contains(".") && !value.Equals("00"))
                         _num1To99 = value;
                    OnPropertyChanged();
               }
          }

          private string _dnaChars;
          public string DnaChars
          {
               get { return _dnaChars; }
               set
               {
                    if (value.Length > 0)
                    {
                         if (value.EndsWith("A") || value.EndsWith("C") || value.EndsWith("G") || value.EndsWith("T"))
                              _dnaChars = value;
                         if (value.EndsWith("a") || value.EndsWith("c") || value.EndsWith("g") || value.EndsWith("t"))
                              _dnaChars = value.ToUpper();
                    }
                    else
                         _dnaChars = value;
                    OnPropertyChanged();
               }
          }


          private string _rnaChars;
          public string RnaChars
          {
               get { return _rnaChars; }
               set
               {
                    if (value.Length > 0)
                    {
                         if (value.EndsWith("A") || value.EndsWith("C") || value.EndsWith("G") || value.EndsWith("U"))
                              _rnaChars = value;
                         if (value.EndsWith("a") || value.EndsWith("c") || value.EndsWith("g") || value.EndsWith("u"))
                              _rnaChars = value.ToUpper();
                    }
                    else
                         _rnaChars = value;
                    OnPropertyChanged();
               }
          }

          private string _proteinChars;
          public string ProteinChars
          {
               get { return _proteinChars; }
               set
               {
                    if (value.Length > 0)
                    {
                         if (value[value.Length - 1] < 65 || (value[value.Length - 1] > 90 && value[value.Length - 1] < 97) || value[value.Length - 1] > 122 || value.EndsWith("H") || value.EndsWith("J") || value.EndsWith("O") || value.EndsWith("U") || value.EndsWith("h") || value.EndsWith("j") || value.EndsWith("o") || value.EndsWith("u"))
                              _proteinChars = value.Remove(value.Length-1);
                         else
                              _proteinChars = value.ToUpper();
                    }
                    else
                         _proteinChars = value;
                    OnPropertyChanged();
               }
          }


          public event PropertyChangedEventHandler PropertyChanged;

          protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
          {
               PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
          }
     }
}