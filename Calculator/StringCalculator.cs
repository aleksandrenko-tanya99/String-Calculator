using OpenXmlPowerTools;
using SolrNet.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class StringCalculator
    {

        public int Add(string numbers)
        {
            var delimiters = ",\n";

            if (string.IsNullOrEmpty(numbers)) { return 0; }

            if (numbers.Contains("//"))
            {
                delimiters += numbers[2];
                numbers = numbers.Substring(4,numbers.Length-4);
            }

            var items = numbers.Split(delimiters.ToCharArray());
            if (items.Any(x => string.IsNullOrEmpty(x)))
                throw new ArgumentException();

            var integers = items.Select(x => int.Parse(x));
            var negatives = integers.Where(x => x < 0);
            if (negatives.Count() > 0)
            {
                var message = "Negatives not allowed: {0}";
                throw new ArgumentOutOfRangeException(string.Format(message,
                    string.Join(",",negatives.Select(x=>x.ToString()).ToArray())));
            }

            return items
            .Select(x=>int.Parse(x)).Sum();


        }
        
        static void Main(string[] args)
        {

        }
    }
}
