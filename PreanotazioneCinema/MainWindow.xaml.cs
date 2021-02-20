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
        int ps = 0;
        private List<Image> images;
        private List<Image> occupa;
        private List<Posto> posti;
        private object x;
   
        Random r;
        Thread c1;
        Thread c2;
        bool inCorso=false ;
        public MainWindow()
        {
            InitializeComponent();
            images = new List<Image>();
            occupa = new List<Image>();
            occupa.Add(imgOccupato1); occupa.Add(imgOccupato2); occupa.Add(imgOccupato3); occupa.Add(imgOccupato4); occupa.Add(imgOccupato5); occupa.Add(imgOccupato6); occupa.Add(imgOccupato7); occupa.Add(imgOccupato8); occupa.Add(imgOccupato9); occupa.Add(imgOccupato10);
            images.Add(imgPosto1); images.Add(imgPosto2); images.Add(imgPosto3); images.Add(imgPosto4); images.Add(imgPosto5); images.Add(imgPosto6); images.Add(imgPosto7); images.Add(imgPosto8); images.Add(imgPosto9); images.Add(imgPosto10);
            posti = new List<Posto>(10);
            Posto p1 = new Posto(1, false);
            Posto p2 = new Posto(2, false);
            Posto p3 = new Posto(3, false);
            Posto p4 = new Posto(4, false);
            Posto p5 = new Posto(5, false);
            Posto p6 = new Posto(6, false);
            Posto p7 = new Posto(7, false);
            Posto p8 = new Posto(8, false);
            Posto p9 = new Posto(9, false);
            Posto p10 = new Posto(10, false);
            posti.Add(p1); posti.Add(p2); posti.Add(p3); posti.Add(p4); posti.Add(p5); posti.Add(p6); posti.Add(p7); posti.Add(p8); posti.Add(p9); posti.Add(p10);
            x = new object();

            r =new Random();
            
            
            

        }
        public void Cassa1()
        {
                      

            foreach (Posto p in posti)
            {
                if (ps == p.Numero && p.Occupato == false)
                {
                    p.Occupato = true;
                    GestisciImmagini(ps.ToString());
                    break;
                }
            }
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                txtInCassa1.Text = "";
            }));

        }
        public void Cassa2()
        {
            foreach (Posto p in posti)
            {
                if (ps == p.Numero && p.Occupato == false)
                {
                    p.Occupato = true;
                    GestisciImmagini(ps.ToString());
                    break;
                }
            }
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                txtInCassa2.Text = "";
            }));


        }
        private void btnCassa1_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                ps = int.Parse(txtInCassa1.Text);
                c1 = new Thread(new ThreadStart(Cassa1));
                c1.Start();
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
                ps = int.Parse(txtInCassa2.Text);
                c2 = new Thread(new ThreadStart(Cassa2));
                c2.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void GestisciImmagini(string nPosto)
        {
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                occupa[int.Parse(nPosto) - 1].Visibility = Visibility.Visible;
            }));/*
            foreach (Image img in images)
            {
                bool verifica =false;
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    verifica = img.Name.Contains(nPosto);
                }));
                if (verifica)
                {
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        occupa[int.Parse(nPosto) - 1].Visibility = Visibility.Visible;
                    }));
                    break;
                }
            }*/
        }
        public void Simula()
        {
            if (inCorso==false)
            {
                inCorso = true;
                for (int i = 0; i < 10; i++)
                {
                    int daPrenotare = GeneraRandom();
                    foreach (Posto p in posti)
                    {
                        if (p.Numero == daPrenotare && p.Occupato == false)
                        {
                            lock (x)
                            {
                                p.Occupato = true;
                                GestisciImmagini(daPrenotare.ToString());
                            }
                        }
                    }
                }
                inCorso = false;
            }
        }
       /*public void Shish()
        {
            ();
        }*/
        
        public int GeneraRandom()
        {
            int daPrenotare = r.Next(1, 11);
            return daPrenotare;
        }
        private void btnSimula_Click(object sender, RoutedEventArgs e)
        {
            c1 = new Thread(new ThreadStart(Simula));
            c2 = new Thread(new ThreadStart(Simula));
            c1.Start();
            c2.Start();
        }

        private void txtInCassa1_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnCassa1.IsEnabled = true;
        }

        private void txtInCassa2_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnCassa2.IsEnabled = true;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            foreach (Image m in occupa)
            {
                m.Visibility = Visibility.Hidden;
                
            }
            foreach(Posto p in posti)
            {
                p.Occupato = false;
            }
        }
    }
}
