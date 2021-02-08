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
            if(registro != null)
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

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            var Context = new PersonasDBContext();
            if(Context.Personas.Any(p => p.Cedula == persona.Cedula))
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
            Context.Dispose();
            
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
    }
}
