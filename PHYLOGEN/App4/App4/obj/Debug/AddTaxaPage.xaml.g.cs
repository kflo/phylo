//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App4.Pages {
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    
    
    public partial class AddTaxaPage : ContentPage {
        
        private Entry NumTaxa;
        
        private void InitializeComponent() {
            this.LoadFromXaml(typeof(AddTaxaPage));
            NumTaxa = this.FindByName<Entry>("NumTaxa");
        }
    }
}
