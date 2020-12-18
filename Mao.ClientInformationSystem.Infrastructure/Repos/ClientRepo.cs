using Mao.ClientInformationSystem.Core.Entities;
using Mao.ClientInformationSystem.Core.RepoInterfaces;
using Mao.ClientInformationSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mao.ClientInformationSystem.Infrastructure.Repos
{
    public class ClientRepo: EfRepo<Clients> ,IClientRepo
    {
        public ClientRepo(ClientInformationSystemDbContext dbContext) : base(dbContext)
        {
        }
    }
}
