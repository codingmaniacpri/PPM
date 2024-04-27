using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace PPM.Model
{
public interface IEntityOperation<T>
{
    void Add(T entity);
    List<T> ListAll();
    T ListById(int id);
    void Delete(int id);

}
}