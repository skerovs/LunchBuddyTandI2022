using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Conditions;
using System.Text;

namespace DfdsLunchBuddy.Domain.Extensions
{
    /// <summary>
    /// Adds extension methods to the <see cref="string" /> class.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Converts the specified string to title case.
        /// </summary>
        /// <param name="instance">The current instance.</param>
        /// <returns>The specified string converted to title case.</returns>
        /// <remarks>The current implementation of the ToTitleCase method provides an arbitrary casing behavior which is not necessarily linguistically correct.</remarks>
        public static string ToTitleCase(this string instance)
        {
            instance.Requires(nameof(instance)).IsNotNull();
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(instance.ToLower());
        }
    }
}