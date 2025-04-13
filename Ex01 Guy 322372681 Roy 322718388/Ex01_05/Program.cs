
namespace Ex01_05
{
    public class Program
    {
        public static void Main()
        {
            string validNumberFromUser = ConsoleHandler.RecieveUserInput();
            NumberWithStatistics number = new NumberWithStatistics(validNumberFromUser);
            number.CalculateStatisticsOnNumber();
            ConsoleHandler.ShowStatistics(number);
        }
    }
}