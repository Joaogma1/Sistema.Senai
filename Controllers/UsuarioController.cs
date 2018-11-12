using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Transacoes.Mvc.Models;
using Senai.Transacoes.Mvc.Repositorios;

namespace Senai.Transacoes.Mvc.Controllers {
    public class UsuarioController : Controller{
        [HttpGet]
        public ActionResult Cadastro() => View();


        [HttpPost]
        public ActionResult Cadastro (IFormCollection form) {
            UsuarioModel usuario = new UsuarioModel ();
            usuario.Nome = form["nome"];
            usuario.Email = form["email"];

            usuario.Senha = form["senha"];
            usuario.DataNascimento = DateTime.Parse (form["dataNascimento"]);

            using (StreamWriter sw = new StreamWriter ("usuario.csv", true)) {
                sw.WriteLine ($"{usuario.Nome};{usuario.Email};{usuario.Senha};{usuario.DataNascimento}");
            };
            ViewBag.Mensagem = "Usuario Cadastrado com sucesso!";

            return View ();
        }

        [HttpGet]
        public ActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(IFormCollection form){
            UsuarioModel usuario = new UsuarioModel{
                Email = form["email"],
                Senha = form["senha"]
            };
            UsuarioRepositorio usuarioRep =  new UsuarioRepositorio();
            UsuarioModel  usuarioModel = usuarioRep.BuscarPorEmailESenha(usuario.Email, usuario.Senha) ;
            if (usuarioModel!= null)
            {
                HttpContext.Session.SetString("idUsuario", usuarioModel.Email.ToString());
            

                ViewBag.Mensagem = "Login Realizado com sucesso!";
                return RedirectToAction("Cadastro", "Transacao");
                
            }else
            {
            ViewBag.Mensagem = "Acesso Negado!";
                
            }

            return View();

        }

    }
}