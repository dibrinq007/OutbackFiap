using System;
using System.Collections.Generic;
using System.Text;

namespace OutbackFiap.Mobile.Services
{
    public interface IService<T> where T : new()
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        T Insert(T model);
        T Update(T model);
        void Delete(T model);
    }
}
