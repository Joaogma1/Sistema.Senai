using System;
using System.Collections.Generic;
using System.IO;
using Senai.Transacoes.Mvc.Models;

namespace Senai.Transacoes.Mvc.Repositorios {
    public class UsuarioRepositorio {

        private List<UsuarioModel> CarregarDoCSV () {
            List<UsuarioModel> lsUsuario = new List<UsuarioModel> ();

            string[] linhas = File.ReadAllLines ("usuario.csv");

            foreach (string linha in linhas) {
                String[] dadosDaLiha = linha.Split (";");

                UsuarioModel usuario = new UsuarioModel {

                    //Pedro;1234567;pedro@gmail.com;01/02/2000 00:00:00
                    Nome = dadosDaLiha[0],
                    Senha = dadosDaLiha[1],
                    Email = dadosDaLiha[2],
                    DataNascimento = DateTime.Parse(dadosDaLiha[3])
                };

                lsUsuario.Add (usuario);
            }

            return lsUsuario;
        }
        public UsuarioModel BuscarPorEmailESenha (String Email, string Senha) {
            List<UsuarioModel> UsuarioCadastrados = CarregarDoCSV ();

            foreach (UsuarioModel usuario in UsuarioCadastrados) {
                if (usuario.Email == Email && usuario.Senha == Senha) {
                    return usuario;
                }

            }
            return null;
            // caso o sistema não encontre nenhuma combinação de email e senha retuna null
        }
    }
}