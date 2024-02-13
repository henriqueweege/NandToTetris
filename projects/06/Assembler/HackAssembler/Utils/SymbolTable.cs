namespace HackAssembler.Utils
{
    public static class SymbolTable
    {
        public static List<Symbol> Symbols { get; set; }
        private static int MinimumAddress { get; set; }
        static SymbolTable()
        {
            MinimumAddress = 15;
            Symbols = new List<Symbol>()
            {
                new Symbol("R0", 0),
                new Symbol("R1", 1),
                new Symbol("R2", 2),
                new Symbol("R3", 3),
                new Symbol("R4", 4),
                new Symbol("R5", 5),
                new Symbol("R6", 6),
                new Symbol("R7", 7),
                new Symbol("R8", 8),
                new Symbol("R9", 9),
                new Symbol("R10", 10),
                new Symbol("R11", 11),
                new Symbol("R12", 12),
                new Symbol("R13", 13),
                new Symbol("R14", 14),
                new Symbol("R15", 15),
                new Symbol("SP", 0),
                new Symbol("LCL", 1),
                new Symbol("ARG", 2),
                new Symbol("THIS", 3),
                new Symbol("THAT", 4),
                new Symbol("SCREEN", 16384),
                new Symbol("KBD", 24576)
            };
        }

        public static int GetSymbolVal(string symbol)
        {
            foreach(var s in Symbols)
            {
                if(s.Name == symbol)
                {
                    return s.Value;
                }
            }
            return -1;
        }

        public static void AddASymbol(string symbol)
        {
            foreach(var s in Symbols)
            {
                if(s.Value == MinimumAddress)
                {
                    ++MinimumAddress;
                    AddASymbol(symbol);
                    return;
                }
            }
            Symbols.Add(new Symbol(symbol, MinimumAddress));
        }

    }
}
