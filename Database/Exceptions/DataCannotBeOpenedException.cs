using System;

namespace DataBase.Exceptions;

public class DataCannotBeOpenedException : Exception
{
    private string file;

    public DataCannotBeOpenedException(string file) => this.file = file;

    public override string Message =>
        $"""
                Os dados não puderam ser lidos/escritos no arquivo '{file}'.
            """;
}
