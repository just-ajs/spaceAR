using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Population
    {
        List<Layout> solutions = new List<Layout>();

                      

        public Population (List<GameObject> rooms, float width, float depth, int populationSize)
        {
            for (int i = 0; i < populationSize; i++)
            {
                Layout sol = new Layout(rooms, width, depth);
                sol.GenerateRandomLayout();

                solutions.Add(sol);
                //sol.InstantiateSolution();
            }

            solutions[0].InstantiateLayout();
        }



    }
}
