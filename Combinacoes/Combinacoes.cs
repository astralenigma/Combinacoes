﻿using System;
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

        public void removerConhecidas(CombinacoesDeIngredientes conhecidas)
        {
            foreach (String item in conhecidas)
            {
                removerCombinacoesDesnecessarias(item);
            }
        }

        public CombinacoesDeIngredientes adicionarCombinacoes(CombinacoesDeIngredientes novasCombin)
        {
            CombinacoesDeIngredientes uniao = new CombinacoesDeIngredientes();
            IEnumerable<String> union = this.Union<String>(novasCombin).Distinct();
            uniao.AddRange(union);
            return uniao;
        }

        //Arranjar um uso para isto
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
            Sort();
        }


        public void removerCombinacoesDesnecessarias(String receita)
        {
            ListaIngredientes receitaLI=ListaIngredientes.criarListaDeIngredientes(receita);
            RemoveAll(x=> receitaLI.contemReceita(ListaIngredientes.criarListaDeIngredientes(x)));

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
                contaCombi.removerCombinacoesDesnecessarias(gCombinacao);
            }
            cdi.Reverse();
            return cdi;
        }

        public CombinacoesDeIngredientes devolverCombinacoesDeElementos(ListaIngredientes elemento)
        {
            CombinacoesDeIngredientes comIngrediente = new CombinacoesDeIngredientes();
            List<String> lista = FindAll(x=> elemento.contemReceita(ListaIngredientes.criarListaDeIngredientes(x));
            comIngrediente.AddRange(lista);
            return comIngrediente;
        }

        public CombinacoesDeIngredientes devolverCombinacoesDeElementos(String elemento)
        {
            return devolverCombinacoesDeElementos(ListaIngredientes.criarListaDeIngredientes(elemento));
        }
    }

}
