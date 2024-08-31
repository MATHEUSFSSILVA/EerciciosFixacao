using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorTarefas
{
    public class Tarefa
    {
        public Tarefa (string tarefa)
        {
            Descricao = tarefa;
            Status = false;
        }

        public string Descricao { get; set; }
        public bool Status { get; set; }
        
        public void MarcarComoConcluida ()
        {
            Status = true;
        }
    }
}