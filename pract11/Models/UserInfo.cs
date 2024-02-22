using pract11.DataAnnotationsExample.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract11.Models
{
    public class UserInfo
    {
        [Required(ErrorMessage = "Укажите имя")]
        [RegularExpression(@"[a-zA-Z0-9_]+",
            ErrorMessage = "Имя пользователя может содержать только латинские буквы, цифры и символ подчеркивания")]
        public string Username { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Введите корректный Email")]
        public string Email { get; set; } = string.Empty;

        [StrongPassword]
        public string Password { get; set; } = string.Empty;

        [Compare(nameof(Password), ErrorMessage = "Пароли не совпадают")]
        public string RepeatPassword { get; set; } = string.Empty;
    }
}
