using System;

namespace apiwithpomelo.Models
{
    public partial class Cliente 
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public DateTime? Nascimento { get; set; }
        public string Endereco { get; set; }
    }
}