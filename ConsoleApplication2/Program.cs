using System;
using System.Runtime.InteropServices;

namespace ConsoleApplication2
{
    static class PInvoke
    {
        //#define WTS_CURRENT_SESSION ((DWORD)-1)
        public const UInt32 WTS_CURRENT_SESSION = unchecked((UInt32)(-1));

        //#define WTS_CHANNEL_OPTION_DYNAMIC          0x00000001       // dynamic channel
        //#define WTS_CHANNEL_OPTION_DYNAMIC_PRI_LOW  0x00000000   // priorities
        //#define WTS_CHANNEL_OPTION_DYNAMIC_PRI_MED  0x00000002
        //#define WTS_CHANNEL_OPTION_DYNAMIC_PRI_HIGH 0x00000004
        //#define WTS_CHANNEL_OPTION_DYNAMIC_PRI_REAL 0x00000006
        //#define WTS_CHANNEL_OPTION_DYNAMIC_NO_COMPRESS 0x00000008
        public const UInt32 WTS_CHANNEL_OPTION_DYNAMIC = 0x00000001;
        public const UInt32 WTS_CHANNEL_OPTION_DYNAMIC_PRI_LOW = 0x00000000;
        public const UInt32 WTS_CHANNEL_OPTION_DYNAMIC_PRI_MED = 0x00000002;
        public const UInt32 WTS_CHANNEL_OPTION_DYNAMIC_PRI_HIGH = 0x00000004;
        public const UInt32 WTS_CHANNEL_OPTION_DYNAMIC_PRI_REAL = 0x00000006;
        public const UInt32 WTS_CHANNEL_OPTION_DYNAMIC_NO_COMPRESS = 0x00000008;

        //WINBASEAPI
        //HANDLE
        //WINAPI
        //GetCurrentProcess(
        //    VOID
        //    );
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetCurrentProcess();

        //WINBASEAPI
        //BOOL
        //WINAPI
        //DuplicateHandle(
        //    _In_ HANDLE hSourceProcessHandle,
        //    _In_ HANDLE hSourceHandle,
        //    _In_ HANDLE hTargetProcessHandle,
        //    _Outptr_ LPHANDLE lpTargetHandle,
        //    _In_ DWORD dwDesiredAccess,
        //    _In_ BOOL bInheritHandle,
        //    _In_ DWORD dwOptions
        //    );
        [DllImport("kernel32.dll")]
        public static extern Boolean DuplicateHandle(
            [In] IntPtr hSourceProcessHandle,
            [In] IntPtr hSourceHandle,
            [In] IntPtr hTargetProcessHandle,
            [In, Out] ref IntPtr lpTargetHandle,
            [In] UInt32 dwDesiredAccess,
            [In] Boolean bInheritHandle,
            [In] UInt32 dwOptions);

        //HANDLE
        //WINAPI
        //WTSVirtualChannelOpenEx(
        //                     IN DWORD SessionId,
        //                     _In_ LPSTR pVirtualName,   /* ascii name */
        //                     IN DWORD flags
        //                     );
        [DllImport("wtsapi32.dll")]
        public static extern IntPtr WTSVirtualChannelOpenEx(
            [In] UInt32 SessionId,
            [MarshalAs(UnmanagedType.LPStr)]
            [In] String pVirtualName,
            [In] UInt32 flags);

        //BOOL
        //WINAPI
        //WTSVirtualChannelClose(
        //    IN HANDLE hChannelHandle
        //    );
        [DllImport("wtsapi32.dll")]
        public static extern Boolean WTSVirtualChannelClose(
            [In] IntPtr hChannelHandle);

        //BOOL
        //WINAPI
        //WTSVirtualChannelQuery(
        //    IN HANDLE hChannelHandle,
        //    IN WTS_VIRTUAL_CLASS,
        //    OUT PVOID *ppBuffer,
        //    OUT DWORD *pBytesReturned
        //    );
        [DllImport("wtsapi32.dll")]
        public static extern Boolean WTSVirtualChannelQuery(
            [In] IntPtr hChannelHandle,
            [In] IntPtr WtsVirtualClass,
            [In, Out] ref IntPtr ppBuffer,
            [In, Out] ref UInt32 pBytesReturned);

        //VOID
        //WINAPI
        //WTSFreeMemory(
        //    IN PVOID pMemory
        //    );
        [DllImport("wtsapi32.dll")]
        public static extern void WTSFreeMemory(
            [In] IntPtr pMemory);
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PInvoke.WTS_CURRENT_SESSION);

            IntPtr handle = PInvoke.WTSVirtualChannelOpenEx(
                PInvoke.WTS_CURRENT_SESSION,
                "Channel1",
                PInvoke.WTS_CHANNEL_OPTION_DYNAMIC);
            if (handle != IntPtr.Zero)
            {
                Console.WriteLine("OK.");

                PInvoke.WTSVirtualChannelClose(handle);
            }
            else
            {
                Console.WriteLine("WTSVirtualChannelOpenEx(): {0}", Marshal.GetLastWin32Error());
            }
        }
    }
}
