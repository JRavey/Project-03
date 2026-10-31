using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine;
using UnityEngine.InputSystem;
// Force the script to use the New Input System's Touch and TouchPhase
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch; // Avoid ambiguity
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class InputBroadcaster : MonoBehaviour
{
    public bool IsTapPressed { get; private set; } = false;
    public bool IsSpacePressed { get; private set; } = false;

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable(); // Must be enabled once
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    private void Update()
    {
        // NOTE: put better Input Decetion here. This code
        // is just for simple example and does not account 
        // for new Unity Input System

        int touchCount = Touch.activeTouches.Count;

        if(touchCount > 0)
        {
            var touch = Touch.activeTouches[0];
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    IsTapPressed = true;
                    break;
                case TouchPhase.Ended:
                    IsTapPressed = false;
                    break;
            }
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            IsSpacePressed = true;
            Debug.Log("Space key pressed this frame!");
        }
        else
        {
            IsSpacePressed = false;
        }
    }
}
