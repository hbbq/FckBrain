namespace FckBrain.Parser.Commands
{
    public interface ICommand
    {
        
        char Symbol { get; }
        bool IsNoOp { get; }
        string Description { get; }

    }

}
