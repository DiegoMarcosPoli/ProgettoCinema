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
using System.Threading;

namespace PreanotazioneCinema
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Posto> posti;
        private Queue<string> prenotazioni;
        public MainWindow()
        {
            posti = new List<Posto>(12);
            InitializeComponent();
            Thread c1 = new ThreadStart();
        }

        private void btnCassa1_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                foreach (Posto p in posti)
                {
                    if (Convert.ToInt32(txtInCassa1.Text) == p.Numero && p.Occupato == false)
                    {
                        p.Occupato = true;
                        GestisciImmagini(txtInCassa1.Text);
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }          
            
        }

        private void btnCassa2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (Posto p in posti)
                {
                    if (Convert.ToInt32(txtInCassa2) == p.Numero && p.Occupato == false)
                    {
                        p.Occupato = true;
                        GestisciImmagini(txtInCassa1.Text);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void GestisciImmagini(string nPosto)
        {

        }
        public void Simula()
        {
            Random r;
            r = new Random();


            for (int i = 0; i < 12; i++)
            {
                
                int daPrenotare= r.Next(0, 13);
                foreach (Posto p in posti)
                {
                    if(p.Numero==daPrenotare && p.Occupato == false)
                    {
                        p.Occupato = true;
                    }
                }
            }

        }
    }
}
