using System;
using ProjetoEvento.ClassePai.ClassesFilhas;

namespace ProjetoEventoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
           MenuPrincipal();
        }
        static void MenuPrincipal() {

            System.Console.WriteLine("---- ingresso.com ----");
            System.Console.WriteLine("digite a opcao desejada:");
            System.Console.WriteLine("1 - show");
            System.Console.WriteLine("2 - teatro");
            System.Console.WriteLine("3 - cinema");
            System.Console.WriteLine("4 - sair");
            string opcaoMenuPrincial = Console.ReadLine();
            switch(opcaoMenuPrincial) {
                case "1":
                    show();
                break;
                case "2":
                    //teatro();
                break;
                case "3":
                    //cinema();
                break;
                case "4":
                    Environment.Exit(1);
                break;
                default:
                    System.Console.WriteLine("Opcao digitada invalida.");
                    MenuPrincipal();
                break;
            }
        }

        static void show() {
            System.Console.WriteLine("---- show ----");
            System.Console.WriteLine("digite a opcao desejada");
            System.Console.WriteLine("1 - cadastrar show");
            System.Console.WriteLine("2 - pesquisar show");
            System.Console.WriteLine("3 - voltar");
            string opcaoMenuShow = Console.ReadLine();
            switch(opcaoMenuShow) {
                case "1":
                    cadastrarShow();
                break;
                case "2":

                break;
                case "3":
                    MenuPrincipal();
                break;
                default:
                    System.Console.WriteLine("opcao digitada invalida.");
                    show();
                break;
            }
        }

        static void cadastrarShow() {
            System.Console.WriteLine("---- cadastrando show ----");
            System.Console.WriteLine("Digite o titulo do show:");
            string Titulo = Console.ReadLine();
            System.Console.WriteLine("digite o local do show:");
            string Local = Console.ReadLine();
            System.Console.WriteLine("digite a lotacao do show:");
            int Lotacao = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("digite a data do show:");
            DateTime Data = Convert.ToDateTime(Console.ReadLine());
            System.Console.WriteLine("digite a duracao do show:");
            string Duracao = Console.ReadLine();
            System.Console.WriteLine("digite a classificacao do show:");
            int Classificacao = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("digite a atracao do show:");
            string Artista = Console.ReadLine();
            System.Console.WriteLine("Digite o genero musical");
            string GeneroMusical = Console.ReadLine();
            Show show = new Show(Titulo, Local, Lotacao, Data, Duracao, Classificacao, Artista, GeneroMusical);
            show.Cadastrar();
        }
    }
}
