using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using Serilog;

namespace DeepLClient.Functions
{
    internal static class NativeFunctions
    {
        [DllImport("advapi32.dll", SetLastError = true)]
        internal static extern bool OpenProcessToken(nint processHandle, uint desiredAccess, out nint tokenHandle);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool CloseHandle(nint hObject);

        [DllImport("User32.dll")]
        internal static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        [StructLayout(LayoutKind.Sequential)]
        // ReSharper disable once InconsistentNaming
        internal struct LASTINPUTINFO
        {
            internal static readonly int SizeOf = Marshal.SizeOf(typeof(LASTINPUTINFO));

            [MarshalAs(UnmanagedType.U4)]
            internal int cbSize;
            [MarshalAs(UnmanagedType.U4)]
            internal uint dwTime;
        }
    }
}
