using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinacoes
{
    class ListaIngredientes : List<String>
    {
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

        public static ListaIngredientes criarListaDeIngredientes(String lista)
        {
            ListaIngredientes novaLista = new ListaIngredientes();
            string[] arrayLisa = lista.Split('+');
            foreach (string ingrediente in arrayLisa)
            {
                novaLista.Add(ingrediente);
            }
            novaLista.Sort();
            ListaIngredientes lOutput = new ListaIngredientes();
            lOutput.AddRange(novaLista.Distinct<String>());
            lOutput.Sort();
            return lOutput;
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
                        combinacoes.Add(chem1 + "+" + chem2 + "+" + this.ElementAt(k));
                    }
                }
            }
            combinacoes.Sort();
            return (CombinacoesDeIngredientes)combinacoes;
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
                    combinacoes.Add(chem1 + "+" + this.ElementAt(j));
                }
            }
            combinacoes.Sort();
            return combinacoes;
        }
        //public CombinacoesDeIngredientes criarCombinacoesDeDescoberta()
        //{
        //    CombinacoesDeIngredientes lista = new CombinacoesDeIngredientes();
        //    lista.Add(this.ElementAt(0));
        //    return criarCombinacoesDeDescoberta(lista, 1);
        //}

        //private CombinacoesDeIngredientes criarCombinacoesDeDescoberta(CombinacoesDeIngredientes CI, int count)
        //{
        //    if (this.Count <= count)
        //        return CI;
        //    else
        //    {
        //        CI.combinarMaisUm(this.ElementAt(count));
        //        return criarCombinacoesDeDescoberta(CI, count + 1);
        //    }
        //}

        //public CombinacoesDeIngredientes criarCombinacoesExclusivas(String receita)
        //{
        //    ListaIngredientes ingredientesReceita = criarListaDeIngredientes(receita);
        //    ListaIngredientes ingredientesSemReceita = new ListaIngredientes();
        //    ingredientesSemReceita.AddRange(this);
        //    ingredientesSemReceita.RemoveAll(ingredientesReceita.Contains);
        //    CombinacoesDeIngredientes combX = ingredientesSemReceita.criarCombinacoesDeDescoberta().combinarReceita(receita);

        //    return combX;
        //}


    }
}
