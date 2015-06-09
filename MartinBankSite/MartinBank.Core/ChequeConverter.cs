using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MartinBank.Core
{
    public class ChequeConverter
    {
        public static string NumericAmountToWords(double amount)
        {
            const string amountInWordsTemplate = "{0} dollars and {1} cents";
            string decimalsInWords = "zero";
            string integerInWords = "";

            var str = new StringBuilder(amount.ToString(CultureInfo.InvariantCulture));
            str = str.Replace(" ", "").Replace(",", "");
            string amountAsStr = str.ToString();

            int decimalPointIndex = amountAsStr.IndexOf('.');
            bool hasDecimals = decimalPointIndex > 0;

            if (hasDecimals)
            {
                decimalsInWords = ConvertNumbericValue(amountAsStr.Substring(decimalPointIndex + 1));
                integerInWords = amountAsStr.Substring(0, decimalPointIndex);
            }
            else
            {
                integerInWords = amountAsStr;
            }
            
            return string.Format(amountInWordsTemplate, ConvertNumbericValue(integerInWords), decimalsInWords);
        }

        private static string ConvertNumbericValue(string numeric)
        {
            int numberOfDigits = numeric.Length;
            switch (numberOfDigits)
            {
                case 1: return _numbersBetweenZeroAndTenInclusive[numeric];
                case 2: return ConvertTwoDigitsToWord(numeric);
                default:
                    foreach (var key in _numberDigitsAndDescription.Keys)
                    {
                        if (!key.Contains(numberOfDigits.ToString()))
                        {
                            continue;
                        }

                        long partialAmount = Convert.ToInt64(numeric);
                        string[] values = _numberDigitsAndDescription[key].Split('|');
                        string largeNumberWord = values[0];
                        long divisor = Convert.ToInt64(1.ToString().PadRight(Convert.ToInt32(values[1]), '0'));
                        string str1 = (partialAmount / divisor).ToString();
                        string str2 = (partialAmount % divisor).ToString();
                        
                        return string.Format("{0} {1} and {2}", ConvertNumbericValue(str1), largeNumberWord, ConvertNumbericValue(str2));
                    }
                    break;
            }

            return string.Empty;
        }

        private static string ConvertTwoDigitsToWord(string num)
        {
            if (_multipleTens.ContainsKey(num))
            {
                return _multipleTens[num];
            }

            if (_numbersBetweenTenAndTwentyExclusive.ContainsKey(num))
            {
                return _numbersBetweenTenAndTwentyExclusive[num];
            }

            var numberInTens = num.Substring(0, 1).PadRight(2, '0');
            return string.Format("{0} {1}", _multipleTens[numberInTens], _numbersBetweenZeroAndTenInclusive[num.Substring(1)]);
        }

        #region >> Data

        private static readonly IDictionary<string, string> _numbersBetweenZeroAndTenInclusive = new Dictionary<string, string>
        {
            {"0", "Zero"}, 
            {"1", "One"},
            {"2", "Two"},
            {"3", "Three"},
            {"4", "Four"},
            {"5", "Five"},
            {"6", "Six"},
            {"7", "Seven"},
            {"8", "Eight"},
            {"9", "Nine"}
        };

        private static readonly IDictionary<string, string> _numbersBetweenTenAndTwentyExclusive = new Dictionary<string, string>
        {
            {"11", "Eleven"},
            {"12", "Twelve"},
            {"13", "Thirteen"},
            {"14", "Fourteen"},
            {"15", "Fifteen"},
            {"16", "Sixteen"},
            {"17", "Seventeen"},
            {"18", "Eighteen"},
            {"19", "Nineteen"}
        };

        private static readonly IDictionary<string, string> _multipleTens = new Dictionary<string, string>
        {
            {"10", "Ten"},
            {"20", "Twenty"},
            {"30", "Thirty"},
            {"40", "Fourty"},
            {"50", "Fifty"},
            {"60", "Sixty"},
            {"70", "Seventy"},
            {"80", "Eighty"},
            {"90", "Ninety"}
        };

        private static readonly IDictionary<string, string> _numberDigitsAndDescription = new Dictionary<string, string>
        {
            {"3", "Hundred|3"},
            {"456", "Thousand|4"},
            {"789", "Million|7"},
            {"10", "Billion|10"}
        };

        #endregion
    }
}
