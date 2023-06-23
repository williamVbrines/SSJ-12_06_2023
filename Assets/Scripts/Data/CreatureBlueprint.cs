using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssj12062023
{
    [Serializable]
    public struct CreatureBlueprint
    {
        private string uid;

        public string Name;
        public string BehaviourMutation;
        public List<string> BodyMutations;

        public string Uid => uid;

        public CreatureBlueprint(string name)
        {
            uid = System.Guid.NewGuid().ToString();
            Name = name;
            BehaviourMutation = string.Empty;
            BodyMutations = new List<string>();
        }
    }
}