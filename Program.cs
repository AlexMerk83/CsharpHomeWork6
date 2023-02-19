main();

void main()
{
    bool isWork = true;

    while (isWork)
    {
        ConsoleIOHandler.PrintMainMenu();

        int taskNo = ConsoleIOHandler.ReadInt("a task number", 0, 2, ConsoleIOHandler.msgNoSuchOption);

        switch (taskNo)
        {
            case 1: Task41QuantityOfNaturalNumbers(); break;
            case 2: Task43PointOfIntersection(); break;
            case 0: isWork = false; break;
            default: System.Console.WriteLine(ConsoleIOHandler.msgNoSuchOption); break;
        }

        if (isWork)
            ConsoleIOHandler.WaitForAnyKey();
    }
}

#region Task41 Quantity Of Natural Numbers
// Задача 41: Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.
// 0, 7, 8, -2, -2 -> 2
// 1, -7, 567, 89, 223-> 3
void Task41QuantityOfNaturalNumbers()
{
    Console.Clear();

}
#endregion

#region Task43 Point of intersection
// Задача 43: Напишите программу, которая найдёт точку пересечения двух прямых,
// заданных уравнениями y = k1 * x + b1, y = k2 * x + b2; значения b1, k1, b2 и k2 задаются пользователем.
// b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; -0,5)
void Task43PointOfIntersection()
{
    Console.Clear();
    
}
#endregion


#region Input and Output methods
class ConsoleIOHandler
{
    #region Output Support Methods

    public const string msgAnyKeyRequest = "Press any key to continue...";
    public const string msgNoSuchOption = "There is no such option. Try again.";


    public static void PrintMainMenu()
    {
        Console.Clear();

        System.Console.WriteLine("Homework 6 tasks:");
        System.Console.WriteLine("1 - Task41: Quantity of natural numbers");
        System.Console.WriteLine("2 - Task43: Point of intersection");
        System.Console.WriteLine("0 - Exit");
    }

    public static void WaitForAnyKey()
    {
            System.Console.WriteLine();
            System.Console.WriteLine(msgAnyKeyRequest);
            Console.ReadKey();
    }

    public static void ClearLine(int lineShift = 0, bool keepCursor = true)
    {
        int currentTop = Console.CursorTop,
            currentLeft = Console.CursorLeft;
        
        Console.SetCursorPosition(0, currentTop + lineShift);
        Console.Write(new string(' ', Console.WindowWidth));

        if (keepCursor)
            Console.SetCursorPosition(currentLeft, currentTop);
        else
            Console.SetCursorPosition(0, currentTop + lineShift);
    }

    #endregion

    #region Input Support Methods

    public const string defaultIntErrorMessage = "Input error. Please enter an integer number.";
    private const string defaultRangeErrorMessage = "Input error. Please enter an integer number from the range {0}..{1}.";
    public const string defaultDoubleErrorMessage = "Input error. Please enter a real number.";
    
    public static int ReadInt(string argument)
    {
        int parsedNum = 0,
            inputFieldX = 0,
            inputFieldY = 0;

        System.Console.Write($"Enter {argument}: ");
        inputFieldX = Console.CursorLeft;
        inputFieldY = Console.CursorTop;
        while (!int.TryParse(Console.ReadLine(), out parsedNum))
        {
            Console.SetCursorPosition(0, inputFieldY);
            ClearLine();
            System.Console.WriteLine($"Enter {argument}: ");
            System.Console.WriteLine(defaultIntErrorMessage);
            Console.SetCursorPosition(inputFieldX, inputFieldY);
        }

        ClearLine();
        
        return parsedNum;
    }

    public static int ReadInt(string argument, int minValue, int maxValue, string errorMessage = defaultRangeErrorMessage)
    {
        int parsedNum = 0,
            inputFieldX = 0,
            inputFieldY = 0;

        System.Console.Write($"Enter {argument}: ");
        inputFieldX = Console.CursorLeft;
        inputFieldY = Console.CursorTop;
        while (!int.TryParse(Console.ReadLine(), out parsedNum) || parsedNum < minValue || parsedNum > maxValue)
        {
            Console.SetCursorPosition(0, inputFieldY);
            ClearLine();
            System.Console.WriteLine($"Enter {argument}: ");
            System.Console.WriteLine(errorMessage, minValue, maxValue);
            Console.SetCursorPosition(inputFieldX, inputFieldY);
        }

        ClearLine();
        
        return parsedNum;
    }

    public static double ReadDouble(string argument)
    {
        double parsedNum = 0.0;
        int inputFieldX = 0,
            inputFieldY = 0;

        System.Console.Write($"Enter {argument}: ");
        inputFieldX = Console.CursorLeft;
        inputFieldY = Console.CursorTop;
        while (!double.TryParse(Console.ReadLine(), out parsedNum))
        {
            Console.SetCursorPosition(0, inputFieldY);
            ClearLine();
            System.Console.WriteLine($"Enter {argument}: ");
            System.Console.WriteLine(defaultDoubleErrorMessage);
            Console.SetCursorPosition(inputFieldX, inputFieldY);
        }

        ClearLine();
        
        return parsedNum;
    }
    #endregion
}
#endregion


#region Array Methods

class ArrayHandler
{
    public static int[] GetRandomIntArray(int length, int minVal, int maxVal)
    {
        int[] arr = new int[length];

        Random rnd = new Random();

        for (int i = 0; i < length; i++)
            arr[i] = rnd.Next(minVal, maxVal + 1);
        
        return arr;
    }

    public static double[] GetRandomDoubleArray(int length, double minVal, double maxVal)
    {
        double[] arr = new double[length];

        Random rnd = new Random();

        for (int i = 0; i < length; i++)
            arr[i] = minVal + rnd.NextDouble() * (maxVal - minVal);

        return arr;
    }

    public static double[] GetMinAndMaxElements(double[] array)
    {
        double[] arrMinMax = new double[2];
        
        arrMinMax[0] = array[0];
        arrMinMax[1] = array[0];

        for (int i = 1; i < array.Length; i++)
            if (array[i] < arrMinMax[0]) arrMinMax[0] = array[i];
            else if (array[i] > arrMinMax[1]) arrMinMax[1] = array[i];

        return arrMinMax;
    }

}

#endregion