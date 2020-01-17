using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomsInBoundingBox : MonoBehaviour
{
    public GameObject kitchen;
    public GameObject bedroom;
    public GameObject bathroom;

    List<GameObject> rooms = new List<GameObject>();

    List<GameObject> instantiated = new List<GameObject>();
    Population pop;

    Vector3 position;
    float width;
    float depth;



    // Start is called before the first frame update
    void Start()
    {
        position = this.transform.position;
        width = this.transform.localScale.x;
        depth = this.transform.localScale.z;

        rooms.Add(kitchen);
        rooms.Add(bedroom);
        rooms.Add(bathroom);

        // new population 
        pop = new Population(rooms, width, depth, 10);

    }

    // Update is called once per frame
    void Update()
    {

        
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





}
