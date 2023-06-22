using System.Collections;
using System.Collections.Generic;
using TooLoo;
using UnityEngine;

namespace ssj12062023
{
    public class DataManager : Singleton<DataManager>
    {
        [Header("Resources Sub-folder")]
        public string BodyMutationsFolder = "BodyMutations";
        public string BehaviourMutationsFolder = "BehaviourMutations";
        public string ConfigurationLayoutsFolder = "ConfigurationLayouts";

        protected override void Awake()
        {
            base.Awake();
            Load();
        }

        private void Load()
        {
            BodyMutationData.Load(BodyMutationsFolder);
            BehaviourMutationData.Load(BehaviourMutationsFolder);
            ConfigurationLayoutData.Load(ConfigurationLayoutsFolder);
        }
    }
}