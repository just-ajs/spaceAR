using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Layout
    {

        List<GameObject> members = new List<GameObject>();

        float planeWidth;
        float planeDepth;

        List<Space> spaces = new List<Space>();

        List<GameObject> instantiated = new List<GameObject>();

        public float Fitness { get; set; }


        // population coordinates
        List<Vector3> coords = new List<Vector3>();

        public Layout(List<GameObject> rooms, float width, float depth)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                members.Add(rooms[i]);
            }

            planeDepth = depth;
            planeWidth = width;
        }

        public void GenerateRandomLayout()
        {
            for (int i = 0; i < members.Count; i++)
            {

                var location = Utilities.GenerateRoomLocation(members[i], planeWidth, planeDepth);

                Space x = new Space(location, members[i].transform.localScale.x, members[i].name);
                spaces.Add(x);

            }
        }

        public void InstantiateLayout()
        {
            for (int i = 0; i < spaces.Count; i++)
            {
                instantiated.Add(UnityEngine.Object.Instantiate(members[i], spaces[i].coords, new Quaternion()));
            }
        }


        public void CalculateFitness()
        {
            // smaller score if overlapping

            for (int i = 0; i < spaces.Count; i++)
            {
                for (int j = 0; j < spaces.Count; j++)
                {
                    if (i == j) continue;

                    var desirableDist = spaces[i].size / 2 + spaces[j].size / 2;

                    var actualDist = spaces[i].coords - spaces[j].coords;


                }
            }
        }
    }

}

