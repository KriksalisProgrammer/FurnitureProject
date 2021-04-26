using FurnitureStore.Model.Administrator;
using FurnitureStore.Model.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureStore.Model
{
    [Serializable]
    public class FurnitureModel
    {
        public static List<Furniture> listFurniture = new List<Furniture>();
        public static List<AdminModel> adminList = new List<AdminModel>();
        public static List<MyManager> managerList = new List<MyManager>();


    }
}
