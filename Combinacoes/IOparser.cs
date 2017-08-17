using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinacoes
{
    class IOparser
    {
        /// <summary>
        /// Method that reads the file to create the input lists.
        /// </summary>
        public static void lerFicheiro(out ListaIngredientes listaChems, out CombinacoesDeIngredientes combinacoesEncontradas, out CombinacoesDeIngredientes combinacoesTestadas, out CombinacoesDeIngredientes combinacoesDescoberta, string completion)
        {
            Console.Write("Reading file...");
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
                                combinacoesEncontradas.Add(new ListaIngredientes(line));
                                break;
                            case 3: combinacoesTestadas.Add(new ListaIngredientes(line));
                                break;
                            default: Console.WriteLine("Erro");
                                break;
                        }
                        break;
                }
            }
            RemoverDuplicados(listaChems);
            combinacoesDescoberta.Add(listaChems);
            //combinacoesDescoberta.Sort((a, b) => b.Length.CompareTo(a.Length));
            Console.WriteLine(completion);

        }

        /// <summary>
        /// Removes duplicated items from the input list.
        /// </summary>
        /// <param name="lista">List from which to remove duplicity.</param>

        private static void RemoverDuplicados(List<String> lista)
        {
            List<String> listaNaoDuplicada = new List<string>();
            listaNaoDuplicada.AddRange(lista.Distinct());
            lista.Clear();
            lista.AddRange(listaNaoDuplicada);
            lista.Sort();
        }

        /// <summary>
        /// Writes the results to a file for later reading.
        /// </summary>
        public static void escreverFicheiro(ListaIngredientes listaChems, CombinacoesDeIngredientes combinacoesEncontradas, CombinacoesDeIngredientes combinacoesTestadas, CombinacoesDeIngredientes combinacoesDescoberta, CombinacoesDeIngredientes combinacoes3Elementos, string completion)
        {
            Console.Write("Writting results to file...");
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"output.txt"))
            {

                file.WriteLine("-");
                foreach (String item in listaChems)
                {
                    file.WriteLine(item);
                }
                file.WriteLine("--");
                foreach (ListaIngredientes item in combinacoesEncontradas)
                {
                    file.WriteLine(item);
                }
                file.WriteLine("---");
                foreach (ListaIngredientes item in combinacoesTestadas)
                {
                    file.WriteLine(item);
                }
                file.WriteLine("----");

                foreach (ListaIngredientes item in combinacoesDescoberta)
                {
                    file.WriteLine(item);
                }
                file.WriteLine("-----");
                file.WriteLine("You need to make at least " + combinacoesDescoberta.Count + " combinations to make sure there are no more recipes.");
                file.WriteLine("There are at least " + combinacoes3Elementos.Count + " combinations of 3.");
                Console.WriteLine(completion);
            }
        }
        public static void escreverFicheiroIngrediente(String ingrediente, ListaIngredientes listaChems, CombinacoesDeIngredientes combinacoesEncontradas, CombinacoesDeIngredientes combinacoesTestadas, CombinacoesDeIngredientes combinacoesDescoberta, CombinacoesDeIngredientes combinacoes3Elementos, string completion)
        {
            Console.Write("Calculating combinations...");
            CombinacoesDeIngredientes combiIEncontrado = combinacoesEncontradas.devolverCombinacoesDeElementos(ingrediente, combinacoesDescoberta);
            Console.WriteLine(completion);
            Console.Write("Writting results to file...");
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"output" + ingrediente + ".txt"))
            {

                file.WriteLine("-");
                foreach (String item in listaChems)
                {
                    file.WriteLine(item);
                }
                file.WriteLine("--");
                foreach (ListaIngredientes item in combinacoesEncontradas)
                {
                    file.WriteLine(item);
                }
                file.WriteLine("---");
                foreach (ListaIngredientes item in combinacoesTestadas)
                {
                    file.WriteLine(item);
                }
                file.WriteLine("----");

                foreach (ListaIngredientes item in combiIEncontrado)
                {
                    file.WriteLine(item);
                }
                file.WriteLine("-----");
                file.WriteLine("You need to make at least " + combiIEncontrado.Count + " combinations to make sure there are no more recipes.");
                file.WriteLine("There are at least " + combinacoes3Elementos.Count + " combinations of 3.");
                Console.WriteLine(completion);
            }
        }

    }
}
