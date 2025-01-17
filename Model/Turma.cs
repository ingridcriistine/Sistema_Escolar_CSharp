using System.Collections.Generic;
using System.Linq;
using DataBase;

namespace Model;

public class Turma : DataBaseObject
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Periodo { get; set; }
    public int Professor { get; set; }
    public int Disciplina { get; set; }
    public List<int> Alunos { get; set; }

    protected override void LoadFrom(string[] data)
    {
        this.Id = int.Parse(data[0]);
        this.Periodo = data[1];
        this.Professor = int.Parse(data[2]);
        this.Disciplina = int.Parse(data[3]);
        this.Alunos = data[4].Split('.').Select(i => int.Parse(i)).ToList();
        this.Nome = data[5];
    }

    protected override string[] SaveTo() =>
        new string[]
        {
            this.Id.ToString(),
            this.Periodo,
            this.Professor.ToString(),
            this.Disciplina.ToString(),
            string.Join('.', this.Alunos),
            this.Nome,
        };
}
