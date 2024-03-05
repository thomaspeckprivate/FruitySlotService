namespace FruitySlot.DataStructures.Config.Data
{
    public class GameConfigData
    {
        public GameDefinitionData GameDefinition { get; set; }
    }

    public class GameDefinitionData
    {
        public List<SymbolData> Symbols { get; set; }
    }

    public class SymbolData
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public decimal Payout { get; set; }
    }
}
