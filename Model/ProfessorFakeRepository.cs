using System.Collections.Generic;

namespace Model.Repository;

public class ProfessorFakeRepository : IRepository<Professor>
{
    List<Professor> professores = [];

    public ProfessorFakeRepository()
    {
        professores.Add(
            new()
            {
                Id = 0,
                Nome = "Gilmar",
                Formacao = "Doutor",
            }
        );
        professores.Add(
            new()
            {
                Id = 1,
                Nome = "Vanessa",
                Formacao = "Doutora",
            }
        );
    }

    public List<Professor> All => professores;

    public void Add(Professor obj) => this.professores.Add(obj);

    public Professor findById(int id)
    {
        foreach (var prof in professores)
        {
            if (prof.Id == id)
            {
                return prof;
            }
        }
        ;

        return null;
    }

    public int getMaxId()
    {
        throw new System.NotImplementedException();
    }
}
