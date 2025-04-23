#if UNITY_EDITOR
using UnityEngine;

namespace Common.Scripts
{
    public class SpawnPointGizmo : MonoBehaviour
    {
        [Tooltip("Color of the spawn‐point gizmo")]
        public Color gizmoColor = Color.yellow;
        [Tooltip("Radius of the wire‐sphere")]
        public float radius = 0.5f;

        void OnDrawGizmos()
        {
            Gizmos.color = gizmoColor;
            Gizmos.DrawWireSphere(transform.position, radius);
        }

        void OnDrawGizmosSelected()
        {
            // Slightly filled when selected
            Gizmos.color = gizmoColor * new Color(1,1,1,0.25f);
            Gizmos.DrawSphere(transform.position, radius * 0.5f);
        }
    }
}
#endif