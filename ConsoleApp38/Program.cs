
// track



using ConsoleApp38;

double[,] m1 = new double[,]
{
    { 1, 2, },
    { 4, 5  },
    { 7, 8 }
};

double[,] m2 = new double[,]
{
    { 10, 11   },
    { 13, 14   }
  
};

var  res = MatrixService.MatrixMultiplication(m1, m2);

MatrixService.PrintMatrix(res);