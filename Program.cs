while (true)
{
    ShowMenu();
    string? response = Console.ReadLine()?.Trim().ToLower();

    if (response == "q")
    {
        break;
    }

    if (!int.TryParse(response, out int choice) || choice < 1 || choice > 7)
    {
        Console.WriteLine("Please enter a number from 1 to 7, or q to quit.");
        continue;
    }

    RunCalculation(choice);
}


static void ShowMenu()
{
    Console.WriteLine("What calculation would you like to do? (enter q to quit)");
    Console.WriteLine("Press 1 for Addition");
    Console.WriteLine("Press 2 for Subtraction");
    Console.WriteLine("Press 3 for Multiplication");
    Console.WriteLine("Press 4 for Division");
    Console.WriteLine("Press 5 for Power");
    Console.WriteLine("Press 6 for Square Root");
    Console.WriteLine("Press 7 for Percentage, Percentage (X% of Y)");

}

static void RunCalculation(int option)
{

    if (option == 6)
        OneNumberCalc();
    else
        TwoNumberCalc(option);

}

static void PrintResult(double result)
{
    Console.WriteLine($"The answer is {result}");
}

static void OneNumberCalc()
{
    double a = ReadNumber("Input number: ");

    if (a < 0)
    {
        Console.WriteLine("Can't take the square root of a negative number.");
        return;
    }

    double result = Root(a);

    PrintResult(result);
}


static void TwoNumberCalc(int choice)
{
    double a = 0;
    double b = 0;
    if (choice == 5)
    {
        a = ReadNumber("First number: ");
        b = ReadNumber("Exponent: ");
    }
    else if (choice == 7)
    {
        a = ReadNumber("How much percent?: ");
        b = ReadNumber("Of number?: ");
    }
    else
    {
        a = ReadNumber("Input first number: ");
        b = ReadNumber("Input second number: ");
    }

    if (choice == 4 && b == 0)
    {
        Console.WriteLine("Can't divide by zero.");
        return;
    }

    double result = choice switch
    {
        1 => Add(a, b),
        2 => Subtract(a, b),
        3 => Multiply(a, b),
        4 => Divide(a, b),
        5 => Power(a, b),
        7 => Percentage(a, b),
        _ => throw new ArgumentOutOfRangeException(nameof(choice))
    };

    PrintResult(result);
}

static double ReadNumber(string prompt)
{
    Console.Write(prompt);
    double value;
    while (!double.TryParse(Console.ReadLine(), out value))
    {
        Console.Write("Numbers only, please re-input: ");


    }

    return value;

}



static double Add(double a, double b)
{
    return a + b;
}

static double Subtract(double a, double b)
{

    return a - b;
}

static double Multiply(double a, double b)
{

    return a * b;
}

static double Divide(double a, double b)
{

    return a / b;
}

static double Root(double a)
{

    return Math.Sqrt(a);

}

static double Power(double a, double b)
{
    return Math.Pow(a, b);
}

static double Percentage(double percent, double of)
{
    return percent / 100 * of;
}