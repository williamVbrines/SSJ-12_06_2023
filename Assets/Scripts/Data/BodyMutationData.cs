using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssj12062023
{
    [CreateAssetMenu(fileName ="New Body Mutation", menuName ="SSJ12062023/Mutations/Body Mutation")]
    public class BodyMutationData : MutationData
    {
        public float Hp;
        public BodyPartData BodyPart;

        protected static List<BodyMutationData> bodyMutationData = new();

        public static void Load(string folder = "")
        {
            bodyMutationData.Clear();
            bodyMutationData.AddRange(Resources.LoadAll<BodyMutationData>(folder));
        }

        public static BodyMutationData Get(string id)
        {
            foreach (BodyMutationData m in bodyMutationData)
            {
                if (m.id == id)
                {
                    return m;
                }
            }

            Debug.LogError($"No BodyMutationData with Id {id} exists");
            return null;
        }

        public static List<BodyMutationData> GetAll()
        {
            return bodyMutationData;
        }
    }
}