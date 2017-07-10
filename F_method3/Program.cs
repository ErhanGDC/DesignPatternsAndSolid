using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_method3
{
    class Program
    {
        static void Main(string[] args)
        {
            //the basic Swift car of Blue color -Creation
            SwiftCar BlueBasicSwiftCar = SwiftCarFactory.CreateSwiftCar(SwiftCarType.BASIC, CarColor.BLUE);

            //Computation of Price
            float BlueBasicSwiftCarPrice = BlueBasicSwiftCar.CaliculatePrice();
            Console.WriteLine("price of Blue Basic Swift car" + BlueBasicSwiftCarPrice);

            //the Red Featured Swift car of Blue color -Creation
            SwiftCar RedFeaturedSwiftCar = SwiftCarFactory.CreateSwiftCar(SwiftCarType.FEATURED, CarColor.RED);

            // Computation of Price
            float RedFeaturedSwiftCarPrice = RedFeaturedSwiftCar.CaliculatePrice();
            Console.WriteLine("price of  Red Featured Swift car" + RedFeaturedSwiftCarPrice);
        }
    }
    /// <summary>
    /// abstract class for swift car
    /// </summary>
    public abstract class SwiftCar
    {
        /// <summary>
        /// color of the Swift car
        /// </summary>
        public CarColor Color { get; private set; }

        protected SwiftCar(CarColor color)
        {
            this.Color = color;
        }

        /// <summary>
        /// function that calculates the price
        ///  of the swift car
        /// </summary>
        /// <returns></returns>
        public abstract float CaliculatePrice();
    }

    /// <summary>
    /// the basic swift car
    /// </summary>
    public class SwiftCarBasic : SwiftCar
    {
        /// <summary>
        /// creates a basic swift car of defined color
        /// </summary>
        /// <param name="color">the color requested by the client</param>
        public SwiftCarBasic(CarColor color)
            : base(color)
        {

        }
        /// <summary>
        /// customised calculation of price
        /// </summary>
        /// <returns> the price of the basic model of swift car</returns>
        public override float CaliculatePrice()
        {
            float BasicPrice = 400000F;
            return BasicPrice;
        }
    }

    /// <summary>
    /// The swift car with additional features
    /// </summary>
    public class SwiftCarFeatured : SwiftCar
    {
        /// <summary>
        /// Creates a Featured swift car with a color requested by the client
        /// </summary>
        /// <param name="Color">the color of the featured swift car</param>
        public SwiftCarFeatured(CarColor Color)
            : base(Color)
        {

        }
        /// <summary>
        /// customised calculation of the car with additional features such as airbags,speakers power window etc
        /// </summary>
        /// <returns></returns>
        public override float CaliculatePrice()
        {
            float basicPrice = 400000F;
            float otherEquipmentCosts = 200000F;
            return basicPrice + otherEquipmentCosts;
        }
    }

    /// <summary>
    /// The different types of Swift Car
    /// </summary>
    public enum SwiftCarType
    {
        /// <summary>
        /// basic model of Swift car
        /// </summary>
        BASIC,
        /// <summary>
        /// Advanced model of swift car
        /// </summary>
        FEATURED
    }
    /// <summary>
    /// the car color types
    /// </summary>
    public enum CarColor
    {
        BLACK,
        RED,
        BLUE
    }/// <summary>
    /// The Class represents the Factory of the Swift Car
    /// </summary>
    public static class SwiftCarFactory
    {
        /// <summary>
        /// The method creates a swift car as desired by the consumer
        /// </summary>
        /// <param name="carType"> the car type specified by the Consumer</param>
        /// <param name="carColor"> the color  of the car specified by the consumer </param>
        /// <returns> the desired swift car</returns>
        public static SwiftCar CreateSwiftCar(SwiftCarType carType, CarColor carColor)
        {
            SwiftCar car = null;

            switch (carType)
            {
                case SwiftCarType.BASIC: car = new SwiftCarBasic(carColor);
                    break;
                case SwiftCarType.FEATURED: car = new SwiftCarFeatured(carColor);
                    break;
            }
            return car;
        }
    }
}
