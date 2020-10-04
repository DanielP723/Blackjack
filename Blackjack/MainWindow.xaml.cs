using API;
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

namespace Blackjack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        Dealer d;
        Player p;
        int apuesta = 0;
        int saldo = 1000;
        int suma = 0;
        int volo = 0;
        int tallador = 0;
        int jugador = 0;
        int j = 0;
        int v = 0;
        int der = 0;
        public void Check(List<Card> c)
        {
            suma = 0;
            foreach (Card car in c)
            {
                suma += car.Score;
            }
            foreach (Card carta in c)
            {
                if (carta.Symbol == "A" && suma > 21)
                {
                    suma -= 10;
                }
            }
            if (suma > 21)
            {
                volo = 1;
            }
            else
            {
                volo = 0;
            }
        }
        public MainWindow(int saldo,int apuesta)
        {
            this.saldo = 1000;
            this.apuesta = 0;
            
        }
        public MainWindow()
        {
            InitializeComponent();
            lblApuesta.Content = 0;
            lblSaldo.Content = 1000;
        }
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            suma = 0;
            tallador = 0;
            jugador = 0;
            volo = 0;
            btnPedir.Visibility = Visibility.Visible;
            btnPlantar.Visibility = Visibility.Visible;
            btnAumentar.Visibility = Visibility.Hidden;
            btnDisminuir.Visibility = Visibility.Hidden;
            p = new Player();
            d = new Dealer();
            d.Generate();
            d.Randomize();
            p.InitP(d.Deal(), d.Deal());
            d.Init();
            foreach (Card car in p.Hand)
            {
                txtPlayer.Text += car.Symbol + car.Suit + " ";
                suma += car.Score;
            }
            txtDealer.Text = d.Hand[0].Symbol + d.Hand[0].Suit + " ?";
            if (suma == 21)
            {
                lblResultados.Content = "Blackjack";
                v += 1;
                j += 1;
                btnRestart.Visibility = Visibility.Visible;
                btnPedir.Visibility = Visibility.Hidden;
                btnPlantar.Visibility = Visibility.Hidden;
                lblDerrotas.Content = der;
                lblVictorias.Content = v;
                lblJugadas.Content = j;
                saldo += apuesta + apuesta;
                apuesta = 0;
                lblSaldo.Content = saldo;
                lblApuesta.Content = apuesta;
            }
            btnStart.Visibility = Visibility.Hidden;
        }
        private void btnPedir_Click(object sender, RoutedEventArgs e)
        {
            Card c = d.Deal();
            p.AddCardP(c);
            suma = 0;
            Check(p.Hand);
            txtPlayer.Text += c.Symbol + c.Suit + " ";
            if (volo == 1)
            {
                lblResultados.Content = "Derrota";
                j += 1;
                der += 1;
                btnRestart.Visibility = Visibility.Visible;
                btnPedir.Visibility = Visibility.Hidden;
                btnPlantar.Visibility = Visibility.Hidden;
                lblDerrotas.Content = der;
                lblVictorias.Content = v;
                lblJugadas.Content = j;
                apuesta = 0;
                lblSaldo.Content = saldo;
                lblApuesta.Content = apuesta;
                if (saldo == 0)
                {
                    btnRestart.Visibility = Visibility.Hidden;
                    MessageBox.Show("Sin saldo");
                    Application.Current.Shutdown();
                }
            }
            MessageBox.Show("Lleva: " + suma);
        }

        private void btnPlantar_Click(object sender, RoutedEventArgs e)
        {
            txtDealer.Text = d.Hand[0].Symbol + d.Hand[0].Suit + " " + d.Hand[1].Symbol + d.Hand[1].Suit;
            Check(p.Hand);
            jugador = suma;
            Check(d.Hand);
            tallador = suma;

            while (tallador < jugador && tallador < 21)
            {
                Card nc = d.Deal();
                d.AddCard(nc);
                Check(d.Hand);
                tallador = suma;
                txtDealer.Text +=" " + nc.Symbol + nc.Suit ;
            }
            MessageBox.Show("Jugador:" + jugador + "\n Tallador:" + tallador);
            if (tallador == 21 || (tallador > jugador && tallador < 21) || tallador == jugador)
            {
                lblResultados.Content = "Derrota";
                j += 1;
                der += 1;
                btnRestart.Visibility = Visibility.Visible;
                btnPedir.Visibility = Visibility.Hidden;
                btnPlantar.Visibility = Visibility.Hidden;
                lblDerrotas.Content = der;
                lblVictorias.Content = v;
                lblJugadas.Content = j;
                apuesta = 0;
                lblSaldo.Content = saldo;
                lblApuesta.Content = apuesta;
                if (saldo == 0)
                {
                    btnRestart.Visibility = Visibility.Hidden;
                    MessageBox.Show("Sin saldo");
                    Application.Current.Shutdown();
                }
            }
            else
            {
                if (tallador > 21)
                {
                    lblResultados.Content = "Victoria";
                    j += 1;
                    v += 1;
                    btnRestart.Visibility = Visibility.Visible;
                    btnPedir.Visibility = Visibility.Hidden;
                    btnPlantar.Visibility = Visibility.Hidden;
                    lblDerrotas.Content = der;
                    lblVictorias.Content = v;
                    lblJugadas.Content = j;
                    saldo += apuesta + apuesta;
                    apuesta = 0;
                    lblSaldo.Content = saldo;
                    lblApuesta.Content = apuesta;
                }
            }
        }

        private void btnAumentar_Click(object sender, RoutedEventArgs e)
        {
            apuesta += 100;
            saldo -= 100 ;
            lblApuesta.Content = apuesta;
            lblSaldo.Content = saldo;
            if (saldo < 0)
            {
                MessageBox.Show("No puede tener saldo en negativo");
                saldo += 100;
                apuesta -= 100;
                lblSaldo.Content = saldo;
                lblApuesta.Content = apuesta;
            }
        }

        private void btnDisminuir_Click(object sender, RoutedEventArgs e)
        {
            apuesta -= 100;
            saldo += 100;
            lblApuesta.Content = apuesta;
            lblSaldo.Content = saldo;
            if (apuesta < 0)
            {
                MessageBox.Show("No puede apostar en negativo");
                apuesta += 100;
                saldo -= 100;
                lblApuesta.Content = apuesta;
                lblSaldo.Content = saldo;
            }
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            lblResultados.Content = " ";
            txtDealer.Text = " ";
            txtPlayer.Text = " ";
            btnStart.Visibility = Visibility.Visible;
            btnRestart.Visibility = Visibility.Hidden;
            btnAumentar.Visibility = Visibility.Visible;
            btnDisminuir.Visibility = Visibility.Visible;
        }
    }
}