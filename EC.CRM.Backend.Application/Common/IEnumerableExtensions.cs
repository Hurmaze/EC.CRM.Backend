namespace EC.CRM.Backend.Application.Common
{
    public static class IEnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> values) => values == null || !values.Any();
    }
}
