using System.Collections.Generic;
using System.Linq;

namespace WebExtensions.Net.Generator.Extensions
{
    public static class ThreeDimensionalArrayExtensions
    {
        public static IEnumerable<IEnumerable<T>> GetCombinations<T>(this IEnumerable<IEnumerable<T>> arrays)
        {
            if (!arrays.Any())
            {
                return arrays;
            }
            if (arrays.Count() == 1)
            {
                return arrays.First().Select(item => new[] { item }).ToArray();
            }
            var firstArray = arrays.First();
            var restArray = arrays.Skip(1).ToArray();
            var combinations = firstArray.SelectMany(item =>
            {
                var restCombinations = GetCombinations(restArray);
                return restCombinations.Select(array => new[] { item }.Concat(array)).ToArray();
            }).ToArray();
            return combinations;
        }
    }
}
