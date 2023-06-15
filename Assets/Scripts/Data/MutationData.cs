using System.Collections;
using System.Collections.Generic;
using TooLoo;
using UnityEngine;

namespace ssj12062023
{
    public class MutationData : ScriptableObject
    {
        [SerializeField, ReadOnly]
        protected string id = string.Empty;

        [Space(20)]

        public string Name;
        
        [TextArea(3, 5)]
        public string Description;

        [Space(20)]

        [Range(1, 50)]
        public int GeneticCost;

        public Sprite Icon;

        public string Id => id;

        public void GenerateUID()
        {
            string uniqueId = System.Guid.NewGuid().ToString();
            if (id.Equals(uniqueId)) return;

            id = uniqueId;
        }
    }
}