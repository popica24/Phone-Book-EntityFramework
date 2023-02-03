using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookEntityFramework
{
    public interface IContacts<T,S>
    {
        List<T> Search(S entitySearchParameters);
        int Create(T entity);
        void Update(T entity,S entityUpdateParameters);
        T GetById(int entityId);
        void Delete(T entity);
    }
}
