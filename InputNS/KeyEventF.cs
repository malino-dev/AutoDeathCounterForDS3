namespace AutoDeathCounterForDS3.InputNS;

[Flags]
public enum KeyEventF
{
    KeyDown = 0x0000,
    ExtendedKey = 0x0001,
    KeyUp = 0x0002,
    Unicode = 0x0004,
    ScanCode = 0x0008
}
