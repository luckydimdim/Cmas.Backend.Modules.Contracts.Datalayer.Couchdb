using Cmas.Backend.Infrastructure.Domain.Queries;
using Cmas.Backend.Modules.Contracts.Criteria;
using Cmas.Backend.Modules.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cmas.Backend.Modules.Contracts.Datalayer.Couchdb.Queries
{
    public class FindByIdQuery : IQuery<FindById, Contract>
    {
        public Contract Ask(FindById criterion)
        {
            return new Contract{ Name = criterion.Id.ToString()};
        }
    }
}
