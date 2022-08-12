using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        T GetByID(int Id);
        void Create(T item);
        void Update(T item);
        void Delete(int Id);
        T GetByString(string value);
        T GetByAuthData(string val_1, string val_2);
        
    }
}
