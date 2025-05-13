using jmailaS5.Models;
using jmailaS5.Repositories;

namespace jmailaS5.Views;

public partial class vHome : ContentPage
{
	public vHome()
	{
		InitializeComponent();
	}

    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        var name = txtNombre.Text;
        App.personRepo.AddNewPerson(name);
        statusMassage.Text = App.personRepo.statusMasagge;
        txtNombre.Text = string.Empty;
    }

    private void btnListar_Clicked(object sender, EventArgs e)
    {
        var personas = App.personRepo.GetAllPerson();
        listPersonas.ItemsSource = personas;

        if (personas.Count > 0)
            txtId.IsEnabled = true;

        statusMassage.Text = App.personRepo.statusMasagge;
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        statusMassage.Text = "";
        if (int.TryParse(txtId.Text, out int id))
        {
            App.personRepo.UpdatePerson(id, txtNombre.Text);
            statusMassage.Text = App.personRepo.statusMasagge;
        }
        else
        {
            statusMassage.Text = "ID inválido.";
        }
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        statusMassage.Text = "";
        if (int.TryParse(txtId.Text, out int id))
        {
            App.personRepo.DeletePerson(id);
            statusMassage.Text = App.personRepo.statusMasagge;
        }
        else
        {
            statusMassage.Text = "ID inválido.";
        }
    }

    private void listPersonas_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (listPersonas.SelectedItem is Persona seleccionada)
        {
            txtId.Text = seleccionada.Id.ToString();
            txtNombre.Text = seleccionada.Name;
        }
    }
}