using AutoDeathCounterForDS3;
using WinApiUtils.ProcessNS;

public class Program
{
    static event Action<int> DeathsChanged;
    static event Action<int> HpChanged;

    static void Main(string?[]? args)
    {
        var process = new ProcessMemory("DarkSoulsIII");
        var ds3 = new Ds3(process);

        RegisterEvents();
        GameLoop(ds3);
    }

    static void RegisterEvents()
    {
        DeathsChanged += OnDeathsChanged;
        HpChanged += OnHpChanged;
    }

    static void GameLoop(Ds3 ds3)
    {
        DataCache? cache = null;

        while (true)
        {
            DataCache newData = new DataCache
            {
                Deaths = ds3.GetDeaths(),
                Hp = ds3.GetHp(),
            };

            if (cache != null)
            {
                if (cache.Deaths != newData.Deaths)
                {
                    DeathsChanged.Invoke(newData.Deaths);
                }

                if (cache.Hp != newData.Hp)
                {
                    HpChanged.Invoke(newData.Hp);
                }
            }

            cache = newData;

            Thread.Sleep(16); // 60 FPS = 16.67 frame duration
        }
    }

    static void OnDeathsChanged(int deaths)
    {
        Console.WriteLine("died");
    }

    static void OnHpChanged(int obj)
    {
        
    }
}