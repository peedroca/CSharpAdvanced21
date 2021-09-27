using System;
using apiwithpomelo.Entities;

namespace apiwithpomelo.Models
{
    public class Cliente 
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public DateTime? Nascimento { get; set; }
        public string Endereco { get; set; }

        public static implicit operator TbCliente(Cliente cliente)
        {
            return new TbCliente()
            {
                IdCliente = cliente.Id,
                NmCliente = cliente.Nome,
                DsEmail = cliente.Email,
                DsCpf = cliente.CPF,
                DsEndereco = cliente.Endereco,
                DsTelefone = cliente.Telefone,
                DtNascimento = cliente.Nascimento
            };
        }
    }
}