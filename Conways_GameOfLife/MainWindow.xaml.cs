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
using System.Windows.Threading;

namespace Conways_GameOfLife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly int DEFAULT_HEIGHT = 30;
        private readonly int DEFAULT_WIDTH = 60;

        private CellController cellController = CellController.GetInstance();
        private DispatcherTimer dispatcherTimer;

        public MainWindow()
        {
            InitializeComponent();
            InitializeDefaultGrid();
            dispatcherTimer = new();
            
            dispatcherTimer.Tick += new EventHandler(UpdateGenerations_Tick);
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(50);
        }

        public void InitializeDefaultGrid()
        {
            GameGrid.SetGridSize(DEFAULT_HEIGHT, DEFAULT_WIDTH);
        }


        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Start();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            cellController.ApplyGameRules();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
            GameGrid.SetGridSize(DEFAULT_HEIGHT, DEFAULT_WIDTH);
        }

        private void UpdateGenerations_Tick(object sender, EventArgs e)
        {
            cellController.ApplyGameRules();
        }
    }
}
