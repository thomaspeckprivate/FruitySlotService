using FruitySlot.DataStructures;
using System.Text;

namespace FruitySlot.DataStructures.Display
{
    public static class RudimentaryFrontEnd
    {
        public static void DisplayGame(GameState gameState)
        {
            var sb = new StringBuilder();
            var symbolSize = gameState.DisplayedSymbol.Name.Length;
            sb.Append("\n|");
            sb.Append(gameState.DisplayedSymbol.Name);
            sb.Append("|\n");
            Console.WriteLine(sb.ToString());
        }

        public static void DisplayRoundsPlayed(int threadNumber, GameState gameState, long totalGames)
        {
            Console.WriteLine($"Thread {threadNumber}, Games Played: {gameState.PlayedGames}/{totalGames} ");
        }


        public static void DisplaySummary(GameState gameState)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Average Payout per Spin: {gameState.TotalPayout / gameState.PlayedGames}");
            sb.AppendLine($"% non-Blank spins: {((decimal)gameState.Hits / (decimal)gameState.PlayedGames) * 100m}%");
            sb.AppendLine($"% of payout from Seven symbol: {(gameState.TotalPayoutSevenSymbol / gameState.TotalPayout) * 100}%");
            Console.WriteLine(sb.ToString());
        }
    }
}
