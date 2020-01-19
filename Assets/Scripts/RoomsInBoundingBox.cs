using Assets.Scripts;
using Microsoft.MixedReality.Toolkit.UI;
using System;
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
        _mentors, _kitchen, _relax,
        _bathroom, _common, _core, _keynote,
        _hardware;


    public float[] scores;
    public GameObject[] sliders;


    float scaleMax = 0.5f;

    float targetScaleMin = 0.2f;
    float targetScaleMax = 0f;

    public List<Timestamp> timeLine;
    GameObject[] objects;

    bool positionChanged = true;
    public bool DisplayHistory = false;
    public float historyStep = 0.7f;
    bool runningTimestamp = false;
    bool isShowingBarGraph = true;

    // Start is called before the first frame update
    void Start()
    {
        scores = new float[8];
        timeLine = new List<Timestamp>();
        objects = new GameObject[11];

        // general
        position = this.transform.position;
        width = this.transform.localScale.x;
        depth = this.transform.localScale.z;

        // rooms
        _wsA = UnityEngine.Object.Instantiate(workingSpaceA);
        _wsB = UnityEngine.Object.Instantiate(workingSpaceB);
        _wsC = UnityEngine.Object.Instantiate(workingSpaceC);

        _kitchen = UnityEngine.Object.Instantiate(Kitchen);
        _bathroom = UnityEngine.Object.Instantiate(Bathrooms);
        _relax = UnityEngine.Object.Instantiate(Relaxation);
        _mentors = UnityEngine.Object.Instantiate(Mentors);
        _relax = UnityEngine.Object.Instantiate(Relaxation);
        _common = UnityEngine.Object.Instantiate(Common);
        _keynote = UnityEngine.Object.Instantiate(Keynote);
        _core = UnityEngine.Object.Instantiate(Core);
        _hardware = UnityEngine.Object.Instantiate(Hardware);

        // ui
        GetScores();
        sliders = DisplaySliders(scores, feedbackSlider);
        //text


        AddObjectsToArray();

        var stamp = new Timestamp(objects, scores);
        timeLine.Add(stamp);
        Debug.Log("timestamp added");



    }

    // Update is called once per frame
    void Update()
    {

        if (DisplayHistory)
        {

            runningTimestamp = true;

            int index = (int)Math.Round(historyStep * timeLine.Count);

            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].transform.position = timeLine[index].positions[i];
                objects[i].transform.localScale = timeLine[index].scale[i];
            }
        }

        else
        {
            //historyStep = 1f;
            if (runningTimestamp)
            {

                for (int i = 0; i < objects.Length; i++)
                {
                    objects[i].transform.position = timeLine[timeLine.Count-1].positions[i];
                    objects[i].transform.localScale = timeLine[timeLine.Count - 1].scale[i];
                }

                runningTimestamp = false;
            }

            GetScores();
            UpdateSliders(scores, .8f);

            positionChanged = CheckPositionChanged();

            if (positionChanged)
            {
                var stamp = new Timestamp(objects, scores);

                timeLine.Add(stamp);
                Debug.Log("timestamp added");
            }
        }



    }


    bool CheckPositionChanged()
    {
        var lastStamp = timeLine[timeLine.Count - 1];

        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].transform.position.x != lastStamp.positions[i].x
                || objects[i].transform.position.y != lastStamp.positions[i].y
                || objects[i].transform.position.z != lastStamp.positions[i].z
                || objects[i].transform.localScale.x != lastStamp.scale[i].x
                || objects[i].transform.localScale.y != lastStamp.scale[i].y
                || objects[i].transform.localScale.z != lastStamp.scale[i].z
                )
            {
                return true;
            }
        }

        return false;
    }

    void GetScores()
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

        scores[2] = targetScaleMin - scores[2];

    }

    GameObject[] DisplaySliders(float[] scores, GameObject slider)
    {
        GameObject[] sliders = new GameObject[scores.Length];

        for (int i = 0; i < scores.Length; i++)
        {


            sliders[i] = UnityEngine.Object.Instantiate(slider, new Vector3((0.05f * i)-0.175f, 1.05f, 1.2f), new Quaternion());


            //sliders[i].transform.localScale = new Vector3(1, scores[i], 1);


        }

        return sliders;
    }

    void AddObjectsToArray()
    {
        objects[0] = _wsA;
        objects[1] = _wsB;
        objects[2] = _wsC;
        objects[3] = _kitchen;
        objects[4] = _bathroom;
        objects[5] = _relax;
        objects[6] = _mentors;
        objects[7] = _common;
        objects[8] = _keynote;
        objects[9] = _core;
        objects[10] = _hardware;
    }


    void UpdateSliders(float[] scores, float barScaler)
    {
        for (int i = 0; i < sliders.Length; i++)
        {
            //sliders[i] = Object.Instantiate(slider, new Vector3(10 * i, 40, 40), new Quaternion());

            //sliders[i].transform.localScale = new Vector3(1, scores[i], 1);
            float posX = sliders[i].transform.position.x;
            float posZ = sliders[i].transform.position.z;
            float posY = sliders[i].transform.position.y;

            float scaleX = sliders[i].transform.localScale.x;
            float scaleZ = sliders[i].transform.localScale.z;

            float multiplier = Math.Abs(scores[i] * barScaler);

            sliders[i].transform.localScale = new Vector3(scaleX, multiplier, scaleZ);
            sliders[i].transform.position = new Vector3(posX, (multiplier / 2) , posZ);
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

            instantiated.Add(UnityEngine.Object.Instantiate(rooms[i], location, new Quaternion()));
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

    public void ToggleBarGraph()
    {
        isShowingBarGraph = !isShowingBarGraph;

        for(int i = 0; i < sliders.Length; i++)
        {
            sliders[i].SetActive(isShowingBarGraph);
        }
    }

    public void ToggleHistory()
    {
        DisplayHistory = !DisplayHistory;
        //HistorySlider.SetActive(DisplayHistory);
    }

    public void HistorySliderChanging(SliderEventData data)
    {
        historyStep = data.NewValue;
    }



}
