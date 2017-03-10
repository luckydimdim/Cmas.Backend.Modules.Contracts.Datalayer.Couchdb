using System;
using System.Linq;
using Cmas.Backend.Infrastructure.Domain.Commands;
using Cmas.Backend.Modules.Contracts.CommandsContexts;
using Cmas.Backend.Modules.Contracts.Datalayer.Couchdb.Dtos;
using MyCouch;
using System.Threading.Tasks;
using MyCouch.Requests;

namespace Cmas.Backend.Modules.Contracts.Datalayer.Couchdb.Commands
{
    public class CreateContractCommand : ICommand<CreateContractCommandContext>
    {
        public async Task<CreateContractCommandContext> Execute(CreateContractCommandContext commandContext)
        {
            using (var store = new MyCouchStore("http://cmas-backend:backend967@cm-ylng-msk-03:5984", "cmas"))
            {

                var query = new QueryViewRequest("contracts", "empty");

                var viewResult = await store.Client.Views.QueryAsync(query);

                var firstRow = viewResult.Rows.FirstOrDefault();

                if (firstRow != null)
                {
                    commandContext.id = firstRow.Id;
                }
                else
                {
                    var doc = new ContractDto();

                    doc.UpdatedAt = DateTime.Now;
                    doc.CreatedAt = DateTime.Now;
                    doc.Status = "empty";

                    var result = await store.Client.Entities.PostAsync(doc);

                    commandContext.id = result.Id;
                }

               

                return commandContext;
            }

        }
    }
}
