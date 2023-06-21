using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssj12062023
{
    public enum EMutationType
    {
        Eyes, Head, Torso, Arms, Legs, Tail, Behaviour
    }

    [CreateAssetMenu(fileName = "New Body Part", menuName = "SSJ12062023/Body Part")]
    public class BodyPartData : Data
    {
        
        public Sprite Part;
        public int AnchorPointsCount;
    }
}