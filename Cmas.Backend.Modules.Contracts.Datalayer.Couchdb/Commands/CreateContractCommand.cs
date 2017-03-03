using Cmas.Backend.Infrastructure.Domain.Commands;
using Cmas.Backend.Modules.Contracts.CommandsContexts;
using Cmas.Backend.Modules.Contracts.Datalayer.Couchdb.Dtos;
using MyCouch;
using System.Threading.Tasks;

namespace Cmas.Backend.Modules.Contracts.Datalayer.Couchdb.Commands
{
    public class CreateContractCommand : ICommand<CreateContractCommandContext>
    {
        public async Task<CreateContractCommandContext> Execute(CreateContractCommandContext commandContext)
        {
            using (var client = new MyCouchClient("http://cmas-backend:backend967@cm-ylng-msk-03:5984", "cmas"))
            {
                var doc = new ContractDto();

                doc.Name = commandContext.Name;
                doc.Number = commandContext.Number;
                doc.StartDate = commandContext.StartDate;
                doc.FinishDate = commandContext.FinishDate;
                doc.ContractorName = commandContext.ContractorName;
                doc.Currency = commandContext.Currency;
                doc.Amount = commandContext.Amount;
                doc.VatIncluded = commandContext.VatIncluded;
                doc.ConstructionObjectName = commandContext.ConstructionObjectName;
                doc.ConstructionObjectTitleName = commandContext.ConstructionObjectTitleName;
                doc.ConstructionObjectTitleCode = commandContext.ConstructionObjectTitleCode;
                doc.Description = commandContext.Description;

                var result = await client.Entities.PostAsync(doc);

                commandContext.id = result.Content.Id;

                return commandContext;
            }

        }
    }
}
