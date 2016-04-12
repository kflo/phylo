using System;
using Phylogen.Classes;
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
          private Label[] _labelArray;

          private int _numTaxa;
          private Button[] _rowBtnArray;
          private StackLayout[] _rowStackArray;
          //private bool _taxaTxtChanged;
          private Entry[] _taxonArray;

          public AddTaxaPage(string title)
          {
               var scrollView = new ScrollView();
               var contentStack = new StackLayout
               {
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Start
               };
               _taxaStack = new StackLayout
               {
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

          private async void NumTaxa_OnCompleted(object sender, EventArgs e)
          {
               _noteLabel.TextColor = Color.Accent;
               _noteLabel.Text = "Note: If necessary, you can come back and edit this information.";
               string answer = null;
               var newNumTaxa = 0;
               try
               {
                    if (!string.IsNullOrWhiteSpace(_numEntry.Text))
                         newNumTaxa = Convert.ToInt32(_numEntry.Text);
               }
               catch (FormatException)
               {
                    await DisplayAlert("Number of Taxa", "Please enter a number between 2 and 99", "OK", "CANCEL");
               }

               if (newNumTaxa < _numTaxa)
               {
                    var action = await DisplayActionSheet("Any Taxa already entered will be deleted:" + _numTaxa + " --> " + newNumTaxa,
                                   "CANCEL", "DELETE");
                    answer = action;
                    if (action == "DELETE")
                    {
                         var difference = _taxaStack.Children.Count - newNumTaxa;
                         for (var i = 0; i < difference; i++)
                         {
                              RemoveStackChild(_taxaStack.Children.Count - 1);
                         }
                         _numTaxa = _taxaStack.Children.Count;
                    }
                    if (action == "CANCEL")
                         newNumTaxa = _numTaxa;
               }

               if (answer == null)
               {
                    _numTaxa = newNumTaxa;
                    //_taxaTxtChanged = false;
                    Populate();
               }
          }


          private void Populate()
          {
               _taxonArray = new Entry[_numTaxa];
               _labelArray = new Label[_numTaxa];
               _rowStackArray = new StackLayout[_numTaxa];
               _rowBtnArray = new Button[_numTaxa];
               for (var i = _taxaStack.Children.Count; i < _numTaxa; i++)
               {
                    _rowStackArray[i] = new StackLayout
                    {
                         Orientation = StackOrientation.Horizontal,
                         HorizontalOptions = LayoutOptions.FillAndExpand
                    };
                    _taxonArray[i] = new Entry { Placeholder = "Enter Taxon Name", HorizontalOptions = LayoutOptions.FillAndExpand };
                    _taxonArray[i].TextChanged += TaxonChanged;
                    _taxonArray[i].Keyboard = Keyboard.Text;
                    _taxonArray[i].BindingContext = new EntryRestrictions();
                    _taxonArray[i].SetBinding(Entry.TextProperty, "ProteinChars");
                    var labelNum = i + 1;
                    _labelArray[i] = new Label { Text = "Taxon" + labelNum };
                    _rowBtnArray[i] = new Button { Text = "Remove", BackgroundColor = Color.Red, IsEnabled = true };
                    _rowBtnArray[i].Clicked += OnTaxonRemoveClicked;
                    _rowStackArray[i].Children.Add(_labelArray[i]);
                    _rowStackArray[i].Children.Add(_taxonArray[i]);
                    _rowStackArray[i].Children.Add(_rowBtnArray[i]);
                    _taxaStack.Children.Add(_rowStackArray[i]);
               }
               _addTaxaBtn.IsVisible = true;
          }


          private void OnAddTaxa(object sender, EventArgs e)
          {//ADD THESE TAXA BUTTON
               _addTaxaBtn.IsEnabled = false;
               for (var i = 0; i < _taxaStack.Children.Count; i++)
               {
                    if (!string.IsNullOrWhiteSpace(_taxonArray[i].Text))
                    {
                         double hue = (.18*i)%1;
                         Random rand = new Random();
                         Color color = new Color(hue, rand.NextDouble()*i%1, .9);
                         App.TaxaList.Add(new Taxon(_taxonArray[i].Text, color));
                         //App.TaxaList2.Add(taxonArray[i].Text);
                    }
               }
               OnReady();
          }

          private void RemoveStackChild(int index)
          {
               if (App.TaxaList.Count > index) App.TaxaList.RemoveAt(0);
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