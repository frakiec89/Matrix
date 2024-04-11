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
        public static double[ , ] MatrixMultiplyingByNumber (double[,] matrix , double  number  )
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

    }
}
