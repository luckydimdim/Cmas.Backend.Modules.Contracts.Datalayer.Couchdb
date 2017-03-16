using Cmas.Backend.Infrastructure.Domain.Queries;
using Cmas.Backend.Modules.Contracts.Entities;
using MyCouch;
using MyCouch.Requests;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cmas.Backend.Modules.Contracts.Datalayer.Couchdb.Dtos;
using Cmas.Backend.Infrastructure.Domain.Criteria;

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

                var viewResult = await client.Views.QueryAsync<ContractDto>(query);

                foreach (var row in viewResult.Rows.OrderByDescending(s=>s.Value.CreatedAt))
                {
                    Contract c = new Contract();

                    c.Id = row.Value._id;
                    c.Name = row.Value.Name;
                    c.Number = row.Value.Number;
                    c.StartDate = row.Value.StartDate;
                    c.FinishDate = row.Value.FinishDate;
                    c.ContractorName = row.Value.ContractorName;
                    c.Currency = row.Value.Currency;
                    c.Amount = row.Value.Amount;
                    c.VatIncluded = row.Value.VatIncluded;
                    c.ConstructionObjectName = row.Value.ConstructionObjectName;
                    c.ConstructionObjectTitleName = row.Value.ConstructionObjectTitleName;
                    c.ConstructionObjectTitleCode = row.Value.ConstructionObjectTitleCode;
                    c.Description = row.Value.Description;

                    result.Add(c);
                }

                return result;
            }
        }
    }


}
