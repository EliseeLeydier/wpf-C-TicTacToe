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
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace tictactoe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void case_Click(object sender, RoutedEventArgs e)
        {
            string TurnIcon = "X";
            string TurnIconInverse = "O";
            if (turn.Text == "X")
            {
                TurnIcon = "O";
                TurnIconInverse = "X";
            }

            Button bt = sender as Button;

            if (bt.Content == "")
            {
                Case caseBtn = new Case(bt, TurnIconInverse, MaGrille);
                caseBtn.Jouer();
                turn.Text = TurnIcon;
                caseBtn.verifier();
            }
        }

        /*private string AfficherGrille()
        {
            string str = "";
            for(int i = 0;i < 3; i++)
            {
                str += grille[i,0];
                str += grille[i,1];
                str += grille[i,2];
                str += "\n";
            }
            return str;
        }*/

    }
}
