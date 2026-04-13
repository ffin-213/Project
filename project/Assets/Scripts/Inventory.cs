using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    [Header("Item Counts")]
    public List<int> counts = new List<int>();

    [Header("Prefabs")]
    public List<GameObject> prefabs = new List<GameObject>();

    [Header("UI Images")]
    public List<GameObject> pics = new List<GameObject>();

    [Header("UI Text")]
    public List<TextMeshProUGUI> texts = new List<TextMeshProUGUI>();

    [Header("Settings")]
    public int index = 0;
    public float dropForce = 2f;

    void Start()
    {
        for (int i = 0; i < pics.Count; i++)
        {
            pics[i].SetActive(false);
            texts[i].text = "0";
        }
    }

    void Update()
    {
        SelectIndex();

        if (Input.GetMouseButtonDown(1))
        {
            Drop();
        }
    }

    public void Add(int itemIndex)
    {
        if (itemIndex < 0 || itemIndex >= counts.Count) return;

        counts[itemIndex]++;

        pics[itemIndex].SetActive(true);
        texts[itemIndex].text = counts[itemIndex].ToString();
    }

    void SelectIndex()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) index = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2)) index = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3)) index = 2;
        if (Input.GetKeyDown(KeyCode.Alpha4)) index = 3;
        if (Input.GetKeyDown(KeyCode.Alpha5)) index = 4;
        if (Input.GetKeyDown(KeyCode.Alpha6)) index = 5;
        if (Input.GetKeyDown(KeyCode.Alpha7)) index = 6;
        if (Input.GetKeyDown(KeyCode.Alpha8)) index = 7;
        if (Input.GetKeyDown(KeyCode.Alpha9)) index = 8;

        Debug.Log("selected: " + index);
    }

    void Drop()
    {
        if (index < 0 || index >= counts.Count) return;

        if (counts[index] <= 0)
        {
            Debug.Log("no item to drop");
            return;
        }

        GameObject obj = Instantiate(
            prefabs[index],
            transform.position + transform.forward,
            Quaternion.identity
        );

        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(transform.forward * dropForce, ForceMode.Impulse);
        }

        counts[index]--;
        texts[index].text = counts[index].ToString();

        if (counts[index] == 0)
        {
            pics[index].SetActive(false);
        }

        Debug.Log("dropped item at index: " + index);
    }
}