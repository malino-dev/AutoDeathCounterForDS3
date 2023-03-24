using AutoDeathCounterForDS3;

public class Program
{
    public static void Main(string[] args)
    {
        var ds3 = new Ds3(Ds3.V1_15);
        int deaths = ds3.GetDeaths();
        
        while (true)
        {
            int newDeaths = ds3.GetDeaths();

            if(newDeaths != deaths)
            {
                IncreaseCounter();
            }

            deaths = newDeaths;

            Thread.Sleep(16); // 60 FPS = 16.67 frame duration
        }
    }

    private static void IncreaseCounter()
    {
        Console.WriteLine("died");
    }
}