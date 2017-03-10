using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cmas.Backend.Modules.Contracts.CommandsContexts;
using Cmas.Backend.Modules.Contracts.Criteria;
using Cmas.Backend.Modules.Contracts.Datalayer.Couchdb.Commands;
using Cmas.Backend.Modules.Contracts.Datalayer.Couchdb.Queries;
using Cmas.Backend.Modules.Contracts.Entities;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //FindByIdQueryTest().Wait();
                FindAllEntitiesTest().Wait();
                //UpdateContractCommand().Wait();
                //DeleteContractCommand().Wait();
                //CreateContractCommand().Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
         

            Console.ReadKey();
        }


        static async Task<bool> FindByIdQueryTest()
        {
            FindByIdQuery findByIdQuery = new FindByIdQuery();
            FindById criterion = new FindById{Id = "26270cfa2422b2c4ebf158285e027730" };
            Contract result = null;

            try
            {
                result = await findByIdQuery.Ask(criterion);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            Console.WriteLine(result.Id);

            return true;
        }

        static async Task<bool> FindAllEntitiesTest()
        {
            AllEntitiesQuery query = new AllEntitiesQuery();
            AllEntities criterion = null;
            IEnumerable<Contract> result = null;

           
               result = await query.Ask(criterion);
           
            Console.WriteLine(result.Count());

            return true;
        }

        static async Task<bool> UpdateContractCommand()
        {
            var commandContext = new UpdateContractCommandContext();
            var createContractCommand = new UpdateContractCommand();

            commandContext.Name = "new name";
            commandContext.id = "26270cfa2422b2c4ebf158285e0200a5";

            var result = await createContractCommand.Execute(commandContext);

            return true;
        }

        static async Task<bool>DeleteContractCommand()
        {
            var commandContext = new DeleteContractCommandContext();
            var command = new DeleteContractCommand();

            commandContext.id = "26270cfa2422b2c4ebf158285e0241e5";

            var result = await command.Execute(commandContext);

            return true;
        }

        static async Task<bool> CreateContractCommand()
        {
            var commandContext = new CreateContractCommandContext();
            var command = new CreateContractCommand();

            var result = await command.Execute(commandContext);

            return true;
        }
    }
}
