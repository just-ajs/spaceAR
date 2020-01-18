using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{

    float width;
    float depth;

    float lukeScale = 1f;

    public float SquareFootArea = 0f;
    public float SquareMetersArea = 0f;

    public int hackers = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        width = this.transform.localScale.x;
        depth = this.transform.localScale.z;

        SquareFootArea = GetSquareFoot();
        SquareMetersArea = FootToMeters(SquareFootArea);

        hackers = GetHackers(SquareFootArea);
    }

    float GetSquareFoot()
    {
        float sq = width * depth;


        var scaling = 40000 / lukeScale;

        sq = sq * scaling;
        return Math.Abs(sq);
    }

    float FootToMeters(float foot)
    {
        return (float)Math.Round(foot * 0.092903f);
    }

    int GetHackers(float foot)
    {
        int ppl = 0;

        ppl = (int)Math.Floor(foot * 0.05);

        return ppl;
    }
}
