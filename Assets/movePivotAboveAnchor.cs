using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePivotAboveAnchor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject anchor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (gameObject.transform.position.x != anchor.transform.position.x || gameObject.transform.position.z != anchor.transform.position.z) {
            gameObject.transform.position = new Vector3(anchor.transform.position.x, 0.1f, anchor.transform.position.z);
        }
    }
}
