namespace JackAnalyzer.CompilationEngine
{
    internal class Engine
    {
        public IEnumerable<XmlTag> Tags { get; set; }

        public Engine()
        {
            Tags = new List<XmlTag> { new XmlTag(TokenTypeEnum.IntConst, ) };
        }
    }
}
