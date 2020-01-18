using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isHistoryPressed : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool isPressed = false;

    public void changePressed() {
        if (isPressed)
        {
            isPressed = false;
        }
        else {
            isPressed = true;
        }
        Debug.Log(isPressed);
    }
    
}
