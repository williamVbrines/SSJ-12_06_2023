using System.Collections;
using System.Collections.Generic;
using TooLoo;
using UnityEngine;

namespace ssj12062023
{
    public class MutationData : Data
    {
        [Space(20)]

        public string Name;
        
        [TextArea(3, 5)]
        public string Description;

        [Space(20)]

        [Range(1, 50)]
        public int GeneticCost;

        public Sprite Icon;

        public EMutationType Type;
    }
}