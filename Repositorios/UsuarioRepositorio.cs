using System.Collections.Generic;
using System.IO;
using Senai.Transacoes.Mvc.Models;

namespace Senai.Transacoes.Mvc.Repositorios
{
    public class UsuarioRepositorio
    {
        public List<UsuarioModel> lsUsuario = new List<UsuarioModel>();

        public void CarregarDoCSV(){
            string[] linhas = File.ReadAllLines("usuario.csv");
            foreach (string Linha in Linhas)
            {
                
            }
        }
    }
}