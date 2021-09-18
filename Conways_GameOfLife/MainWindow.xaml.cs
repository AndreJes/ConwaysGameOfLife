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

namespace Conways_GameOfLife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly int DEFAULT_HEIGHT = 50;
        private readonly int DEFAULT_WIDTH = 70;

        public MainWindow()
        {
            InitializeComponent();
            InitializeDefaultGrid();
        }

        public void InitializeDefaultGrid()
        {
            GameGrid.SetGridSize(DEFAULT_HEIGHT, DEFAULT_WIDTH);
        }
    }
}
