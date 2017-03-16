using Cmas.Backend.Infrastructure.Domain.Criteria;
using Cmas.Backend.Infrastructure.Domain.Queries;
using Cmas.Backend.Modules.Contracts.Datalayer.Couchdb.Dtos;
using Cmas.Backend.Modules.Contracts.Entities;
using MyCouch;
using System.Threading.Tasks;

namespace Cmas.Backend.Modules.Contracts.Datalayer.Couchdb.Queries
{
    public class FindByIdQuery : IQuery<FindById, Task<Contract>>
    {

        public async Task<Contract> Ask(FindById criterion)
        {
            using (var client = new MyCouchClient("http://cmas-backend:backend967@cm-ylng-msk-03:5984", "cmas"))
            {

                var result = new Contract();

                var dto = await client.Entities.GetAsync<ContractDto>(criterion.Id);

                var content = dto.Content;

                result.Id = content._id;
                result.Name = content.Name;
                result.Number = content.Number;
                result.StartDate = content.StartDate;
                result.FinishDate = content.FinishDate;
                result.ContractorName = content.ContractorName;
                result.Currency = content.Currency;
                result.Amount = content.Amount;
                result.VatIncluded = content.VatIncluded;
                result.ConstructionObjectName = content.ConstructionObjectName;
                result.ConstructionObjectTitleName = content.ConstructionObjectTitleName;
                result.ConstructionObjectTitleCode = content.ConstructionObjectTitleCode;
                result.Description = content.Description;

                return result;
            }

        }
    }
}
