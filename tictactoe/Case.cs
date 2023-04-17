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


        private void reset()
        {
            foreach (Button button in gridInstance.Children.OfType<Button>())
            {
                button.Content = "";
            }
            grille = new string[3, 3] { { "", "", "" }, { "", "", "" }, { "", "", "" } };

        }

        public bool verifier()
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

            //MessageBox.Show(CompteurColumn.ToString() + CompteurDiag.ToString() + CompteurAntiDiag.ToString());
            if (CompteurColumn == 3 || CompteurRow == 3 || CompteurDiag == 3 || CompteurAntiDiag == 3)
            {
                MessageBox.Show(player + " a gagné ");
                reset();
                return true;
            }
            return false;
        }
    }
}
