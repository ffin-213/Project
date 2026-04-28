using UnityEngine;

public class DoorDoor : MonoBehaviour
{

    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("isOpen", true);
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("isOpen", false);
    }
}
