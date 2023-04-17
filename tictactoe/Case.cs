using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace tictactoe
{
    class Case
    {
        private Button bt;
        private string player;
        private Grid gridInstance;
        private static string[,] grille = new string[3, 3] { { "", "", "" }, { "", "", "" }, { "", "", "" } };

        public Case(Button bt, string player, Grid gridInstance)
        {
            this.bt = bt;
            this.player = player;
            this.gridInstance = gridInstance;
        }

        public void Jouer()
        {
            if (bt.Content == "")
            {
                bt.Content = player;
                grille[Grid.GetRow(bt), Grid.GetColumn(bt)] = player;
            }
        }


        public void reset()
        {
            foreach (Button button in gridInstance.Children.OfType<Button>())
            {
                button.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.White);
                button.Content = "";
            }
            grille = new string[3, 3] { { "", "", "" }, { "", "", "" }, { "", "", "" } };

        }

        private void column()
        {
            foreach (Button button in gridInstance.Children.OfType<Button>())
            {
                if (Grid.GetColumn(button) == Grid.GetColumn(bt))
                {
                    button.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);

                }
            }
        }
        private void row()
        {
            foreach (Button button in gridInstance.Children.OfType<Button>())
            {
                if (Grid.GetRow(button) == Grid.GetRow(bt))
                {
                    button.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);

                }
            }
        }
        private void diag()
        {
            foreach (Button button in gridInstance.Children.OfType<Button>())
            {
                if (Grid.GetRow(button) == Grid.GetColumn(button))
                {
                    button.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);
                }
            }
        }
        private void antiDiag()
        {
            foreach (Button button in gridInstance.Children.OfType<Button>())
            {
                if (Grid.GetRow(button) + Grid.GetColumn(button) == 2)
                {
                    button.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);
                }
            }
        }

        public void verifier()
        {
            int row = Grid.GetRow(bt);
            int column = Grid.GetColumn(bt);
            int CompteurColumn = 0;
            int CompteurRow = 0;
            int CompteurDiag = 0;
            int CompteurAntiDiag = 0;

            int coordonneCol = 0;
            int coordonneRow = 0;
            for (int i = 0; i < 3; i++) // Ligne
            {
                coordonneRow = i;
                coordonneCol = (column + i) % 3;

                // Compter les cases alignées verticalement
                if (grille[coordonneRow, column] == player)
                {
                    CompteurColumn += 1;
                }
                // Compter les cases alignées horizontalement
                if (grille[row, coordonneCol] == player)
                {
                    CompteurRow += 1;
                }
                // Compter les cases alignées diagonalement
                if (grille[i, i] == player)
                {
                    CompteurDiag += 1;
                }
                // Compter les cases alignées anti-diagonalement
                if (grille[i, 2 - i] == player)
                {
                    CompteurAntiDiag += 1;
                }
            }
            if (CompteurColumn == 3)
            {
                this.column();
                MessageBox.Show(player + " a gagné ");
                reset();
            }
            else if (CompteurRow == 3)
            {
                this.row();
                MessageBox.Show(player + " a gagné ");
                reset();

            }
            else if (CompteurDiag == 3)
            {
                this.diag();
                MessageBox.Show(player + " a gagné ");
                reset();

            }
            else if (CompteurAntiDiag == 3)
            {
                this.antiDiag();
                MessageBox.Show(player + " a gagné ");
                reset();
            }
        }
    }
}
