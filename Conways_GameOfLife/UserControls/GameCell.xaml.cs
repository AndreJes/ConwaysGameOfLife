using Conways_GameOfLife.Classes;
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
    /// Interação lógica para GameCell.xam
    /// </summary>
    public partial class GameCell : UserControl
    {
        private SolidColorBrush BLACK_COLOR_BRUSH = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        private SolidColorBrush WHITE_COLOR_BRUSH = new SolidColorBrush(Color.FromRgb(255, 255, 255));

        public CellData Data { get; set; }

        public GameCell(int coordinateX, int coordinateY)
        {
            InitializeComponent();
            Data = new();
            
            Data.IsAlive = false;
            Data.CellId = "x: " + coordinateX.ToString() + "y: " + coordinateY.ToString();

            string upperNeighbor = "x: " + coordinateX.ToString() + "y: " + (coordinateY - 1).ToString();
            string lowerNeighbor = "x: " + coordinateX.ToString() + "y: " + (coordinateY + 1).ToString();

            string leftNeighbor = "x: " + (coordinateX - 1).ToString() + "y: " + coordinateY.ToString();
            string rightNeighbor = "x: " + (coordinateX + 1).ToString() + "y: " + coordinateY.ToString();

            string upperLeftNeighbor = "x: " + (coordinateX - 1).ToString() + "y: " + (coordinateY - 1).ToString();
            string upperRightNeighbor = "x: " + (coordinateX + 1).ToString() + "y: " + (coordinateY - 1).ToString();

            string lowerLeftNeighbor = "x: " + (coordinateX - 1).ToString() + "y: " + (coordinateY + 1).ToString();
            string lowerRightNeighbor = "x: " + (coordinateX + 1).ToString() + "y: " + (coordinateY + 1).ToString();


            Data.NeighborsIds = new List<string>()
            {
                upperNeighbor,
                lowerNeighbor,
                leftNeighbor,
                rightNeighbor,
                upperLeftNeighbor,
                upperRightNeighbor,
                lowerLeftNeighbor,
                lowerRightNeighbor
            };

            UpdateColor();
        }

        public void ChangeState()
        {
            Data.IsAlive = !Data.IsAlive;
        }

        public void UpdateColor()
        {
            if (Data.IsAlive)
            {
                this.CellGrid.Background = BLACK_COLOR_BRUSH;
                this.CellBorder.BorderBrush = WHITE_COLOR_BRUSH;
            }
            else
            {
                this.CellGrid.Background = WHITE_COLOR_BRUSH;
                this.CellBorder.BorderBrush = BLACK_COLOR_BRUSH;
            }
        }

        private void CellGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ChangeState();
            UpdateColor();
        }
    }
}
