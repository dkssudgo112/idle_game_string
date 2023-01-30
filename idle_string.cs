
using System;


namespace NX.Data
{
    public struct Big
    {
        public Big(double value)
        {
            Value = value;
        }

        public double Value { get; set; }

        #region operator+

        public static Big operator +(Big big1, Big big2)
        {
            return new Big(big1.Value + big2.Value);
        }

        public static Big operator +(double value, Big big)
        {
            return new Big(value + big.Value);
        }

        public static Big operator +(Big big, double value)
        {
            return new Big(big.Value + value);
        }

        #endregion

        #region operator-
        public static Big operator -(Big big1, Big big2)
        {
            return new Big(big1.Value - big2.Value);
        }

        public static Big operator -(double value, Big big)
        {
            return new Big(value - big.Value);
        }

        public static Big operator -(Big big, double value)
        {
            return new Big(big.Value - value);
        }
        #endregion

        #region operator*
        public static Big operator *(Big big1, Big big2)
        {
            return new Big(big1.Value * big2.Value);
        }

        public static Big operator *(Big big, double value)
        {
            return new Big(big.Value * value);
        }

        public static Big operator *(double value, Big big)
        {
            return new Big(value * big.Value);
        }

        #endregion

        #region operator/
        public static Big operator /(Big big1, Big big2)
        {
            return new Big(big1.Value / big2.Value);
        }

        public static Big operator /(double value, Big big)
        {
            return new Big(value / big.Value);
        }

        public static Big operator /(Big big, double value)
        {
            return new Big(big.Value / value);
        }
        #endregion

        #region operator>=
        public static bool operator >=(Big big1, Big big2)
        {
            return big1.Value >= big2.Value;
        }

        public static bool operator >=(double value, Big big)
        {
            return value >= big.Value;
        }

        public static bool operator >=(Big big, double value)
        {
            return big.Value >= value;
        }


        public static bool operator >=(int value, Big big)
        {
            return value >= big.Value;
        }

        public static bool operator >=(Big big, int value)
        {
            return big.Value >= value;
        }
        #endregion

        #region operator<=
        public static bool operator <=(Big big1, Big big2)
        {
            return big1.Value <= big2.Value;
        }

        public static bool operator <=(double value, Big big)
        {
            return value <= big.Value;
        }

        public static bool operator <=(Big big, double value)
        {
            return big.Value <= value;
        }

        public static bool operator <=(int value, Big big)
        {
            return value <= big.Value;
        }

        public static bool operator <=(Big big, int value)
        {
            return big.Value <= value;
        }
        #endregion

        public override string ToString()
        {
            var exp = (int)Math.Log(Value, 1000);
            var displayNum = Value / Math.Pow(1000, exp);
            var unit = "";
            var displayStr = "";
            if (exp < 1)
            {
                displayStr = Value.ToString("G5");

            }
            else if (exp <= 25)
            {
                unit = (exp % 25) < 15 ? Convert.ToChar((exp % 25) + 64).ToString() : Convert.ToChar((exp % 25) + 65).ToString();
                if (exp % 25 == 0) { unit = "Z"; }
                displayStr = displayNum.ToString("G5");
            }
            else
            {
                var secondUnit = (exp % 25) < 15 ? Convert.ToChar((exp % 25) + 64) : Convert.ToChar((exp % 25) + 65);
                if (exp % 25 == 0) { secondUnit = 'Z'; }
                var firstUnit = ((exp - 1) / 25) < 15 ? Convert.ToChar(((exp - 1) / 25) + 64) : Convert.ToChar(((exp - 1) / 25) + 65);
                unit = firstUnit.ToString() + secondUnit.ToString();
                displayStr = displayNum.ToString("G5");
            }
            if (displayStr.Length >= 5)
            {

                displayStr = displayStr[..^2];
                if (displayStr[^1] == '.')
                {
                    displayStr = displayStr[..^1];
                }

            }


            return displayStr + unit;
        }

        public static explicit operator Big(string text)
        {
            return Parse(text);
        }

        public static implicit operator Big(double value)
        {
            return new Big(value);
        }

        public static implicit operator Big(float value)
        {
            return new Big(value);
        }

        public static implicit operator Big(int value)
        {
            return new Big(value);
        }

        public static implicit operator double(Big big)
        {
            return big.Value;
        }

        public static implicit operator int(Big big)
        {
            return (int)big.Value;
        }

        public static Big Parse(string text)
        {
            var result = 0d;
            if (Char.IsLetter(text[^1]))
            {
                var firstUnit = Convert.ToInt32(text[^1]) - 64;
                firstUnit = firstUnit < 15 ? firstUnit : firstUnit - 1;
                if (Char.IsLetter(text[^2]))
                {
                    var secondUnit = Convert.ToInt32(text[^2]) - 64;
                    secondUnit = secondUnit < 15 ? secondUnit : secondUnit - 1;
                    result = Convert.ToDouble(text[..^2]) * Math.Pow(Math.Pow(1000, 25), secondUnit) * Math.Pow(1000, firstUnit);
                    return new Big(result);
                }
                result = Convert.ToDouble(text[..^1]) * Math.Pow(1000, firstUnit);
                return new Big(result);
            }
            else
            {
                result = Convert.ToDouble(text);
                return new Big(result);
            }
        }
    }
}
