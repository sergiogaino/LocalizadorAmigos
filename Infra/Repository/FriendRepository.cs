using Domain.Entities;
using Domain.Interface;
using Infra.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repository
{
    public class FriendRepository : GenericRepository<Friend>, FriendInterface
    {
    }
}
