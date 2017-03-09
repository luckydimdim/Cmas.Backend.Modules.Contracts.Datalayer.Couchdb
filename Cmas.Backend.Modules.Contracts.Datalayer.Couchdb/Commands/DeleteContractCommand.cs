using Cmas.Backend.Infrastructure.Domain.Commands;
using Cmas.Backend.Modules.Contracts.CommandsContexts;
using Cmas.Backend.Modules.Contracts.Datalayer.Couchdb.Dtos;
using MyCouch;
using System.Threading.Tasks;

namespace Cmas.Backend.Modules.Contracts.Datalayer.Couchdb.Commands
{
    public class DeleteContractCommand : ICommand<DeleteContractCommandContext>
    {
        public async Task<DeleteContractCommandContext> Execute(DeleteContractCommandContext commandContext)
        {
            using (var store = new MyCouchStore("http://cmas-backend:backend967@cm-ylng-msk-03:5984", "cmas"))
            {
                await store.DeleteAsync(commandContext.id);
                
                return commandContext;
            }

        }
    }
}
