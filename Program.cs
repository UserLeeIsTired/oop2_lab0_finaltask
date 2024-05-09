using System;
using System.Numerics;

class UserInput // Task 1
{
    public Array ValidUserInput()
    {
        double[] interval = new double[2];
        string low, high;
        double temp;
        
        
        Console.Write("Please enter a number (low): ");
        low = Console.ReadLine();
        while (low == null || !double.TryParse(low, out temp))
        {
            warning();
            Console.Write("Please enter a number (low): ");
            low = Console.ReadLine();
        }

        Console.Write("Please enter a number (high): ");
        high = Console.ReadLine();
        while (high == null || !double.TryParse(high, out temp))
        {
            warning();
            Console.Write("Please enter a number (high): ");
            high = Console.ReadLine();
        }

        double lowValue = double.Parse(low);
        double highValue = double.Parse(high);

        if (lowValue <= highValue)
        {
            interval[0] = lowValue;
            interval[1] = highValue;
        }
        else
        {
            Console.WriteLine("Invalid input. The low value cannot be higher than the high value.");
            return null;
        }

        return interval;
    }

    private void warning()
    {
        Console.WriteLine("The input is not valid!");
    }
}

class ReadFile // Task 2
{
    public int readfile(string filepath)
    {
        int sum = 0;
        try
        {
            string[] lines = File.ReadAllLines(filepath);
            foreach (string line in lines)
            {
                if (int.TryParse(line, out int num))
                {
                    sum += num;
                }
            }
            Console.WriteLine("Sum of numbers: " + sum);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found: " + filepath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error occurred: " + ex.Message);
        }
        return sum;
    }
}

class StoreVariable // Task 4
{
    public List<double> convertList(double low, double high)
    {
        List<double> nums = new List<double>();
        
        for (double i = low; i <= high; i++)
        {
            nums.Add(i);
        }

        return nums;
    }
}

class FindPrime
{
    public bool checkPrime(double num)
    {
        int value = Convert.ToInt32(num);
        
        if (value <= 3)
        {
            return true;
        }

        for (int i = 2; i <= Math.Floor(Math.Pow(value, 0.5)); i++)
        {
            if (value % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}

class Program 
{
    static void Main()  // the program logic
    {
        UserInput userInput = new UserInput();
        StoreVariable storeVariable = new StoreVariable();
        FindPrime findPrime = new FindPrime();

        double[] acceptInterval = null;
        List<double> nums = new List<double>();


        while (acceptInterval == null)
        {
            acceptInterval = (double[]?)userInput.ValidUserInput();
        }

        nums = storeVariable.convertList(acceptInterval[0], acceptInterval[1]);

        Console.WriteLine($"Prime number(s) between {acceptInterval[0]} and {acceptInterval[1]} is/ are: ");
        foreach (double num in nums)
        {
            if (findPrime.checkPrime(num)) {
                Console.WriteLine(num); 
            }
        }

    }
}
