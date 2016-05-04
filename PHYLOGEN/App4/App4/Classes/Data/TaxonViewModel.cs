using System.ComponentModel;
using Phylogen.Classes.@enum;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Phylogen.Annotations;

namespace Phylogen.Classes.Data
{

    public class TaxonViewModel : INotifyPropertyChanged
          {
               //private int _numEntries;
               public Taxon Taxon { get; set; }
               public string Alias { get; set; }
               public string Name { get; set; }
               public char[] Data { get; set; }
               public SequenceTypeEnum DataType { get; set; }
               public Color Color { get; set; }

               public TaxonViewModel(string name, Color color)
               {
               Taxon = new Taxon(name, color);
                    //Name = name;
                    //Color = color;
               }

               public void TaxonDataInitialize(BindableProperty dataString){
                    Taxon.BoundDataProperty = dataString;
                    //_numEntries = numEntries;
               }

               //public bool NumEntriesMatch() => _numEntries == Data.Length;
               public event PropertyChangedEventHandler PropertyChanged;

               [NotifyPropertyChangedInvocator]
               protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
               {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
               }
          }
     }
