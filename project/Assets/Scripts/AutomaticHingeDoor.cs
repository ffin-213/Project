using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class AutomaticHingeDoor : MonoBehaviour
{
    [Header("References")]
    public Transform hinge; 
    public Transform player;

    [Header("Settings")]
    public float openAngle = -90f;
    public float duration = 1f;
    public float detectionRadius = 3f;
    public LayerMask playerLayer;
    public bool openAwayFromPlayer = true;

    [Header("Events")]
    public UnityEvent<bool> onDoorTriggered;

    private Quaternion closedRotation;
    private Quaternion targetOpenRotation;

    private bool isOpen;
    private Coroutine currentRoutine;

    void Start()
    {
        closedRotation = hinge.localRotation;
    }

    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius, playerLayer);
        bool shouldOpen = hits.Length > 0;

        if (shouldOpen != isOpen)
        {
            isOpen = shouldOpen;

            if (openAwayFromPlayer && player != null)
                CalculateOpenDirection();

            onDoorTriggered?.Invoke(isOpen);
            StartDoorAnimation(isOpen);
        }
    }

    void CalculateOpenDirection()
    {
        Vector3 toPlayer = (player.position - hinge.position).normalized;
        float dot = Vector3.Dot(hinge.right, toPlayer);

        float direction = dot > 0 ? 1f : -1f;
        targetOpenRotation = closedRotation * Quaternion.Euler(0, openAngle * direction, 0);
    }

    void StartDoorAnimation(bool open)
    {
        if (currentRoutine != null)
            StopCoroutine(currentRoutine);

        Quaternion target = open
            ? (openAwayFromPlayer ? targetOpenRotation : closedRotation * Quaternion.Euler(0, openAngle, 0))
            : closedRotation;

        currentRoutine = StartCoroutine(RotateDoor(target));
    }

    IEnumerator RotateDoor(Quaternion target)
    {
        Quaternion start = hinge.localRotation;
        float time = 0f;

        while (time < duration)
        {
            float t = time / duration;
            t = Mathf.SmoothStep(0, 1, t);

            hinge.localRotation = Quaternion.Slerp(start, target, t);

            time += Time.deltaTime;
            yield return null;
        }

        hinge.localRotation = target;
        currentRoutine = null;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}

