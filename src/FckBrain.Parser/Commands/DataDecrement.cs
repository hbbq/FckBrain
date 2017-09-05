namespace FckBrain.Parser.Commands
{

    public class DataDecrement : CommandBase
    {
        
        public override string Description => "Decrements the data at the data pointer by 1";
        public override char Symbol => '-';

    }

}
