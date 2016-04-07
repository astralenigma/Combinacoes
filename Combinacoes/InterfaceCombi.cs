using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinacoes
{
    class InterfaceCombi
    {
        static ListaIngredientes listaChems;
        static CombinacoesDeIngredientes combinacoes3Elementos;
        static CombinacoesDeIngredientes combinacoesDescoberta;
        static CombinacoesDeIngredientes combinacoesEncontradas;
        static CombinacoesDeIngredientes combinacoesTestadas;

        private static CombinacoesDeIngredientes calcularListaDescoberta()
        {
            Console.WriteLine(combinacoesDescoberta.Count);
            RemoverReceitas();
            combinacoesDescoberta = reordenarCombinacoes(combinacoesDescoberta);
            foreach (String item in combinacoesTestadas)
            {
                combinacoesDescoberta= combinacoesDescoberta.removerConhecidas(ListaIngredientes.criarListaDeIngredientes(item).criarCombinacoesDeDescoberta());
            }
            combinacoesDescoberta = reordenarCombinacoes(combinacoesDescoberta);
            combinacoesDescoberta = combinacoesDescoberta.listarCombinacoesNecessarias();
            Console.WriteLine(combinacoesDescoberta.Count);
            Console.WriteLine(combinacoesTestadas.Count);
            return combinacoesDescoberta;
        }

        private static void RemoverReceitas()
        {
            foreach (String item in combinacoesEncontradas)
            {
                combinacoesDescoberta.removerReceita(item);
            }
        }

        public static void processarInformacao()
        {
            calcularListaDescoberta();
            Console.WriteLine(combinacoesDescoberta.Count);
        }

        //public static void processarIngrediente(String ingrediente)
        //{
        //    calcularListaDescobertaR(listaChems, combinacoesEncontradas, combinacoesTestadas, ingrediente);
        //}

        //private static CombinacoesDeIngredientes CombinacoesDescobertaTeste(ListaIngredientes listaChems, CombinacoesDeIngredientes combinacoesDescoberta, CombinacoesDeIngredientes combinacoesEncontradas)
        //{
        //    foreach (String comb in combinacoesEncontradas)
        //    {
        //        combinacoesDescoberta = combinacoesDescoberta.removerConhecidas(listaChems.criarCombinacoesExclusivas(comb));
        //        Console.WriteLine(combinacoesDescoberta.Count);
        //    }
        //    return combinacoesDescoberta;
        //}

        //private static void calcularListaDescobertaR(ListaIngredientes listaChems, CombinacoesDeIngredientes combinacoesEncontradas, CombinacoesDeIngredientes combinacoesTestadas, String ingrediente)
        //{
        //    Console.WriteLine();
        //    Console.WriteLine(ingrediente);
        //    CombinacoesDeIngredientes combinacoesDoIngrediente = listaChems.criarCombinacoesExclusivas(ingrediente);
        //    CombinacoesDeIngredientes combinacoesDescobertaR = calcularListaDescoberta(listaChems, combinacoesEncontradas, combinacoesTestadas);
        //    listarReceitas(combinacoesDescobertaR);
        //}

        //private static void listarReceitas(CombinacoesDeIngredientes combinacoesDescoberta)
        //{
        //    Console.WriteLine(combinacoesDescoberta.Last());
        //    Console.WriteLine(combinacoesDescoberta.ElementAt((combinacoesDescoberta.Count - 2)));
        //    Console.WriteLine(combinacoesDescoberta.ElementAt((combinacoesDescoberta.Count - 3)));
        //    Console.WriteLine(combinacoesDescoberta.ElementAt((combinacoesDescoberta.Count - 4)));
        //    Console.WriteLine(combinacoesDescoberta.ElementAt((combinacoesDescoberta.Count - 5)));
        //    Console.WriteLine(combinacoesDescoberta.First());
        //    Console.WriteLine(combinacoesDescoberta.ElementAt((1)));
        //    Console.WriteLine(combinacoesDescoberta.ElementAt((2)));
        //    Console.WriteLine(combinacoesDescoberta.ElementAt((3)));
        //    Console.WriteLine(combinacoesDescoberta.ElementAt((4)));
        //}

        //private static void listarCalculoListaDescobertaR(ListaIngredientes listaChems, CombinacoesDeIngredientes combinacoesEncontradas, CombinacoesDeIngredientes combinacoesTestadas)
        //{
        //    foreach (String item in listaChems)
        //    {
        //        calcularListaDescobertaR(listaChems, combinacoesEncontradas, combinacoesTestadas, item);
        //    }
        //}

        public static void lerFicheiro()
        {
            listaChems = new ListaIngredientes();
            combinacoesEncontradas = new CombinacoesDeIngredientes();
            CombinacoesDeIngredientes combinacoesTestadasIn = new CombinacoesDeIngredientes();
            combinacoesTestadas = new CombinacoesDeIngredientes();
            combinacoesDescoberta = new CombinacoesDeIngredientes();

            string[] lines = System.IO.File.ReadAllLines(@"input.txt");
            int sinal = 0;

            foreach (string line in lines)
            {
                switch (line)
                {
                    case "-": sinal = 1;
                        break;
                    case "--": sinal = 2;
                        break;
                    case "---": sinal = 3;
                        break;
                    case "----":
                    case "-----": sinal = 4;
                        break;
                    default:
                        switch (sinal)
                        {
                            case 1:
                                listaChems.Add(line);
                                break;
                            case 2:
                                combinacoesEncontradas.Add(line);
                                break;
                            case 3: combinacoesTestadas.Add(line);
                                break;
                            default: Console.WriteLine("Erro");
                                break;
                        }
                        break;
                }
            }
            combinacoesDescoberta.Add(listaChems.ToString());
            combinacoesDescoberta.Sort((a, b) => b.Length.CompareTo(a.Length));
            //Remover necessidade de Contar as testadas.
            consolaOutput(combinacoesTestadasIn);

        }

        private static void consolaOutput(CombinacoesDeIngredientes combinacoesTestadasIn)
        {
            Console.WriteLine(listaChems);
            Console.WriteLine(combinacoesEncontradas);
            Console.WriteLine(combinacoesTestadasIn);
            Console.WriteLine(combinacoesTestadas.Count);
        }

        public static void escreverFicheiro()
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"output.txt"))
            {

                file.WriteLine("-");
                foreach (String item in listaChems)
                {
                    file.WriteLine(item);
                }
                file.WriteLine("--");
                foreach (String item in combinacoesEncontradas)
                {
                    file.WriteLine(item);
                }
                file.WriteLine("---");
                foreach (String item in combinacoesTestadas)
                {
                    file.WriteLine(item);
                }
                file.WriteLine("----");

                foreach (String item in combinacoesDescoberta)
                {
                    file.WriteLine(item);
                }
                file.WriteLine("-----");
                file.WriteLine("You need to make at least " + combinacoesDescoberta.Count + " combinations to make sure there are no more recipes.");
            }
        }

        //private static CombinacoesDeIngredientes listarCombinacoesFalhadas(CombinacoesDeIngredientes combs)
        //{
        //    CombinacoesDeIngredientes combsF = new CombinacoesDeIngredientes();
        //    foreach (String item in combs)
        //    {
        //        ListaIngredientes LI = ListaIngredientes.criarListaDeIngredientes(item);
        //        combsF.AddRange(LI.criarCombinacoesDeDescoberta());
        //    }
        //    CombinacoesDeIngredientes combsOut = new CombinacoesDeIngredientes();
        //    combsOut.AddRange(combsF.Distinct());
        //    combsOut.Sort();
        //    return combsOut;
        //}

        private static CombinacoesDeIngredientes reordenarCombinacoes(CombinacoesDeIngredientes combinacoesDescoberta)
        {
            List<String> combs = combinacoesDescoberta.OrderBy(x => x.Length).Distinct().ToList();
            CombinacoesDeIngredientes combsOut = new CombinacoesDeIngredientes();
            foreach (String item in combs)
            {
                combsOut.Add(item);
            }
            return combsOut;
        }

        static CombinacoesDeIngredientes criarCombinacoesDe3Elementos(ListaIngredientes lista)
        {
            CombinacoesDeIngredientes combinacoes = lista.criarCombinacoesDe3Elementos();
            return combinacoes;
        }
    }
}
