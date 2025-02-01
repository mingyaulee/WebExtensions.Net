namespace Shouldly
{
    public static class ShouldlyExtensions
    {
        public static void ShouldNotBeNullOrEmpty<T>(this IEnumerable<T> actual)
        {
            actual.ShouldNotBeNull();
            actual.ShouldNotBeEmpty();
        }

        public static void ShouldHaveCount<T>(this IEnumerable<T> actual, int count)
        {
            actual.Count().ShouldBe(count);
        }

        public static void ShouldHaveValue<T>(this T? actual)
            where T : struct
        {
            actual.HasValue.ShouldBeTrue();
        }

        public static void ShouldBeFalse(this bool? actual)
        {
            actual.ShouldBe(false);
        }

        public static void ShouldBeCloseTo(this DateTime actual, DateTime expected, TimeSpan precision)
        {
            actual.ShouldBeInRange(expected - precision, expected + precision);
        }
    }
}
