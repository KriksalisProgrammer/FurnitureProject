using FurnitureStore.Connections;
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
using MySql.Data.MySqlClient;
namespace FurnitureStore.View.ProductView
{
    public partial class AddCategory : Form
    {
        private ToDataBase conBase = new ToDataBase();
        private AddProduct addProduct = new AddProduct();
        public Category category { get; private set; }
        public AddCategory()
        {
            InitializeComponent();
        }

        private void buttonAddCategory_Click(object sender, EventArgs e)
        {
            try
            {
                
                conBase.Connection();
                conBase.cn.Open();
                conBase.cm = new MySql.Data.MySqlClient.MySqlCommand("insert into category (Fid,Name) values(@Fid,@Name)", conBase.cn);
                conBase.cm.Parameters.AddWithValue("@Fid", textBox2.Text);
                conBase.cm.Parameters.AddWithValue("@Name", textBox1.Text);
                conBase.cm.ExecuteNonQuery();
                conBase.cn.Close();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            category = new Category(Convert.ToInt32(textBox2.Text), textBox1.Text);
            addProduct.LoadCategory();
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
