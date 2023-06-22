using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssj12062023
{
    public class CreatureBlueprint : ScriptableObject
    {
        public string Name;
        public string BehaviourMutation;
        public List<string> BodyMutations;
    }
}