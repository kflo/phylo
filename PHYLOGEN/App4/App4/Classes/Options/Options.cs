using System.ComponentModel;
using System.Runtime.CompilerServices;
using Phylogen.Classes.@enum;

namespace Phylogen.Classes.Options
{
     public sealed class Options : INotifyPropertyChanged
     {
          private static Options _instance;
          private Options() { }

          private static object _syncLock = new object();

          public static Options GetOptions () {
               if (_instance == null){
                    lock (_syncLock){
                         if (_instance == null)
                              _instance = new Options();
                    }
               }
               return _instance;
          }


          private int _numberOfCharacters;
          public int NumberOfCharacters
          {
               get { return _numberOfCharacters; }
               set { _numberOfCharacters = value; OnPropertyChanged(); }
          }

          private SequenceTypeEnum _dataType;
          public SequenceTypeEnum DataType
          {
               get { return _dataType; }
               set { _dataType = value; OnPropertyChanged(); }
          }

          private char _gapCharacter;
          public char GapCharacter
          {
               get { return _gapCharacter; }
               set { _gapCharacter = value; OnPropertyChanged(); }
          }

          private char _missingCharacter;
          public char MissingCharacter
          {
               get { return _missingCharacter; }
               set { _missingCharacter = value; OnPropertyChanged(); }
          }

          private bool _interleaveMatrix;
          public bool InterleaveMatrix
          {
               get { return _interleaveMatrix; }
               set { _interleaveMatrix = value; OnPropertyChanged(); }
          }

          public event PropertyChangedEventHandler PropertyChanged;
          private void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
     }
}