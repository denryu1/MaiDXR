using System;
using System.Runtime.InteropServices;
using UnityEngine;
using WindowsInput.Native;
public class ButtonToKey : MonoBehaviour
{
    [DllImport("user32.dll")]
    public static extern uint MapVirtualKey(uint uCode, uint uMapType);
    [DllImport("user32.dll")]
    static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
    public VirtualKeyCode keyToPress;

    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        keybd_event(System.Convert.ToByte(keyToPress), (byte)MapVirtualKey((uint)keyToPress, 0), 0, UIntPtr.Zero);  
    }

    private void OnTriggerExit(Collider other)
    {
        keybd_event(System.Convert.ToByte(keyToPress), (byte)MapVirtualKey((uint)keyToPress, 0), 2, UIntPtr.Zero);
    }
    
}
