using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinacoes
{
    class CombinacoesDeIngredientes : List<String>
    {
        public override String ToString()
        {
            String list = "";
            foreach (String comb in this)
            {
                list += comb + "\n";
            }
            return list;
        }

        public CombinacoesDeIngredientes removerConhecidas(CombinacoesDeIngredientes conhecidas)
        {
            CombinacoesDeIngredientes combsX = new CombinacoesDeIngredientes();
            combsX.AddRange(this.Except(conhecidas));
            return combsX;
        }

        public CombinacoesDeIngredientes adicionarCombinacoes(CombinacoesDeIngredientes novasCombin)
        {
            CombinacoesDeIngredientes uniao = new CombinacoesDeIngredientes();
            IEnumerable<String> union = this.Union<String>(novasCombin).Distinct();
            uniao.AddRange(union);

            //foreach (String comb in union)
            //{
            //    uniao.Add(comb);
            //}
            return uniao;
        }

        public String contarComposicao()
        {
            ListaIngredientes lista = new ListaIngredientes();
            string sOutput = "";
            foreach (String comb in this)
            {
                lista.receberListaDeIngredientes(comb);
            }
            lista.Sort();
            String lastIng = "";
            int countIng = 0;
            foreach (String ingCount in lista)
            {
                if (lastIng.CompareTo(ingCount) == 0)
                {
                    countIng++;
                }
                else
                {
                    if (lastIng != "")
                    {
                        sOutput += countIng + " ";
                    }
                    countIng = 0;
                    sOutput += ingCount + " ";
                    lastIng = ingCount;
                }
            }
            sOutput += countIng;
            return sOutput;
        }
        public void combinarMaisUm(String segundaParte)
        {
            CombinacoesDeIngredientes novas = new CombinacoesDeIngredientes();
            foreach (string comb in this)
            {
                ListaIngredientes liComb = ListaIngredientes.criarListaDeIngredientes(comb);
                if (!liComb.Contains(segundaParte))
                {
                    liComb.Add(segundaParte);
                    liComb.Sort();
                    novas.Add(liComb.ToString());
                }
            }
            this.Add(segundaParte);
            this.AddRange(novas);
        }

        public void removerReceita(String receita)
        {
            ListaIngredientes receitaLI = ListaIngredientes.criarListaDeIngredientes(receita);
            CombinacoesDeIngredientes removidas = new CombinacoesDeIngredientes();
            CombinacoesDeIngredientes adicionadas = new CombinacoesDeIngredientes();
            foreach (String item in this)
            {
                ListaIngredientes combinacao = ListaIngredientes.criarListaDeIngredientes(item);
                if (combinacao.contemReceita(receitaLI))
                {
                    foreach (String item2 in receitaLI)
                    {
                        ListaIngredientes combL = new ListaIngredientes();
                        combL.AddRange(combinacao);
                        combL.Remove(item2);
                        adicionadas.Add(combL.ToString());
                    }
                    removidas.Add(combinacao.ToString());
                }
            }
            AddRange(adicionadas);
            foreach (String item in removidas)
            {
                Remove(item);
            }
        }

        //public CombinacoesDeIngredientes combinarReceita(String segundaReceita)
        //{
        //    ListaIngredientes listaReceita = ListaIngredientes.criarListaDeIngredientes(segundaReceita);
        //    CombinacoesDeIngredientes novas = new CombinacoesDeIngredientes();
        //    foreach (string comb in this)
        //    {
        //        ListaIngredientes liComb = ListaIngredientes.criarListaDeIngredientes(comb);
        //        foreach (String ingRec in listaReceita)
        //        {
        //            liComb.Add(ingRec);
        //            liComb.Sort();
        //        }
        //        novas.Add(liComb.ToString());
        //    }
        //    return novas;
        //}

        //public int ContarCombinacoesRestantes()
        //{
        //    CombinacoesDeIngredientes contaCombi = this;
        //    int count = 0;
        //    while (contaCombi.Count!=0)
        //    {
        //        count++;
        //        String gCombinacao = contaCombi.Last();
        //        CombinacoesDeIngredientes listaEliminacao = ListaIngredientes.criarListaDeIngredientes(gCombinacao).criarCombinacoesDeDescoberta();
        //        contaCombi=contaCombi.removerConhecidas(listaEliminacao);
        //    }
        //    return count;
        //}
        public void removerCombinacoesDesnecessarias(String receita)
        {
            ListaIngredientes receitaLI=ListaIngredientes.criarListaDeIngredientes(receita);
            RemoveAll(x=> receitaLI.contemReceita(ListaIngredientes.criarListaDeIngredientes(x));

        }
        public CombinacoesDeIngredientes listarCombinacoesNecessarias()
        {
            CombinacoesDeIngredientes cdi = new CombinacoesDeIngredientes();
            CombinacoesDeIngredientes contaCombi = this;
            int count = 0;
            while (contaCombi.Count != 0)
            {
                count++;
                String gCombinacao = contaCombi.Last();
                cdi.Add(gCombinacao);
                //CombinacoesDeIngredientes listaEliminacao = ListaIngredientes.criarListaDeIngredientes(gCombinacao).criarCombinacoesDeDescoberta();
                contaCombi.removerCombinacoesDesnecessarias(gCombinacao);
            }
            cdi.Reverse();
            return cdi;
        }
    }

}
