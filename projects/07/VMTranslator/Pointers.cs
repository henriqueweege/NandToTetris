namespace VMTranslator
{
    public static class Pointers
    {
        public static Dictionary<string, string> Addresses { get; set; }
        static Pointers()
        {
            Addresses = new Dictionary<string, string>();
            Addresses.Add("local", "LCL");
            Addresses.Add("argument", "ARG");
            Addresses.Add("this", "THIS");
            Addresses.Add("that", "THAT");
            Addresses.Add("constant", "SP");
            Addresses.Add("temp", "TEMP");
            Addresses.Add("static", "16");
        }
    }
}
