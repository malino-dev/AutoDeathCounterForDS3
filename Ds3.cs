namespace AutoDeathCounterForDS3;

public class Ds3
{
    private ProcessMemory _process;

    const int baseA = 0x4740178;
    const int baseB = 0x4768E78;
    const int baseC = 0x4743AB0;
    const int baseD = 0x4743A80;

    public Ds3()
    {
        _process = new ProcessMemory("DarkSoulsIII");
    }

    public int GetHp()
    {
        int[] offsets = { 0x80, 0x1F90, 0x18, 0xD8 };
        int deaths = _process.ReadPtr32(baseB, offsets);
        return deaths;
    }

    public int GetDeaths()
    {
        int[] offsets = { 0x98 };
        int deaths = _process.ReadPtr32(baseA, offsets);
        return deaths;
    }
}
