using System.Runtime.InteropServices;

namespace AutoDeathCounterForDS3.InputNS;

[StructLayout(LayoutKind.Sequential)]
public struct KeyboardInput
{
    public ushort wVk;
    public ushort wScan;
    public uint dwFlags;
    public uint time;
    public IntPtr dwExtraInfo;
}
