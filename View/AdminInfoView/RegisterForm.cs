using FurnitureStore.Model.Manager;
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
    public partial class RegisterForm : Form
    {
        public MyManager NewManager { get; set; }
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            if (openFile.ShowDialog(this) == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFile.FileName);
            }
        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
            NewManager = new MyManager(pictureBox1.Image, textBoxName.Text, textBoxSurname.Text, Convert.ToUInt32(textBoxAge.Text), textBoxNumber.Text, textBoxEmail.Text, textBoxLogin.Text, textBoxPassword.Text);
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
