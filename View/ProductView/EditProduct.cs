using FurnitureStore.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FurnitureStore.View.ProductView
{
    public partial class EditProduct : Form
    {
        public Furniture furniture { get; private set; }
        public EditProduct()
        {
            InitializeComponent();
        }
        public void Initialization(Furniture furniture)
        {
            textBoxName.Text = furniture.NameProduct;
            textBoxCount.Text =furniture.Count.ToString();
            textBoxCountry.Text = furniture.TheCountry;
            textBoxGab.Text = furniture.Dimensions.ToString();
            textBoxModel.Text = furniture.Model;
            textBoxNumber.Text = furniture.SerialNumber;
            
            pictureBox1.Image = furniture.ImageProduct;
        }
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            //furniture = new Furniture(textBoxName.Text, Convert.ToUInt32(textBoxCount.Text), textBoxNumber.Text, textBoxCountry.Text, textBoxModel.Text, Convert.ToInt32(textBoxGab.Text),
            //   pictureBox1.Image, Convert.ToDecimal(textBoxPricePurch.Text), Convert.ToDecimal(textBoxProcent.Text));
            DialogResult = DialogResult.Yes;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            if (openFile.ShowDialog(this) == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFile.FileName);
            }
        }
    }
}
