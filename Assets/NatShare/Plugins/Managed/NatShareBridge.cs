/* 
*   NatShare
*   Copyright (c) 2018 Yusuf Olokoba
*/

namespace NatShareU.Core {

    using System;
    using System.Runtime.InteropServices;

    public static class NatShareBridge {

        private const string Assembly =
        #if (UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR
        "__Internal";
        #else
        "NatShare";
        #endif

        #if UNITY_IOS && !UNITY_EDITOR
        [DllImport(Assembly, EntryPoint = "NSShareVideo")]
        public static extern bool Share (string path);
        [DllImport(Assembly, EntryPoint = "NSSaveVideoToCameraRoll")]
        public static extern bool SaveToCameraRoll (string path);
        [DllImport(Assembly, EntryPoint = "NSGetThumbnail")]
        public static extern bool GetThumbnail (string path, float time, ref IntPtr pixelBuffer, ref int width, ref int height);
        [DllImport(Assembly, EntryPoint = "NSFreeThumbnail")]
        public static extern void FreeThumbnail (IntPtr pixelBuffer);

        #else
        public static bool Share (string path) {return false;}
        public static bool SaveToCameraRoll (string path) {return false;}
        public static bool GetThumbnail (string path, float time, ref IntPtr pixelBuffer, ref int width, ref int height) {return false;}
        public static void FreeThumbnail (IntPtr pixelBuffer) {}
        #endif
    }
}