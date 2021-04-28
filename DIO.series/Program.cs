using System;

namespace DIO.series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSerie();
                        break;

                    case "2":
                        InserirSerie();
                        break;

                    case "3":
                        AtualizarSerie();
                        break;

                    case "4":
                        ExcluirSerie();
                        break;

                    case "5":
                        VisualizarSerie();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }

            System.Console.WriteLine("Obrigado por utiliar nossos serviços!!!");
            System.Console.ReadLine();
        }

        private static void VisualizarSerie()
        {
            System.Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static void ExcluirSerie()
        {
            System.Console.WriteLine("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);

        }

        private static void AtualizarSerie()
        {
            System.Console.WriteLine("Digite o ID da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("digite o gênero entre as opções acima: ");
            int EntraGenero = int.Parse(Console.ReadLine());

            Console.Write("digite o título da série: ");
            string EntradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano da série: ");
            int EntradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da série: ");
            string EntradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)EntraGenero,
                                        Titulo: EntradaTitulo,
                                        Ano: EntradaAno,
                                        Descricao: EntradaDescricao);
            repositorio.Atualiza(indiceSerie, atualizaSerie); 


        }

        private static void ListarSerie()
        {
            System.Console.WriteLine("Listar Série");
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                System.Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                           
                System.Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaTitulo(), (excluido "excluido" , ""));
            }
        }

        private static void InserirSerie()
        {
            System.Console.WriteLine("Inserir Nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("digite o gênero entre as opções acima: ");
            int EntraGenero = int.Parse(Console.ReadLine());

            Console.Write("digite o título da série: ");
            string EntradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano da série: ");
            int EntradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da série: ");
            string EntradaDescricao = Console.ReadLine();
            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)EntraGenero,
                                        Titulo: EntradaTitulo,
                                        Ano: EntradaAno,
                                        Descricao: EntradaDescricao);
            repositorio.Insere(novaSerie);
        }

        private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("DIO séries ao seu dispor!!!");
            System.Console.WriteLine("Informe a opção desejada: ");
            System.Console.WriteLine("1 - Listar Series");
            System.Console.WriteLine("2 - Inserir nova série");
            System.Console.WriteLine("3 - Atualizar série");
            System.Console.WriteLine("4 - Excluir série");
            System.Console.WriteLine("5 - Visualizar série");
            System.Console.WriteLine("C - Limpar tela");
            System.Console.WriteLine("X - Sair");
            System.Console.WriteLine();

            string ObterOpcaoUsuario = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return ObterOpcaoUsuario;
        }
    }
}
