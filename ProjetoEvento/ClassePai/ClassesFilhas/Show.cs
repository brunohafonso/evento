using System;
using System.IO;
using System.Text;

namespace ProjetoEvento.ClassePai.ClassesFilhas
{
    public class Show : Evento
    {
        public string Artista { get; set; }

        public string GeneroMusical { get; set; }

        public Show()
        {

        }

        public Show(string Titulo, String Local, int Lotacao, DateTime Data, string Duracao, int Classificacao, string Artista, string GeneroMusical)
        {
            base.Titulo = Titulo;
            base.Local = Local;
            base.Lotacao = Lotacao;
            base.Data = Data;
            base.Duracao = Duracao;
            base.Classificacao = Classificacao;
            this.Artista = Artista;
            this.GeneroMusical = GeneroMusical;
        }

        public override bool Cadastrar()
        {
            bool efetuado = false;
            StreamWriter arquivo = null;
            try
            {
                arquivo = new StreamWriter("show.csv", true);
                arquivo.WriteLine("{0};{1};{2};{3};{4};{5};{6};{7};", Titulo, Local, Lotacao, Data, Duracao, Classificacao, Artista, GeneroMusical);
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

        public override string Pesquisar(string TituloShow)
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
                    if (dados[3] == TituloShow)
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

        public override string Pesquisar(DateTime DataEvento)
        {
            string Resultado = "";
            StreamReader ler = null;
            try
            {
                ler = new StreamReader("show.cs", Encoding.Default);
                string linha = "";
                while ((linha = ler.ReadLine()) != null)
                {
                    string[] dados = linha.Split(';');
                    if (dados[0] == Convert.ToString(DataEvento));
                    {
                        Resultado = linha;
                        break;
                    }
                    Resultado = "Data nao encontrada";
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