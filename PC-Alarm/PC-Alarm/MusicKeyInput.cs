﻿using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Input;

namespace PC_Alarm
{
    class MusicKeyInput
    {
        public const int KEYEVENTF_EXTENTEDKEY = 1;
        public const int KEYEVENTF_KEYUP = 0;
        public const int VK_MEDIA_NEXT_TRACK = 0xB0;// code to jump to next track
        public const int VK_MEDIA_PLAY_PAUSE = 0xB3;// code to play or pause a song
        public const int VK_MEDIA_PREV_TRACK = 0xB1;// code to jump to prev track
        public const int VK_SPACE = 0x20;// code to space

        private const int SPI_GETSCREENSAVEACTIVE = 0x10;
        private const int SPI_SETSCREENSAVEACTIVE = 0x11;
        private const int SPIF_SENDWININICHANGE = 2;

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, IntPtr extraInfo);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool SystemParametersInfo(int uAction, int uParam, ref int lpvParam, int flags);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool SystemParametersInfo(int uAction, int uParam, ref bool lpvParam, int flags);

        public static void SetScreenSaverActive(int Active)
        {
            int nullVar = 0;

            SystemParametersInfo(SPI_SETSCREENSAVEACTIVE, Active, ref nullVar, SPIF_SENDWININICHANGE);
        }

        public static void PreviousTrack()
        {
            SetScreenSaverActive(0);
            Thread.Sleep(1000);
            // Jump to previous track
            keybd_event(VK_MEDIA_PREV_TRACK, 0, KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);
            keybd_event(VK_MEDIA_PREV_TRACK, 0, KEYEVENTF_KEYUP, IntPtr.Zero);
        }
        public static void PauseTrack()
        {
            System.Windows.Input.
            Cursor.SetCursor();
            Thread.Sleep(1000);
            // Play or Pause music
            keybd_event(VK_MEDIA_PLAY_PAUSE, 0, KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);
            keybd_event(VK_MEDIA_PLAY_PAUSE, 0, KEYEVENTF_KEYUP, IntPtr.Zero);
        }
        public static void NextTrack()
        {
            SetScreenSaverActive(0);
            Thread.Sleep(1000);
            // Jump to next track
            keybd_event(VK_MEDIA_NEXT_TRACK, 0, KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);
            keybd_event(VK_MEDIA_NEXT_TRACK, 0, KEYEVENTF_KEYUP, IntPtr.Zero);
        }
        public static void SpaceTrack()
        {
            SetScreenSaverActive(0);
            Thread.Sleep(1000);
            // Play or Pause music
            keybd_event(VK_SPACE, 0, KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);
            keybd_event(VK_SPACE, 0, KEYEVENTF_KEYUP, IntPtr.Zero);
        }
    }
}
