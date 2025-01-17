using System;
using System.Collections.Generic;
using Model;
using Model.Repository;
using static System.Console;

IRepository<Aluno>? alunoRepo = null;
IRepository<Professor>? professorRepo = null;
IRepository<Turma>? turmaRepo = null;
IRepository<Disciplina>? disciplinaRepo = null;

// alunoRepo = new AlunoFakeRepository();
// professorRepo = new ProfessorFakeRepository();
// turmaRepo = new TurmaFakeRepository();
// disciplinaRepo = new DisciplinaFakeRepository();

alunoRepo = new AlunoRepository();
professorRepo = new ProfessorRepository();
turmaRepo = new TurmaRepository();
disciplinaRepo = new DisciplinaRepository();

while (true)
{
    try
    {
        Clear();
        WriteLine(
            """
                1 - Cadastrar Professor
                2 - Cadastrar Aluno
                3 - Cadastrar Turma
                4 - Cadastrar Disciplina
                5 - Ver professores
                6 - Ver alunos
                7 - Ver turma
                8 - Ver disciplina
                9- Sair
            """
        );

        int option = int.Parse(ReadLine());

        switch (option)
        {
            case 1:
                Clear();
                Professor professor = new();
                professor.Id = professorRepo.getMaxId() + 1;
                WriteLine("Insira o nome do professor: ");
                professor.Nome = ReadLine();
                WriteLine("Insira a formação: ");
                professor.Formacao = ReadLine();
                professorRepo.Add(professor);
                break;

            case 2:
                Clear();
                Aluno aluno = new();
                aluno.Id = alunoRepo.getMaxId() + 1;
                WriteLine("Insira o nome do aluno: ");
                aluno.Nome = ReadLine();
                WriteLine("Insira a idade do aluno: ");
                aluno.Idade = int.Parse(ReadLine());
                alunoRepo.Add(aluno);
                break;

            case 3:
                Clear();

                Turma turma = new();
                turma.Id = turmaRepo.getMaxId() + 1;

                WriteLine("Insira o nome: ");
                turma.Nome = ReadLine();

                WriteLine("Insira o periodo: ");
                turma.Periodo = ReadLine();

                WriteLine("\nLista de professores cadastrados: ");
                foreach (var prof in professorRepo.All)
                {
                    WriteLine($"{prof.Id} - {prof.Nome} - {prof.Formacao}");
                }
                ;
                WriteLine("\nInsira o id do professor: ");
                turma.Professor = int.Parse(ReadLine());

                WriteLine("\nLista de disciplinas cadastradas: ");
                foreach (var disc in disciplinaRepo.All)
                {
                    for (int i = 0; i < disc.Professores.Count; i++)
                    {
                        if (disc.Professores[i] == turma.Professor)
                        {
                            WriteLine(
                                $"""
                                    Disciplina: {disc.Id} - {disc.Nome}
                                """
                            );
                            WriteLine(
                                """
                                ---------------------------------
                                """
                            );
                        }
                    }
                }
                WriteLine("\nInsira o id da disciplina: ");
                turma.Disciplina = int.Parse(ReadLine());

                WriteLine("\nLista de alunos cadastrados: ");
                foreach (var alun in alunoRepo.All)
                {
                    WriteLine($"{alun.Id} - {alun.Nome} - {alun.Idade}");
                }
                ;

                WriteLine("\n");

                List<int> alunosTurma = [];
                while (true)
                {
                    WriteLine($"Digite o ID do aluno para adicionar ou -1 para prosseguir: ");
                    int id = int.Parse(ReadLine());

                    if (id == -1)
                    {
                        break;
                    }
                    else
                    {
                        var isValid = alunoRepo.findById(id);
                        if (isValid == null)
                        {
                            WriteLine($"Digite um ID válido!");
                        }
                        else
                        {
                            alunosTurma.Add(id);
                        }
                    }
                }

                turma.Alunos = alunosTurma;
                turmaRepo.Add(turma);
                break;

            case 4:
                Clear();

                Disciplina disciplina = new();
                disciplina.Id = disciplinaRepo.getMaxId() + 1;
                WriteLine("Insira o nome do disciplina: ");
                disciplina.Nome = ReadLine();

                WriteLine("\nLista de professores cadastrados: ");
                foreach (var prof in professorRepo.All)
                {
                    WriteLine($"{prof.Id} - {prof.Nome} - {prof.Formacao}");
                }

                List<int> profsDisciplina = [];
                while (true)
                {
                    WriteLine($"Digite o ID do professor para adicionar ou -1 para prosseguir: ");
                    int id = int.Parse(ReadLine());

                    if (id == -1)
                    {
                        break;
                    }
                    else
                    {
                        var isValid = professorRepo.findById(id);
                        if (isValid == null)
                        {
                            WriteLine($"Digite um ID válido!");
                        }
                        else
                        {
                            profsDisciplina.Add(id);
                        }
                    }
                }

                disciplina.Professores = profsDisciplina;
                disciplinaRepo.Add(disciplina);
                break;

            case 5:
                Clear();

                var profs = professorRepo.All;
                if (professorRepo.All.Count == 0)
                {
                    WriteLine(
                        $"""
                        A lista está vazia!
                        """
                    );
                }
                else
                {
                    foreach (var prof in profs)
                    {
                        WriteLine(
                            $"""
                                {prof.Id} - {prof.Formacao} - {prof.Nome}
                            ---------------------------------
                            """
                        );
                    }
                }

                break;

            case 6:
                Clear();

                var alunos = alunoRepo.All;

                if (alunoRepo.All.Count == 0)
                {
                    WriteLine(
                        $"""
                        A lista está vazia!
                        """
                    );
                }
                else
                {
                    foreach (var alun in alunos)
                    {
                        WriteLine(
                            $"""
                                {alun.Id} - {alun.Nome} - {alun.Idade}
                            ---------------------------------
                            """
                        );
                    }
                }

                break;

            case 7:
                Clear();

                var turmas = turmaRepo.All;

                if (turmaRepo.All.Count == 0)
                {
                    WriteLine(
                        $"""
                        A lista está vazia!
                        """
                    );
                }
                else
                {
                    WriteLine(
                        """
                        ---------------------------------
                        """
                    );

                    foreach (var turm in turmas)
                    {
                        var prof = professorRepo.findById(turm.Professor);
                        var disc = disciplinaRepo.findById(turm.Disciplina);
                        WriteLine(
                            $"""
                                Cod: {turm.Id} - Turma: {turm.Nome} - Período: {turm.Periodo}
                                Professor responsável: {prof.Nome}
                                Disciplina: {disc.Nome}
                                Alunos matriculados:
                            """
                        );

                        foreach (var id in turm.Alunos)
                        {
                            var alun = alunoRepo.findById(id);
                            WriteLine(
                                $"""
                                    {alun.Id} - {alun.Nome}
                                """
                            );
                        }

                        WriteLine(
                            """
                            ---------------------------------
                            """
                        );
                    }
                }

                break;

            case 8:
                Clear();

                var disciplinas = disciplinaRepo.All;

                if (disciplinaRepo.All.Count == 0)
                {
                    WriteLine(
                        $"""
                        A lista está vazia!
                        """
                    );
                }
                else
                {
                    WriteLine(
                        """
                        ---------------------------------
                        """
                    );

                    foreach (var disc in disciplinas)
                    {
                        WriteLine(
                            $"""
                                Disciplina: {disc.Id} - {disc.Nome}
                                Professores:
                            """
                        );

                        foreach (var id in disc.Professores)
                        {
                            var prof = professorRepo.findById(id);
                            WriteLine(
                                $"""
                                    {prof.Id} - {prof.Nome}
                                """
                            );
                        }
                        ;

                        WriteLine(
                            """
                            ---------------------------------
                            """
                        );
                    }
                }

                break;

            case 9:
                return;

            default:
                break;
        }
    }
    catch (Exception e)
    {
        WriteLine(e);
        WriteLine("Erro na aplicação, por favor consulte a TI");
    }

    WriteLine("Pressione qualquer tecla para continuar...");
    ReadKey(true);
}
