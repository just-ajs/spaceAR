using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class NonUniformScaleHandle : MonoBehaviour
{
    private Vector3 initialPosition;

    private enum Axis
    {
        x = 0,
        z
    }

    private Axis currentAxis;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = this.transform.localPosition;

        currentAxis = Mathf.Abs(initialPosition.x) > Mathf.Abs(initialPosition.z) ? Axis.x : Axis.z;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (currentAxis == Axis.x)
        {
            this.transform.localPosition = new Vector3(this.transform.localPosition.x, initialPosition.y, initialPosition.z);
        }
        else
        {
            this.transform.localPosition = new Vector3(initialPosition.x, initialPosition.y, this.transform.localPosition.z);
        }
    }
}
