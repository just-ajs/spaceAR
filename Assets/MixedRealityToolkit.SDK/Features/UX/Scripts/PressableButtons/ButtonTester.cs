using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTester : MonoBehaviour
{
    public void ButtonClickTest()
    {
        Debug.Log("I was clicked, my name is " + this.gameObject.name);
    }
}
