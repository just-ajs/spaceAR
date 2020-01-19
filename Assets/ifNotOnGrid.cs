using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ifNotOnGrid : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject scalerObject;
    public GameObject toolTip;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x < 0.3 && gameObject.transform.position.x > -0.3 && gameObject.transform.position.z < 1.2 && gameObject.transform.position.z > 0.6)
        {
            //ganeobject is on the grid
            //check to see if the scalar script is on, and if it is, turn it off
            //if (scalerObject.activeSelf == true) {
                scalerObject.SetActive(false);
                toolTip.SetActive(true);
           // }
            //turn off the scaler script
        }
        else {
            //turn on the scaler gameobject
            //if (scalerObject.activeSelf == false) {
                scalerObject.SetActive(true);
                toolTip.SetActive(false);
            //}
            //check to see if the scalar script is off, and if it is, turn it on
        }
    }
}
