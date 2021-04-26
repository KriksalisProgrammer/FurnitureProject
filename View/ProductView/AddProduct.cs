using FurnitureStore.Connections;
using FurnitureStore.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FurnitureStore.View.ProductView
{
    public partial class AddProduct : Form
    {
        public Furniture furniture { get; private set; }
        private ToDataBase conBase = new ToDataBase();

        public AddProduct()
        {
            InitializeComponent();
            conBase.Connection();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            SaveProduct();
            this.Close();
        }

        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            AddPicture();
        }
        private void AddPicture()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            if (openFile.ShowDialog(this) == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFile.FileName);
            }
        }
        private void SaveProduct()
        {
            var mstream = new MemoryStream();
            pictureBox1.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Png);
            Byte[] arrImage = mstream.GetBuffer();
            try
            {
                conBase.cn.Open();
                conBase.cm = new MySql.Data.MySqlClient.MySqlCommand("insert into product(Id_Product,Fid_Category,Name,Model,SerialNumber,Count,Price,Coutry,Dimensions,Image)" +
                    "values(@id_Product,@Fid_Category,@Name,@Model,@SerialNumber,@Count,@Price,@Country,@Dimensions,@Image)", conBase.cn);
                conBase.cm.Parameters.AddWithValue("@id_Product", textBox1.Text);
                conBase.cm.Parameters.AddWithValue("@Fid_Category", comboBox1.Text);
                conBase.cm.Parameters.AddWithValue("@Name", textBoxName.Text);
                conBase.cm.Parameters.AddWithValue("@Model", textBoxModel.Text);
                conBase.cm.Parameters.AddWithValue("@SerialNumber", textBoxNumber.Text);
                conBase.cm.Parameters.AddWithValue("@Count", textBoxCount.Text);
                conBase.cm.Parameters.AddWithValue("@Price", textBoxPrice.Text);
                conBase.cm.Parameters.AddWithValue("@Country", textBoxCountry.Text);
                conBase.cm.Parameters.AddWithValue("@Dimensions", textBoxGab.Text);
                conBase.cm.Parameters.AddWithValue("@Image", arrImage);
                conBase.cm.ExecuteNonQuery();
                conBase.cn.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            furniture = new Furniture(Convert.ToInt32(textBox1.Text),textBoxName.Text,Convert.ToUInt32(textBoxCount.Text),textBoxNumber.Text,textBoxCountry.Text,textBoxModel.Text,textBoxGab.Text,
                pictureBox1.Image,Convert.ToDecimal(textBoxPrice.Text),comboBox1.Text);
            DialogResult = DialogResult.OK;
            this.Close();
        }
        public void LoadCategory()
        {
            comboBox1.Items.Clear();
            
            conBase.cn.Open();
            conBase.cm = new MySql.Data.MySqlClient.MySqlCommand("select * from category",conBase.cn);
            conBase.dr = conBase.cm.ExecuteReader();
            while(conBase.dr.Read())
            {
                comboBox1.Items.Add(conBase.dr.GetString(0));
            }
            conBase.dr.Close();
            conBase.cn.Close();
        }
        private void AddProduct_Load(object sender, EventArgs e)
        {

        }

       
    }
}
