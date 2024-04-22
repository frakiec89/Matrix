// track
using ConsoleApp38;

Console.WriteLine("Матричный калькулятор");

PrintCommand();

void PrintCommand()
{
    Console.WriteLine("Доступные команды:");
    Console.WriteLine("Умножить матрицу на число: \"multi number\"");
    Console.WriteLine("Сложить две матрицы: \"addition matrix\"");
    Console.WriteLine("Вычесть из матрицы матрицу: \"subtract matrix\"");
    Console.WriteLine("Умножить две матрицы: \"multi double matrix\"");
    Console.WriteLine("транспонировать матрицу: \"T matrix\"");
    Console.WriteLine("найти определитель  матрицы: \"d\"");

}

while (true)
{
    Console.WriteLine("Введите команду:");

    try
    {
        switch (Console.ReadLine())
        {
            case "multi number": ConsoleMultiNumber(); break;
            case "addition matrix": ConsoleAdditionMatrix(); break;
            case "subtract matrix": ConsoleSubtractMatrix(); break;
            case "multi double matrix": ConsoleMultiDoubleMatrix(); break;
            case "T matrix": ConsoleTransposeMatrix(); break;
            case "d": ConsoleDeterminant(); break;
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

void ConsoleDeterminant()
{
    Console.WriteLine("Определитель  матрицы");
    var m1 = GenericMatrix("Генерация матрицы (матрица должна быть квадратной)");
   // var m1 = MatrixService.MatricStatic();

    Console.WriteLine($"Ответ {MatrixService.DeterminantMatrix(m1)}");

}



/// транспонирование матрицы
void ConsoleTransposeMatrix()
{
    Console.WriteLine("Транспонировать матрцу");
    var m1 = GenericMatrix("Генерация матрицы");


    var tMatrix = MatrixService.TransposeMatrix(m1);
    Console.WriteLine("Транспонированная матрица");
    MatrixService.PrintMatrix(tMatrix);

}

/// умножение матриц
void ConsoleMultiDoubleMatrix()
{
    Console.WriteLine("Умножение двух матриц");

    var m1 = GenericMatrix("Генерация первой матрицы");

    var m2 = GenericMatrix("Генерация второй матрицы");

    var resault = MatrixService.MatrixMultiplication(m1, m2);

    Console.WriteLine("Ответ");
    MatrixService.PrintMatrix(resault);
}

/// вычитание матриц
void ConsoleSubtractMatrix()
{
    Console.WriteLine("Вычитание двух матриц");
    Console.WriteLine("Генерация первой матрицы");
    
    var m1 = GenericMatrix("Генерация первой матрицы");
    var m2 = GenericMatrix("Генерация второй матрицы");

    var resault = MatrixService.MatrixSubtraction(m1, m2);

    Console.WriteLine("Ответ");
    MatrixService.PrintMatrix(resault);
}

/// сложение  матриц 
void ConsoleAdditionMatrix()
{
    Console.WriteLine("Сложение двух матриц");
    var m1 = GenericMatrix("Генерация первой матрицы");
    var m2 = GenericMatrix("Генерация второй матрицы");

    var resault = MatrixService.MatrixAddition(m1, m2);

    Console.WriteLine("Ответ");
    MatrixService.PrintMatrix(resault);
    
}

///умножение  матрицы на  число
void ConsoleMultiNumber()
{
    Console.WriteLine("Умножение матрицы на  число");
    var m1 = GenericMatrix("Генерация  матрицы");

    double x = GetDouble("Введите число на  которое  надо  умнодить  матрицу");
    var reseult = MatrixService.MatrixMultiplyingByNumber(m1, x);
    Console.WriteLine("Ответ");
    MatrixService.PrintMatrix(reseult);
}



/// генерация матрицы - случайной  или  ручной  ввод
static double [,] GenericMatrix(string message)
{
    Console.WriteLine(message);
    int[] size = GetMatrixDimensions();
    Console.WriteLine("Введете \"r\" если хотите случайную  матрицу");
    Console.WriteLine("Введете \"m\" если хотите ввести матрицу вручеую");
    switch (Console.ReadLine())
    {
        case "r":  var r = MatrixService.RandomMatrix(size[0], size[1]);
            Console.WriteLine("исходная случайная матрица");
            MatrixService.PrintMatrix (r);
            return r;   
        case "m": return MatrixService.SetMatrix(size[0] , size[1]); 
        default: Console.WriteLine("команда не распозднана, попробуйте еще раз");
            return GenericMatrix(message);
    }
}

///  получение  размеров матрицы
static int  []  GetMatrixDimensions()
{
    int[] size = new int[2];
    size[0] = GetInt("Введите кол-во  строк  в  матрице");
    size[1] = GetInt("Введите кол-во  столбцов  в  матрице");
    return size;
}


///получение  числа int
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

/// получиение числа double
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