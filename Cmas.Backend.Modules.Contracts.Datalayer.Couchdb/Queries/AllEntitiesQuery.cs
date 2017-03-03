using Cmas.Backend.Infrastructure.Domain.Queries;
using Cmas.Backend.Modules.Contracts.Criteria;
using Cmas.Backend.Modules.Contracts.Entities;
using MyCouch;
using MyCouch.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Cmas.Backend.Modules.Contracts.Datalayer.Couchdb.Queries
{
    public class AllEntitiesQuery : IQuery<AllEntities, Task<IEnumerable<Contract>>>
    {
        public async Task<IEnumerable<Contract>> Ask(AllEntities criterion)
        {
            using (var client = new MyCouchClient("http://cmas-backend:backend967@cm-ylng-msk-03:5984", "cmas"))
            {
                var result = new List<Contract>();

                var query = new QueryViewRequest("contracts", "all");

                var viewResult = await client.Views.QueryAsync<Contract>(query);

                foreach (var row in viewResult.Rows)
                {
                    result.Add(row.Value);
                }

                return result;
            }
        }
    }


}
