namespace EC.CRM.Backend.Application.Services.Implementation.TOPSIS
{
    public static class MatrixExtension
    {
        public static T[] GetColumn<T>(this T[,] matrix, int columnNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(0))
                    .Select(x => matrix[x, columnNumber])
                    .ToArray();
        }

        public static T[] GetRow<T>(this T[,] matrix, int rowNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(1))
                    .Select(x => matrix[rowNumber, x])
                    .ToArray();
        }

        public static void SetRow<T>(this T[,] matrix, int rowIndex, IEnumerable<T> values)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (matrix.GetLength(1) != values.Count())
                throw new ArgumentException("The length of values must match the number of columns in the matrix");

            for (int i = 0; i < values.Count(); i++)
            {
                matrix[rowIndex, i] = values.ElementAt(i);
            }
        }
    }
}
