using AutoDeathCounterForDS3.OffsetDataNS;

namespace AutoDeathCounterForDS3;

public class Ds3
{
    private static IOffsetData _1_15 = new OffsetData_1_15();
    public static IOffsetData V1_15 => _1_15;

    private ProcessMemory _process;
    private IOffsetData _offsetData;

    public Ds3(IOffsetData offsetData)
    {
        _process = new ProcessMemory("DarkSoulsIII");
        _offsetData = offsetData;
    }

    public int GetHp()
    {
        int[] offsets = { 0x80, 0x1F90, 0x18, 0xD8 };
        int deaths = _process.ReadPtr32(_offsetData.BaseB, offsets);
        return deaths;
    }

    public int GetDeaths()
    {
        int[] offsets = { 0x98 };
        int deaths = _process.ReadPtr32(_offsetData.BaseA, offsets);
        return deaths;
    }
}
