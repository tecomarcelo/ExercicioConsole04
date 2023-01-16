using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetoDOS04.Entities
{
    public class Funcionario
    {
        public Guid Id { get; set; }

        private string? _nome; //atributo
        public string? Nome 
        {
            get => _nome; //retornando valor do atributo
            set // receber o valor do campo
            {
                //validar se o nome esta vazio
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Nome do funcionário é obrigatório.");

                //validar se o nome possui de 10 a 150 caracteres
                else if (value.Length < 10 || value.Length > 150)
                    throw new ArgumentException("Nome do funcionário deve ter de 10 a 150 caracteres.");

                else
                    _nome = value; //armazenando o valor recebido
            }
        }

        private string? _matricula; //atributo
        public string? Matricula
        {
            get => _matricula; //retornando valor do atributo
            set // receber o valor do campo
            {
                //validar se a matricula esta vazio
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Número da Matricula é obrigatório.");

                //validar se o nome possuir 6 caracteres
                else if (!new Regex("^[0-9]{6}$").IsMatch(value))
                    throw new ArgumentException("Matricula deve ter 6 digitos numéricos.");

                else
                    _matricula = value; //armazenando o valor recebido
            }
        }

        private string? _Cpf; //atributo
        public string? Cpf
        {
            get => _Cpf; //retornando valor do atributo
            set // receber o valor do campo
            {
                //validar se o CPF esta vazio
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Número do CPF é obrigatório.");

                //validar se o nome possuir 6 caracteres
                else if (!new Regex("^[0-9]{11}$").IsMatch(value))
                    throw new ArgumentException("CPF deve ter 11 digitos numéricos.");

                else
                    _Cpf = value;  //armazenando o valor recebido
            }
        }

    }
}
