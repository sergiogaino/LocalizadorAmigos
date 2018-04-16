using Application.Interface;
using Domain.Entities;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.App
{
    public class MathLogApplication : MathLogApplicationInterface
    {
        MathLogInterface _MathLogInterface;

        public MathLogApplication(MathLogInterface MathLogInterface)
        {
            _MathLogInterface = MathLogInterface;
        }

        public void Add(MathLog Entitie)
        {
            _MathLogInterface.Add(Entitie);
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public MathLog GetForId(int id)
        {
            throw new NotImplementedException();
        }

        public List<MathLog> List()
        {
            throw new NotImplementedException();
        }

        public List<MathLog> ListThreFriends(MathLog Entitie)
        {
            throw new NotImplementedException();
        }

        public void Update(MathLog Entitie)
        {
            throw new NotImplementedException();
        }
    }
}
