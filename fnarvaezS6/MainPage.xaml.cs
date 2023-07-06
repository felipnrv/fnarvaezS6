﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace fnarvaezS6
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.100.28/Moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<estudiante> _post;
        public MainPage()
        {
            InitializeComponent();
            Obtener();

        }
        public async void Obtener()
        {
            var content = await client.GetStringAsync(Url);
            List<estudiante> post = JsonConvert.DeserializeObject<List<estudiante>>(content);
            ListaEstudiantes.ItemsSource = post;
            _post = new ObservableCollection<estudiante>(post);

        }

        private void ListaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            


            var objeto = (estudiante)e.SelectedItem;
            var item = objeto.codigo.ToString();
            int codigo = Convert.ToInt32(item);
            var nombre = objeto.nombre.ToString();
            var apellido = objeto.apellido.ToString();
            var itemedad = objeto.edad.ToString();
            int edad = Convert.ToInt32(itemedad);
            Navigation.PushAsync(new Vista(codigo, nombre, apellido, edad));
        }

        private async void btnInsertar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Insertar());
        }
    }
}
