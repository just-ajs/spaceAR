using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBar : MonoBehaviour
{
    [SerializeField] public float scoreInput = 5.0f; // just for testing - fakes input value from JS
    [SerializeField] public float barScaler = 0.1f; // just for testing - scales down graph

    private float posY;
    private float posX;
    private float posZ;
    private float scaleX;
    private float scaleY;
    private float scaleZ;
    // Start is called before the first frame update
    void Start()
    {
        // get existing scale & coordinates
        float posY = this.transform.position.y;
        float posX = this.transform.position.x;
        float posZ = this.transform.position.z;
        float scaleX = this.transform.localScale.x;
        float scaleY = this.transform.localScale.y;
        float scaleZ = this.transform.localScale.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(scaleX, (scoreInput * barScaler), scaleZ);
        transform.position = new Vector3(posX, ((scoreInput * barScaler)/ 2), posZ);
        // if > 0 pink, else purple - jeff to do

    }
}
