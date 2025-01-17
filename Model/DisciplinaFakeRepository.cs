using System.Collections.Generic;

namespace Model.Repository;

public class DisciplinaFakeRepository : IRepository<Disciplina>
{
    List<Disciplina> disciplinas = [];

    public DisciplinaFakeRepository()
    {
        disciplinas.Add(
            new()
            {
                Id = 1,
                Nome = "10",
                Professores = [0, 1],
            }
        );
    }

    public List<Disciplina> All => disciplinas;

    public void Add(Disciplina obj) => this.disciplinas.Add(obj);

    public Disciplina findById(int id)
    {
        throw new System.NotImplementedException();
    }

    public int getMaxId()
    {
        throw new System.NotImplementedException();
    }
}
