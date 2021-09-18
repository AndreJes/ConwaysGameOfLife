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
        public bool IsAlive { get; set; }
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }

        public GameCell()
        {
            InitializeComponent();
        }


    }
}
