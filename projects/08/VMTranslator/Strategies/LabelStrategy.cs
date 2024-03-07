using VMTranslator.Strategies.Contract;

namespace VMTranslator.Strategies
{
    internal class LabelStrategy : IStrategy
    {
        public int Lesses { get; set; }
        public string Translate(string labelName, string position)
        {
            Lesses++;

            return $@"({labelName})";

        }
    }
}
