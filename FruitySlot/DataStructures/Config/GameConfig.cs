using FruitySlot.DataStructures.Config.Data;
using FruitySlot.DataStructures.Misc;

namespace FruitySlot.DataStructures.Config
{
    public class GameConfig
    {
        public WeightedList<SymbolState> Reel { get; }

        public GameConfig(GameConfigData game)
        {
            var symbols = game.GameDefinition.Symbols.Select(symbol => new SymbolState(symbol));
            var weights = game.GameDefinition.Symbols.Select(symbol => symbol.Weight);
            Reel = new WeightedList<SymbolState>(symbols, weights);
        }
    }
}
