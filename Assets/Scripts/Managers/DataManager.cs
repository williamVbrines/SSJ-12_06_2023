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

        [SerializeField, ReadOnly] private List<CreatureBlueprint> creatures = new();

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

        public void SaveBlueprint(CreatureBlueprint blueprint)
        {
            creatures.Add(blueprint);
        }

        public CreatureBlueprint? GetBlueprint(string uid)
        {
            foreach (CreatureBlueprint blueprint in creatures)
            {
                if (blueprint.Uid == uid)
                {
                    return blueprint;
                }
            }
            return null;
        }
    }
}