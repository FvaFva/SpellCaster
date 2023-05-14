using UnityEngine;
using WorldSpace;

namespace View
{
    public class PathPosition : MonoBehaviour
    {
        public Position Position => GetWorldPosition();

        private Position GetWorldPosition()
        {
            Vector3 worldPosition = transform.TransformPoint(Vector3.zero);
            return new Position(worldPosition.x, worldPosition.y, worldPosition.z);
        }
    }
}