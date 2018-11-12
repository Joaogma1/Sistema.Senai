using System;

namespace Senai.Transacoes.Mvc.Models
{
    public class TransacaoModel
    {
        
        public int Id{get; set;}
         public string Descricao {get;set;}
        public decimal Valor {get;set;}

        public string Tipo {get;set;}
        public string Senha {get;set;}
        public DateTime Dataransacao {get;set;}

    }
}