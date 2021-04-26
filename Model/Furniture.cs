using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureStore.Model
{
    [Serializable]
    public class Furniture
    {
        public Image ImageProduct { get; set; }
        public int Id { get; set; }
        public string NameProduct { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public uint Count { get; set; }       
        public decimal Price { get; set; }
        public string TheCountry { get; set; }
        private decimal PricePurchasing { get; set; }
        public string Dimensions { get; set; }//Габариты
        private decimal Procent { get; set; }
        public string IDCategory { get; set; }
        
        public Furniture(int ID,string Name, uint Counter, string Serial, string Country, string ModelProduct, string Dimensions, Image ImageP, decimal Price,string IdCategory)
        {
            Id = ID;
            NameProduct = Name;
            Count = Counter;
            SerialNumber = Serial;
            TheCountry = Country;
            Model = ModelProduct;
            this.Dimensions = Dimensions;
            ImageProduct = ImageP;
            this.Price = Price;
            IDCategory = IdCategory;
        }

        public Furniture()
        {

        }
    }
}
