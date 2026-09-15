using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class PemancarEvent : MonoBehaviour
{
    public static event Action TekanTombol;
   
   void Update()
   {
    if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
    {
        Debug.Log("Tombol ditekan, memanggil event TekanTombol");
        // Memanggil event 
        TekanTombol?.Invoke();
    }
   }
}
