using UnityEngine;
using TMPro;
using NUnit.Framework;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    [Header("Object Counts")]
    public int bottleCount = 0;
    public int batteryCount = 0;
    public int cannnedFoodCount = 0;
    public int firstAidCount = 0;
    public int flashlightCount = 0;
    public int matchboxCount = 0;
    public int pillsCount = 0;
    public int tapeCount = 0;
    public int walkieCount = 0;

    [Header("Prefabs")]
    public GameObject bottlePref;
    public GameObject batteryPref;
    public GameObject cannnedFoodPref;
    public GameObject firstAidPref;
    public GameObject flashlightPref;
    public GameObject matchboxPref;
    public GameObject pillsPref;
    public GameObject tapePref;
    public GameObject walkiePref;

    [Header("Display Pics")]
    public GameObject bottlePic;
    public GameObject batteryPic;
    public GameObject cannedFoodPic;
    public GameObject firstAidPic;
    public GameObject flashlightPic;
    public GameObject matchboxPic;
    public GameObject pillsPic;
    public GameObject tapePic;
    public GameObject walkiePic;

    [Header("Display Texts")]
    public TextMeshProUGUI bottleQuantityText;
    public TextMeshProUGUI batteryQuantityText;
    public TextMeshProUGUI cannedFoodQuantityText;
    public TextMeshProUGUI firstAidQuantityText;
    public TextMeshProUGUI flashlightQuantityText;
    public TextMeshProUGUI matchboxQuantityText;
    public TextMeshProUGUI pillsQuantityText;
    public TextMeshProUGUI tapeQuantityText;
    public TextMeshProUGUI walkieQuantityText;

    [Header("Others")]
    public List<GameObject> objects = new List<GameObject>();
    public int index = 0;
    private bool selected;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bottlePic.SetActive(false);
        selected = false;
        SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        SelectIndex();

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("try drop");
            Drop();
        }
    }

    public void Add()
    {
        bottleCount++;
        bottlePic.SetActive(true);
        bottleQuantityText.text = bottleCount.ToString();
    }

    private void SelectIndex()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {index = 0;}
        if (Input.GetKeyDown(KeyCode.Alpha2)) {index = 1;}
        if (Input.GetKeyDown(KeyCode.Alpha3)) {index = 2;}
        if (Input.GetKeyDown(KeyCode.Alpha4)) {index = 3;}
        if (Input.GetKeyDown(KeyCode.Alpha5)) {index = 4;}
        if (Input.GetKeyDown(KeyCode.Alpha6)) {index = 5;}
        if (Input.GetKeyDown(KeyCode.Alpha7)) {index = 6;}
        if (Input.GetKeyDown(KeyCode.Alpha8)) {index = 7;}
        if (Input.GetKeyDown(KeyCode.Alpha9)) {index = 8;}

        Selected();
    }

    private void Selected()
    {
        for(int i = 0; i < objects.Count; i++)
        {
            if(i == index)
            {
                Debug.Log("selected " + i + " = " + index);
                //objects[i].color = Color.red;
                selected = true;
            }
            else
            {
                Debug.Log("nothing selected");
                selected = false;
            }
        }
    }

    void Drop()
    {
        Debug.Log("dropped");
    }

    void SetUp()
    {
        objects.Add(bottlePic);
        objects.Add(batteryPic);
        objects.Add(cannedFoodPic);
        objects.Add(firstAidPic);
        objects.Add(flashlightPic);
        objects.Add(matchboxPic);
        objects.Add(pillsPic);
        objects.Add(tapePic);
        objects.Add(walkiePic);
    }
}
