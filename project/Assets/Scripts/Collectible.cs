using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float collectDistance = 3f;
    public Transform player;

    public int itemIndex;
    Player p;

    private void Start()
    {
        p = FindAnyObjectByType<Player>();
        player = p.transform;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float distance = Vector3.Distance(player.position, transform.position);

            if (distance <= collectDistance)
            {
                Inventory inv = FindAnyObjectByType<Inventory>();

                if (inv != null)
                {
                    inv.Add(itemIndex);
                }

                Destroy(gameObject);
            }
        }
    }
}