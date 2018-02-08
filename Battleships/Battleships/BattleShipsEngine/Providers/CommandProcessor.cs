using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.BattleshipsEngine.Providers
{
    class CommandProcessor : ICommandProcessor
    {
        public CommandProcessor()
        {
            this.Commands = new List<ICommand>();
        }
        public void ProcessSingleCommand(ICommand command, string commandParameters)
        {
            var lineParameters = commandParameters.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var result = command.Execute(lineParameters);
            var normalizedOutput = this.NormalizeOutput(result);
            Console.WriteLine(normalizedOutput);
        }
        private string NormalizeOutput(string commandOutput)
        {
            var list = commandOutput.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList().Where(x => !string.IsNullOrWhiteSpace(x));

            return string.Join("\r\n", list);
        }
    }
}
