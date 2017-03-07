using Cmas.Backend.Infrastructure.Domain.Commands;
using Cmas.Backend.Modules.Contracts.CommandsContexts;
using Cmas.Backend.Modules.Contracts.Datalayer.Couchdb.Dtos;
using MyCouch;
using System.Threading.Tasks;

namespace Cmas.Backend.Modules.Contracts.Datalayer.Couchdb.Commands
{
    public class UpdateContractCommand : ICommand<UpdateContractCommandContext>
    {
        public async Task<UpdateContractCommandContext> Execute(UpdateContractCommandContext commandContext)
        {
            using (var client = new MyCouchClient("http://cmas-backend:backend967@cm-ylng-msk-03:5984", "cmas"))
            {
                // FIXME: нельзя так делать, надо от frontend получать
                var existingDoc = (await client.Entities.GetAsync<ContractDto>(commandContext.id)).Content;

                if (commandContext.Name != null)
                {
                    existingDoc.Name = commandContext.Name;
                }

                if (commandContext.Number != null)
                {
                    existingDoc.Number = commandContext.Number;
                }

                if (commandContext.StartDate != null)
                {
                    existingDoc.StartDate = commandContext.StartDate;
                }

                if (commandContext.FinishDate != null)
                {
                    existingDoc.FinishDate = commandContext.FinishDate;
                }

                if (commandContext.ContractorName != null)
                {
                    existingDoc.ContractorName = commandContext.ContractorName;
                }

                if (commandContext.Currency != null)
                {
                    existingDoc.Currency = commandContext.Currency;
                }

                if (commandContext.Amount != null)
                {
                    existingDoc.Amount = commandContext.Amount;
                }

                if (commandContext.VatIncluded.HasValue)
                {
                    existingDoc.VatIncluded = commandContext.VatIncluded.Value;
                }

                if (commandContext.ConstructionObjectName != null)
                {
                    existingDoc.ConstructionObjectName = commandContext.ConstructionObjectName;
                }

                if (commandContext.ConstructionObjectTitleName != null)
                {
                    existingDoc.ConstructionObjectTitleName = commandContext.ConstructionObjectTitleName;
                }

                if (commandContext.ConstructionObjectTitleCode != null)
                {
                    existingDoc.ConstructionObjectTitleCode = commandContext.ConstructionObjectTitleCode;
                }

                if (commandContext.Description != null)
                {
                    existingDoc.Description = commandContext.Description;
                }

                var result = await client.Entities.PutAsync<ContractDto>(existingDoc._id, existingDoc);

                // TODO: возвращать _revid

                return commandContext;
            }

        }
    }
}
