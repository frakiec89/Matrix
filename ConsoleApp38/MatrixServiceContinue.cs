// track

namespace ConsoleApp38
{
    internal partial class MatrixService
    {
        // Нахождение  определителя , нижней треугольной матрицы

        /// <summary>
        /// нахождение  определителя  матрицы 
        /// </summary>
        /// <param name="m1"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static double DeterminantMatrix(double[,] m1)
        {
            if (m1.GetLength(0) != m1.GetLength(1))
                throw new ArgumentException("матрица должна быть квадратной");

            if (m1.GetLength(0) == 1)
                return m1[0, 0];

            if (m1.GetLength(1) == 2)
            {
                double res = (m1[0, 0] * m1[1, 1]) - (m1[0, 1] * m1[1, 0]);
                return res;
            }

            if (m1.GetLength(1) == 3)
            {
                double res = GetDeterminant3x3(m1);
                return res;
            }
            return GausMetod(m1);
        }

        /// <summary>
        /// Нижняя треугольная матрица (с выводом данных на консоль)
        /// </summary>
        /// <param name="matrixGaus"></param>
        /// <returns></returns>
        public static double[,] TriangularMatrix(double[,] matrixGaus)
        {
            for (int i = 0; i < matrixGaus.GetLength(0); i++) // перебор  столбцов 
            {
                double[] row = GetRow(matrixGaus, i); //  получаем   первую  строку 

                if (row[i] == 0) // проверяем  не  является  нужный  элемент 0 
                {
                    СhangeRow(matrixGaus, row, i); // если да  - меняем  строку  на  подходящую нижнюю   умноженную  на -1
                    row = GetRow(matrixGaus, i); // получаем актуальную строку 
                }

                for (int j = i + 1; j < matrixGaus.GetLength(0); j++) // перебираем  строки  
                {
                    if (j == 0 && i == 0) // если первая  строка  в матрице  - не  трогаем её
                        continue;

                    double[] row2 = GetRow(matrixGaus, j); // получаем нижнюю  строку

                    double[] rowSub = GetGausRow(row, row2, i); // получаем  новую  строку  с  нулем  в индексе  i, j , 

                    for (int k = 0; k < matrixGaus.GetLength(1); k++)
                    {
                        matrixGaus[j, k] = rowSub[k]; // переписываем  матрицу

                    }
                    Console.WriteLine();
                    PrintMatrix(matrixGaus); // выводим на  экран  для наглядности
                }
            }
            return matrixGaus;
        }

        // приватные  методы (треугольный метод, метод Гауса для нахождения определителя)
        /// <summary>
        /// метод  треугольника для  матрицы  3x3
        /// </summary>
        /// <param name="m1"></param>
        /// <returns></returns>
        private static double GetDeterminant3x3(double[,] m1)
        {
            double x1 = m1[0, 0] * m1[1, 1] * m1[2, 2];
            double x2 = m1[0, 1] * m1[1, 2] * m1[2, 0];
            double x3 = m1[0, 2] * m1[1, 0] * m1[2, 1];
            double x4 = m1[0, 2] * m1[1, 1] * m1[2, 0];
            double x5 = m1[0, 0] * m1[1, 2] * m1[2, 1];
            double x6 = m1[0, 1] * m1[1, 0] * m1[2, 2];
            return x1 + x2 + x3 - x4 - x5 - x6;
        }

        /// <summary>
        /// метод гауса 
        /// </summary>
        /// <param name="matrixGaus"></param>
        /// <returns></returns>
        private static double GausMetod(double[,] matrixGaus)
        {
            double[,] triangularMatrix = TriangularMatrix(matrixGaus);

            double res = 1; // переменная  для подсчета  главной диагонали 
            for (int i = 0; i < triangularMatrix.GetLength(1); i++)
            {
                res *= triangularMatrix[i, i]; // перебираем  главную диагональ
            }
            return Math.Round ( res , 3); // возвращаем определитель
        }

        // приватные методы (вспомогательные)

        /// <summary>
        /// замена  строк  местами (для TriangularMatrix)
        /// </summary>
        /// <param name="matrixGaus"></param>
        /// <param name="row">строка  которую надо  заменить</param>
        /// <param name="index">индекс с нулем</param>
        private static void СhangeRow(double[,] matrixGaus, double[] row, int index) // матрица . ,   
        {
            for (int i = index; i < matrixGaus.GetLength(0); i++)
            {
                if (matrixGaus[index, i] == 0) // ищем  другую  строку 
                    continue; //  если там нуль  - то не  подойдет

                double[] row2 = GetRow(matrixGaus, i); // получим строку на  замену

                for (int  j = 0  ; j < matrixGaus.GetLength(0); j ++) // перебираем  строку 
                {
                    matrixGaus[index  , j] = row2[j]; // меняем  местами
                    matrixGaus[i, j] =  row[j] * -1;  // меняем  местами
                }
                break; // заканчиваем  
            }
        }

        /// <summary>
        /// метод перемножает  строку  на  число  и  вычитаем  из  другой строки  что  бы  получить  нуль  в  нужном  месте 
        /// </summary>
        /// <param name="row">строка которую  умножим </param>
        /// <param name="row2">строка  из которой вычти - они измениться  в ней  хочу нуль</param>
        /// <param name="coIndex">индекс  где  хочу ноль</param>
        /// <returns></returns>
        private static double[] GetGausRow(double[] row, double[] row2, int coIndex)
        {
            double[] r1 = new double[row.Length]; // выделю  память  под  первую  строку  
            double[] r2 = new double[row2.Length];// выделю  память  под  вторую   строку 

            Array.Copy(row, r1, row.Length);  // скопирую  что  пришло   - иначе матрица  измениться  а  я  так не  хочуу 
            Array.Copy(row2, r2, row2.Length); // скопирую  что  пришло   - иначе матрица  измениться  а  я  так не  хочуу 
            
            double x1 = row[coIndex]; // возьмем  число  их первой  строки
            double x2 = row2[coIndex]; // возьмем  число  их второй строки -- тут  хочу получить нуль

            if (x2 == 0) // если они  и так нуль  - вернем  строку   
                return r2;

            double del = GetDel(x1, x2);  // пойму  на что надо  умножить  первое  число что  бы  вычитая  второе  из  первого  получит ноль

            if(x1==0) // если в  первой  строке 0 - вернем  ее 
                return r1;

            double[] doubles = new double[row2.Length]; // ищем  новую  строку 

            for (int i = 0; i < row.Length; i++)
            {
                r1[i] *= del; // умножаем ее на делитель
                var  r =  r2[i] - r1[i] ; // вычитаем  из второй строки  первую                 
                doubles[i] = r;
            }
            return doubles; // вернем новую  строку 
        }

        /// <summary>
        /// найдем общий делитель
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <returns></returns>
        private static double GetDel(double x1, double x2)
        {
            var d =  x2 / x1  ;
            return d;
        }

        /// <summary>
        /// получаем  строку  по  индексу из  матрицы  
        /// </summary>
        /// <param name="matrixGaus"></param>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        private static double[] GetRow(double[,] matrixGaus, int rowIndex)
        {
            double[] row = new double[matrixGaus.GetLength(1)];

            for (int i = 0; i < row.Length; i++)
            {
                row[i] = matrixGaus[rowIndex, i];
            }

            return row;
        }
    }
}
