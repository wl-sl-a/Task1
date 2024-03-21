namespace Task1
{
    public class Population
    {
        private int redHedgehog;
        private int greenHedgehog;
        private int blueHedgehog;

        public Population(int redHedgehog, int greenHedgehog, int blueHedgehog)
        {
            if (CheckSum() && CheckCount(redHedgehog) && CheckCount(greenHedgehog) && CheckCount(blueHedgehog))
            {
                this.redHedgehog = redHedgehog;
                this.greenHedgehog = greenHedgehog;
                this.blueHedgehog = blueHedgehog;
            }
        }

        private bool CheckSum()
        {
            if (TotalPopulation >= 1 && TotalPopulation <= Int32.MaxValue) return true;
            else
            {
                Console.WriteLine("Sum of hedgehogs in population is 0 or more than Int32.MaxValue");
                return false;
            }
        }

        private bool CheckCount(int count)
        {
            if (count >= 0 && count <= Int32.MaxValue) return true;
            else
            {
                Console.WriteLine("Count of hedgehogs is incorrect");
                return false;
            }
        }

        public int RedHedgehog
        {
            get { return redHedgehog; }
        }

        public int GreenHedgehog
        {
            get { return greenHedgehog; }
        }

        public int BlueHedgehog
        {
            get { return blueHedgehog; }
        }

        public int TotalPopulation
        {
            get { return RedHedgehog + GreenHedgehog + BlueHedgehog; }
        }

        public int MinimumMeetings(int color)
        {
            int[] arrayPopulation = { RedHedgehog, GreenHedgehog, BlueHedgehog };

            int result;
            int firstOtherColor = (color + 1) % 3;
            int secondOtherColor = (color + 2) % 3;

            int? totalPopulation = TotalPopulation;
            if (totalPopulation == 0) result = -1;
            else if (arrayPopulation[color] == totalPopulation) result = 0;
            else if (arrayPopulation[firstOtherColor] == totalPopulation || arrayPopulation[secondOtherColor] == totalPopulation) result = -1;
            else if (arrayPopulation[firstOtherColor] == arrayPopulation[secondOtherColor])   result = arrayPopulation[firstOtherColor];
            else if (Math.Abs((arrayPopulation[firstOtherColor] - arrayPopulation[secondOtherColor])) % 3 != 0) result = -1;
            else result = Math.Max(arrayPopulation[firstOtherColor], arrayPopulation[secondOtherColor]);

            return result;
        }
    }
    public class Program
    {

        static void Main(string[] args)
        {
            (int red, int green, int blue, int color) = Input();
            Population population = new Population(red, green, blue);

            int resultMeetings = population.MinimumMeetings(color);

            if (resultMeetings == -1)
                Console.WriteLine($"Solution with this input data is impossible");
            else if (resultMeetings == 0)
                Console.WriteLine($"All hedgehogs have the right color already");
            else
                Console.WriteLine($"The minimum count of meetings is - {resultMeetings}");

            Console.ReadKey();
        }

        static public (int, int, int, int) Input()
        {
            int red, green, blue, color;
            while (true)
            {
                try
                {
                    Console.Write($"Enter count of red hedgehogs: ");
                    red = Convert.ToInt32(Console.ReadLine());

                    Console.Write($"Enter count of green hedgehogs: ");
                    green = Convert.ToInt32(Console.ReadLine());

                    Console.Write($"Enter count of blue hedgehogs: ");
                    blue = Convert.ToInt32(Console.ReadLine());

                    Console.Write($"Enter color (0 - red, 1 - green, 2 - blue): ");
                    color = Convert.ToInt32(Console.ReadLine());
                }
                catch (OverflowException exc)
                {
                    Console.WriteLine(exc.Message);
                    red = green = blue = color = -1;
                }
                catch (FormatException exc)
                {
                    Console.WriteLine(exc.Message);
                    red = green = blue = color = -1;
                }

                if (red < 0 || green < 0 || blue < 0)
                    Console.WriteLine("Incorrect input of count hedgehogs");
                else if (color == 0 || color == 1 || color == 2)
                    break;
                else
                    Console.WriteLine("Incorrect input of color");
            }

            return (red, green, blue, color);
        }
    }
}
