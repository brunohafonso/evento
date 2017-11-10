using System;
using System.IO;
using System.Text;

namespace ProjetoEvento.ClassePai.ClassesFilhas
{
    public class Cinema : Evento
    {
        public string Genero { get; set; }
        public DateTime[] Sessao { get; set; }

        /// <summary>
        
        /// </summary>
        
        public Cinema()
        {

        }

        public Cinema(string Titulo, String Local, int Lotacao, DateTime Data, string Duracao, int Classificacao, string Genero, DateTime[] Sessao) 
        {
            base.Titulo = Titulo;
            base.Local = Local;
            base.Lotacao = Lotacao;
            base.Data = Data;
            base.Duracao = Duracao;
            base.Classificacao = Classificacao;
            this.Genero = Genero;
            this.Sessao = Sessao;
        }

        public override bool Cadastrar() 
        {
            bool efetuado = false;
            StreamWriter arquivo = null;
            try
            {
                string sessoes = "";
                foreach(var sses in Sessao) {
                    sessoes += sses + "-";
                }
                arquivo = new StreamWriter("show.csv", true);
                arquivo.WriteLine("{0};{1};{2};{3};{4};{5};{6};{7};", Titulo, Local, Lotacao, Data, Duracao, Classificacao, Genero, Sessao);
                efetuado = true;
            }
            catch (Exception ex)
            {
                throw new Exception("erro ao tentar gravar o arquivo" + ex.Message);
            }
            finally
            {
                arquivo.Close();
            }

            return efetuado;
        }
        public override string Pesquisar(string TituloFilme)
        {
            string Resultado = "";
            StreamReader ler = null;
            try
            {
                ler = new StreamReader("show.csv", Encoding.Default);
                string linha = "";
                while ((linha = ler.ReadLine()) != null)
                {
                    string[] dados = linha.Split(';');
                    if (dados[3] == TituloFilme)
                    {
                        Resultado = linha;
                        break;
                    }
                    Resultado = "Titulo nao encontrada";
                }
            }
            catch (Exception ex)
            {
                Resultado = "Não foi possivel ler o arquivo" + ex.Message;
            }
            finally
            {
                ler.Close();
            }
            return Resultado;
        }
        
    }
}