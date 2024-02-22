using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract11.DataAnnotationsExample.Annotations
{
    public class StrongPasswordAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            bool lowerCaseSymbol = false;
            bool upperCaseSymbol = false;
            bool numericSymbol = false;
            bool specSymbol = false;
            string password = value?.ToString() ?? string.Empty;
            foreach (Char symbol in password)
            {
                if (Char.IsLetter(symbol))
                {
                    if (Char.ToUpper(symbol) == symbol)
                        upperCaseSymbol = true;
                    else
                        lowerCaseSymbol = true;
                }
                else if (Char.IsNumber(symbol))
                    numericSymbol = true;
                else if (Char.IsSymbol(symbol))
                    specSymbol = true;
            }

            if (!lowerCaseSymbol)
            {
                ErrorMessage = "Пароль должен содержать буквы в нижнем регистре";
                return false;
            }
            else if (!upperCaseSymbol)
            {
                ErrorMessage = "Пароль должен содержать буквы в верхнем регистре";
                return false;
            }
            else if (!numericSymbol)
            {
                ErrorMessage = "Пароль должен содержать цифру";
                return false;
            }
            else if (!specSymbol)
            {
                ErrorMessage = "Пароль должен содержать спец. символ";
                return false;
            }
            else
                return true;
        }
    }
}
    
