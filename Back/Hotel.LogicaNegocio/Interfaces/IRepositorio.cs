using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.LogicaNegocio.Interfaces
{
    public interface IRepositorio <T> where T : class
    {
        #region FIRMAS
        // Add
        public void Create(T t);
        // Update
        public void Update(T t);
        // Delete
        public void Delete(int id);
        // Get
        public T GetById(int id);
        public IEnumerable<T> GetAll();
        #endregion
    }
}
