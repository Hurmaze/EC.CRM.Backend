namespace EC.CRM.Backend.Application.Common.Extensions
{
    internal static class MatrixExtensions
    {
        internal static void PrintMatrix(this double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{matrix[i, j]:F6}  ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        internal static void PrintMatrix(this double[] matrix)
        {
            int rows = matrix.GetLength(0);

            for (int i = 0; i < rows; i++)
            {
                Console.Write($"{matrix[i]:F6}  ");
            }
            Console.WriteLine();
        }
        internal static void PrintMatrix(this bool[] matrix)
        {
            int rows = matrix.GetLength(0);

            for (int i = 0; i < rows; i++)
            {
                Console.Write($"{matrix[i]}  ");
            }
            Console.WriteLine();
        }
    }
}
