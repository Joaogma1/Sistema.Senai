using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Transacoes.Mvc.Models;

namespace Senai.Transacoes.Mvc.Controllers {
    public class TransacaoController : Controller {
        [HttpGet]
        public IActionResult Cadastro () {
            if (string.IsNullOrEmpty (HttpContext.Session.GetString ("idUsuario"))) {
                return RedirectToAction ("Login", "Usuario");

            }
            return View ();

        }

        [HttpPost]
        public ActionResult Cadastro (IFormCollection form) {

            TransacaoModel transacao = new TransacaoModel ();
            transacao.Descricao = form["descri"];
            transacao.Valor = decimal.Parse (form["valor"]);
            transacao.Tipo = form["tipo"];
            transacao.Dataransacao = DateTime.Parse (form["data"]);

            using (StreamWriter sw = new StreamWriter ("transacoes.csv", true)) {
                sw.WriteLine ($"{transacao.Descricao};{transacao.Valor};{transacao.Tipo};{transacao.Dataransacao}");
            }

            ViewBag.Mensagem = "Transacao Cadastrado";
            return View ();
        }
    }
}