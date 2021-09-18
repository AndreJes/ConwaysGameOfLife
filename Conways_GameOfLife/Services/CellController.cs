using Conways_GameOfLife.Classes;
using Conways_GameOfLife.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Conways_GameOfLife.Services
{
    public class CellController
    {
        private static CellController _instance;

        public List<GameCell> GameCells { get; private set; }

        private CellController()
        {
            this.GameCells = new List<GameCell>();
        }

        public static CellController GetInstance()
        {
            if (_instance == null)
            {
                _instance = new();
            }

            return _instance;
        }

        public void AddCell(GameCell newCell)
        {
            this.GameCells.Add(newCell);
        }

        public void ApplyGameRules()
        {
            List<CellData> currentCellStates = new List<CellData>();

            foreach (var item in GameCells.Select(cell => cell.Data))
            {
                currentCellStates.Add(new CellData() { CellId = item.CellId, IsAlive = item.IsAlive });
            }

            foreach (var cell in GameCells)
            {
                var cellNeighbors = currentCellStates.FindAll(neighbor => cell.Data.NeighborsIds.Contains(neighbor.CellId));


                var liveNeighbors = cellNeighbors.FindAll(neighbor => neighbor.IsAlive);

                if (cell.Data.IsAlive)
                {
                    if (liveNeighbors.Count is not 2 and not 3)
                    {
                        cell.ChangeState();
                    }
                }
                else
                {
                    if (liveNeighbors.Count == 3)
                    {
                        //MessageBox.Show($" Sou {cell.Data.CellId} e esses são os meus vizinhos: " + string.Join("\n", cellNeighbors.Select(c => c.CellId)));

                        cell.ChangeState();
                    }
                }

            }
            
            currentCellStates.Clear();
            
            UpdateCellsColors();
        }

        public void UpdateCellsColors()
        {
            foreach (var cell in GameCells)
            {
                cell.UpdateColor();
            }
        }
    }
}
