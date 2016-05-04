using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Phylogen.Classes;
using Phylogen.Classes.Data;
using Phylogen.Classes.@enum;
using Phylogen.Classes.Options;
using Xamarin.Forms;

namespace Phylogen.Pages
{
     internal class NexusPage : ContentPage
     {
          
          public NexusPage()
          {
               ScrollView scrollView = new ScrollView();
               StackLayout stackLayout = new StackLayout { Orientation = StackOrientation.Vertical, Padding = new Thickness(10, 10), HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
               NexusWriter nw = new NexusWriter(Application.TaxaList);
               stackLayout.Children.Add(nw.WriteToFile());
               scrollView.Content = stackLayout;
               Content = scrollView;
          }
     }

     internal class NexusWriter
     {
          private List<Taxon> _taxaListInst;
          private Options _opt;
          public NexusWriter(List<Taxon> n){
               _taxaListInst = n;
               _opt = Options.GetOptions();
          }

          public Label WriteToFile() {

               Label file = new Label();
               //StorageFile file = await DownloadsFolder.CreateFileAsync("output.nex");

               List<String> info = new List<String>();
               info.Add("#NEXUS");
               info.Add("BEGIN TAXA;");
               info.Add($"Dimensions NTax={_taxaListInst.Count}");
               info.Add("TaxLabels ");
               // TAXA NAMES
               for (int i = 0; i < _taxaListInst.Count; i++)
               {
                    if (i == _taxaListInst.Count - 1)
                         info.Add(_taxaListInst[i].Name);
                    else
                         info.Add(_taxaListInst[i].Name + " ");
               }
               info.Add(";");
               info.Add("\n");
               info.Add("END;");
               info.Add("BEGIN CHARACTERS;");
               info.Add($"DIMENSIONS NChar={_opt.NumberOfCharacters};");
               info.Add($"FORMAT DataType={Enum.GetName(typeof(SequenceTypeEnum), _opt.DataType)};");
               info.Add("MATRIX");
               // MATRIX DATA
               for (int i = 0; i < _taxaListInst.Count; i++)
               {
                    if (i == _taxaListInst.Count - 1)
                         info.Add($"{_taxaListInst[i].Name} {_taxaListInst[i].Data};");
                    else
                         info.Add($"{_taxaListInst[i].Name} {_taxaListInst[i].Data}");
               }
               info.Add("END;");

               string outString = "";
               foreach (var line in info)
               {
                    outString += line + "\n";
               }
               file.Text = outString;
               return file;
               //await FileIO8.WriteLinesAsync(file, info);
          }
     }

     //public class NexusFile
     //{
     //     [XmlElement("TaxaBlock")]
     //     public TaxaBlock T { get; set; }
     //     [XmlElement("CharactersBlocks")]
     //     public CharactersBlock C { get; set; }
     //}
}