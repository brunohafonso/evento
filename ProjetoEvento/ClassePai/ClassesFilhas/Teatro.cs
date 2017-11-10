using System;
using System.IO;
using System.Text;

namespace ProjetoEvento.ClassePai.ClassesFilhas
{
    public class Teatro : Evento
    {
        public string Diretor { get; set; }
        
        string[] Elenco { get; set; }

        public Teatro()
        {
            
        }

        public Teatro(string Titulo, String Local, int Lotacao, DateTime Data, string Duracao, int Classificacao, string Diretor, string[] Elenco) 
        {
            base.Titulo = Titulo;
            base.Local = Local;
            base.Lotacao = Lotacao;
            base.Data = Data;
            base.Duracao = Duracao;
            base.Classificacao = Classificacao;
            this.Diretor = Diretor;
            this.Elenco = Elenco;
        }

        public override bool Cadastrar() 
        {
            bool efetuado = false;
            StreamWriter arquivo = null;
            try
            {
                string elenco = "";
                foreach(var elenc in Elenco) {
                    elenco += elenc;
                }
                arquivo = new StreamWriter("show.csv", true);
                arquivo.WriteLine("{0};{1};{2};{3};{4};{5};{6};{7};", Titulo, Local, Lotacao, Data, Duracao, Classificacao, Diretor, Elenco);
                efetuado = true;
            }
            catch (Exception ex)
            {
                throw new Exception("erro ao tentar gravar o arquivo");
            }
            finally
            {
                arquivo.Close();
            }

            return efetuado;
        }
        public override string Pesquisar(string TituloPeca)
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
                    if (dados[3] == TituloPeca)
                    {
                        Resultado = linha;
                        break;
                    }
                    Resultado = "Titulo nao encontrada";
                }
            }
            catch (Exception ex)
            {
                Resultado = "Não foi possivel ler o arquivo";
            }
            finally
            {
                ler.Close();
            }
            return Resultado;
        }

        public override string Pesquisar(DateTime DataPeca)
        {
            string Resultado = "";
            StreamReader ler = null;
            try
            {
                ler = new StreamReader("teatro.cs", Encoding.Default);
                string linha = "";
                while ((linha = ler.ReadLine()) != null)
                {
                    string[] dados = linha.Split(';');
                    if (dados[0] == Convert.ToString(DataPeca));
                    {
                        Resultado = linha;
                        break;
                    }
                    Resultado = "Data nao encontrada.";
                }
            }
            catch (Exception ex)
            {
                Resultado = "Não foi possivel ler o arquivo";
            }
            finally
            {
                ler.Close();
            }
            return Resultado;
        }
    }
}