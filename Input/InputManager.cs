using System.Runtime.InteropServices;

namespace AutoDeathCounterForDS3.InputNS;

public class InputManager
{
    [DllImport("user32.dll", SetLastError = true)]
    private static extern uint SendInput(uint nInputs, Input[] pInputs, int cbSize);

    [DllImport("user32.dll")]
    private static extern IntPtr GetMessageExtraInfo();

    public void SendKeyboardInput(ushort scanCode)
    {
        Input[] inputs = new Input[]
        {
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wScan = scanCode,
                        dwFlags = (uint)(KeyEventF.KeyDown | KeyEventF.ScanCode),
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            },
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wScan = scanCode,
                        dwFlags = (uint)(KeyEventF.KeyUp | KeyEventF.ScanCode),
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }
}
