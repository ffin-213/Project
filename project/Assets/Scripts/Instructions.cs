using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Instructions : MonoBehaviour
{
    public List<GameObject> instructions = new List<GameObject> ();
    public Transform currentPos;
    Player player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindAnyObjectByType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentPos = player.transform;
            SceneManager.LoadScene(2);
        }
    }
}
