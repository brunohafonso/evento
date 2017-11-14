using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

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
            try
            {
                //ler todas a linhas
                string[] linhas = System.IO.File.ReadAllLines("show.csv");
                //array das colunas
                string[] coluna = new string[8];
                //funcao que recebe parametro para comparacao na busca
                Regex regex = new Regex(@TituloShow.ToUpper());
                //laco para fazer a busca
                foreach (var linha in linhas)
                {
                    //quebra a linha em colunas
                    coluna = linha.Split(';');
                    //busca na string da primeira coluna e compara se texto digitado bate
                    Match match = regex.Match(coluna[0].ToUpper());
                    //if tiver alguma correspondencia
                    var i = 0;
                    if (match.Success)
                    {
                        //seta a linha e substitui as virgulas por espaco
                        Resultado = linha.Replace(";"," ");
                        //System.Console.WriteLine(linha.Replace(";", " "));
                        break;
                    }
                    Resultado = "Titulo nao encontrado";
            }
            }
            catch (Exception ex)
            {
                Resultado = "Não foi possivel ler o arquivo" + ex.Message;
            }
            finally
            {
                //ler.Close();
            }
            return Resultado;
        }

        public override string Pesquisar(DateTime DataEvento)
        {
            string Resultado = "";
            try
            {
                string[] linhas = System.IO.File.ReadAllLines("show.csv");
                string[] coluna = new string[8];
                foreach (var linha in linhas)
                {
                    string[] dados = linha.Split(';');
                    if (Convert.ToDateTime(coluna[3]) == DataEvento);
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
                //ler.Close();
            }
            return Resultado;
        }
    }
}