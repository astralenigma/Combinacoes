using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinacoes
{
    class Program
    {
        static void Main(string[] args)
        {
            //ListaIngredientes listaChems = criarListaIngredientes();
            //CombinacoesDeIngredientes combinacoes3Elementos = criarCombinacoesDe3Elementos(listaChems);
            //CombinacoesDeIngredientes combinacoesDescoberta = listaChems.criarCombinacoesDeDescoberta();
            //CombinacoesDeIngredientes combinacoesEncontradas = criarListaCombinacoesEncontradas();
            //CombinacoesDeIngredientes combinacoesTestadas = listarCombinacoesFalhadas(criarListaCombinacoesTestadas());

            //combinacoesDescoberta = calcularListaDescoberta(listaChems, combinacoesDescoberta, combinacoesEncontradas, combinacoesTestadas);

            //listarReceitas(combinacoesDescoberta);
            ////Console.WriteLine();
            ////String ingrediente = "Eu";

            ////calcularListaDescobertaI(listaChems, combinacoesEncontradas, combinacoesTestadas, ingrediente);
            //Console.WriteLine();

            //listarCalculoListaDescobertaI(listaChems, combinacoesEncontradas, combinacoesTestadas);

            //Console.WriteLine();

            //combinacoes3Elementos = calcularCombinacoes3(combinacoes3Elementos, combinacoesEncontradas, combinacoesTestadas);

            InterfaceCombi.lerFicheiro();
            InterfaceCombi.processarInformacao();
            InterfaceCombi.escreverFicheiro();
            //System.Console.WriteLine(combinacoes3Elementos.ToString());
            //Console.WriteLine(combinacoes3Elementos.Count);
            //Console.WriteLine(combinacoes3Elementos.contarComposicao());
            Console.WriteLine("FIM");
            System.Console.ReadLine();
        }

        private static CombinacoesDeIngredientes calcularCombinacoes3(CombinacoesDeIngredientes combinacoes3Elementos, CombinacoesDeIngredientes combinacoesEncontradas, CombinacoesDeIngredientes combinacoesTestadas)
        {
            Console.WriteLine(combinacoes3Elementos.Count);
            combinacoes3Elementos = combinacoes3Elementos.removerConhecidas(combinacoesEncontradas);
            Console.WriteLine(combinacoes3Elementos.Count);
            combinacoes3Elementos = combinacoes3Elementos.removerConhecidas(combinacoesTestadas);
            Console.WriteLine(combinacoes3Elementos.Count);
            return combinacoes3Elementos;
        }

        static CombinacoesDeIngredientes criarCombinacoesDe3Elementos(ListaIngredientes lista)
        {
            CombinacoesDeIngredientes combinacoes = lista.criarCombinacoesDe3Elementos();
            return combinacoes;
        }
    }
}
