using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

namespace BookStore.Extension
{
    public static class Extensions
    {
        public static string ToTitleCase(this string str)
        {
            var CultureInfo = Thread.CurrentThread.CurrentCulture;
            return CultureInfo.TextInfo.ToTitleCase(str.ToLower().Trim());
        }

        public static string TrimSpaces(this string str)
        {
            string result = string.Empty;

            if (!string.IsNullOrWhiteSpace(str))
            {
                foreach (char letter in str)
                {
                    if (char.IsUpper(letter))
                    {
                        result = result.Trim();
                    }
                    result += letter;
                }
                result = result.Trim();
            }

            return result;
        }

        public static ObservableCollection<T> ToObservableCollection<T>
            (this IEnumerable<T> data)
        {
            var c = new ObservableCollection<T>();
            foreach (var item in data)
                c.Add(item);

            return c;
        }

    }
}
