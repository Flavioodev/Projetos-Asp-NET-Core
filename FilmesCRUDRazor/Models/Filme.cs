using System;

namespace FilmesCRUDRazor.Models
{

    public class Filme
    {

        private Filme(string titulo, string preco)
        {
            Titulo = titulo;
            Preco = preco;
        }

        public int FilmeId { get; set; }
        public string Titulo { get; set; }
        public DateTime DataLancamento { get; set; }
        public string Preco { get; set; }

    }


}