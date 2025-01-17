using System.Collections.Generic;
using DataBase;

namespace Model.Repository;

public class AlunoRepository : IRepository<Aluno>
{
    List<Aluno> alunos = [];
    DB<Aluno> database = DB<Aluno>.App;

    public AlunoRepository()
    {
        alunos.Add(
            new()
            {
                Id = 0,
                Nome = "Nycollas",
                Idade = 21,
            }
        );
        alunos.Add(
            new()
            {
                Id = 1,
                Nome = "Ingrid",
                Idade = 20,
            }
        );
        alunos.Add(
            new()
            {
                Id = 2,
                Nome = "Juan",
                Idade = 20,
            }
        );
        alunos.Add(
            new()
            {
                Id = 3,
                Nome = "Milena",
                Idade = 19,
            }
        );

        alunos = database.All;
    }

    public List<Aluno> All => alunos;

    public void Add(Aluno obj)
    {
        this.alunos.Add(obj);
        database.Save(this.alunos);
    }

    public Aluno findById(int id)
    {
        foreach (var alun in alunos)
        {
            if (alun.Id == id)
            {
                return alun;
            }
        }

        return null;
    }

    public int getMaxId()
    {
        var maior = 0;

        for (int i = 0; i < alunos.Count; i++)
        {
            if (alunos[i].Id > maior)
            {
                maior = alunos[i].Id;
            }
        }

        return maior;
    }
}
