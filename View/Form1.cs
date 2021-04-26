using FurnitureStore.Connections;
using FurnitureStore.Model;
using FurnitureStore.Model.Administrator;
using FurnitureStore.View.AdminInfoView;
using FurnitureStore.View.ProductView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FurnitureStore
{
    public partial class Form1 : Form
    {
        public IOController<Furniture> IO = new IOController<Furniture>();
        public BindingSource bs;
        private AdminModel admin;
        private ToDataBase basedate;
        public Form1()
        {
            InitializeComponent();
            bs = new BindingSource();
            bs.DataSource = FurnitureModel.listFurniture;
            dataGridView1.DataSource = bs;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            IO.SaveProduct(FurnitureModel.listFurniture);
            IO.SaveAdmin();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.LoadCategory();
            if(addProduct.ShowDialog()==DialogResult.OK)
            {
                FurnitureModel.listFurniture.Add(addProduct.furniture);
                bs.DataSource = FurnitureModel.listFurniture;
                bs.ResetBindings(true);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IO.LoadProduct();
            IO.LoadAdmin();
            bs.DataSource = FurnitureModel.listFurniture;
            bs.ResetBindings(true);
            var adminprofile=FurnitureModel.adminList[0];
            admin = adminprofile;
            labelName.Text = adminprofile.Name;
            labelSurname.Text = adminprofile.Surname;
            pictureBox1.Image = adminprofile.imageAdmin;
            try
            {
                basedate = new ToDataBase();
                basedate.Connection();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var product = dataGridView1.SelectedRows[0].DataBoundItem as Furniture;
            FurnitureModel.listFurniture.Remove(product);
            bs.ResetBindings(true);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            EditProduct edit = new EditProduct();
            var product = dataGridView1.SelectedRows[0].DataBoundItem as Furniture;
            edit.Initialization(product);
            if (edit.ShowDialog()==DialogResult.Yes)
            {
                Furniture item = FurnitureModel.listFurniture.FirstOrDefault(x => x.SerialNumber == product.SerialNumber);
                if(item!=null)
                {
                    int index = FurnitureModel.listFurniture.IndexOf(item);
                    FurnitureModel.listFurniture[index] = edit.furniture;
                }
                bs.DataSource = FurnitureModel.listFurniture;
                bs.ResetBindings(true);
            }
        }

        private void buttonProfileAdministrator_Click(object sender, EventArgs e)
        {
            AdminInfo info = new AdminInfo();
            info.Initiailze(admin);
            if (info.ShowDialog()==DialogResult.OK)
            {
               
            }
        }

        private void buttonAddCategory_Click(object sender, EventArgs e)
        {
            AddCategory add = new AddCategory();
            if(add.ShowDialog()==DialogResult.OK)
            {
                
            }
        }
    }
}
