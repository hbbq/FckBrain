namespace FckBrain.Parser.Commands
{
    public class BlockStart : CommandBase
    {

        public override string Description => "Jumps to the matching block end command if the data at the pointer is zero";
        public override char Symbol => '[';

    }

}
