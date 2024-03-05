using FruitySlot.DataStructures;
using PRNG;
using FruitySlot.DataStructures.Config;
using FruitySlot.DataStructures.Display;

namespace FruitySlot
{
    public class Game
    {
        private DisplayFilter _displayFilter { get; }
        private GameConfig _config { get; }
        public GameState State { get; private set; }

        public Game(DisplayFilter displayFilter, GameConfig config)
        {
            _displayFilter = displayFilter;
            _config = config;
        }

        public void PlayGame(PseudoRandom random, long numberOfSpins, decimal betAmount)
        {
            // Initial reel state may be determined within configuration or randomly generated on start-up - would ordinarilly be stored within db.
            State = new GameState(_config.Reel.GetItem(random), betAmount);

            while (numberOfSpins > 0)
            {
                State.Update(_config.Reel.GetItem(random), betAmount);
                numberOfSpins--;
                if (_displayFilter.DisplayGamePlay)
                    RudimentaryFrontEnd.DisplayGame(State);
            }
        }
    }
}
