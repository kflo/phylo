using App4.Classes.@enum;

namespace App4.Classes.Data
{
     internal class SequenceData : IDataType
     {
          public string Sequence { get; set; }
          public SequenceTypeEnum Type { get; set; }

          public SequenceData(SequenceTypeEnum type, int numberOfCharacters)
          {
               Type = type;
               NumberOfCharacters = numberOfCharacters;
          }

          public SequenceData()
          {
          }

          public static int NumberOfCharacters { get; set; }

          public bool IsRightLength()
          {
               return (Sequence.Length == NumberOfCharacters);
          }
     }
}