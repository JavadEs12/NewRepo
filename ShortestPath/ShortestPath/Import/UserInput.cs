namespace ShortestPath
{
    public class UserInput
    {
        public (string, string) ReadUserInput()
        {
            Console.WriteLine("Please choose your Origin-Destination couple\nYou are allowed to choose numbers between 1-6");
            string Origin = CheckInputAccuracy();
            string Destination = CheckInputAccuracy(Origin);
            return (Origin, Destination);
        }
        private string CheckInputAccuracy(string origin = null)
        {
            while (true)
            {
                try
                {
                    var input = Int16.Parse(Console.ReadLine());
                    if (origin == null && input >= 1 && input <= 6)
                    {
                        return input.ToString();
                    }
                    else if (origin != null && input >= 1 && input <= 6)
                    {
                        if (input.ToString() == origin)
                        {
                            Console.WriteLine("Entered number is repeated, please try another number for destination");
                        }
                        else
                        {
                            return input.ToString();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong input data, Please enter a number between 1-6");
                    }
                }
                catch
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }
        }
    }
}
