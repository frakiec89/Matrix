// nocopy

namespace ConsoleApp38
{
    internal class MatrixService
    {

        /// <summary>
        /// Умножение  матрицы на число
        /// </summary>
        /// <param name="matrix">исходная матрица</param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static double[ , ] MatrixMultiplyingByNumber (double[,] matrix , int  number  )
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = matrix[i, j] * number;
                }
            }
            return matrix;
        }

       
        /// <summary>
        /// Случайная  матрица
        /// </summary>
        /// <param name="row"></param>
        /// <param name="colum"></param>
        /// <returns></returns>
        public static double[,] RandomMatrix ( int row , int  colum  )
        {
            Random random = new Random();

            double[,] massiv = new double[row , colum ];

            for (int i = 0; i < massiv.GetLength(0); i++)
            {
                for (int j = 0; j < massiv.GetLength(1); j++)
                {
                    massiv[i, j] = random.Next(5);
                }
            }
            return massiv;
        }

        /// <summary>
        /// Вывод матрицы на экран 
        /// </summary>
        /// <param name="matrix"></param>
        public static void PrintMatrix(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }


        public static double[,] MatrixMultiplication (double[,] M1 , double[,] M2)
         {
            if (M1.GetLength(1) != M2.GetLength(0))
                throw new Exception("Количество столбцов первой матрицы должно равняться количеству строк второй.");

            double[,] resMatrix = new double[M1.GetLength(0), M2.GetLength(1)];


            for (int i = 0; i < M1.GetLength(0); i++)
            {
                for (int j = 0; j < M2.GetLength(1); j++)
                {
                    resMatrix[i, j] = GetElement(M1, M2, i, j);
                }
            }

            return resMatrix;
        }

        private static double GetElement(double[,] m1, double[,] m2, int colum, int row)
        {
            double res = 0;
            for (int i = 0; i < m2.GetLength(0); i++)
            {
                var r = m1[colum, i];
                var r2 = m2[ i , row];

                res += r * r2;
            }
            return res;
        }
    }
}
