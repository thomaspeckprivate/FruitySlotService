namespace FruitySlot.DataStructures
{
    public class GameState
    {
        public SymbolState DisplayedSymbol { get; private set; }
        public decimal BetAmount { get; private set; }

        // Could be implemented as a separate history class which stores other data or potentially a "counter" class that increments on certain conditions
        public long PlayedGames { get; private set; }
        public decimal TotalWagered { get; private set; }
        public decimal TotalPayout { get; private set; }
        public long Hits { get; private set; }
        public decimal TotalPayoutSevenSymbol { get; private set; }

        public GameState(SymbolState symbol, decimal betAmount)
        {
            DisplayedSymbol = symbol;
            BetAmount = betAmount;
        }
        public GameState()
        {
        }

        public void Update(SymbolState displayedSymbol, decimal betAmount)
        {
            DisplayedSymbol = displayedSymbol;
            BetAmount = betAmount;

            PlayedGames++;
            TotalWagered += betAmount;
            TotalPayout += displayedSymbol.Payout * betAmount;
            Hits += displayedSymbol.Payout > 0 ? 1 : 0;
            TotalPayoutSevenSymbol += displayedSymbol.Payout > 0 && displayedSymbol.Name.Equals("Seven") ? displayedSymbol.Payout : 0;
        }
        public void Update(GameState gs)
        {
            PlayedGames += gs.PlayedGames;
            TotalWagered += gs.TotalWagered;
            TotalPayout += gs.TotalPayout;
            Hits += gs.Hits;
            TotalPayoutSevenSymbol += gs.TotalPayoutSevenSymbol;
        }
    }
}
