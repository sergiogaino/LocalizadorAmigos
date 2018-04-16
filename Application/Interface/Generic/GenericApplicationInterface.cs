using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface.Generic
{
    public interface GenericApplicationInterface<T> where T : class
    {
        void Add(T Entitie);

        void Update(T Entitie);

        void Delete(int Id);

        List<T> List();

        List<T> ListThreFriends(T Entitie);

        T GetForId(int id);
    }
}
