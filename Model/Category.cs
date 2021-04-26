using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureStore.Model
{
    public class Category:Furniture
    {
        public int Id { get; set; }
        public string NameCategory { get; set; }
        public Category(int ID,string Name)
        {
            this.Id = Id;
            this.NameCategory = Name;
        }
    }
}
