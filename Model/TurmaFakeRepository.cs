using System.Collections.Generic;

namespace Model.Repository;

public class TurmaFakeRepository : IRepository<Turma>
{
    List<Turma> turmas = [];

    public TurmaFakeRepository()
    {
        turmas.Add(
            new()
            {
                Id = 1,
                Periodo = "Noturno",
                Alunos = [0, 1, 2, 3],
            }
        );
    }

    public List<Turma> All => turmas;

    public void Add(Turma obj) => this.turmas.Add(obj);

    public Turma findById(int id)
    {
        throw new System.NotImplementedException();
    }

    public int getMaxId()
    {
        throw new System.NotImplementedException();
    }
}
