using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class AutomaticDoor : MonoBehaviour
{
    [Header("References")]
    public Transform doorTransform;

    [Header("Settings")]
    public Vector3 closePos;
    public Vector3 openPos;
    public Vector3 rotation;
    public float duration = 1.0f; 
    public float detectionRadius = 3.0f;
    public LayerMask playerLayer;

    [Header("Events")]
    public UnityEvent<bool> onDoorTriggered;

    private bool isOpen;
    private Coroutine doorCoroutine;

    public void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, playerLayer);
        Debug.Log("player detected");

        bool shouldBeOpen = colliders.Length > 0;

        if (shouldBeOpen != isOpen)
        {
            isOpen = shouldBeOpen;
            onDoorTriggered?.Invoke(isOpen);
            ToggleDoor();
        }
    }

    public void ToggleDoor()
    {
        if (doorCoroutine != null)
        {
            StopCoroutine(doorCoroutine);
        }

        doorCoroutine = StartCoroutine(TweenCoroutine(isOpen));
        Debug.Log("door open");
    }

    private IEnumerator TweenCoroutine(bool open)
    {
        Vector3 startPos = doorTransform.localPosition;
        Vector3 targetPos = open ? openPos : closePos;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;

            t = Mathf.SmoothStep(0, 1, t);

            doorTransform.localPosition = Vector3.Lerp(startPos, targetPos, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        doorTransform.localPosition = targetPos;
        doorCoroutine = null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}

