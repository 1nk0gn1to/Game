using System.Linq;
using UnityEngine;

namespace Entities
{
    public abstract class Counter : MonoBehaviour
    {
        [SerializeField] private GameObject visualObject;
        [SerializeField] private LayerMask counterLayerMask = default;

        public bool IsSelected => visualObject.activeInHierarchy;

        private void Update()
        {
            CheckPlayer();
        }

        private void CheckPlayer()
        {
            float maxDistance = 0.5f;

            var colliders = Physics.OverlapSphere(transform.position, maxDistance, counterLayerMask, QueryTriggerInteraction.Collide);

            if (!colliders.Any())
            {
                if (IsSelected)
                {
                    visualObject.SetActive(false);
                    Debug.Log("Set no active");
                }
            }
            else
            {
                if (!IsSelected)
                {
                    visualObject.SetActive(true);
                    Debug.Log("Set active");
                }
            }
        }

        public abstract void Interact();
    }
}