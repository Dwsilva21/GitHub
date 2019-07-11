using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace Consumindo_WebAPI_Livros
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpClient client = new HttpClient();

        public MainWindow()
        {
            InitializeComponent();
 
            client.BaseAddress = new Uri("http://localhost:53095");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            this.Loaded += MainWindow_Loaded;
        }

        async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("/api/livros");
                response.EnsureSuccessStatusCode(); // Lança um código de erro
                var livros = await response.Content.ReadAsAsync<IEnumerable<Livro>>();
                livrosListView.ItemsSource = livros;
            }
            catch
            {
                //throw;
            }
        }

        private async void btnGetLivro_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("/api/livros/" + txtID.Text);
                response.EnsureSuccessStatusCode(); //lança um código de erro
                var livros = await response.Content.ReadAsAsync<Livro>();
                livroDetalhesPanel.Visibility = Visibility.Visible;
                livroDetalhesPanel.DataContext = livros;
            }
            catch (Exception)
            {
                MessageBox.Show("Livro não localizado");
            }
        }

        private async void btnNovoLivro_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var livro = new Livro()
                {
                    nome = txtNomeLivro.Text,
                    id = int.Parse(txtIDLivro.Text),
                    autor = txtAutorLivro.Text,
                    preco = int.Parse(txtPreco.Text)
                };
                var response = await client.PostAsJsonAsync("/api/livros/", livro);
                response.EnsureSuccessStatusCode(); //lança um código de erro
                MessageBox.Show("Livro incluído com sucesso", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
                livrosListView.ItemsSource = await GetAllLivros();
                livrosListView.ScrollIntoView(livrosListView.ItemContainerGenerator.Items[livrosListView.Items.Count - 1]);
            }
            catch (Exception)
            {
                MessageBox.Show("O Livro não foi incluído. (Verifique se o ID não esta duplicado)");
            }
        }

        private async void btnAtualiza_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var livro = new Livro()
                {
                    nome = txtNomeLivro.Text,
                    id = int.Parse(txtIDLivro.Text),
                    autor = txtAutorLivro.Text,
                    preco = int.Parse(txtPreco.Text)
                };
                var response = await client.PutAsJsonAsync("/api/livros/", livro);
                response.EnsureSuccessStatusCode(); //lança um código de erro
                MessageBox.Show("Livro atualizado com sucesso", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
                livrosListView.ItemsSource = await GetAllLivros();
                livrosListView.ScrollIntoView(livrosListView.ItemContainerGenerator.Items[livrosListView.Items.Count - 1]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnDeletaLivro_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("/api/livros/" + txtID.Text);
                response.EnsureSuccessStatusCode(); //lança um código de erro
                MessageBox.Show("Livro deletado com sucesso");
                livrosListView.ItemsSource = await GetAllLivros();
                livrosListView.ScrollIntoView(livrosListView.ItemContainerGenerator.Items[livrosListView.Items.Count - 1]);
            }
            catch (Exception)
            {
                MessageBox.Show("Livro deletado com sucesso");
            }
        }

        private async Task<IEnumerable<Livro>> GetAllLivros()
        {
            HttpResponseMessage response = await client.GetAsync("/api/livros");
            response.EnsureSuccessStatusCode(); //lança um código de erro
            var livros = await response.Content.ReadAsAsync<IEnumerable<Livro>>();
            return livros;
        }

    }
}
