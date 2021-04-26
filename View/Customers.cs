using FurnitureStore.View.Shop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FurnitureStore.Model
{
    public partial class Customers : Form
    {
        private int start = default;
        public Customers()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            start += 1;
            progressBar1.Value = start;
            if(progressBar1.Value==100)
            {
                progressBar1.Value = 0;
                timer1.Stop();
                MainShop shop = new MainShop();
                this.Hide();
                shop.Show();
            }
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
