using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinacoes
{
    class ListaIngredientes : List<String>,IEnumerable
    {

        public ListaIngredientes(string[] chems)
        {
            // TODO: Complete member initialization
            foreach (string chem in chems)
            {
                this.Add(chem);
            }
        }
        public ListaIngredientes() :base()
        {
        }
        /// <summary>
        /// Creates a list of ingredients out of a string.
        /// </summary>
        /// <param name="lista">String containing the ingredients in the format "ing1+ing2".</param>
        public ListaIngredientes(String lista)
        {
            ListaIngredientes novaLista = new ListaIngredientes();
            string[] arrayLisa = lista.Split('+');
            foreach (string ingrediente in arrayLisa)
            {
                novaLista.Add(ingrediente);
            }
            //novaLista.Sort();
            AddRange(novaLista.Distinct<String>());
            Sort();
        }
        public override string ToString()
        {
            String outstring = "";
            foreach (String item in this)
            {
                if (item.CompareTo(this.Last()) != 0)
                {
                    outstring += item + "+";
                }
                else
                {
                    outstring += item;
                }
            }
            return outstring;
        }
        public void receberListaDeIngredientes(String lista)
        {
            string[] arrayLisa = lista.Split('+');
            this.AddRange(arrayLisa);
            this.Sort();
        }

        public CombinacoesDeIngredientes criarCombinacoesDe3Elementos()
        {
            CombinacoesDeIngredientes combinacoes = new CombinacoesDeIngredientes();
            int length = this.Count;
            for (int i = 0; i < length; i++)
            {
                String chem1 = this.ElementAt(i);
                for (int j = (i + 1); j < length; j++)
                {
                    String chem2 = this.ElementAt(j);
                    for (int k = (j + 1); k < length; k++)
                    {
                        combinacoes.Add(new ListaIngredientes( new string[] {chem1, chem2 , this.ElementAt(k)}));
                    }
                }
            }
            combinacoes.Sort();
            return combinacoes;
        }

        public CombinacoesDeIngredientes criarCombinacoesDe2Elementos()
        {
            CombinacoesDeIngredientes combinacoes = new CombinacoesDeIngredientes();
            int length = this.Count;
            for (int i = 0; i < length; i++)
            {
                String chem1 = this.ElementAt(i);
                for (int j = (i + 1); j < length; j++)
                {
                    combinacoes.Add(new ListaIngredientes( new string[] {chem1, this.ElementAt(j)}));
                }
            }
            combinacoes.Sort();
            return combinacoes;
        }

        public CombinacoesDeIngredientes criarCombinacoesDeDescoberta()
        {
            CombinacoesDeIngredientes lista = new CombinacoesDeIngredientes();
            lista.Add(this);
            return criarCombinacoesDeDescoberta(lista, 1);
        }

        /// <summary>
        /// Checks if another ListaIngredientes is contained in this ListaIngredientes.
        /// </summary>
        /// <param name="receita">ListaIngredientes to be compared.</param>
        /// <returns>Returns true if all the items in the input are found in this ListaIngredientes.</returns>
        public bool contemReceita(ListaIngredientes receita)
        {
            int count = 0;
            foreach (String item2 in receita)
            {
                if (this.Contains(item2))
                {
                    count++;
                }
            }
            return count == receita.Count;
        }
        private CombinacoesDeIngredientes criarCombinacoesDeDescoberta(CombinacoesDeIngredientes CI, int count)
        {
            if (this.Count <= count)
                return CI;
            else
            {
                CI.combinarMaisUm(this.ElementAt(count));
                return criarCombinacoesDeDescoberta(CI, count + 1);
            }
        }
    }
}
