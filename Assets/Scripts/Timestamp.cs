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
        Vector3[] positions;
        Vector3[] scale;

        float[] scores;

        public Timestamp(GameObject[] o, float[] scores)
        {
            positions = GetPositions(o);
            scale = GetScale(o);

            this.scores = scores;
        }


        Vector3[] GetPositions(GameObject[] o)
        {
            var pos = new Vector3[o.Length];

            for (int i = 0; i < o.Length; i++)
            {
                positions[i] = o[i].transform.position;
            }

            return pos;
        }


        Vector3[] GetScale(GameObject[] o)
        {
            var pos = new Vector3[o.Length];

            for (int i = 0; i < o.Length; i++)
            {
                positions[i] = o[i].transform.localScale;
            }

            return pos;
        }
    }
}
