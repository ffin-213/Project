//using System.Collections;
//using UnityEngine;
//using UnityEngine.Events;

//public class AutomaticDoor : MonoBehaviour
//{
//    [Header("References")]
//    public Transform doorTransform;

//    [Header("Settings")]
//    public Vector3 closePos;
//    public Vector3 openPos;
//    public float duration = 1.0f; // How long it takes to open/close
//    public float detectionRadius = 3.0f;
//    public LayerMask playerLayer;

//    [Header("Events")]
//    public UnityEvent<bool> onDoorTriggered;

//    private bool isOpen;
//    private Coroutine doorCoroutine;

//    public void FixedUpdate()
//    {
//        // Check if any colliders on the playerLayer are within detectionRadius
//        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, playerLayer);

//        bool shouldBeOpen = colliders.Length > 0;

//        if (shouldBeOpen != isOpen)
//        {
//            isOpen = shouldBeOpen;
//            onDoorTriggered?.Invoke(isOpen);
//            ToggleDoor();
//        }
//    }

//    public void ToggleDoor()
//    {
//        if (doorCoroutine != null)
//        {
//            StopCoroutine(doorCoroutine);
//        }

//        doorCoroutine = StartCoroutine(TweenCoroutine(isOpen));
//    }

//    private IEnumerator TweenCoroutine(bool open)
//    {
//        Vector3 startPos = doorTransform.localPosition;
//        Vector3 targetPos = open ? openPos : closePos;
//        float elapsed = 0f;

//        // Using Lerp ensures the door moves smoothly over exactly the duration specified
//        while (elapsed < duration)
//        {
//            float t = elapsed / duration;

//            // Adding SmoothStep makes the door start and stop gently
//            t = Mathf.SmoothStep(0, 1, t);

//            doorTransform.localPosition = Vector3.Lerp(startPos, targetPos, t);
//            elapsed += Time.deltaTime;
//            yield return null;
//        }

//        doorTransform.localPosition = targetPos;
//        doorCoroutine = null;
//    }

//    private void OnDrawGizmosSelected()
//    {
//        Gizmos.color = Color.green;
//        Gizmos.DrawWireSphere(transform.position, detectionRadius);
//    }
//}

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
    public float duration = 1.0f; // How long it takes to open/close
    public float detectionRadius = 3.0f;
    public LayerMask playerLayer;

    [Header("Events")]
    public UnityEvent<bool> onDoorTriggered;

    private bool isOpen;
    private Coroutine doorCoroutine;

    public void FixedUpdate()
    {
        // Check if any colliders on the playerLayer are within detectionRadius
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, playerLayer);

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
    }

    private IEnumerator TweenCoroutine(bool open)
    {
        Vector3 startPos = doorTransform.localPosition;
        Vector3 targetPos = open ? openPos : closePos;
        float elapsed = 0f;

        // Using Lerp ensures the door moves smoothly over exactly the duration specified
        while (elapsed < duration)
        {
            float t = elapsed / duration;

            // Adding SmoothStep makes the door start and stop gently
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

