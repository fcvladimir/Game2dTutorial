using UnityEngine;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Marks a trigger as a HalfwayCheckPointZone, usually used to set new spawn point at the half of path in level.
    /// </summary>
    public class HalfwayCheckPointZone : MonoBehaviour
    {

        public GameObject billBoard;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                if (collider.gameObject.TryGetComponent<PlayerController>(out var p))
                {
                    p.UpdateSpawnPoint(collider.gameObject.transform.position);
                }
                billBoard.SetActive(true);
            }
        }
    }
}