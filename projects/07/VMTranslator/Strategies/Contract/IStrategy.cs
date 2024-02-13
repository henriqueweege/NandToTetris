namespace VMTranslator.Strategies.Contract
{
    public interface IStrategy
    {
        public string Translate(string pointerName = "", string position = "");
    }
}
