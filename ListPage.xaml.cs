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
        var slist = (Serviciu)BindingContext;
        await App.Database.SaveServiciuAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Serviciu)BindingContext;
        await App.Database.DeleteServiciuAsync(slist);
        await Navigation.PopAsync();
    }
}
