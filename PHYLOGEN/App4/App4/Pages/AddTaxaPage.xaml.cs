using System;
using System.Linq;
using Phylogen.Classes;
using Phylogen.Classes.Data;
using Phylogen.Classes.Options;
using Xamarin.Forms;

namespace Phylogen.Pages
{
     public partial class AddTaxaPage : ContentPage
     {
          private readonly Button _addTaxaBtn = new Button { Text = "Add These Taxa", IsEnabled = false };
          private readonly Label _noteLabel;
          private readonly Entry _numEntry;
          private readonly StackLayout _taxaStack;

          private int _numTaxa;
          private StackLayout[] _taxonStackArray;
          private Label[] _taxonLabelArray;
          private Entry[] _taxonEntryArray;
          private Button[] _removeBtnArray;
          //private bool _taxaTxtChanged;

          public AddTaxaPage(string title) {    
               var scrollView = new ScrollView();
               var contentStack = new StackLayout {
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Start
               };
               _taxaStack = new StackLayout {
                    Orientation = StackOrientation.Vertical,
                    HorizontalOptions = LayoutOptions.FillAndExpand
               };

               var numLabel = new Label { Text = "Enter Number of Taxa:" };
               _numEntry = new Entry { WidthRequest = 50 };
               _numEntry.Completed += NumTaxa_OnCompleted;
               _numEntry.Keyboard = Keyboard.Numeric;
               _numEntry.BindingContext = new EntryRestrictions();
               _numEntry.SetBinding(Entry.TextProperty, "Num1To99");
               contentStack.Children.Add(numLabel);
               contentStack.Children.Add(_numEntry);
               _noteLabel = new Label { Text = "These are the organisms you will be comparing." };
               contentStack.Children.Add(_noteLabel);
               contentStack.Children.Add(_taxaStack);
               _addTaxaBtn.Clicked += OnAddTaxa;
               _addTaxaBtn.BackgroundColor = Color.Accent;
               _addTaxaBtn.IsEnabled = false;
               _addTaxaBtn.IsVisible = false;
               contentStack.Children.Add(_addTaxaBtn);

               scrollView.Content = contentStack;
               Content = scrollView;
               Title = title;
          }

          private async void NumTaxa_OnCompleted(object sender, EventArgs e) {
               _noteLabel.TextColor = Color.Accent;
               _noteLabel.Text = "Note: If necessary, you can come back and edit this information.";
               string answer = null;
               var newNumTaxa = 0;

               try {
                    if (!string.IsNullOrWhiteSpace(_numEntry.Text))
                         newNumTaxa = Convert.ToInt32(_numEntry.Text);
               } catch (FormatException){
                    await DisplayAlert("Number of Taxa", "Please enter a number between 2 and 99", "OK", "CANCEL");
               }

               if (newNumTaxa < _numTaxa) {
                    var action = await DisplayActionSheet("Any Taxa already entered will be deleted:" + _numTaxa + " --> " + newNumTaxa,
                                   "CANCEL", "DELETE");
                    answer = action;
                    if (action == "DELETE") {
                         var difference = _taxaStack.Children.Count - newNumTaxa;
                         for (var i = 0; i < difference; i++)
                              RemoveStackChild(_taxaStack.Children.Count - 1);
                         _numTaxa = _taxaStack.Children.Count;
                    }
                    if (action == "CANCEL")
                         newNumTaxa = _numTaxa;
               }
               if (answer == null) {
                    _numTaxa = newNumTaxa;
                    Populate();
                    //_taxaTxtChanged = false;
               }
          }
          
          private void Populate() {
               _taxonEntryArray = new Entry[_numTaxa];
               _taxonLabelArray = new Label[_numTaxa];
               _taxonStackArray = new StackLayout[_numTaxa];
               _removeBtnArray = new Button[_numTaxa];
               for (var i = _taxaStack.Children.Count; i < _numTaxa; i++) {
                    _taxonStackArray[i] = new StackLayout {
                         Orientation = StackOrientation.Horizontal,
                         HorizontalOptions = LayoutOptions.FillAndExpand
                    };
                    _taxonEntryArray[i] = new Entry { Placeholder = "Enter Taxon Name", HorizontalOptions = LayoutOptions.FillAndExpand };
                    _taxonEntryArray[i].TextChanged += TaxonChanged;
                    _taxonEntryArray[i].Keyboard = Keyboard.Text;
                    _taxonEntryArray[i].SetBinding(Entry.TextProperty, "AlphaChars");
                    _taxonEntryArray[i].BindingContext = new EntryRestrictions();
                    var labelNum = i + 1;
                    _taxonLabelArray[i] = new Label { Text = "Taxon" + labelNum };
                    _removeBtnArray[i] = new Button { Text = "Remove", BackgroundColor = Color.Red, IsEnabled = true };
                    _removeBtnArray[i].Clicked += OnTaxonRemoveClicked;
                    _taxonStackArray[i].Children.Add(_taxonLabelArray[i]);
                    _taxonStackArray[i].Children.Add(_taxonEntryArray[i]);
                    _taxonStackArray[i].Children.Add(_removeBtnArray[i]);
                    _taxaStack.Children.Add(_taxonStackArray[i]);
               }
               _addTaxaBtn.IsVisible = true;
          }


          private void OnAddTaxa(object sender, EventArgs e) {//'ADD THESE TAXA' BUTTON
               _addTaxaBtn.IsEnabled = false;
               Random rand = new Random();
               for (var i = 0; i < _taxaStack.Children.Count; i++) {
                    if (_taxonEntryArray[i] == null)
                         continue;
                    if (!Application.TaxaList.Any(j => j.Name == _taxonEntryArray[i].Text) && !string.IsNullOrWhiteSpace(_taxonEntryArray[i].Text)) {
                         double hue = (.18*i)%1;
                         var hexColor = String.Format("#{0:X6}", rand.Next(0x1000000)); // = "#A197B9"
                         Color color = Color.FromHex(hexColor);
                         Application.TaxaList.Add(new Taxon(_taxonEntryArray[i].Text, color));
                         //App.TaxaList2.Add(taxonArray[i].Text);
                    }
               }
               OnReady();
          }

          private void RemoveStackChild(int index) {
               if (Application.TaxaList.Count > index) Application.TaxaList.RemoveAt(0);
               _taxaStack.Children.RemoveAt(index);
               _numTaxa = _taxaStack.Children.Count;
          }

          // # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # #
          //             EVENTS
          // # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # #

          public event EventHandler Ready;

          private void TaxonChanged(object sender, TextChangedEventArgs e) //checks if Taxa text was changed
          {
               var entrySent = (Entry)sender;
               if (entrySent.Text.Length > 0)
               {
                    //_taxaTxtChanged = true;            //OBSOLETE?
                    _addTaxaBtn.IsEnabled = true;
               }
          }

          private void OnTaxonRemoveClicked(object sender, EventArgs eventArgs)
          {
               Button btn = (Button)sender;
               var btnIndex = _taxaStack.Children.IndexOf((View)btn.Parent);
               RemoveStackChild(btnIndex);
          }


          private void OnReady() => Ready?.Invoke(this, EventArgs.Empty);
     }
}