using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FigureArea
{
    public abstract class Figure
    {
        private readonly IDictionary<string, object> _parameters;

        protected Figure(IDictionary<string, object> parameters)
        {
            _parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
        }

        public double OnCalculate()
        {
            Validate();
            return Calculate(_parameters);
        }

        private void Validate()
        {
            if (!_parameters.Any())
                throw new ValidationException("Пустые параметры");
        }

        protected void ValidateRequiredParameters(params string[] parameterNames)
        {
            foreach (var name in parameterNames)
            {
                if (!_parameters.TryGetValue(name, out var value))
                    throw new InvalidOperationException($"Не найден обязательный параметр #{name}");

                if (value == null)
                   throw new ArgumentNullException($"аргумент #{name} не может быть пустым");
            }
        }

        protected abstract double Calculate(IDictionary<string, object> param);
    }
}