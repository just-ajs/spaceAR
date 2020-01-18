using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Timestamp
    {
        public Vector3[] positions;
        public Vector3[] scale;

        public float[] scores;

        public Timestamp(GameObject[] o, float[] scores)
        {
            positions = new Vector3[o.Length];
            scale = new Vector3[o.Length];
            scores = new float[o.Length];

            positions = GetPositions(o);
            scale = GetScale(o);

            this.scores = scores;
        }


        Vector3[] GetPositions (GameObject[] o)
        {
            var pos = new Vector3[o.Length];

            for (int i = 0; i < o.Length; i++)
            {
                pos[i] = o[i].transform.position;
            }

            return pos;
        }


        Vector3[] GetScale(GameObject[] o)
        {
            var sc = new Vector3[o.Length];

            for (int i = 0; i < o.Length; i++)
            {
                sc[i] = o[i].transform.localScale;
            }

            return sc;
        }
    }
}
