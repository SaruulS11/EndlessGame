 using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;              // drag your player here
    public Vector3 offset;                // initial camera offset from player

    [Header("Smoothing")]
    public float smoothSpeed = 0.125f;    // 0.05 – 0.2 range is common
                                          // smaller = smoother / more lag
                                          // larger  = faster / snappier

    void Start()
    {
        if (target == null)
        {
            Debug.LogWarning("Camera has no target assigned!");
            return;
        }

        // Optional: auto-calculate offset at start
        offset = transform.position - target.position;
    }

    // We use LateUpdate for cameras → runs after player movement
    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;

        Vector3 smoothedPosition = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed
        );
        transform.position = smoothedPosition;
    }
}