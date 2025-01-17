using System.Collections.Generic;
using DataBase;

namespace Model;

public interface IRepository<T>
    where T : DataBaseObject
{
    List<T> All { get; }
    void Add(T obj);
    T findById(int id);
    int getMaxId();
}
