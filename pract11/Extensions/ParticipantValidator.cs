using FluentValidation;
using pract11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract11.Extensions
{
    public class ParticipantValidator : AbstractValidator<Participant>
    {
        public ParticipantValidator()
        {
            RuleFor(p => p.Fullname)
                .NotEmpty()
                .WithMessage("Имя не может быть пустым")
                .Must(name => name.All(c => char.IsLetter(c) || c == ' ' || c == '-' || c == '\''))
                .WithMessage("Имя может содержать только буквы, дефисы, апострофы и пробелы");
            RuleFor(p => p.Email)
                .EmailAddress()
                .WithMessage("Введите корректный email адрес");
            RuleFor(p => p.Age)
                .LessThan(110)
                .WithMessage("Возраст не может превышать 110 лет")
                .GreaterThanOrEqualTo(18)
                .WithMessage("Возраст не может быть меньше 18 лет");
        }
    }   
}
