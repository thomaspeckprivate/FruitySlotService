namespace FruitySlot.DataStructures.Display
{
    public class DisplayFilter
    {
        public bool DisplayGamePlay { get; }
        public bool DisplaySummary { get; }
        public bool DisplayNumSpins { get; }

        public DisplayFilter()
        { 
            DisplayGamePlay = bool.Parse(Environment.ExpandEnvironmentVariables("%DisplayGamePlay%"));
            DisplaySummary = bool.Parse(Environment.ExpandEnvironmentVariables("%DisplaySummary%"));
            DisplayNumSpins = bool.Parse(Environment.ExpandEnvironmentVariables("%DisplayNumSpins%"));
        }
    }
}
