using SalonInfrumusetare.Models;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections;

namespace SalonInfrumusetare;

public partial class ServiciuPage : ContentPage
{ 
   
    ListaServiciu ls;

    public ServiciuPage(ListaServiciu slist)
    {
        InitializeComponent();
        ls = slist;
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var serviciu = (Serviciu)BindingContext;
        await App.Database.SaveServiciuAsync(serviciu);
        ListView.ItemsSource = await App.Database.GetServiciuAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var serviciu = (Serviciu)BindingContext;
        await App.Database.DeleteServiciuAsync(serviciu);
        ListView.ItemsSource = await App.Database.GetServiciuAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        ListView.ItemsSource = await App.Database.GetServiciuAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Serviciu s;
        if (ListView.SelectedItem != null)
        {
            s = ListView.SelectedItem as Serviciu;
            var Ls = new ListaServiciu()
            {
              
                TipServiciuID = s.ID
            };
            await App.Database.SaveListaServiciuAsync(Ls);
            s.ListaServiciu = new List<ListaServiciu> { Ls };
            await Navigation.PopAsync();
        }


    }
}