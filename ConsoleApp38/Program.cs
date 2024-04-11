
// track
using ConsoleApp38;

Console.WriteLine("Матричный калькулятор");

PrintCommand();

void PrintCommand()
{
    Console.WriteLine("Доступные команды:");
    Console.WriteLine("получить случайную матрицу: \"random\"");
}

while (true)
{
    Console.WriteLine("Введите команду:");

    try
    {
        switch (Console.ReadLine())
        {
            case "random": ConsoleRandomMatrix(); break;
            case "multi number": ConsoleMultiNumber(); break;

            default:
                Console.WriteLine("Не верная команда");
                break;
        }
    }
    catch (Exception ex) 
    {
        Console.WriteLine(ex.Message);
    }
}

void ConsoleMultiNumber()
{
    Console.WriteLine("Умножение матрицы на  число");
    Console.WriteLine("Ввод  матрицы:");
    int[] size = GetMatrixDimensions();
    var matrix = MatrixService.SetMatrix(size[0], size[1]);
    double x = GetDouble("Введите число на  которое  надо  умнодить  матрицу");
    var reseult = MatrixService.MatrixMultiplyingByNumber(matrix, x);
    Console.WriteLine("Ответ");
    MatrixService.PrintMatrix(reseult);
}

void ConsoleRandomMatrix()
{
    Console.WriteLine("Генерация случайной  матрицы:");
    int [] size =  GetMatrixDimensions();

    var randomMatrix =   MatrixService.RandomMatrix(size[0], size[1]);
    Console.WriteLine("Случайная матрица");
    MatrixService.PrintMatrix(randomMatrix);
}

static int  []  GetMatrixDimensions()
{
    int[] size = new int[2];
    size[0] = GetInt("Введите кол-во  строк  в  матрице");
    size[1] = GetInt("Введите кол-во  столбцов  в  матрице");
    return size;
}


 static int GetInt(string message)
{
    Console.WriteLine(message);
    try
    {
        return Convert.ToInt32(Console.ReadLine());
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message + " Попробуйте еще раз");
        return GetInt(message);
    }
}

static double GetDouble(string message)
{
    Console.WriteLine(message);
    try
    {
        return Convert.ToDouble(Console.ReadLine());
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message + " Попробуйте еще раз");
        return GetDouble(message);
    }
}