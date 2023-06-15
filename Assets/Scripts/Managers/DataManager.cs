using System.Collections;
using System.Collections.Generic;
using TooLoo;
using UnityEngine;

namespace ssj12062023
{
    public class DataManager : Singleton<DataManager>
    {
        [Header("Resources Sub-folder")]
        public string bodyMutationLoadFolder = "";
        public string behaviourMutationLoadFolder = "";

        protected override void Awake()
        {
            base.Awake();
            Load();
        }

        private void Load()
        {
            BodyMutationData.Load(bodyMutationLoadFolder);
            BehaviourMutationData.Load(behaviourMutationLoadFolder);
        }
    }
}