using AutoDeathCounterForDS3;

public class Program
{
    public static void Main(string[] args)
    {
        Ds3 ds3 = new Ds3(Ds3.V1_15);
        DataCache cache = null;

        while (true)
        {
            DataCache newData = new DataCache
            {
                Deaths = ds3.GetDeaths()
            };

            if (cache != null)
            { 
                if (cache.Deaths != newData.Deaths)
                {
                    IncreaseCounter();
                }
            }

            cache = newData;

            Thread.Sleep(16); // 60 FPS = 16.67 frame duration
        }
    }

    private static void IncreaseCounter()
    {
        Console.WriteLine("died");
    }
}