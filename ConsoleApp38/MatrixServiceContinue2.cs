// nocopy

namespace ConsoleApp38
{
    internal partial class MatrixService
    {
        // нахождение ранга матрицы,  обратной матрицы  

        /// <summary>
        /// ранг  матрицы 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static int RangMatrix(double[,] matrix)
        {
            double[,] trMatrix = TriangularMatrix(matrix);

            int x = 0; // для счета не  нулевых строк 

            for (int i = 0; i < trMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < trMatrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        x++;
                        break;
                    }
                }
            }
            return x;
        }

        /// <summary>
        /// Нахождение обратной матрицы
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static double[,] ReverseMatrix(double[,] matrix)
        {
            Console.WriteLine("Определитель");
            double detMatrix = DeterminantMatrix(matrix);
            if (detMatrix == 0)
                throw new Exception("Матрица с нулевым определителем");

            double[,] _matrivC = new double[matrix.GetLength(0), matrix.GetLength(1)];


            Console.WriteLine("Обратная матрица");

            //  получаем каждый элемент  этой  матрицы_matrivC 
            int step = 0;
            for (int i = 0; i < _matrivC.GetLength(0); i++)
            {
                for (int j = 0; j < _matrivC.GetLength(0); j++)
                {
                    _matrivC[i, j] = MetodUnionMatrix(matrix, i, j, step);
                    step++;
                }
            }

            var matrixT = TransposeMatrix(_matrivC); // Транспонируем 

            return MatrixMultiplyingByNumber(matrixT, 1.0 / detMatrix); // умножаем  на 1/ det
        }

        // приватные методы

        /// <summary>
        /// находим Элементы новой матрицы что  бы найти  обратную матрицу  (для обратной матрицы)
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="step"></param>
        /// <returns></returns>
        private static double MetodUnionMatrix(double[,] matrix, int i, int j, int step)
        {
            double[,] newMatrix = GetNewMatrix(matrix, i, j);

            double detnewMatrix = DeterminantMatrix(newMatrix);

            if (step % 2 == 0)
                return detnewMatrix;
            else
                return detnewMatrix * -1;
        }

        /// <summary>
        /// находит  новую матрицу исключая  строку  и столбец в  зависимости  от  индекса (для обратной матрицы)
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="irow"></param>
        /// <param name="jColum"></param>
        /// <returns></returns>
        private static double[,] GetNewMatrix(double[,] matrix, int irow, int jColum)
        {
            double[,] newMatrix = new double[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
            int x = 0;
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int y = 0;

                if (i == irow)
                {
                    x = 1;
                    continue;
                }

                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (jColum == j)
                    {
                        y = 1;
                        continue;
                    }

                    newMatrix[i - x, j - y] = matrix[i, j];
                }
            }
            
            Console.WriteLine();
            PrintMatrix(newMatrix);
            return newMatrix;
        }
    }
}
