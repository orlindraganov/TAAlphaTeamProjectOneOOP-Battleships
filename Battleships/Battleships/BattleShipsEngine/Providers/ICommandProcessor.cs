namespace Battleships.BattleshipsEngine.Providers
{
    interface ICommandProcessor
    {
        void ProcessSingleCommand(ICommand command, string commandParameters);
    }
}