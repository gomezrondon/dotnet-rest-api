using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public IEnumerable<Command> GetAppCommands()
        {
            var commands = new List<Command> {
                new Command { Id = 0, HowTo = "dotnet new", Line = "dotnet new", Platform = ".Net" },
            new Command { Id = 1, HowTo = "dotnet new webapi -n <app name>", Line = "dotnet new webapi -n <app name>", Platform = ".Net" },
            new Command { Id = 2, HowTo = "dotnet new gitignore", Line = "dotnet new gitignore", Platform = ".Net" }
        };

            return commands;

        }

        public Command GetCommandById(int id)
        {
            return new Command { Id = 0, HowTo = "dotnet new", Line = "dotnet new", Platform = ".Net" };
        }
    }
}
