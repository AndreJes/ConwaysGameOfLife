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

namespace Conways_GameOfLife.UserControls
{
    /// <summary>
    /// Interação lógica para GameGrid.xam
    /// </summary>
    public partial class GameGrid : UserControl
    {
        public GameGrid()
        {
            InitializeComponent();
        }

        public void SetGridSize(int new_height, int new_width)
        {
            MainGrid.RowDefinitions.Clear();
            MainGrid.ColumnDefinitions.Clear();

            for(int row = 0; row < new_height; row++)
            {
                MainGrid.RowDefinitions.Add(new RowDefinition() { Height= new GridLength(15)});
            }

            for (int column = 0; column < new_width; column++)
            {
                MainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(15) });
            }


        }
    }
}
