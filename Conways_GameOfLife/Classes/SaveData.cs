using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conways_GameOfLife.Classes
{
    public class SaveData
    {
        public List<CellData> CellsData { get; set; }

        public int GridHeight { get; set; }
        public int GridWidth { get; set; }
    }
}
