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
        Random r;
        bool inCorso = false;
        public MainWindow()
        {
            posti = new List<Posto>(12);
            r=new Random();
            prenotazioni = new Queue<string>();
            InitializeComponent();
            

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
                txtInCassa1.Text = "";
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
                txtInCassa2.Text = "";
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
            if (inCorso == false)
            {
                inCorso = true;
                for (int i = 0; i < 12; i++)
                {
                    lock (posti)
                    {
                        int daPrenotare = GeneraRandom();
                        foreach (Posto p in posti)
                        {
                            if (p.Numero == daPrenotare && p.Occupato == false)
                            {
                                p.Occupato = true;
                                GestisciImmagini(daPrenotare.ToString());
                            }
                        }
                        inCorso = false;
                    }
                }
            }
            else
            {               
                prenotazioni.Enqueue(GeneraRandom().ToString());
            }

            
        }
       /*public void Shish()
        {
            ();
        }*/
        
        public int GeneraRandom()
        {
            int daPrenotare = r.Next(0, 12);
            return daPrenotare;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Thread c1 = new Thread(new ThreadStart(Simula));
            Thread c2 = new Thread(new ThreadStart(Simula));
            c1.Start();
            c2.Start();
        }
    }
}
