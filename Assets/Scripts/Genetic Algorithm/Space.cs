using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Space
    {
        public Vector3 coords;
        public float size;
        public string name;

        public Space (Vector3 coords, float size, string name)
        {
            this.coords = coords;
            this.size = size;
            this.name = name;

        }

    }
}
