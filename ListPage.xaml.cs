using SalonInfrumusetare.Models;
namespace SalonInfrumusetare;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        
        var slist = (ListaServiciu)BindingContext;
        await App.Database.SaveListaServiciuAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (ListaServiciu)BindingContext;
        await App.Database.DeleteListaServiciuAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ServiciuPage((ListaServiciu)this.BindingContext)
        {
            BindingContext = new TipServiciu()
        });

    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        
        ListaServiciu s;
        


        if (listView.SelectedItem != null)
        {
            s = listView.SelectedItem as ListaServiciu;
            var ls = new ListaServiciu()
            {
                
                ServiciuID = s.ID
            };
            await App.Database.SaveListaServiciuAsync(ls);
           // s.ListaServiciu = new List<ListaServiciu> { ls };
            await Navigation.PopAsync();
        }
    }


    protected override async void OnAppearing()
    {
        base.OnAppearing();
       var shopl = (ListaServiciu)BindingContext;
        listView.ItemsSource = await App.Database.GetListaServiciuAsync(shopl.ID);


    }


}
