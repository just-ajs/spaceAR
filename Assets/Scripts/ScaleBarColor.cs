using Microsoft.MixedReality.Toolkit.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBarColor : MonoBehaviour
{
    // Start is called before the first frame update
    float yScale;

    Color bad = new Color(0.913f, 0.078f, 0.313f);
    Color good = new Color(0.498f, 0.498f, 0.078f);


    float maximumSliderHeight = 0.15f;

    Color objectColor;

    void Start()
    {


    }


    // Update is called once per frame
    void Update()
    {
        // get value to assign

        var barHeight = this.transform.localScale.y;
        var percentage = barHeight / maximumSliderHeight;
        //float percentage = PinchSlider.mySliderVal;

        // mix bad color with good color

        objectColor = MixTwoColors(good, bad, percentage);

        // assign color
        this.GetComponent<MeshRenderer>().material.color = objectColor;

    }


    Color MixTwoColors (Color one, Color two, float factor)
    {
        Color c = new Color();

        var r = (factor * one.r) + ((1 - factor) * two.r);
        var g = (factor * one.g) + ((1 - factor) * two.g);
        var b = (factor * one.b) + ((1 - factor) * two.b);

        c.r = r;
        c.g = g;
        c.b = b;

        return c;
    }
}
