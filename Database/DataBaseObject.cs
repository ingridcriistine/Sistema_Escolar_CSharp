namespace DataBase;

public abstract class DataBaseObject
{
    protected internal abstract void LoadFrom(string[] data);
    protected internal abstract string[] SaveTo();
}
