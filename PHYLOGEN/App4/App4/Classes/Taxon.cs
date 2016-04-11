﻿using App4.Classes.@enum;

namespace App4.Classes
{
     using Xamarin.Forms;

     public class Taxon
     {
          private int _numEntries;
          public string Alias { get; set; }
          public string Name { get; set; }
          public char[] Data { get; set; }
          public SequenceTypeEnum DataType { get; set; }
          public Color Color { get; set; }

          public Taxon(string name)
          {
               Name = name;
               Color = Color.Accent;
          }

          public void TaxonDataInitialize(SequenceTypeEnum dataType, int numEntries)
          {
               DataType = dataType;
               Data = new char[numEntries];
               //_numEntries = numEntries;
          }

          //public bool NumEntriesMatch() => _numEntries == Data.Length;
     }
}