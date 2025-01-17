using System.Collections.Generic;
using DataBase;

namespace Model.Repository;

public class DisciplinaRepository : IRepository<Disciplina>
{
    List<Disciplina> disciplinas = [];
    DB<Disciplina> database = DB<Disciplina>.App;

    public DisciplinaRepository()
    {
        disciplinas.Add(
            new()
            {
                Id = 1,
                Nome = "10",
                Professores = [0, 1],
            }
        );

        disciplinas = database.All;
    }

    public List<Disciplina> All => disciplinas;

    public void Add(Disciplina obj)
    {
        this.disciplinas.Add(obj);
        database.Save(this.disciplinas);
    }

    public Disciplina findById(int id)
    {
        foreach (var disc in disciplinas)
        {
            if (disc.Id == id)
            {
                return disc;
            }
        }

        return null;
    }

    public int getMaxId()
    {
        var maior = 0;

        for (int i = 0; i < disciplinas.Count; i++)
        {
            if (disciplinas[i].Id > maior)
            {
                maior = disciplinas[i].Id;
            }
        }

        return maior;
    }
}
