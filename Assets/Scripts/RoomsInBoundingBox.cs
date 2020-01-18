using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomsInBoundingBox : MonoBehaviour
{
    public GameObject plane;
    
    // objects
    public GameObject workingSpaceA;
    public GameObject workingSpaceB;
    public GameObject workingSpaceC;
    public GameObject Kitchen;
    public GameObject Bathrooms;
    public GameObject Relaxation;
    public GameObject Common;
    public GameObject Keynote;
    public GameObject Core;
    public GameObject Mentors;
    public GameObject Hardware;

    // ui
    public GameObject feedbackSlider;

 
    List<GameObject> rooms = new List<GameObject>();

    List<GameObject> instantiated = new List<GameObject>();
    Population pop;

    Vector3 position;
    float width;
    float depth;

    GameObject _wsA, _wsB, _wsC, 
        _mentors , _kitchen, _relax, 
        _bathroom, _common, _core, _keynote,
        _hardware;


    public float [] scores;
    public GameObject[] sliders;


    float scaleMax = 1;

    float targetScaleMin = 0.80f;
    float targetScaleMax = -0.0f;

    // Start is called before the first frame update
    void Start()
    {
        scores = new float[8];

        // general
        position = this.transform.position;
        width = this.transform.localScale.x;
        depth = this.transform.localScale.z;

        // rooms
        _wsA = Object.Instantiate(workingSpaceA);
        _wsB = Object.Instantiate(workingSpaceB);
        _wsC = Object.Instantiate(workingSpaceC);

        _kitchen = Object.Instantiate(Kitchen);
        _bathroom = Object.Instantiate(Bathrooms);
        _relax = Object.Instantiate(Relaxation);
        _mentors = Object.Instantiate(Mentors);
        _relax = Object.Instantiate(Relaxation);
        _common = Object.Instantiate(Common);
        _keynote = Object.Instantiate(Keynote);
        _core = Object.Instantiate(Core);
        _hardware = Object.Instantiate(Hardware);

        // ui
        sliders = DisplaySliders(scores, feedbackSlider);


        
    }

    // Update is called once per frame
    void Update()
    {
        scores[0] = GetScore1(_wsA, _wsB, _wsC, _mentors);
        scores[1] = GetScore1(_wsA, _wsB, _wsC, _mentors);
        scores[2] = GetScore1(_wsA, _wsB, _wsC, plane);
        scores[3] = GetScore5(_kitchen, _relax);
        scores[4] = GetScore5(_common, _keynote);
        scores[5] = GetScore5(_common, _bathroom);
        scores[6] = GetScore5(_hardware, _mentors);
        scores[7] = GetScore5(_kitchen, _common);

        for (int i = 0; i < scores.Length; i++)
        {
            scores[i] = Remap(scores[i], 0, scaleMax, targetScaleMin, targetScaleMax);
        }

        scores[2] = -scores[2];


        UpdateSliders(scores, 1f);
    }

    GameObject[] DisplaySliders (float[] scores, GameObject slider)
    {
        GameObject[] sliders = new GameObject[scores.Length];

        for (int i = 0; i < scores.Length; i++)
        {
            sliders[i] = Object.Instantiate(slider, new Vector3((0.1f*i) - 0.4f , 0, 3), new Quaternion());

            //sliders[i].transform.localScale = new Vector3(1, scores[i], 1);
        }

        return sliders;
    }

    void UpdateSliders(float[] scores, float barScaler)
    {
        for (int i = 0; i < sliders.Length; i++)
        {
            //sliders[i] = Object.Instantiate(slider, new Vector3(10 * i, 40, 40), new Quaternion());

            //sliders[i].transform.localScale = new Vector3(1, scores[i], 1);
            float posX = sliders[i].transform.position.x;
            float posZ = sliders[i].transform.position.z;

            float scaleX = this.transform.localScale.x;
            float scaleZ = this.transform.localScale.z;


            sliders[i].transform.localScale = new Vector3(scaleX, (scores[i] * barScaler), scaleZ);
            sliders[i].transform.position = new Vector3(posX, ((scores[i] * barScaler) / 2), posZ);
        }
    }


    void InstantiateNotOverlappingRooms()
    {
        for (int i = 0; i < rooms.Count; i++)
        {
            Vector3 location;
            //var location = GenerateRoomLocation(rooms[i]);
            if (instantiated.Count == 0)
            {
                location = Utilities.GenerateRoomLocation(rooms[i], width, depth);
            }
            else
            {
                location = Utilities.GenerateRoomLocationBasedOnAnotherRoom(rooms[i], instantiated[i - 1], instantiated);
            }

            instantiated.Add(Object.Instantiate(rooms[i], location, new Quaternion()));
        }
    }

    public static float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

    // distance from working spaces to mentors
    float GetScore1(GameObject wsA, GameObject wsB, GameObject wsC, GameObject mentors)
    {
        float score = 0;
        var vectorA = wsA.transform.position - mentors.transform.position;
        var vectorB = wsB.transform.position - mentors.transform.position;
        var vectorC = wsC.transform.position - mentors.transform.position;

        score = vectorA.magnitude + vectorA.magnitude + vectorC.magnitude;


        return score;
    }




    float GetScore5(GameObject common, GameObject keynote)
    {
        float score = 0;
        var vectorA = common.transform.position - keynote.transform.position;

        score = vectorA.magnitude;
        return score;
    }



}
