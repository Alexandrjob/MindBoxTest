using FigureArea.Figures;
using FigureArea.Parameters;
using System;
using System.Collections.Generic;
using Xunit;

namespace FigureArea.Test
{
    public class FigureAreaTests
    {
        [Fact]
        public void CheckingAreaCircle()
        {
            const double expectedValue = 78.53981633974483;

            var parameters = new Dictionary<string, object>
            {
                {ParameterKeys.Radius, 5.0}
            };

            var sut = new Circle(parameters);
            var result = sut.OnCalculate();

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void CheckingAreaRectangle()
        {
            const double expectedValue = 24;

            var parameters = new Dictionary<string, object>
            {
                { ParameterKeys.Length, 6D },
                { ParameterKeys.Width, 4D }
            };

            var sut = new Rectangle(parameters);
            var result = sut.OnCalculate();

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void CheckingAreaTriangle()
        {
            const double expectedValue = 12.0;

            var parameters = new Dictionary<string, object>
            {
                {ParameterKeys.Triangle, new TriangleParameter(5, 6, 5)}
            };

            var sut = new Triangle(parameters);
            var result = sut.OnCalculate();

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void CheckingRightAngledTriangle()
        {
            const double expectedValue = 6;

            var parameters = new Dictionary<string, object>
            {
                {ParameterKeys.Triangle, new TriangleParameter(4, 5, 3)}
            };

            var sut = new Triangle(parameters);
            var result = sut.OnCalculate();
            var isRight = sut.IsRight;

            Assert.Equal(expectedValue, result);
            Assert.True(isRight);
        }

        [Fact]
        public void CheckingException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var parameters = new Dictionary<string, object>
                {
                    {ParameterKeys.Radius, 5.0}
                };

                var sut = new Triangle(parameters);
                sut.OnCalculate();
            });
        }

        [Fact]
        public void CheckingAreaUnknownFigure()
        {
            const double expectedValue = 78.53981633974483;

            Func<IDictionary<string, object>, double> func = parameters =>
            {
                if (!parameters.TryGetValue(ParameterKeys.Radius, out var value))
                    throw new KeyNotFoundException($"Ключ #{ParameterKeys.Radius} не найден ");

                if (value is double radius)
                {
                    return Math.PI * Math.Pow(radius, 2);
                }

                throw new InvalidOperationException($"Неверный тип параметра {ParameterKeys.Radius}");
            };

            var unknownFigureParameters = new Dictionary<string, object>
            {
                {ParameterKeys.Radius, 5.0},
                {ParameterKeys.Func, func}
            };

            var sut = new UnknownFigure(unknownFigureParameters);
            var result = sut.OnCalculate();

            Assert.Equal(expectedValue, result);
        }
    }
}
