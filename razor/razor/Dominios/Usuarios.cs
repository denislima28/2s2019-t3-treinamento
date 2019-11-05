using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace razor.Dominios
{
    public partial class Usuarios
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o seu e-mail")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a sua senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
