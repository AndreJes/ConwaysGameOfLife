using Conways_GameOfLife.Services;
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

        private CellController CellController = CellController.GetInstance();

        public GameGrid()
        {
            InitializeComponent();
        }

        public void SetGridSize(int newHeight, int newWidth)
        {
            MainGrid.RowDefinitions.Clear();
            MainGrid.ColumnDefinitions.Clear();
            List<GameCell> updateList = new();
            for (int row = 0; row < newHeight; row++)
            {
                MainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(18) });

                for (int column = 0; column < newWidth; column++)
                {
                    if (row < 1)
                    {
                        MainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(18) });
                    }

                    GameCell cell = new(row, column, false);

                    cell.Data.CoordinateX = row;
                    cell.Data.CoordinateY = column;

                    updateList.Add(cell);
                }
            }

            UpdateGridCells(updateList);
            updateList.Clear();
        }

        public void UpdateGridCells(List<GameCell> gameCells)
        {
            MainGrid.Children.Clear();
            CellController.GameCells.Clear();

            foreach (var cell in gameCells)
            {
                Grid.SetRow(cell, cell.Data.CoordinateX);
                Grid.SetColumn(cell, cell.Data.CoordinateY);
                CellController.AddCell(cell);
                MainGrid.Children.Add(cell);
            }

        }
    }
}
