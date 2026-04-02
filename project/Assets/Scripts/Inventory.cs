using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public int count = 0;
    public TextMeshProUGUI quantityText;
    public GameObject Bottle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Bottle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add()
    {
        count++;
        Bottle.SetActive(true);
        quantityText.text = count.ToString();
    }
}
