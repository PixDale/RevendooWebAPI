using System;
using System.Collections.Generic;

namespace RevendooWebAPI.Models
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string NomeCompleto { get; set; }
        public string Senha { get; set; }
        public string Cargo { get; set; }
    }
}
