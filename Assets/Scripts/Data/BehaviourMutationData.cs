using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssj12062023
{
    [CreateAssetMenu(fileName = "New Behavior Mutation", menuName = "SSJ12062023/Mutations/Behavior Mutation")]
    public class BehaviourMutationData : MutationData
    {
        [Range(0f, 100f)]
        public float Aggression;

        protected static List<BehaviourMutationData> behaviourMutationData = new();

        public static void Load(string folder = "")
        {
            behaviourMutationData.Clear();
            behaviourMutationData.AddRange(Resources.LoadAll<BehaviourMutationData>(folder));
        }

        public static BehaviourMutationData Get(string uid)
        {
            foreach (BehaviourMutationData m in behaviourMutationData)
            {
                if (m.uid == uid)
                {
                    return m;
                }
            }

            Debug.LogError($"No BehaviourMutationData with Id {uid} exists");
            return null;
        }

        public static List<BehaviourMutationData> GetAll()
        {
            return behaviourMutationData;
        }
    }
}
