using FruitySlot.DataStructures;
using PRNG;
using FruitySlot;
using FruitySlot.DataStructures.Config.Data;
using FruitySlot.DataStructures.Config;
using FruitySlot.DataStructures.Display;

public class Program
{
    public static void Main(string[] args)
    {
        var random = new PseudoRandom();

        var displayFilter = new DisplayFilter();
        var deserializedConfig = ConfigHandler.JSONSerializer.Deserialize<GameConfigData>(".\\Config\\GameConfiguration.json");
        var gameConfig = new GameConfig(deserializedConfig);

        // Should potentially be stored within a config file
        var numberOfSpins = long.Parse(Environment.ExpandEnvironmentVariables("%NumSpins%"));
        var betAmount = decimal.Parse(Environment.ExpandEnvironmentVariables("%BetAmount%"));
        var threads = int.Parse(Environment.ExpandEnvironmentVariables("%Threads%"));

        // PC has limited cores available.
        Task[] taskArray = new Task[threads];
        List<Game> games = Enumerable.Range(1,threads).Select(i => new Game(displayFilter, gameConfig)).ToList();
        // Splitting spins by number of threads - would need additional logic if not perfectly divisible.
        numberOfSpins = numberOfSpins / threads;

        var gameState = new GameState();

        for (int i = 0; i < taskArray.Length; i++)
        {
            taskArray[i] = Task.Factory.StartNew(t =>
            {
                Game game = t as Game;
                game.PlayGame(new PseudoRandom(), numberOfSpins, betAmount);
            },
            games[i]);
        }

        while (!Task.WaitAll(taskArray,10000))
        {
            for (int i = 0; i < games.Count; i++)
            {
                if (displayFilter.DisplayGamePlay)
                {
                    RudimentaryFrontEnd.DisplayGame(games[i].State);
                }
                if (displayFilter.DisplayNumSpins)
                {
                    RudimentaryFrontEnd.DisplayRoundsPlayed(i, games[i].State, numberOfSpins);
                }
            }
        }

        games.ForEach(x => gameState.Update(x.State));

        RudimentaryFrontEnd.DisplayRoundsPlayed(0, gameState, numberOfSpins * threads);
        if (displayFilter.DisplaySummary)
        {
            RudimentaryFrontEnd.DisplaySummary(gameState);
        }

    }
}