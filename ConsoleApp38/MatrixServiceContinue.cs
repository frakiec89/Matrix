using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp38
{
    internal partial class MatrixService
    {
        internal static double DeterminantMatrix(double[,] m1)
        {
            if (m1.GetLength(0) != m1.GetLength(1))
                throw new ArgumentException("матрица должна быть квадратной");


            if(m1.GetLength(0) == 1)
                return m1[0,0];


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

            throw new ArgumentException("Я не  умею");

        }

        private static double GetDeterminant3x3(double[,] m1)
        {
            double x1 = m1[0, 0] * m1[1, 1] * m1[2, 2];
            double x2 = m1[0,1] * m1[1, 2] * m1[2, 0];
            double x3 = m1[0, 2] * m1[1, 0] * m1[2, 1];

            double x4 = m1[0, 2] * m1[1, 1] * m1[2, 0];
            double x5 = m1[0, 0] * m1[1, 2] * m1[2, 1];

            double x6 = m1[0, 1] * m1[1, 0] * m1[2, 2];

            return x1 + x2 + x3 - x4 - x5 - x6;

        }
    }
}
