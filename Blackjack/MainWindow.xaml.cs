﻿using API;
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
        int apuesta;
        int saldo;
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

        private void btnPedir_Click(object sender, RoutedEventArgs e)
        {
            d = new Dealer();
            d.Generate();
            foreach (Card c in d.Deck)
            {
                txtCartas.Text += c.Symbol + c.Suit + "";
            }
        }

        private void btnPlantar_Click(object sender, RoutedEventArgs e)
        {
            p = new Player();
            d = new Dealer();
            d.Generate();
            foreach (Card card in d.Deck)
            {
                txtCartas.Text += card.Symbol + card.Suit + " ";
            }
            p.InitP(d.Deal(),d.Deal());
            txtPrueba.Text = " ";
            foreach (Card car in p.Hand)
            {
                txtPrueba.Text += car.Symbol + car.Suit + " ";
            }
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
