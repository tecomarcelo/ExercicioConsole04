using ProjetoDOS04.Controllers;
using System;

namespace ProjetoDOS04
{
    public class Program
    {
        static void Main(string[] args)
        {
            var funcionarioController = new FuncionarioController();
            funcionarioController.ControleFuncionarios();
        }
    }
    
}
