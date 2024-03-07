using VMTranslator.Strategies.Contract;

namespace VMTranslator.Strategies
{
    public class Selector
    {
        public Dictionary<string, IStrategy> _strategies;
        public Selector()
        {
            _strategies = new();
            _strategies.Add("add", new AddStrategy());
            _strategies.Add("sub", new SubStrategy());
            _strategies.Add("and", new AndStrategy());
            _strategies.Add("eq", new EqStrategy());
            _strategies.Add("push", new PushStrategy());
            _strategies.Add("pop", new PopStrategy());
            _strategies.Add("lt", new LessStrategy());
            _strategies.Add("gt", new GreaterStrategy());
            _strategies.Add("or", new OrStrategy());
            _strategies.Add("neg", new Negtrategy());
            _strategies.Add("not", new NotStrategy());
            _strategies.Add("call", new CallStrategy());
            _strategies.Add("function", new FunctionStrategy());
            _strategies.Add("return", new ReturnStrategy());
            _strategies.Add("if-goto", new IfgotoStrategy());
            _strategies.Add("goto", new GotoStrategy());
            _strategies.Add("label", new LabelStrategy());
        }

    }
}
