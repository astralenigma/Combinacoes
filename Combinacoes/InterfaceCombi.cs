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
        static CombinacoesDeIngredientes combinacoes3Elementos = new CombinacoesDeIngredientes();
        static CombinacoesDeIngredientes combinacoes2Elementos = new CombinacoesDeIngredientes();
        static CombinacoesDeIngredientes combinacoesDescoberta;
        static CombinacoesDeIngredientes combinacoesEncontradas;
        static CombinacoesDeIngredientes combinacoesTestadas;
        static String completion = "Done.";

        /// <summary>
        /// Calculates a list of combinations to be mixed for discovery.
        /// </summary>
        /// <returns>Returns the calculated list.</returns>
        private static CombinacoesDeIngredientes calcularListaDescoberta()
        {
            Console.WriteLine("Building discovery combinations:");
            RemoverReceitas(combinacoesDescoberta);
            combinacoesDescoberta = reordenarCombinacoes(combinacoesDescoberta);
            RemoverCombinacoesFalhadas(combinacoesDescoberta);
            ReorganizandoALista();
            Console.WriteLine("List Built.");
            return combinacoesDescoberta;
        }
        /// <summary>
        /// Puts the discovery list in order.
        /// </summary>
        private static void ReorganizandoALista()
        {
            Console.Write("\tOptimizing the list...");
            combinacoesDescoberta = reordenarCombinacoes(combinacoesDescoberta);
            combinacoesDescoberta = combinacoesDescoberta.listarCombinacoesNecessarias();
            Console.WriteLine(completion);
        }
        /// <summary>
        /// Removes the combinations from the discovery list.
        /// </summary>
        /// <param name="combinacoes">Test combinations.</param>
        private static void RemoverCombinacoesFalhadas(CombinacoesDeIngredientes combinacoes)
        {
            Console.Write("\tRemoving Failed combinations");
            foreach (ListaIngredientes item in combinacoesTestadas)
            {
                combinacoes.removerCombinacoesDesnecessarias(item);
                Console.Write(".");
            }
            Console.WriteLine(completion);
        }
        /// <summary>
        /// Removes the successful combinations.
        /// </summary>
        /// <param name="combinacoes">Test combinations.</param>
        private static void RemoverReceitas(CombinacoesDeIngredientes combinacoes)
        {
            Console.Write("\tRemoving found Recipes");
            foreach (ListaIngredientes item in combinacoesEncontradas)
            {
                combinacoes.removerReceita(item);
                Console.Write(".");
            }
            Console.WriteLine(completion);
        }

        /// <summary>
        /// Public method to start the calculations of the program.
        /// </summary>
        public static void processarInformacao()
        {
            calcularListaDescoberta();
            calcularCombinacoes3();
            calcularCombinacoes2();
            Console.WriteLine();
            lancarEstatistica();

        }

        private static void calcularCombinacoes2()
        {
            Console.WriteLine("Building combinations of 2:");
            combinacoes2Elementos = criarCombinacoesDe2Elementos(listaChems);
            Console.Write("\tRemoving found Recipes...");
            combinacoes2Elementos.removerConhecidas(combinacoesEncontradas);
            Console.WriteLine(completion);
            Console.Write("\tRemoving failed combinations...");
            RemoverCombinacoesFalhadas(combinacoes2Elementos);
            Console.WriteLine(completion);
        }


        /// <summary>
        /// Method that outputs useful information.
        /// </summary>
        public static void lancarEstatistica()
        {
            //Acrescentar quantas receitas de 3 e 2 elementos faltam testar.
            Console.WriteLine("Found " + combinacoesDescoberta.Count + " combinations before you have to test before you found them all.");
            Console.WriteLine("Found " + combinacoes3Elementos.Count + " combinations of 3 elements.");
            Console.WriteLine("Found " + combinacoes2Elementos.Count + " combinations of 2 elements.");
        }

        //private static CombinacoesDeIngredientes CombinacoesDescobertaTeste(ListaIngredientes listaChems, CombinacoesDeIngredientes combinacoesDescoberta, CombinacoesDeIngredientes combinacoesEncontradas)
        //{
        //    foreach (String comb in combinacoesEncontradas)
        //    {
        //        combinacoesDescoberta = combinacoesDescoberta.removerConhecidas(listaChems.criarCombinacoesExclusivas(comb));
        //        Console.WriteLine(combinacoesDescoberta.Count);
        //    }
        //    return combinacoesDescoberta;
        //}

        /*O R é de Receita. */
        //private static void calcularListaDescobertaR(ListaIngredientes listaChems, CombinacoesDeIngredientes combinacoesEncontradas, CombinacoesDeIngredientes combinacoesTestadas, String ingrediente)
        //{
        //    Console.WriteLine();
        //    Console.WriteLine(ingrediente);
        //    CombinacoesDeIngredientes combinacoesDoIngrediente = listaChems.criarCombinacoesExclusivas(ingrediente);
        //    CombinacoesDeIngredientes combinacoesDescobertaR = calcularListaDescoberta(listaChems, combinacoesEncontradas, combinacoesTestadas);
        //    listarReceitas(combinacoesDescobertaR);
        //}

        private static void listarReceitas()
        {
            Console.WriteLine(combinacoesDescoberta.Last());
            Console.WriteLine(combinacoesDescoberta.ElementAt((combinacoesDescoberta.Count - 2)));
            Console.WriteLine(combinacoesDescoberta.ElementAt((combinacoesDescoberta.Count - 3)));
            Console.WriteLine(combinacoesDescoberta.ElementAt((combinacoesDescoberta.Count - 4)));
            Console.WriteLine(combinacoesDescoberta.ElementAt((combinacoesDescoberta.Count - 5)));
            Console.WriteLine(combinacoesDescoberta.First());
            Console.WriteLine(combinacoesDescoberta.ElementAt((1)));
            Console.WriteLine(combinacoesDescoberta.ElementAt((2)));
            Console.WriteLine(combinacoesDescoberta.ElementAt((3)));
            Console.WriteLine(combinacoesDescoberta.ElementAt((4)));
        }
        /*O R é de Receita. */
        //private static void listarCalculoListaDescobertaR(ListaIngredientes listaChems, CombinacoesDeIngredientes combinacoesEncontradas, CombinacoesDeIngredientes combinacoesTestadas)
        //{
        //    foreach (String item in listaChems)
        //    {
        //        calcularListaDescobertaR(listaChems, combinacoesEncontradas, combinacoesTestadas, item);
        //    }
        //}

    

        //private static void consolaOutput(CombinacoesDeIngredientes combinacoesTestadasIn)
        //{
        //    Console.WriteLine(listaChems);
        //    Console.WriteLine(combinacoesEncontradas);
        //    Console.WriteLine(combinacoesTestadasIn);
        //    Console.WriteLine(combinacoesTestadas.Count);
        //}

        
        private static CombinacoesDeIngredientes reordenarCombinacoes(CombinacoesDeIngredientes combinacoesDescoberta)
        {
            List<ListaIngredientes> combs = combinacoesDescoberta.OrderBy(x => x.Count).Distinct().ToList();
            CombinacoesDeIngredientes combsOut = new CombinacoesDeIngredientes();
            combsOut.AddRange(combs);
            return combsOut;
        }

        private static void calcularCombinacoes3()
        {
            Console.WriteLine("Building combinations of 3:");
            combinacoes3Elementos = criarCombinacoesDe3Elementos(listaChems);
            Console.Write("\tRemoving found Recipes...");
            combinacoes3Elementos.removerConhecidas(combinacoesEncontradas);
            Console.WriteLine(completion);
            Console.Write("\tRemoving failed combinations...");
            RemoverCombinacoesFalhadas(combinacoes3Elementos);
            Console.WriteLine(completion);
        }

        static CombinacoesDeIngredientes criarCombinacoesDe3Elementos(ListaIngredientes lista)
        {
            CombinacoesDeIngredientes combinacoes = lista.criarCombinacoesDe3Elementos();
            return combinacoes;
        }

        static CombinacoesDeIngredientes criarCombinacoesDe2Elementos(ListaIngredientes lista)
        {
            CombinacoesDeIngredientes combinacoes = lista.criarCombinacoesDe2Elementos();
            return combinacoes;
        }

        internal static void lerFicheiro()
        {
            IOparser.lerFicheiro(out listaChems, out combinacoesEncontradas, out combinacoesTestadas, out combinacoesDescoberta, completion);
        }

        internal static void escreverFicheiro()
        {
            IOparser.escreverFicheiro(listaChems, combinacoesEncontradas, combinacoesTestadas, combinacoesDescoberta, combinacoes3Elementos, completion);
        }

        internal static void escreverFicheiroIngrediente(string ingrediente)
        {
            IOparser.escreverFicheiroIngrediente(ingrediente, listaChems, combinacoesEncontradas, combinacoesTestadas, combinacoesDescoberta, combinacoes3Elementos, combinacoes2Elementos, completion);
        }
    }
}
