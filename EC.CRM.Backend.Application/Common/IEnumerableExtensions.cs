namespace EC.CRM.Backend.Application.Common
{
    public static class IEnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> values) => values == null || !values.Any();
        public static string Join<T>(this IEnumerable<T> values, string separator) => string.Join(separator, values);
    }
}
