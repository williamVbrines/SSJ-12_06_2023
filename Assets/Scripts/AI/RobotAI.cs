using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ssj12062023
{
    public class RobotAI : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent navigator;
        [SerializeField] private Transform standingSpot;
        [SerializeField] private Transform configurator;

        [Space(20)]
        [Header("Movement Settings")]
        [SerializeField] private float rotateSpeed = 20f;
        [SerializeField] private float maxWaitTime = 3f;
        [SerializeField] private float maxWanderDistance = 5f;
        [SerializeField] private float distanceToActivateConfigurator = 8f;

        private Vector3 destination;
        private bool isWorking;

        private void OnEnable()
        {
            GameManager.Instance.OnClickCreatureCreator += InteractCreatureCreator;
            GameManager.Instance.OnCloseCreatureCreator += ResetRobot;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnClickCreatureCreator -= InteractCreatureCreator;
            GameManager.Instance.OnCloseCreatureCreator -= ResetRobot;
        }

        // Start is called before the first frame update
        void Start()
        {
            ResetRobot();
        }

        // Update is called once per frame
        void Update()
        {
            if (!isWorking)
            {
                if (Vector3.Distance(destination, transform.position) <= 1f)
                {
                    navigator.ResetPath();
                    destination = default;
                    StartCoroutine(MoveToRandomPosition());
                }
            }
        }

        private void HandleRotation()
        {
            if (navigator.hasPath)
            {
                Vector3 facing = navigator.steeringTarget - transform.position;
                facing.y = 0f;
                facing.Normalize();

                //Apply Rotation
                Quaternion targ_rot = Quaternion.LookRotation(facing, Vector3.up);
                Quaternion nrot = Quaternion.Slerp(transform.rotation, targ_rot, rotateSpeed * Time.deltaTime);
                transform.rotation = nrot;
            }
        }

        private void FaceTowards(Transform target)
        {
            Vector3 facing;
            facing = target.position - transform.position;
            facing.y = 0f;
            facing.Normalize();

            //Apply Rotation
            Quaternion targ_rot = Quaternion.LookRotation(facing, Vector3.up);
            Quaternion nrot = Quaternion.RotateTowards(transform.rotation, targ_rot, 360f);
            transform.rotation = nrot;
        }

        private IEnumerator MoveToRandomPosition()
        {
            yield return new WaitForSeconds(Random.Range(0f, maxWaitTime));

            destination = GetRandomNavMeshPosition(transform.position, maxWanderDistance);
            navigator.SetDestination(destination);
        }

        private Vector3 GetRandomNavMeshPosition(Vector3 sourcePos, float maxDistance)
        {
            Vector3 randomDirection = Random.insideUnitSphere * maxDistance + sourcePos;
            Vector3 finalPosition = sourcePos;
            if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, 4f, NavMesh.AllAreas))
            {
                finalPosition = hit.position;
            }
            return finalPosition;
        }

        public void InteractCreatureCreator()
        {
            StopAllCoroutines();
            isWorking = true;

            float distance = Vector3.Distance(transform.position, configurator.transform.position);
            Debug.Log($"Distance from computer: {distance}");
            if (distance <= distanceToActivateConfigurator)
            {
                FaceTowards(configurator);
                GameManager.Instance.ShowCreatureCreator();
                return;
            }

            navigator.SetDestination(configurator.transform.position);            
        }

        public void ResetRobot()
        {
            destination = default;
            isWorking = false;
            StartCoroutine(MoveToRandomPosition());

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == configurator.gameObject
                && isWorking)
            {
                Debug.Log("Reached Configurator");
                FaceTowards(configurator);
                GameManager.Instance.ShowCreatureCreator();
            }
        }
    }

}