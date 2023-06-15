using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssj12062023
{
    public class SimpleInventory : MonoBehaviour
    {
        [SerializeField] private GameObject cardPrefab;

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
                GameObject card = Instantiate(cardPrefab, this.transform);
            }
        }
    }
}