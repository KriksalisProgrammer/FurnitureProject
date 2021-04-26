using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureStore.Model.Manager
{
   public class MyManager
    {
        public Image image { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public uint Age { get; set; }
        public string NumberTelephone { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public uint CountOrders { get; set; }
        public MyManager( Image image,string Name, string Surname, uint Age, string Number, string Email, string Login, string Password)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Age = Age;
            NumberTelephone = Number;
            this.Email = Email;
            this.Login = Login;
            this.Password = Password;
            this.image = image;
        }

    }
}
