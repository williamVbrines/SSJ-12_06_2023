using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssj12062023
{
    public enum EBodyPartType
    {
        Eyes, Head, Torso, Arms, Legs, Tail
    }

    [CreateAssetMenu(fileName = "New Body Part", menuName = "SSJ12062023/Body Part")]
    public class BodyPartData : Data
    {
        public EBodyPartType Type;
        public Sprite Part;
        public int AnchorPointsCount;
    }
}