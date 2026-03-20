using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class Task1
    {
        public struct Number : INumber
        {
            private double _value;

            public double Real => _value;
            public double Abs => Math.Abs(_value);
            public int Sign
            {
                get
                {
                    if (_value > 0) return 1;
                    else if (_value < 0) return -1;
                    else
                    {
                        return 0;
                    }
                }
            }

            public Number(double number)
            {
                _value = number;
            }

            public void Sum(INumber other)
            {
                _value += other.Real;
            }
            public void Sub(INumber other)
            {
                _value -= other.Real;
            }
            public void Mul(INumber other)
            {
                _value *= other.Real;
            }
            public void Div(INumber other)
            {
                _value /= other.Real;
            }
            public void Neg()
            {
                _value = -_value;
            }
            public void Print()
            {
                Console.WriteLine(_value);
            }
        }
    }
}
