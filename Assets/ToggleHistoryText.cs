using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToggleHistoryText : MonoBehaviour
{

    string state;
    public bool on;



    TextMeshProUGUI textmeshPro;
    
    // Start is called before the first frame update
    void Start()
    {
    }

     void Update()
    {
        if (on)
        {
            state = "ON";
        }
        else
        {
            state = "OFF";
        }

        TextMeshProUGUI a = this.GetComponent<TextMeshProUGUI>();
        a.SetText(state);
    }


    public void ToggleOnOffButton()
    {
        on = !on;
    }
}
