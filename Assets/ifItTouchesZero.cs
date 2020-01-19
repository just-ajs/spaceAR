using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ifItTouchesZero : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject myPanel;
    bool wentBelowZero = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gameObject.transform.position.z);
        if (gameObject.transform.position.y <= -0.01 && wentBelowZero != true) {

            Vector3 myPos = gameObject.transform.position;

            gameObject.transform.position = new Vector3(myPanel.transform.localPosition.x, 0, myPanel.transform.localPosition.z );
            gameObject.transform.parent = null;
            gameObject.transform.position = new Vector3(myPanel.transform.localPosition.x, 0, myPanel.transform.localPosition.z );
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            wentBelowZero = true;
            //enable Zscript and other script

        } else if (gameObject.transform.position.y <= -0.01) {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0.0f, gameObject.transform.position.z);
            gameObject.transform.parent = null;
        }
    }
}
