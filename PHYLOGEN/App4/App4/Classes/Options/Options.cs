using System;
using App4.Classes.@enum;

namespace App4.Classes.Options
{
     public sealed class Options
     {
          private static readonly Options instance = new Options();

          private Options() { }

          public static Options Instance { get { return instance;} }


          private static int _numberOfCharacters;
          public static int NumberOfCharacters
          {
               get { return _numberOfCharacters; }
               set { _numberOfCharacters = value; }
          }

          private static SequenceTypeEnum _dataType;
          public static SequenceTypeEnum DataType
          {
               get { return _dataType; }
               set { _dataType = value; }
          }

          private static char _gapCharacter;
          public static char GapCharacter
          {
               get { return _gapCharacter; }
               set { _gapCharacter = value; }
          }

          private static char _missingCharacter;
          public static char MissingCharacter
          {
               get { return _missingCharacter; }
               set { _missingCharacter = value; }
          }

          private static bool _interleaveMatrix;
          public static bool InterleaveMatrix
          {
               get { return _interleaveMatrix; }
               set { _interleaveMatrix = value; }
          }

     }
}