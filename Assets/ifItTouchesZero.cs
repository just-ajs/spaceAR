using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ifItTouchesZero : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject myCubeParent;
    public GameObject myPanel, myPanelParent;
    bool wentBelowZero = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(gameObject.transform.position.z);
        if (gameObject.transform.position.y <= -0.01 && wentBelowZero != true) {
           
            Vector3 myPos = gameObject.transform.position;
            
            gameObject.transform.position = new Vector3(myPanel.transform.localPosition.x + myPanelParent.transform.position.x, 0, myPanel.transform.localPosition.z + myPanelParent.transform.position.z);
            gameObject.transform.SetParent(myCubeParent.transform);
            gameObject.transform.position = new Vector3(myPanel.transform.localPosition.x + myPanelParent.transform.position.x, 0, myPanel.transform.localPosition.z + myPanelParent.transform.position.z);
            //gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            wentBelowZero = true;
            //enable Zscript and other script

        }
    }
}
