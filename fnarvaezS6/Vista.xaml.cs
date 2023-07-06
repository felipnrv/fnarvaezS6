using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace fnarvaezS6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Vista : ContentPage
    {
        public Vista(int id, string nombre, string apellido, int edad)
        {
            InitializeComponent();
            txtCodigo.Text = id.ToString();
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtEdad.Text = edad.ToString();
        }
        

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();

            try
            {
                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);
                cliente.UploadValues("http://192.168.100.28/Moviles/post.php" + "?codigo=" + txtCodigo.Text+ "&nombre=" + txtNombre.Text + "&apellido=" + txtApellido.Text + "&edad=" + txtEdad.Text, "PUT", parametros);
                await Navigation.PushAsync(new MainPage());

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error " + ex.Message, "Cerrar");
            }
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            try
            {
                parametros.Add("codigo",txtCodigo.Text);
                cliente.UploadValues("http://192.168.100.28/Moviles/post.php"+"?codigo="+txtCodigo.Text, "DELETE", parametros);
                await Navigation.PushAsync(new MainPage());

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error "+ex.Message, "Cerrar");
            }
        }
    }
}