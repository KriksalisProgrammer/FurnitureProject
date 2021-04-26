using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using FurnitureStore.Model.Administrator;

namespace FurnitureStore.Model
{
   public class IOController<T>
    {
        private XmlSerializer save = new XmlSerializer(typeof(List<Furniture>));
        public void SaveProduct(List<T> saveList)
        {
          using(FileStream fs=new FileStream("Product.bin",FileMode.Create,FileAccess.Write))
            {
                var formater=new BinaryFormatter();
                formater.Serialize(fs, FurnitureModel.listFurniture);
            }
        }
        public void LoadProduct()
        {
            using(FileStream fs=new FileStream("Product.bin", FileMode.Open, FileAccess.Read))
            {
                var formater = new BinaryFormatter();
                FurnitureModel.listFurniture =(List<Furniture>)formater.Deserialize(fs);
            }
        }
        public void SaveAdmin()
        {
            using (FileStream fs = new FileStream("Admin.bin", FileMode.Create, FileAccess.Write))
            {
                var formater = new BinaryFormatter();
                formater.Serialize(fs, FurnitureModel.adminList);
            }
        }
        public void LoadAdmin()
        {
            using (FileStream fs = new FileStream("Admin.bin", FileMode.Open, FileAccess.Read))
            {
                var formater = new BinaryFormatter();
                FurnitureModel.adminList = (List<AdminModel>)formater.Deserialize(fs);
            }
        }
    }
}
