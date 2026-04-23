using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Instructions : MonoBehaviour
{
    public List<GameObject> instructions = new List<GameObject> ();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(2);
        }
    }
}
