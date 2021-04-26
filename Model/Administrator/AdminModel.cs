using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace FurnitureStore.Model.Administrator
{
    [Serializable]
    public class AdminModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public uint Age { get; set; }
        public string Position { get; set; }
        public string Country { get; set; }
        public Image imageAdmin { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public AdminModel(string Name, string Surname,uint Age,string Position,string Country, Image imageAdmin,string Login,string Password)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Age = Age;
            this.Position = Position;
            this.Country = Country;
            this.imageAdmin = imageAdmin;
            this.Login = Login;
            this.Password = Password;
        }
        public AdminModel(string Name, string Surname, uint Age, string Position, string Country, Image imageAdmin)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Age = Age;
            this.Position = Position;
            this.Country = Country;
            this.imageAdmin = imageAdmin;
        }
        public AdminModel()
        {

        }
    }
}
