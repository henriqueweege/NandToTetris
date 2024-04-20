
namespace JackAnalyzer.Variables
{
    internal class Variable
    {
        public Variable(EVariableType type, EMemSegments kind, int position)
        {
            Type = type;
            Kind = kind;
            Position = position;
        }

        public EVariableType Type { get; set; }
        public EMemSegments Kind { get; set; }
        public int Position { get; set; }
    }
}
