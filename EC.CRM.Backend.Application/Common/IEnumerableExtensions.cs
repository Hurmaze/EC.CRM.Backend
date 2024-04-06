namespace EC.CRM.Backend.Application.Common
{
    public static class IEnumerableExtensions
    {
        public static bool IsNullOrEmpty(this IEnumerable<string> values) => values == null || values.Any();
    }
}
