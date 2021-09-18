using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conways_GameOfLife.Classes
{
    public class CellData
    {
        public string CellId { get; set; }

        public List<string> NeighborsIds { get; set; }

        public bool IsAlive { get; set; }
    }
}
