using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;

namespace DataCollection
{
    class Intercepter
    {
        KeyboardCollector parent;
        int count;
        Thread updateThread;
        public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        //Collection of keystrokes
        private static LinkedList<String> keyStrokes;

        //Declare the hook handle as an int.
        static int hHook = 0;

        //Declare the mouse hook constant.
        //For other hook types, you can obtain these values from Winuser.h in the Microsoft SDK.
        public const int WH_MOUSE_LL = 14;

        //Declare MouseHookProcedure as a HookProc type.
        private static HookProc MouseHookProcedure;

        //Declare the wrapper managed POINT class.
        [StructLayout(LayoutKind.Sequential)]
        public class POINT
        {
            public int x;
            public int y;
        }

        //Declare the wrapper managed MouseHookStruct class.
        [StructLayout(LayoutKind.Sequential)]
        public class MouseHookStruct
        {
            public POINT pt;
            public int hwnd;
            public int wHitTestCode;
            public int dwExtraInfo;
        }

        //This is the Import for the SetWindowsHookEx function.
        //Use this function to install a thread-specific hook.
        [DllImport("user32.dll", CharSet = CharSet.Auto,
         CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn,
        IntPtr hInstance, int threadId);

        //This is the Import for the UnhookWindowsHookEx function.
        //Call this function to uninstall the hook.
        [DllImport("user32.dll", CharSet = CharSet.Auto,
         CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);

        //This is the Import for the CallNextHookEx function.
        //Use this function to pass the hook information to the next hook procedure in chain.
        [DllImport("user32.dll", CharSet = CharSet.Auto,
         CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode,
        IntPtr wParam, IntPtr lParam);

        [DllImport("Kernel32.dll", SetLastError = true)]
        static extern IntPtr GetModuleHandle(IntPtr lpModuleName);

        public Intercepter(KeyboardCollector p)
        {
            parent = p;
            count = 0;
        }
        public void Start()
        {
            //KeyLogger.run();
            updateThread = new Thread(Update);
            updateThread.Start();
            if (hHook == 0)
            {
                keyStrokes = new LinkedList<String>();
                // Create an instance of HookProc.
                MouseHookProcedure = new HookProc(MouseHookProc);
                hHook = SetWindowsHookEx(WH_MOUSE_LL,
                            MouseHookProcedure,
                            GetModuleHandle(IntPtr.Zero),
                            0);
                //If the SetWindowsHookEx function fails.
                if (hHook == 0)
                {
                    parent.updateList(Marshal.GetLastWin32Error().ToString());
                    return;
                }
                //button1.Text = "UnHook Windows Hook";
            }
            else
            {
                bool ret = UnhookWindowsHookEx(hHook);
                //If the UnhookWindowsHookEx function fails.
                if (ret == false)
                {
                    return;
                }
                hHook = 0;
                //button1.Text = "Set Windows Hook";
                //parent.Text = "Mouse Hook";
            } 
        }
        private int MouseHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            //Marshall the data from the callback.
            MouseHookStruct MyMouseHookStruct = (MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseHookStruct));

            if (nCode < 0)
            {
                return CallNextHookEx(hHook, nCode, wParam, lParam);
            }
            else
            {
                //Create a string variable that shows the current mouse coordinates.
                String strCaption = "x = " +
                        MyMouseHookStruct.pt.x.ToString("d") +
                            "  y = " +
                MyMouseHookStruct.pt.y.ToString("d");
                //You must get the active form because it is a static function.
                //LinkedList<String>  = keyStrokes;
                parent.Text = strCaption;

                //Set the caption of the form.
                keyStrokes.AddLast(strCaption);

                return CallNextHookEx(hHook, nCode, wParam, lParam);
            }
        }
        public void Stop()
        {

        }
        public void Update()
        {
            //while(true)
            //    if(KeyLogger.getKeyStrokes().Count != count)
            //    {
            //        parent.updateList(KeyLogger.getKeyStrokes());
            //    }
        }
        public LinkedList<String> getKeyStrokes()
        {
            LinkedList<String> list = new LinkedList<String>();
            return list;
        }
        public void Reset()
        {

        }

    }
}
