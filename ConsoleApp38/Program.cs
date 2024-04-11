
// nocopy
using ConsoleApp38;

Console.WriteLine("Матричный калькулятор");

PrintCommand();

void PrintCommand()
{
    Console.WriteLine("Доступные команды:");
    Console.WriteLine("получить случайную матрицу: \"random\"");
    Console.WriteLine("Умножить матрицу на число: \"multi number\"");
    Console.WriteLine("Сложить две матрицы: \"addition matrix\"");
    Console.WriteLine("Вычесть из матрицы матрицу: \"subtract matrix\"");
    Console.WriteLine("Умножить две матрицы: \"multi double matrix\"");

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
            case "addition matrix": ConsoleAdditionMatrix(); break;
            case "subtract matrix": ConsoleSubtractMatrix(); break;
            case "multi double matrix": ConsoleMultiDoubleMatrix(); break;

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

void ConsoleMultiDoubleMatrix()
{
    Console.WriteLine("Умножение двух матриц");
    Console.WriteLine("Генерация первой матрицы");
    int[] size1 = GetMatrixDimensions();

    var m1 = MatrixService.SetMatrix(size1[0], size1[1]);

    Console.WriteLine("Генерация второй матрицы");
    int[] size2 = GetMatrixDimensions();

    var m2 = MatrixService.SetMatrix(size2[0], size2[1]);

    var resault = MatrixService.MatrixMultiplication(m1, m2);

    Console.WriteLine("Ответ");
    MatrixService.PrintMatrix(resault);
}

void ConsoleSubtractMatrix()
{
    Console.WriteLine("Вычитание двух матриц");
    Console.WriteLine("Генерация первой матрицы");
    int[] size1 = GetMatrixDimensions();

    var m1 = MatrixService.SetMatrix(size1[0], size1[1]);

    Console.WriteLine("Генерация второй матрицы");
    int[] size2 = GetMatrixDimensions();

    var m2 = MatrixService.SetMatrix(size2[0], size2[1]);

    var resault = MatrixService.MatrixSubtraction(m1, m2);

    Console.WriteLine("Ответ");
    MatrixService.PrintMatrix(resault);
}

void ConsoleAdditionMatrix()
{
    Console.WriteLine("Сложение двух матриц");
    Console.WriteLine("Генерация первой матрицы");
    int[] size1 = GetMatrixDimensions();

    var m1 = MatrixService.SetMatrix(size1[0], size1[1]);

    Console.WriteLine("Генерация второй матрицы");
    int[] size2 = GetMatrixDimensions();

    var m2 = MatrixService.SetMatrix(size2[0], size2[1]);

    var resault = MatrixService.MatrixAddition(m1, m2);

    Console.WriteLine("Ответ");
    MatrixService.PrintMatrix(resault);
    
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