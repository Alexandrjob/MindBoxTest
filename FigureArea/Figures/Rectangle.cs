using System;
using System.Collections.Generic;
using FigureArea.Parameters;

namespace FigureArea.Figures
{
    public class Rectangle : Figure
    {
        public Rectangle(IDictionary<string, object> parameters) : base(parameters)
        {
        }

        protected override double Calculate(IDictionary<string, object> parameters)
        {
            ValidateRequiredParameters(ParameterKeys.Length, ParameterKeys.Width);

            if (parameters[ParameterKeys.Length] is double length && parameters[ParameterKeys.Width] is double width)
            {
                return length * width;
            }

            throw new InvalidOperationException($"Неверный тип параметра");
        }
    }
}