using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class Task2
    {
        public class Number : INumber
        {
            protected double _value;

            public double Real => _value;
            public virtual double Abs => Math.Abs(_value);
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

            public virtual void Sum(INumber other)
            {
                _value += other.Real;
            }
            public virtual void Sub(INumber other)
            {
                _value -= other.Real;
            }
            public virtual void Mul(INumber other)
            {
                _value *= other.Real;
            }
            public virtual void Div(INumber other)
            {
                _value /= other.Real;
            }
            public virtual void Neg()
            {
                _value = -_value;
            }
            public virtual void Print()
            {
                Console.WriteLine(_value);
            }
        }
        public class ComplexNumber : Number, IComplexNumber
        {
            private double _imaginary;
            public double Imaginary => _imaginary;
            public int ISign
            {
                get
                {
                    if (_imaginary > 0) return 1;
                    else if (_imaginary < 0) return -1;
                    else
                    {
                        return 0;
                    }
                }
            }
            public override double Abs
            {
                get
                {
                    return Math.Sqrt(Math.Pow(_value, 2) + Math.Pow(_imaginary, 2));
                }
            }
            public ComplexNumber(double real, double imaginary) : base(real)
            {
                _imaginary = imaginary;
            }
            public ComplexNumber(Number number) : base(number.Real)
            {
                if (number is ComplexNumber complex)
                {
                    _imaginary = complex.Imaginary;
                }
                else
                {
                    _imaginary = 0;
                }
            }

            public override void Sum(INumber other)
            {
                base.Sum(other);
                if (other is ComplexNumber complex)
                {
                    _imaginary += complex.Imaginary;
                }
            }
            public override void Sub(INumber other)
            {
                base.Sub(other);
                if (other is ComplexNumber complex)
                {
                    _imaginary -= complex.Imaginary;
                }
            }
            public override void Mul(INumber other)
            {
                base.Mul(other);
                if (other is ComplexNumber complex)
                {
                    _imaginary *= complex.Imaginary;
                }
            }
            public override void Div(INumber other)
            {
                base.Div(other);
                if (other is ComplexNumber complex)
                {
                    _imaginary /= complex.Imaginary;
                }
            }
            public override void Neg()
            {
                base.Neg();
                _imaginary = -_imaginary;
            }
        }
        public class List : IList
        {
            private int _count;
            private readonly string _id;
            private INumber[] _numbers;
            public INumber[] Numbers => _numbers.ToArray();
            public string ID => _id;

            public List()
            {
                string year = DateTime.Now.Year.ToString();
                _id = $"{year}00{_count:D8}";
                _count++;
            }

            public void Add(INumber number)
            {

            }
            public void Add(INumber[] number)
            {

            }
            public INumber[] GetPositive()
            {
                return new INumber[0];
            }
        }
    }
}
