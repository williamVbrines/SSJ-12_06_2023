using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TooLoo;

namespace ssj12062023
{
    public class BodyMutationCard : MonoBehaviour
    {
        [SerializeField, ReadOnly] private BodyMutationData data;

        public BodyMutationData Data => data;

        public void SetData(BodyMutationData data)
        {
            this.data = data;
        }
    }
}