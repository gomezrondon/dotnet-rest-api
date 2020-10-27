using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander.Models;

namespace Commander.Data
{
    public interface ICommanderRepo
    {
        void InsertCommand(Command command);
        IEnumerable<Command> GetAppCommands();
        Command GetCommandById(String id);

    }
}
