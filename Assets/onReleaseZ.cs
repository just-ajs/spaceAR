using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onReleaseZ : MonoBehaviour
{
    // Start is called before the first frame update

    //public GameObject myCube;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z);

    }
}
