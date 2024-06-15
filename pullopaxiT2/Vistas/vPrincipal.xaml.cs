namespace pullopaxiT2.Vistas;

public partial class vPrincipal : ContentPage
{
	public vPrincipal()
	{
		InitializeComponent();
	}

    private void btnCalcular_Clicked(object sender, EventArgs e)
    {
        if (pkEstudiantes.SelectedIndex >= 0)
        {
            string estudiante = pkEstudiantes.Items[pkEstudiantes.SelectedIndex];
            string fecha = dpFecha.Date.ToString("dd/mm/yyyy");
            double notaP1 = Convert.ToDouble(txtnotaP1.Text);
            double notaP2 = Convert.ToDouble(txtnotaP2.Text);
            double examen = Convert.ToDouble(txtnotaExamen.Text);
            double examen2 = Convert.ToDouble(txtnotaExamen2.Text);

            //Parcial 1
            double multip1 = notaP1 * 0.3;
            double multiExa = examen * 0.2;
            double resultadop1 = multip1 + multiExa;
            resultadop1 = Math.Round(resultadop1, 2);

            // Parcial 2
            double multip2 = notaP2 * 0.3;
            double multiExa2 = examen2 * 0.2;
            double resultadop2 = multip2 + multiExa2;
            resultadop2 = Math.Round(resultadop2, 2);
            double sumaTotal = resultadop1 + resultadop2;

            if (sumaTotal >= 7)
            {
                DisplayAlert($"Hola {estudiante}      {fecha}", $"Tus calificaciones son: \n Parcial 1: {resultadop1}\n Parcial 2: {resultadop2} \n Aprobaste con {sumaTotal} ", "OK");
            }
            else
            {
                DisplayAlert($"Hola {estudiante}      {fecha}", $"Tus calificaciones son: \n Parcial 1: {resultadop1}\n Parcial 2: {resultadop2} \n Reprobaste con {sumaTotal} ", "OK");


            }
        }
        else
        {
            DisplayAlert("Error", "Seleccione un estudiante", "Ok");
        }

    }

    private void txtnotaP1_TextChanged(object sender, TextChangedEventArgs e)
    {
        string nombre = "txtnotaP1";
        validacion(txtnotaP1.Text, nombre);
    }

    private void validacion(string valorCampo, string nombreCampo)
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(valorCampo))
            {
                double nota = Convert.ToDouble(valorCampo);
                if (nota > 10 || nota < 0)
                {
                    DisplayAlert("Valor incorrecto", "RANGO 0-10 ", "ok");

                    vaciarCampos(nombreCampo);

                }
            }
        }
        catch (Exception)
        {

        }
    }

    private void vaciarCampos(object nombreCampo)
    {
        switch (nombreCampo)
        {
            case "txtnotaP1":
                txtnotaP1.Text = "";
                txtnotaP1.Focus();
                break;

            case "txtnotaP2":
                txtnotaP2.Text = "";
                txtnotaP2.Focus();
                break;
            case "txtnotaExamen":
                txtnotaExamen.Text = "";
                txtnotaExamen.Focus();
                break;
            case "txtnotaExamen2":
                txtnotaExamen2.Text = "";
                txtnotaExamen2.Focus();
                break;
        }
    }

    private void txtnotaP2_TextChanged(object sender, TextChangedEventArgs e)
    {
        string nombre = "txtnotaP2";
        validacion(txtnotaP2.Text, nombre);
    }

    private void txtnotaExamen_TextChanged(object sender, TextChangedEventArgs e)
    {
        string nombre = "txtnotaExamen";
        validacion(txtnotaExamen.Text, nombre);
    }

    private void txtnotaExamen2_TextChanged(object sender, TextChangedEventArgs e)
    {
        string nombre = "txtnotaExamen2";
        validacion(txtnotaExamen2.Text, nombre);
    }
}

    