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

        [Space(20)]
        [Header("Audio")]
        [SerializeField] private AudioClip saveSuccess;
        [SerializeField] private AudioClip saveFailed;
        [SerializeField] private AudioClip[] voiceActorLines;

        public void SaveBlueprint()
        {
            if (configurator.IsEmpty())
            {
                AudioManager.Instance.PlaySFX(saveFailed);
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

            AudioManager.Instance.PlaySFX(saveSuccess);

            AudioClip voiceLine;
            if (TryRandomVoiceLine(out voiceLine))
            {
                AudioManager.Instance.PlayVoice(voiceLine);
            }

            DataManager.Instance.SaveBlueprint(blueprint);
            Debug.Log("Creature saved!");
        }

        private bool TryRandomVoiceLine(out AudioClip clip)
        {
            System.Random random = new();
            bool shouldPlayVoiceLine = random.Next(0, 4) == 1;

            if (shouldPlayVoiceLine)
            {
                int index = Random.Range(0, voiceActorLines.Length);
                clip = voiceActorLines[index];
                return true;
            }
            clip = null;
            return false;
        }
    }
}