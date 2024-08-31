using GerenciadorTarefas;
using GerenciadorTarefas.Models;

AgendadorDeTarefas agendador = new AgendadorDeTarefas();

Tarefa tarefa1 = new Tarefa("Estudar pra caramba pra ganhar bastante dinheirinho");
Tarefa tarefa2 = new Tarefa("Trabalhar pra caramba para ser escravizado");

agendador.AdicionarTarefa(tarefa1);
agendador.AdicionarTarefa(tarefa2);
agendador.ConcluirTarefa(2);
agendador.ListarTarefas();