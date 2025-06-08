using UnityEngine;

namespace Platformer.Mechanics
{
    public partial class PatrolPath
    {
        /// <summary>
        /// The Mover class oscillates between start and end points of a path at a defined speed.
        /// </summary>
        public class Mover
        {
            private readonly PatrolPath path;
            private float p = 0;
            private readonly float duration;
            private readonly float startTime;

            public Mover(PatrolPath path, float speed)
            {
                this.path = path;
                duration = (path.endPosition - path.startPosition).magnitude / speed;
                startTime = Time.time;
            }

            /// <summary>
            /// Get the position of the mover for the current frame.
            /// </summary>
            /// <value></value>
            public Vector2 Position
            {
                get
                {
                    p = Mathf.InverseLerp(0, duration, Mathf.PingPong(Time.time - startTime, duration));
                    return path.transform.TransformPoint(Vector2.Lerp(path.startPosition, path.endPosition, p));
                }
            }
        }
    }
}