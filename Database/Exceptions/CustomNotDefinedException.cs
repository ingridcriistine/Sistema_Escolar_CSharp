using System;

namespace DataBase.Exceptions;

public class CustomNotDefinedException : Exception
{
    public override string Message =>
        """
            O arquivo custom não foi definido.
            Use DB<T>.SetCustom para definir seu local.
            """;
}
