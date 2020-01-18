using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveToNearestGrid : MonoBehaviour
{
    // Start is called before the first frame update

    int count = 0;
    float mult = 80.0f;
    //public GameObject myCube;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        count++;

        //if (count % 2 == 0) {
            int myX = Mathf.RoundToInt(gameObject.transform.position.x * mult);
            float newX = (float)myX;
            newX = newX / mult;

            int myZ = Mathf.RoundToInt(gameObject.transform.position.z * mult);
            float newZ = (float)myZ;
            newZ = newZ/ mult;

            int myRot = Mathf.RoundToInt(transform.rotation.eulerAngles.y / 90.0f);
            float newRot = (float)myRot;
            newRot = newRot * 90.0f;

            transform.position = new Vector3(newX, 0, newZ);
            transform.rotation = Quaternion.Euler(0, newRot, 0);
        //}
    }
}
