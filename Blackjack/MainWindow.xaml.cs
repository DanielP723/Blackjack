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
        int apuesta;
        int saldo;
        public MainWindow(int saldo,int apuesta)
        {
            this.saldo = 1000;
            this.apuesta = 0;
        }
        

        /* private Check()
        {
            for (int i = 0; i < deck.Count; i++)
            {
                suma=suma + deck[i]
                if suma > 21;
                {
                    Print ("voló")
                }
            }
        }*/
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void btnPedir_Click(object sender, RoutedEventArgs e)
        {
            //deal player
           

        }

        private void btnPlantar_Click(object sender, RoutedEventArgs e)
        {
            //deal dealer hasta 21 o superar al player
            //Después del check preguntar por otra partida
        }

        private void btnAumentar_Click(object sender, RoutedEventArgs e)
        {
            apuesta += 100;
            saldo = 1000 - apuesta;
            lblApuesta.Content = apuesta;
            lblSaldo.Content = 1000 - apuesta;
        }

        private void btnDisminuir_Click(object sender, RoutedEventArgs e)
        {
            apuesta -= 100;
            saldo = 1000 + apuesta;
            lblApuesta.Content = apuesta;
            lblSaldo.Content = 1000 - apuesta;
        }
    }
}
