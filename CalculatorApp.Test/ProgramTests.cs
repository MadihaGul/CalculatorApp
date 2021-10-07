using System;
using Xunit;
using CalculatorApp;

namespace CalculatorApp.Test
{
    public class ProgramTests
    {
        
        double a = 10.0, b = 4.0;
        [Fact]
        public void AdditionTests()
        {
            double[] values = { 1, 5, 6, 7, 4, 9, 10 };
            double sum =42;

            double ansMultipleValues = Program.Addition(values);
            double ans = Program.Addition(a, b);
            
            Assert.Equal(ansMultipleValues, sum );
            Assert.Equal(ans, a+b);
            
        }

        [Fact]
        public void SubtractionTests()
        {
            double[] values = { 1, 5, 6, 7, 4, 9, 10 };
            double difference = -40;

            double ansMultipleValues = Program.Subtraction(values);
            double ans=Program.Subtraction(a, b);

            Assert.Equal(ansMultipleValues, difference);
            Assert.Equal(ans, a - b);
        }

        [Fact]
        public void MultiplicationTests()
        {
            double product = a*b;
            double ans = Program.Multiplication(a, b);
            Assert.Equal(ans, product);
        }

        [Fact]
        public void DivisionTests()
        {
            double quotient = a / b;

            Assert.False(Program.Division(a, b, out double ans));
            Assert.Equal( ans, quotient);
            Assert.False(double.IsInfinity(ans));

            Assert.True(Program.Division(a, 0, out double ansInvalid));
            Assert.False(double.IsInfinity(ansInvalid));
        }

        [Fact]
        public void ModuloTests()
        {
            double mod = a % b;
            double ans=Program.Modulo(a, b);
            Assert.Equal(ans, mod);
        }
        [Fact]
        public void PowerTests()
        {
            double powerRaised = 10000;//a ^ b;
            double ans = Program.Power(a, b);
            Assert.Equal(ans, powerRaised);
        }

        [Fact]
        public void SquareTests()
        {
            double aSquareActual = 100;//a =10
            double bSquareActual = 16;//b =4
            double aSquare = Program.Square(a);
            double bSquare = Program.Square(b);

            Assert.Equal(aSquare, aSquareActual);
            Assert.Equal(bSquare, bSquareActual);
        }

        [Fact]
        public void SquareRootTests()
        {
            double bSqrt = 2;//b=4
            double ans = Program.SquareRoot(b);
            Assert.Equal(ans, bSqrt);
        }

        [Fact]
        public void UnitByNumTests()
        {
            double unitByNum = 0.25;//b=4
            double ans = Program.UnitByNum(b);
            Assert.Equal(ans, unitByNum);
        }

        [Fact]
        public void NumFactTests()
        {
            double factNum = 24;//b=4
            double ans = Program.NumFact(b);
            Assert.Equal(ans, factNum);
        }

        [Fact]
        public void NumLogTests()
        {
            double logNum = 1;//a=10
            double ans = Program.NumLog(a);
            Assert.Equal(ans, logNum);
        }

        [Fact]
        public void NumLnTests()
        {
            double lnNum = 2.3025850929940456840179914546844;//a=10
            double ans = Program.NumLn(a);
            Assert.Equal(ans, lnNum);
        }
    }
}
