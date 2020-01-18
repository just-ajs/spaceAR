using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour
{

    public static Vector3 GenerateRoomLocation(GameObject room, float width, float depth)
    {
        var xpos = Random.Range(-width / 2, width / 2);
        var zpos = Random.Range(-depth  / 2, depth / 2);

        return new Vector3(xpos, 0, zpos);
    }

    public static Vector3 GenerateRoomLocationBasedOnAnotherRoom(GameObject room, GameObject another, List<GameObject> rooms)
    {
        var length = GetVectorLength(room, another);

        var randomMove = RandomVector(length);
        bool overlapping;
        Vector3 addedMove;

        do
        {
            randomMove = RandomVector(length);
            addedMove = another.transform.position + randomMove;

            overlapping = CheckIfNotOverlapping(addedMove, room, rooms);
        }
        while (!overlapping);


        //var addedMove = another.transform.position + randomMove;

        return addedMove;
    }

    public static bool CheckIfNotOverlapping(Vector3 move, GameObject room,  List<GameObject> rooms)
    {
        for (int i = 0; i < rooms.Count; i++)
        {
            var distance = GetVectorLength(room, rooms[i]);

            var vectorSubstracted = move - rooms[i].transform.position;

            if (vectorSubstracted.magnitude < distance)
            {
                return false;
            }
        }

        return true;
    }

    // get the vector length so it is exactly like distance to the previous rooms from the list
    public static float GetVectorLength(GameObject a, GameObject b)
    {
        float length = a.transform.localScale.x / 2 + b.transform.localScale.z / 2;
        return length;
    }

    //get random vector with normal distribution, normalized
    public static Vector3 RandomVector(float length)
    {
        Vector3 randomVect = new Vector3();

        randomVect.x = Random.Range(-1.0f, 1.0f);
        randomVect.y = 0.0f;
        randomVect.z = Random.Range(-1.0f, 1.0f);

        Vector3 normalizedVect = randomVect.normalized;

        Vector3 adjustedLength = normalizedVect * length;
        return adjustedLength;
    }
}
