using System;

namespace DIO.series
{
    public class Serie : EntidadeBase
    {
        //atributod
        public Serie(Genero genero, string descricao)
        {
            this.genero = genero;
            this.Descricao = descricao;

        }
        private Genero genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }

        private bool Excluido {get; set; }

        //Metodos

        public Serie(int id, Genero genero, string Titulo, string Descricao, int Ano)
        {
            this.id = id;
            this.genero = genero;
            this.Titulo = Titulo;
            this.Descricao = Descricao;
            this.Ano = Ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }

        public string retornaTitulo()
        {

            return this.Titulo;
        }

        internal int retornaId()
        {
            return this.id;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }
        

        public void Excluir()
        {
            this.Excluido =true;
        }

    }

}