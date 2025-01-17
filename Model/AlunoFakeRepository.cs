using System.Collections.Generic;

namespace Model.Repository;

public class AlunoFakeRepository : IRepository<Aluno>
{
    List<Aluno> alunos = [];

    public AlunoFakeRepository()
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
    }

    public List<Aluno> All => alunos;

    public void Add(Aluno obj) => this.alunos.Add(obj);

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
        throw new System.NotImplementedException();
    }
}
