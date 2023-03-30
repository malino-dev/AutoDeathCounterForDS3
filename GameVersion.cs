using AutoDeathCounterForDS3.OffsetDataNS;
using WinApiUtils.ProcessNS;

namespace AutoDeathCounterForDS3;

public class GameVersion
{
    private ProcessMemory _process;

    public GameVersion(ProcessMemory process)
    {
        _process = process;
    }
    
    private static IDictionary<string, string> _versionMap = new Dictionary<string, string>()
    {
        ["1.4.1.0"] = "1.04",
        ["1.8.0.0"] = "1.08",
        ["1.11.0.0"] = "1.11",
        ["1.12.0.0"] = "1.12",
        ["1.15.0.0"] = "1.15",
        ["1.15.1.0"] = "1.15",
        ["1.15.2.0"] = "1.15.2",
    };

    public string Version
    {
        get
        {
            string ver = _process.GetFileVersion(0).FileVersion ?? throw new Exception("no file version");

            return _versionMap[ver];
        }
    }

    private static IOffsetData V1_15 => new OffsetData_1_15();
    
    private static IDictionary<string, IOffsetData> _offsetMap => new Dictionary<string, IOffsetData>
    {
        ["1.15"] = V1_15,
    };

    public IOffsetData OffsetData => _offsetMap[Version];
}
