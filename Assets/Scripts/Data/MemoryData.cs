using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssj12062023
{
    [CreateAssetMenu(fileName = "New Memory", menuName = "SSJ12062023/Memory")]
    public class MemoryData : Data
    {
        public string Title;
        [TextArea(5, 10)]
        public string Description;
    }
}