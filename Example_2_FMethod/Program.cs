using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_2_FMethod
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public enum FurnitureType
    {
        Sofa,
        Desk,
        Table
    }
    public class FurnitureFactory
    {
        public IFurniture CreateFurniture(FurnitureType furnitureType)
        {
            IFurniture furniture = null;
            switch (furnitureType)
            {
                case FurnitureType.Sofa:
                    furniture = new SofaFurniture();
                    break;
                case FurnitureType.Desk:
                    furniture = new DeskFurniture();
                    break;
                case FurnitureType.Table:
                    furniture = new TableFurniture();
                    break;
                default:
                    break;
            }
            return furniture;
        }
    }
    public interface IFurniture
    {

    }
}
