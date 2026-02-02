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

        // Desired position = player's current position + fixed offset
        Vector3 desiredPosition = target.position + offset;

        // For endless runner we usually want:
        // - instant or very fast Z follow
        // - smooth X/Y if player moves sideways

        // Option A: smooth everything (most common & forgiving)
        Vector3 smoothedPosition = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed
        );

        // Option B: only smooth X & Y, lock Z perfectly (very crisp feel)
        // Vector3 smoothedPosition = new Vector3(
        //     Mathf.Lerp(transform.position.x, desiredPosition.x, smoothSpeed),
        //     Mathf.Lerp(transform.position.y, desiredPosition.y, smoothSpeed),
        //     desiredPosition.z   // ← no delay in forward direction
        // );

        transform.position = smoothedPosition;

        // Optional: keep looking at player (if camera is slightly angled)
        // transform.LookAt(target);
    }
}