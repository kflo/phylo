﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Phylogen.Classes.Options
{
     public class EntryRestrictions : INotifyPropertyChanged
     {
          //===========================================================
          //        1 to 99
          //===========================================================
          private string _num1To99;
          public string Num1To99 {
               get { return _num1To99; }
               set {
                    if (value.Length < 3 && !value.Contains(".") && !value.Equals("00"))
                         _num1To99 = value;
                    OnPropertyChanged();
               }
          }
          //===========================================================
          //        1 to 9999
          //===========================================================
          private string _num1To9999;
          public string Num1To9999 {
               get { return _num1To9999; }
               set {
                    if (value.Length < 5 && !value.Contains(".") && !value.Equals("0000"))
                         _num1To9999 = value;
                    OnPropertyChanged();
               }
          }
          //===========================================================
          //        singleChar
          //===========================================================
          private List<int> GapIllegal = new List<int> {32,34,39,40,41,42,44,47,58,59,60,61,62,91,92,93,94,96,123,125}; // ( ) [ ] { } / \ , ; : = * ' " ` < > ^
          private string _singleChar;
          public string SingleChar {
               get { return _singleChar; }
               set
               {
                    if (value.Length > 0) {
                         if (!GapIllegal.Contains(value[value.Length - 1])) {
                              if (value.Length > 1)
                                   _singleChar = value.Remove(value.Length - 1);
                              else
                                   _singleChar = value;
                         }
                    }
                    else
                         _singleChar = value;
                    OnPropertyChanged();
               }
          }
          //===========================================================
          //        DNA
          //===========================================================
          private List<int> ACGT = new List<int> { 65, 67, 71, 84, 97, 99, 103, 116 }; //A C G T a c g t
          private string _dna;
          public string Dna {
               get { return _dna; }
               set {
                    if (value.Length > 0) {
                         if (ACGT.Contains(value[value.Length-1]))
                              _dna = value.ToUpper();
                    } else
                         _dna = value;
                    OnPropertyChanged();
               }
          }
          //===========================================================
          //        RNA
          //===========================================================
          private List<int> ACGU = new List<int> { 65, 67, 71, 85, 97, 99, 103, 117 }; //A C G U a c g u
          private string _rna;
          public string Rna {
               get { return _rna; }
               set {
                    if (value.Length > 0) {
                         if (ACGU.Contains(value[value.Length - 1]))
                              _rna = value.ToUpper();
                    } else
                         _rna = value;
                    OnPropertyChanged();
               }
          }

          //===========================================================
          //        Protein
          //===========================================================
          private List<int> Proteins = new List<int> { 72, 74, 79, 85, 104, 106, 111, 117 }; //NOT(!) H J O U h j o u
          private string _protein;
          public string Protein {
               get { return _protein; }
               set {
                    if (value.Length > 0) {
                         if (value[value.Length - 1] < 65 || (value[value.Length - 1] > 90 && value[value.Length - 1] < 97) || value[value.Length - 1] > 122 || Proteins.Contains(value[value.Length - 1]))
                              _protein = value.Remove(value.Length-1);
                         else
                              _protein = value.ToUpper();
                    } else
                         _protein = value;
                    OnPropertyChanged();
               }
          }

          //===========================================================
          //        Nucleotide
          //===========================================================
          private List<int> nucs = new List<int> { 65, 67, 71, 84, 85, 97, 99, 103, 116, 117 }; //A C G T U a c g t u
          private string _nucleotide;
          public string Nucleotide
          {
               get { return _nucleotide; }
               set
               {
                    if (value.Length > 0)
                    {
                         if (nucs.Contains(value[value.Length - 1]))
                              _nucleotide = value.ToUpper();
                    }
                    else
                         _nucleotide = value;
                    OnPropertyChanged();
               }
          }


          //===========================================================
          //        ALPHA
          //===========================================================
          private string _alphaChars;
          public string AlphaChars
          {
               get { return _alphaChars; }
               set
               {
                    if (value.Length > 0)
                    {
                         if (value[value.Length - 1] < 65 || (value[value.Length - 1] > 90 && value[value.Length - 1] < 97) || value[value.Length - 1] > 122)
                              _alphaChars = value.Remove(value.Length - 1);
                         else
                              _alphaChars = value.ToUpper();
                    }
                    else
                         _alphaChars = value;
                    OnPropertyChanged();
               }
          }

          //===========================================================
          //        EVENTS
          //===========================================================
          public event PropertyChangedEventHandler PropertyChanged;
          protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
     }
}