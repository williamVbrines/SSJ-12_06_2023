using System.Collections;
using System.Collections.Generic;
using TooLoo;
using UnityEngine;

namespace ssj12062023
{
    public enum EMutationType
    {
        Eyes, Head, Torso, Arms, Legs, Tail, Behaviour
    }

    public enum EBidirectionality
    {
        Left, Right, None
    }

    public class MutationData : Data
    {
        [Space(20)]

        public string Name;
        
        [TextArea(3, 5)]
        public string Description;

        [Space(20)]

        [Range(1, 100)]
        public int GeneticCost;

        public Sprite Icon;

        public EMutationType Type;
        public EBidirectionality Bidirectionality;
    }
}