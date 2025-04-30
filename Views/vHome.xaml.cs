using jmailaS5.Models;

namespace jmailaS5.Views;

public partial class vHome : ContentPage
{
	public vHome()
	{
		InitializeComponent();
	}

    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        statusMassage.Text = " ";
        App.personRepo.AddNewPerson(txtNombre.Text);

        statusMassage.Text = App.personRepo.statusMasagge;
    }

    private void btnListar_Clicked(object sender, EventArgs e)
    {
        statusMassage.Text = " ";
        List<Persona> lista = App.personRepo.GetAllPerson();
        listPersonas.ItemsSource=lista;
    }
}