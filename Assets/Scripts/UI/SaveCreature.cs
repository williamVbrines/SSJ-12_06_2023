using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ssj12062023
{
    public class SaveCreature : MonoBehaviour
    {
        [SerializeField] private Configurator configurator;
        [SerializeField] private TextMeshProUGUI customName;

        public void SaveBlueprint()
        {
            if (configurator.IsEmpty())
            {
                Debug.Log("No mutations added! Can't save an empty configuration!");
                return;
            }

            CreatureBlueprint blueprint = new(customName.text);

            foreach (ConfiguratorSlot s in configurator.Slots)
            {
                if (!s.VialSlot.IsAvailable)
                {
                    if (s.VialSlot.MutationType == EMutationType.Behaviour)
                    {
                        blueprint.BehaviourMutation = s.VialSlot.MutationData.UID;
                    }
                    else
                    {
                        blueprint.BodyMutations.Add(s.VialSlot.MutationData.UID);
                    }
                }
            }

            DataManager.Instance.SaveBlueprint(blueprint);
            Debug.Log("Creature saved!");
        }
    }
}