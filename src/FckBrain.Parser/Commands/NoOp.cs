namespace FckBrain.Parser.Commands
{
    public class NoOp : CommandBase
    {

        private readonly char _symbol;

        public override char Symbol => _symbol;

        public NoOp(char symbol)
        {
            _symbol = symbol;
        }

        public override string Description => "NoOp command";
        public override bool IsNoOp => true;

    }

}
