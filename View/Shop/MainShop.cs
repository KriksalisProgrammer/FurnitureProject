using FurnitureStore.Connections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FurnitureStore.View.Shop
{
    public partial class MainShop : Form
    {
        ToDataBase bs = new ToDataBase();
        public MainShop()
        {
            InitializeComponent();
        }

        private void MainShop_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
