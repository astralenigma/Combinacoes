using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinacoes
{
    class CombinacoesDeIngredientes : List<ListaIngredientes>
    {
        public override String ToString()
        {
            String list = "";
            foreach (ListaIngredientes comb in this)
            {
                list += comb.ToString() + "\n";
            }
            return list;
        }

        public void removerConhecidas(CombinacoesDeIngredientes conhecidas)
        {
            foreach (ListaIngredientes item in conhecidas)
            {
                removerCombinacoesDesnecessarias(item);
            }
        }

        public CombinacoesDeIngredientes adicionarCombinacoes(CombinacoesDeIngredientes novasCombin)
        {
            CombinacoesDeIngredientes uniao = new CombinacoesDeIngredientes();
            IEnumerable<ListaIngredientes> union = this.Union<ListaIngredientes>(novasCombin).Distinct();
            uniao.AddRange(union);
            return uniao;
        }

        //Arranjar um uso para isto
        public String contarComposicao()
        {
            ListaIngredientes lista = new ListaIngredientes();
            string sOutput = "";
            foreach (ListaIngredientes comb in this)
            {
                lista.AddRange(comb);
            }
            lista.Sort();
            String lastIng = "";
            int ingCount = 0;
            foreach (String curIng in lista)
            {
                if (lastIng.CompareTo(curIng) == 0)
                {
                    ingCount++;
                }
                else
                {
                    if (lastIng != "")
                    {
                        sOutput += ingCount + " ";
                    }
                    ingCount = 0;
                    sOutput += curIng + ": ";
                    lastIng = curIng;
                }
            }
            sOutput += ingCount;
            return sOutput;
        }
        public void combinarMaisUm(String segundaParte)
        {
            CombinacoesDeIngredientes novas = new CombinacoesDeIngredientes();
            foreach (ListaIngredientes comb in this)
            {
                if (!comb.Contains(segundaParte))
                {
                    comb.Add(segundaParte);
                    comb.Sort();
                    novas.Add(comb);
                }
            }
            this.Add(new ListaIngredientes(segundaParte));
            this.AddRange(novas);
        }

        public void removerReceita(ListaIngredientes receita)
        {
            CombinacoesDeIngredientes removidas = new CombinacoesDeIngredientes();
            CombinacoesDeIngredientes adicionadas = new CombinacoesDeIngredientes();
            foreach (ListaIngredientes combinacao in this)
            {
                if (combinacao.contemReceita(receita))
                {
                    foreach (String item2 in receita)
                    {
                        ListaIngredientes combL = new ListaIngredientes();
                        combL.AddRange(combinacao);
                        combL.Remove(item2);
                        adicionadas.Add(combL);
                    }
                    removidas.Add(combinacao);
                }
            }
            AddRange(adicionadas);
            foreach (ListaIngredientes item in removidas)
            {
                Remove(item);
            }
            Sort();
        }


        public void removerCombinacoesDesnecessarias(ListaIngredientes receita)
        {
            RemoveAll(x=> receita.contemReceita(x));
        }
        public CombinacoesDeIngredientes listarCombinacoesNecessarias()
        {
            CombinacoesDeIngredientes cdi = new CombinacoesDeIngredientes();
            CombinacoesDeIngredientes contaCombi = this;
            int count = 0;
            while (contaCombi.Count != 0)
            {
                count++;
                ListaIngredientes gCombinacao = contaCombi.Last();
                cdi.Add(gCombinacao);
                contaCombi.removerCombinacoesDesnecessarias(gCombinacao);
            }
            cdi.Reverse();
            return cdi;
        }

        public CombinacoesDeIngredientes devolverCombinacoesDeElementos(ListaIngredientes elemento, CombinacoesDeIngredientes combi)
        {
            CombinacoesDeIngredientes comIngrediente = new CombinacoesDeIngredientes();
            List<ListaIngredientes> lista = combi.FindAll(x => x.contemReceita(elemento));
            comIngrediente.AddRange(lista);
            return comIngrediente;
        }

        public CombinacoesDeIngredientes devolverCombinacoesDeElementos(String elemento, CombinacoesDeIngredientes combi)
        {
            return devolverCombinacoesDeElementos(new ListaIngredientes(elemento), combi);
        }
    }

}
