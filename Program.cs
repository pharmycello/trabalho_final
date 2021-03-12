using System;

namespace UFCD0805_Trabalho_Final
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nomes = new string[10];
            string nome, nomeantigo;
            int i;
            char resp, conf, respfinal;

            do
            {
                Console.WriteLine("--- Menu ---\n");
                Console.WriteLine("1 - Inserir Formandos");
                Console.WriteLine("2 - Alterar nome de um formando");
                Console.WriteLine("3 - Eliminar um formando");
                Console.WriteLine("4 - Pesquisar o formando através do nome");
                Console.WriteLine("5 - Listagem dos formandos (ordem original de inserção)");
                Console.WriteLine("6 - Listagem dos formandos (ordenada pelo nome)");
                Console.WriteLine("0 - Sair\n");
                Console.Write("Opção: ");
                resp = Console.ReadKey().KeyChar;
                Console.WriteLine("\n");

                switch (resp)
                {
                    case '1':
                        {
                            Console.Clear();
                            Console.WriteLine("- - - Inserir Formandos - - -\n");
                            Console.WriteLine("Insira o nome dos formandos: ");
                            for (i = 0; i < nomes.Length; i++)
                            {
                                Console.Write("Formando {0}: ", (i + 1));
                                nomes[i] = Console.ReadLine();
                                if (i == nomes.Length - 1)
                                {
                                    Console.WriteLine("A turma tem {0} formandos, já introduziu todos", nomes.Length);
                                }
                            }
                            break;
                        }

                    case '2':
                        {
                            Console.Clear();
                            Console.WriteLine("- - - Alterar nome de um Formando - - -\n");
                            for (i = 0; i < nomes.Length; i++)
                            {
                                Console.WriteLine("Formando nº{0}: {1}", (i + 1), nomes[i]);
                            }
                            Console.WriteLine("\nDigite 0 e Enter para sair sem alteração\n");
                            Console.Write("Indique o nº do formando para alterar: ");
                            i = int.TryParse(Console.ReadLine(), out i) ? i : -1;
                            if (i == -1 || i > nomes.Length)
                            {
                                do
                                {
                                    Console.WriteLine("Introduzui nº formando/caracter inválido ou carregou no Enter sem querer\n");
                                    Console.Write("Indique o nº do formando para alterar: ");
                                    i = int.TryParse(Console.ReadLine(), out i) ? i : -1;
                                } while (i <= -1 || i > nomes.Length);
                                if (i == 0)
                                {
                                    break;
                                }
                            }
                            else if (i == 0)
                            {
                                break;
                            }

                            nomeantigo = nomes[i - 1];
                            Console.Write("\nIntroduza o nome do formando nº{0}: ", (i));
                            nomes[i - 1] = Console.ReadLine();
                            Console.Write("Quer alterar mesmo? (S/N): ");
                            do
                            {
                                Console.WriteLine();
                                conf = char.ToLower(Console.ReadKey().KeyChar);
                            } while (conf != 's' && conf != 'n');
                            if (conf == 's')
                            {
                                Console.WriteLine();
                                Console.Write("\n{1}, formando nº{0} foi alterado para {2}\n", (i), nomeantigo, nomes[i - 1]);
                                break;
                            }
                            else
                            {
                                nomes[i - 1] = nomeantigo;
                                Console.Write("\nNão foi efectuada nenhuma alteração");
                                break;
                            }
                        }

                    case '3':
                        {
                            Console.Clear();
                            Console.WriteLine("- - - Eliminar um formando - - -\n");
                            for (i = 0; i < nomes.Length; i++)
                            {
                                Console.WriteLine("Formando nº{0}: {1}", (i + 1), nomes[i]);
                            }
                            Console.WriteLine("\nDigite 0 e Enter para sair sem alteração\n");
                            Console.Write("Indique o nº do formando para eliminar: ");
                            i = int.TryParse(Console.ReadLine(), out i) ? i : -1;
                            if (i == -1 || i > nomes.Length)
                            {
                                do
                                {
                                    Console.WriteLine("Introduzui nº formando/caracter inválido ou carregou no Enter sem querer\n");
                                    Console.Write("Indique o nº do formando para eliminar: ");
                                    i = int.TryParse(Console.ReadLine(), out i) ? i : -1;
                                } while (i <= -1 || i > nomes.Length);
                                if (i == 0)
                                {
                                    break;
                                }
                            }
                            else if (i == 0)
                            {
                                break;
                            }

                            nomeantigo = nomes[i - 1];
                            Console.Write("Quer eliminar mesmo? (S/N): ");
                            do
                            {
                                Console.WriteLine();
                                conf = char.ToLower(Console.ReadKey().KeyChar);
                            } while (conf != 's' && conf != 'n');
                            if (conf == 's')
                            {
                                nomes[i - 1] = "";
                                Console.Write("\n{1}, formando nº{0} foi eliminado com sucesso.\n", (i), nomeantigo);
                                break;
                            }
                            else
                            {
                                Console.Write("\n\nNão foi efectuada nenhuma alteração");
                                break;
                            }

                        }


                    case '4':
                        {
                            Console.Clear();
                            Console.WriteLine("- - - Pesquisar o formando através do nome - - -\n");
                            do
                            {
                                Console.Write("Introduza o nome do formando a pesquisar: ");
                                nome = Console.ReadLine();
                            } while (string.IsNullOrEmpty(nome));
                            string match = Array.Find(nomes, n => n.Contains(nome));
                            i = Array.IndexOf(nomes, match);
                            if (i > -1)
                            {
                                Console.WriteLine("\nFormando encontrado");
                                Console.WriteLine("Formando nº{0} {1}", (i + 1), nomes[i]);
                            }
                            else
                            {
                                Console.WriteLine("\nFormando não encontrado");
                            }
                            break;
                        }

                    case '5':
                        {
                            Console.Clear();
                            Console.WriteLine("- - - Listagem dos formandos (ordem original de inserção) - - -\n");
                            for (i = 0; i < nomes.Length; i++)
                            {
                                Console.WriteLine("Formando nº{0}: {1}", (i + 1), nomes[i]);
                            }
                            break;

                        }

                    case '6':
                        {
                            Console.Clear();
                            Console.WriteLine("- - - Listagem dos formandos (ordenado alfabeticamente) - - -\n");
                            string[] nomesord = new string[nomes.Length];
                            Array.Copy(nomes, nomesord, nomes.Length);
                            Array.Sort(nomesord);
                            for (i = 0; i < nomesord.Length; i++)
                            {
                                Console.WriteLine("Formando nº{0}: {1}", (i + 1), nomesord[i]);
                            }

                            break;
                        }

                    case '0':
                        {
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Opção inválida");
                            break;
                        }
                }
                if (resp != '0')
                {
                    Console.Write("\n\nPrima qualquer tecal para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    do
                    {
                        Console.Write("Escolheu 0, quer sair mesmo? (S/N) ");
                        respfinal = char.ToLower(Console.ReadKey().KeyChar);
                        Console.WriteLine();

                        if (respfinal == 'n')
                        {
                            resp = respfinal;
                            Console.Clear();
                        }

                    } while (respfinal != 'n' && respfinal != 's');
                }

            } while (resp != '0');
        }
    }
}
