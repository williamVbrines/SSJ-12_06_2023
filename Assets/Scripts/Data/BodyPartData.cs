using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssj12062023
{
    [CreateAssetMenu(fileName = "New Body Part", menuName = "SSJ12062023/Body Part")]
    public class BodyPartData : Data
    {
        public Sprite Part;
        public int AnchorPointsCount;
    }
}