using FrameWorkTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FrameWorkTutorial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] estado = { "Soltero", "Casado", "Union Libre" };
        private Persona persona = new Persona();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = persona;
            EstadoCivilComboBox.ItemsSource = estado;

        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var Context = new PersonasDBContext();
            var registro = Context.Personas.Find(persona.Cedula);
            if (registro != null)
            {
                persona = registro;
                this.DataContext = persona;
            }
            Context.Dispose();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private async void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            var ListaRegistros = GetPersonas();
            
            if (await GuardarLista(ListaRegistros)){
                MessageBox.Show("Registro Guardados");
            }

            /*var Context = new PersonasDBContext();
            if (Context.Personas.Any(p => p.Cedula == persona.Cedula))
            {
                Context.Personas.Update(persona);
                if (Context.SaveChanges() > 0)
                    Limpiar();
            }
            else
            {
                Context.Personas.Add(persona);
                if (Context.SaveChanges() > 0)
                    Limpiar();
            }
            Context.Dispose();*/

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            var Context = new PersonasDBContext();
            Context.Personas.Remove(persona);
            Context.SaveChanges();
            Context.Dispose();
            Limpiar();
        }

        public void Limpiar()
        {
            persona = new Persona();
            this.DataContext = persona;
        }

        public List<Persona> GetPersonas()
        {

            var persona1 = new Persona()
            {
                Cedula = "2",
                Nombres = "Juan",
                Apellidos = "Ramirez",
                FechaNacimiento = DateTime.Now,
                EstadoCivil = "Casado"
            };

            var persona2 = new Persona()
            {
                Cedula = "3",
                Nombres = "Raul",
                Apellidos = "Perez",
                FechaNacimiento = DateTime.Now,
                EstadoCivil = "Casado"
            };

            var persona3 = new Persona()
            {
                Cedula = "4",
                Nombres = "Saul",
                Apellidos = "Allahu akbar",
                FechaNacimiento = DateTime.Now,
                EstadoCivil = "Casado"
            };

            var persona4 = new Persona()
            {
                Cedula = "5",
                Nombres = "Pablo",
                Apellidos = "Robles",
                FechaNacimiento = DateTime.Now,
                EstadoCivil = "Casado"
            };

            var persona5 = new Persona()
            {
                Cedula = "6",
                Nombres = "Pedro",
                Apellidos = "Suarez",
                FechaNacimiento = DateTime.Now,
                EstadoCivil = "Casado"
            };

            var persona6 = new Persona()
            {
                Cedula = "7",
                Nombres = "Jose",
                Apellidos = "Holmes",
                FechaNacimiento = DateTime.Now,
                EstadoCivil = "Casado"
            };

            var persona7 = new Persona()
            {
                Cedula = "8",
                Nombres = "Steve",
                Apellidos = "Escobar",
                FechaNacimiento = DateTime.Now,
                EstadoCivil = "Casado"
            };

            List<Persona> lista = new List<Persona>()
            {
                persona1,
                persona2,
                persona3,
                persona4,
                persona5,
                persona6,
                persona7
            };

            return lista;
        }

        public async Task<bool> GuardarLista(List<Persona> personas)
        {
            bool ok = false;
 
            var Context = new PersonasDBContext();
            foreach (var item in personas)
            {
                Context.Personas.UpdateRange(item);
                ok = await Context.SaveChangesAsync() > 0;         
            }
            await Context.DisposeAsync();
            return ok;
        }
    }
}
