using UnityEngine;

namespace Platformer.Mechanics
{
    /// <summary>
    /// A simple controller for moving platform. Provides movement control over a patrol path.
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    public class PlatformController : MonoBehaviour
    {

        private readonly bool isMovingToEnd = true;
        private int index = 0;
        [SerializeField] private Transform[] transforms;

        private void Start()
        {
            transform.position = transforms[index].position;
            index++;
        }


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.transform.parent = transform;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.transform.parent = null;
            }
        }

        private void Update()
        {
            // if (isMovingToEnd)
            // {
            Debug.Log("isMovingToEnd");
            if (transform.position != transforms[index].position)
            {
                transform.position = Vector3.MoveTowards(transform.position, transforms[index].position, 1 * Time.deltaTime);
            }
            else
            {
                if (index < transforms.Length - 1)
                {
                    index++;
                }
                else
                {
                    index--;
                }
                // isMovingToEnd = !isMovingToEnd;
            }
            // }
            // else
            // {Debug.Log("ELSE isMovingToEnd");
            //     if (transform.position != startTransform.position)
            //     {
            //         transform.position = Vector3.MoveTowards(transform.position, startTransform.position, 1 * Time.deltaTime);
            //     }
            //     else
            //     {
            //         isMovingToEnd = !isMovingToEnd;
            //     }
            // }
        }
    }
}