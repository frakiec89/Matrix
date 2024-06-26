﻿// track

namespace ConsoleApp38
{
    internal partial class MatrixService
    {
        // основные методы (умножение , сложение , вычитание, транспонирование)
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
        /// Умножение  матриц
        /// </summary>
        /// <param name="M1"></param>
        /// <param name="M2"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Сложение двух матриц
        /// </summary>
        /// <param name="M1"></param>
        /// <param name="M2"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static double[,] MatrixAddition(double[,] M1, double[,] M2)
        {
            if (M1.GetLength(0) != M2.GetLength(0) || M1.GetLength(1) != M2.GetLength(1))
                throw new Exception("Размеры матриц должны быть одинаковыми.");

            double[,] resMatrix = new double[M1.GetLength(0), M1.GetLength(1)];

            for (int i = 0; i < M1.GetLength(0); i++)
            {
                for (int j = 0; j < M1.GetLength(1); j++)
                {
                    resMatrix[i,j] = M1[i, j] + M2[i, j];
                }
            }
            return resMatrix;
        }

        /// <summary>
        /// Вычитание матриц
        /// </summary>
        /// <param name="M1"></param>
        /// <param name="M2"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static double[,] MatrixSubtraction(double[,] M1, double[,] M2)
        {
            if (M1.GetLength(0) != M2.GetLength(0) || M1.GetLength(1) != M2.GetLength(1))
                throw new Exception("Размеры матриц должны быть одинаковыми.");

            double[,] resMatrix = new double[M1.GetLength(0), M1.GetLength(1)];

            for (int i = 0; i < M1.GetLength(0); i++)
            {
                for (int j = 0; j < M1.GetLength(1); j++)
                {
                    resMatrix[i, j] = M1[i, j] - M2[i, j];
                }
            }
            return resMatrix;
        }

        /// <summary>
        /// Транспонирование матрицы
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static double[,] TransposeMatrix(double[,] matrix)
        {
            double[,] tMatrix = new double[matrix.GetLength(1), matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    tMatrix[j, i] = matrix[i, j];
                }
            }
            return tMatrix;
        }

        // Доп методы (вывод на экран, ручной ввод, случайная матрица , статичная матрица)

        /// <summary>
        /// Вывод матрицы на экран  (пригодится)
        /// </summary>
        /// <param name="matrix"></param>
        public static void PrintMatrix(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++) // рамка (чтобы красиво)
            {
                if (i == 0)
                {
                    for (int k = 0; k <= matrix.GetLength(1); k++)
                    {
                        Console.Write($"_____");
                    }
                    Console.WriteLine();
                }

                for (int j = 0; j < matrix.GetLength(1); j++) // сама матрица
                {
                    if(j == 0 )
                        Console.Write($"|");

                    Console.Write( $"{Math.Round(matrix[i, j] , 3),5} " ); // запас пять  символов запас 
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Генерация матрицы (ручной ввод) + (вывод на  экран результата)
        /// </summary>
        /// <param name="matrix"></param>
        public static double[,] SetMatrix(int  row , int  colum )
        {
            double [,] resMatrix = new double[row, colum];

            Console.WriteLine("Создание  новой матрицы");

            for (int i = 0; i < resMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < resMatrix.GetLength(1); j++)
                {
                    resMatrix[i, j] =  GetDouble($"Введите  элемент  матрицы с  индексом [{i + 1 },{j + 1 }]");
                }
            }

            Console.WriteLine("Итоговая матрица:") ;
            PrintMatrix(resMatrix);
            return resMatrix;
        }

        /// <summary>
        /// Случайная  матрица (пригодится)
        /// </summary>
        /// <param name="row"></param>
        /// <param name="colum"></param>
        /// <returns></returns>
        public static double[,] RandomMatrix(int row, int colum)
        {
            Random random = new Random();

            double[,] massiv = new double[row, colum];

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
        /// статичная  матрица  - для опытов 
        /// </summary>
        /// <returns></returns>
        public static double[,] MatricStatic()
        {
            var r = new double[,]
            {
                {  2, 0, 3 },
                {  4, 0, 4 },
                {  3, 3, 1 }
            };

            PrintMatrix(r);
            return r;
        }

        // приватные методы 
        /// <summary>
        /// Находит  элемент  при умножении  матрицы
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <param name="colum"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private static double GetElement(double[,] m1, double[,] m2, int colum, int row)
        {
            double res = 0;
            for (int i = 0; i < m2.GetLength(0); i++)
            {
                var r = m1[colum, i];
                var r2 = m2[i, row];

                res += r * r2;
            }
            return res;
        }

        /// <summary>
        /// обработка ввода числа  с клавиатуры
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private static double GetDouble(string message)
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
    }
}
