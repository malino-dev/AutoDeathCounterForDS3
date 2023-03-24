using System.Diagnostics;
using System.Runtime.InteropServices;

public class ProcessMemory
{
    private Process _process;
    private IntPtr _baseAddress;
    private IntPtr _handle;

    const int PROCESS_WM_READ = 0x0010;

    [DllImport("kernel32.dll")]
    static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

    [DllImport("kernel32.dll")]
    static extern int ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out IntPtr lpNumberOfBytesRead);

    [DllImport("kernel32.dll")]
    static extern int GetLastError();

    public IntPtr BaseAddress => _baseAddress;

    public ProcessMemory(string name)
    {
        _process = Process.GetProcessesByName(name)[0];
        _baseAddress = _process.MainModule?.BaseAddress ?? throw new Exception("Module not found");
        _handle = OpenProcess(PROCESS_WM_READ, false, _process.Id);
    }

    public void ReadBytesAtAddress(IntPtr address, [Out] byte[] buffer)
    {
        int result = ReadProcessMemory(_handle, address, buffer, buffer.Length, out var bytesRead);
        int error = GetLastError();
    }

    public void ReadBytesWithOffset(int offset, [Out] byte[] buffer)
    {
        ReadBytesAtAddress(_baseAddress + offset, buffer);
    }

    public int ReadPtr32(int @base, int[] offsets)
    {
        long ptr = ReadInt64(@base);

        for (int i = 0; i < offsets.Length; i++)
        {
            ptr += offsets[i];

            byte[] buffer = new byte[8];
            ReadBytesAtAddress((IntPtr)ptr, buffer);
            ptr = BitConverter.ToInt64(buffer);
        }

        return (int)ptr;
    }

    public dynamic Read<T>(int offset) where T : struct
    {
        byte[] buffer = new byte[Marshal.SizeOf<T>()];
        ReadBytesWithOffset(offset, buffer);

        if (typeof(T) == typeof(byte)) return buffer[0];
        if (typeof(T) == typeof(short)) return BitConverter.ToInt16(buffer);
        if (typeof(T) == typeof(int)) return BitConverter.ToInt32(buffer);
        if (typeof(T) == typeof(long)) return BitConverter.ToInt64(buffer);

        throw new ArgumentException("Wrong generic type");
    }

    public int ReadInt32(int offset)
    {
        byte[] buffer = new byte[4];
        ReadBytesWithOffset(offset, buffer);

        int value = BitConverter.ToInt32(buffer);
        return value;
    }

    public long ReadInt64(int offset)
    {
        byte[] buffer = new byte[8];
        ReadBytesWithOffset(offset, buffer);
        
        var value = BitConverter.ToInt64(buffer);
        return value;
    }
}