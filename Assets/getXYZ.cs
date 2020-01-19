using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getXYZ : MonoBehaviour
{

    public GameObject myChildCube;
    public Vector3 goPos;
    public GameObject boilerEmpty;
    public GameObject myNewEmpty;
    // Start is called before the first frame update
    void Awake()
    {
        myNewEmpty = Instantiate(boilerEmpty);
    }

    // Update is called once per frame
    void Update()
    {
        goPos = myChildCube.transform.position;
        myNewEmpty.transform.position = goPos;
        myNewEmpty.transform.localScale = myChildCube.transform.localScale;

    }
}
