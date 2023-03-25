using AutoDeathCounterForDS3.OffsetDataNS;

namespace AutoDeathCounterForDS3;

public class Ds3
{
   

    private ProcessMemory _process;
    private IOffsetData _offsetData;

    public GameVersion Version { get; private set; }

    public Ds3(ProcessMemory process)
    {
        _process = process;
        Version = new GameVersion(_process);
        _offsetData = Version.OffsetData;
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
