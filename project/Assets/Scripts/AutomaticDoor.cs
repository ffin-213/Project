using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class AutomaticDoor : MonoBehaviour
{
    public Transform doorTransform;

    public Vector3 closePos;
    public Vector3 openPos;

    public bool isOpen;
    public float duration;

    public float distance;
    public LayerMask layerMask;

    public UnityEvent<bool> onDoorTriggered;
    Coroutine cor;

    public void FixedUpdate()
    {
        //Collider[] colliders = Physics.OverlapBox(transform.position);
    }
}
