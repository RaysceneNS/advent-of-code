using System.Linq;

namespace Library.Day1
{
    public static class FuelCalculator
    {
        public static int CalculateTotalFuel(int[] moduleMasses)
        {
            return moduleMasses.Sum(CalculateFuel);
        }

        public static int CalculateTotalFuelForFuel(int[] moduleMasses) 
        {
            return moduleMasses.Sum(CalculateFuelForFuel);
        }

        public static int CalculateFuelForFuel(int mass) 
        {
            int total = 0;
            int newFuel = mass;
            do
            {
                newFuel = CalculateFuel(newFuel);
                if (newFuel > 0)
                    total += newFuel;
            }
            while (newFuel > 0);
            return total;
        }

        public static int CalculateFuel(int mass)
        {
            return (mass / 3) - 2;
        }
    }
}
