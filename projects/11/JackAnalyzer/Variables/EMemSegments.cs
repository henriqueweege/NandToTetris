using System.ComponentModel;

namespace JackAnalyzer.Variables
{
    public enum EMemSegments
    {
        [Description("static")]
        Static,
        [Description("field")]
        Field,
        [Description("local")]
        Local,
        [Description("argument")]
        Argument,
        [Description("temp")]
        Temp,
        [Description("constant")]
        Constant,
        [Description("pointer")]
        Pointer,
        [Description("that")]
        That
    }
}
