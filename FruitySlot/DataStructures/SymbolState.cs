using FruitySlot.DataStructures.Config.Data;

namespace FruitySlot.DataStructures
{
    public class SymbolState
    {
        public string Name { get; }
        public decimal Payout { get; }

        public SymbolState(SymbolData data)
        {
            Name = data.Name;
            Payout = data.Payout;
        }
    }
}
