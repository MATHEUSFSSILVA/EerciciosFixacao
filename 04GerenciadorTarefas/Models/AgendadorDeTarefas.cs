using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorTarefas.Models
{
    public class AgendadorDeTarefas
    {
        public AgendadorDeTarefas ()
        {
            Tarefas = new List<Tarefa>();
        }

        public List<Tarefa> Tarefas { get; set; }

        public void AdicionarTarefa (Tarefa tarefa)
        {
            Tarefas.Add(tarefa);
        }

        public void ConcluirTarefa (int indice)
        {
            int indiceListadoCorreto = indice-1;
            if (indiceListadoCorreto >= 0 && indiceListadoCorreto < Tarefas.Count)
            {
                Tarefas[indiceListadoCorreto].MarcarComoConcluida();
            }
        }

        public void ListarTarefas ()
        {

            if (Tarefas.Count > 0)
            {
                int indice = 0;
                foreach (Tarefa tarefa in Tarefas)
                {
                    Console.WriteLine ($"{indice+1} - Tarefa: {tarefa.Descricao}, Status: {tarefa.Status}");
                    indice =+ 1;
                }
            }
            else
            {
                Console.WriteLine ("Ainda não existe tarefas.");
            }
        }
    }
}