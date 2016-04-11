namespace App4.Logic
{
     public interface ISaveAndLoad
     {

          void SaveText(string filename, string text);
          string LoadText(string filename);

     }
}