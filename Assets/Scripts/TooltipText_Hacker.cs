using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TooltipText_Hacker : MonoBehaviour
{
    public GameObject Label;
    public Area x;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var areafoot = x.SquareFootArea;
        var areamet = x.SquareMetersArea;

        var ppl = x.hackers;

        string pplStr = ppl.ToString();
        string areaFtStr = areafoot.ToString();
        string areaMStr = areamet.ToString();

        gameObject.GetComponent<TextMeshPro>().text = Label.name + "\n" + areaMStr + " m2 | " + areaFtStr + " sf | " + pplStr + " hackers";
    }
}
