using FurnitureStore.Model;
using FurnitureStore.Model.Administrator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FurnitureStore.View.AdminInfoView
{
    public partial class AdminInfo : Form
    {
        public AdminModel info { get;private set; }
        public AdminInfo()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            info = new AdminModel(textBoxName.Text, textBoxSurname.Text,Convert.ToUInt32(textBoxAge.Text), textBoxPosition.Text, textBoxCountry.Text, pictureBox1.Image);
            DialogResult = DialogResult.OK;
            this.Close();
        }
        public void Initiailze(AdminModel admin)
        {
            textBoxName.Text = admin.Name;
            textBoxSurname.Text = admin.Surname;
            textBoxAge.Text = admin.Age.ToString();
            textBoxPosition.Text = admin.Position;
            textBoxCountry.Text = admin.Country;
            pictureBox1.Image = admin.imageAdmin;
        }
        private void buttonEditImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            if (openFile.ShowDialog(this) == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFile.FileName);
            }
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            RegisterForm register = new RegisterForm();
            if(register.ShowDialog()==DialogResult.OK)
            {
                FurnitureModel.managerList.Add(register.NewManager);
                MessageBox.Show("Зарегистрирован!");
            }
        }
    }
}
