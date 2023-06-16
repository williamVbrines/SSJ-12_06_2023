using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TooLoo;

namespace ssj12062023
{
    public class BehaviourMutationCard : MonoBehaviour
    {
        [SerializeField, ReadOnly] private BehaviourMutationData data;

        public BehaviourMutationData Data => data;

        public void SetData(BehaviourMutationData data)
        {
            this.data = data;
        }
    }
}