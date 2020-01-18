using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{

    float width;
    float depth;

    float lukeScale = 1f;

    public float SquareFoorArea = 0f;
    public float SquareMetersArea = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        width = this.transform.localScale.x;
        depth = this.transform.localScale.z;

        SquareFoorArea = GetSquareFoot();
        SquareMetersArea = FootToMeters(SquareFoorArea);
    }

    float GetSquareFoot()
    { 
        float sq = width * depth;


        var scaling = 40000 / lukeScale;

        sq = sq * scaling;
        return sq;
    }

    float FootToMeters(float foot)
    {
        return foot * 0.092903f;
    }
}
