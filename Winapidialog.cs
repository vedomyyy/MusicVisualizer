using System;
using System.Runtime.InteropServices;

namespace MusicVisualizer
{
    /// <summary>
    /// Открытие файла через нативный WinAPI диалог (comdlg32.dll).
    /// </summary>
    public static class WinApiDialog
    {
        [DllImport("comdlg32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool GetOpenFileName(ref OPENFILENAME ofn);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct OPENFILENAME
        {
            public int lStructSize;
            public IntPtr hwndOwner;
            public IntPtr hInstance;
            public string lpstrFilter;
            public string lpstrCustomFilter;
            public int nMaxCustFilter;
            public int nFilterIndex;
            public string lpstrFile;
            public int nMaxFile;
            public string lpstrFileTitle;
            public int nMaxFileTitle;
            public string lpstrInitialDir;
            public string lpstrTitle;
            public int Flags;
            public short nFileOffset;
            public short nFileExtension;
            public string lpstrDefExt;
            public IntPtr lCustData;
            public IntPtr lpfnHook;
            public string lpTemplateName;
        }

        private const int OFN_EXPLORER = 0x00080000;
        private const int OFN_FILEMUSTEXIST = 0x00001000;

        public static string Show(IntPtr ownerHandle)
        {
            var ofn = new OPENFILENAME
            {
                lStructSize = Marshal.SizeOf(typeof(OPENFILENAME)),
                hwndOwner = ownerHandle,
                lpstrFilter = "Аудио файлы\0*.mp3;*.wav;*.flac;*.ogg;*.aiff\0Все файлы\0*.*\0",
                lpstrFile = new string('\0', 512),
                nMaxFile = 512,
                lpstrTitle = "Выберите аудиофайл",
                Flags = OFN_EXPLORER | OFN_FILEMUSTEXIST
            };

            return GetOpenFileName(ref ofn)
                ? ofn.lpstrFile.TrimEnd('\0')
                : string.Empty;
        }
    }
}