using UnityEngine;

public class Collectible : MonoBehaviour
{
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
        if(other != null)
        {
            if (other.CompareTag("Player"))
            {
                Collect();
            }
        }
    }

    void Collect()
    {
        Debug.Log("collected");

        Destroy(gameObject);
    }
}
