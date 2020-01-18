using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonUniformScale : MonoBehaviour
{
    [SerializeField]
    private Transform transformToManipulate;

    [SerializeField]
    private Transform xHandle;

    [SerializeField]
    private Transform zHandle;

    private Vector3 initialScale;

    private const float defaultHandleScale = 0.01f;

    private void Start()
    {
        initialScale = this.transformToManipulate.localScale;
        this.transform.localScale = initialScale;

        SetHandleScale(xHandle);
        SetHandleScale(zHandle);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = transformToManipulate.position;
        this.transformToManipulate.localScale = new Vector3(initialScale.x * this.xHandle.localPosition.x, initialScale.y, initialScale.z * this.zHandle.localPosition.z);
    }

    private void SetHandleScale(Transform input)
    {
        input.parent = null;
        input.localScale = Vector3.one * defaultHandleScale;
        input.parent = this.transform;
    }
}
