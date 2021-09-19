using Conways_GameOfLife.Services;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Threading;
using System.Text.Json;
using System.Linq;
using System.IO;
using Conways_GameOfLife.Classes;
using System.Collections.Generic;
using Conways_GameOfLife.UserControls;

namespace Conways_GameOfLife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly int DEFAULT_HEIGHT = 20;
        private readonly int DEFAULT_WIDTH = 40;

        private CellController cellController = CellController.GetInstance();
        private DispatcherTimer dispatcherTimer;

        public MainWindow()
        {
            InitializeComponent();
            InitializeDefaultGrid();

            Height_TextBox.Text = DEFAULT_HEIGHT.ToString();
            Width_TextBox.Text = DEFAULT_WIDTH.ToString();

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
            StartButton.IsEnabled = false;
            StopButton.IsEnabled = true;
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
            StartButton.IsEnabled = true;
            StopButton.IsEnabled = false;
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            cellController.ApplyGameRules();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
            GameGrid.SetGridSize(int.Parse(Height_TextBox.Text), int.Parse(Width_TextBox.Text));
        }

        private void UpdateGenerations_Tick(object sender, EventArgs e)
        {
            cellController.ApplyGameRules();
        }

        private void ChangeSizeButton_Click(object sender, RoutedEventArgs e)
        {
            GameGrid.SetGridSize(int.Parse(Height_TextBox.Text), int.Parse(Width_TextBox.Text));
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new();

            saveFileDialog.Filter = "Json (.json)|*.json";
            saveFileDialog.DefaultExt = ".json";
            saveFileDialog.ShowDialog();
            if (!string.IsNullOrEmpty(saveFileDialog.FileName))
            {
                SaveData saveData = new SaveData()
                {
                    CellsData = cellController.GameCells.Select(cell => cell.Data).ToList(),
                    GridHeight = int.Parse(Height_TextBox.Text),
                    GridWidth = int.Parse(Width_TextBox.Text)
                };


                string jsonString = JsonSerializer.Serialize(saveData);
                File.WriteAllText(saveFileDialog.FileName, jsonString, System.Text.Encoding.UTF8);
            }
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new();

            openFileDialog.Filter = "Json (.json)|*.json";
            openFileDialog.DefaultExt = ".json";
            openFileDialog.ShowDialog();
            if (!string.IsNullOrEmpty(openFileDialog.FileName))
            {

                string jsonString = File.ReadAllText(openFileDialog.FileName);
                SaveData saveData = JsonSerializer.Deserialize<SaveData>(jsonString);

                Height_TextBox.Text = saveData.GridHeight.ToString();
                Width_TextBox.Text = saveData.GridWidth.ToString();

                GameGrid.SetGridSize(saveData.GridHeight, saveData.GridWidth);
                List<GameCell> gameCells = new();
                
                foreach (CellData cell in saveData.CellsData)
                {
                    gameCells.Add(new(cell.CoordinateX, cell.CoordinateY, cell.IsAlive));
                }

                GameGrid.UpdateGridCells(gameCells);
            }
        }
    }
}
