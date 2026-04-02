using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float collectDistance;
    private Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            float distance = Vector3.Distance(player.position, transform.position);

            if (distance <= collectDistance)
            {
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("too far");
            }
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if(other != null)
        {
            Debug.Log("trigger collectible");
            if (other.CompareTag("Player"))
            {
                Collect();
            }
        }
    }*/

    private void OnMouseDown()
    {

    }

    void Collect()
    {
        Debug.Log("collected");

        Destroy(gameObject);
    }
}
