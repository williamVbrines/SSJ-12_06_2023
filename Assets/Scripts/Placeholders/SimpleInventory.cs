using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssj12062023
{
    public class SimpleInventory : MonoBehaviour
    {
        [SerializeField] private GameObject bodyMutationCardPrefab;
        [SerializeField] private GameObject behaviourMutationCardPrefab;

        // Start is called before the first frame update
        void Start()
        {
            PopulateInventory();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void PopulateInventory()
        {
            List<BodyMutationData> bodyMutationData = BodyMutationData.GetAll();
            List<BehaviourMutationData> behaviourMutationData = BehaviourMutationData.GetAll();

            foreach (BodyMutationData m in bodyMutationData)
            {
                GameObject card = Instantiate(bodyMutationCardPrefab, this.transform);
                card.GetComponentInChildren<BodyMutationCard>().SetData(m);
            }

            foreach (BehaviourMutationData m in behaviourMutationData)
            {
                GameObject card = Instantiate(behaviourMutationCardPrefab, this.transform);
                card.GetComponentInChildren<BehaviourMutationCard>().SetData(m);
            }
        }
    }
}