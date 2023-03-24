using System.Runtime.InteropServices;

namespace AutoDeathCounterForDS3.InputNS;

[StructLayout(LayoutKind.Sequential)]
public struct HardwareInput
{
    public uint uMsg;
    public ushort wParamL;
    public ushort wParamH;
}
