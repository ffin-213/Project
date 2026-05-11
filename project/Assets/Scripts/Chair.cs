using UnityEngine;

public class Chair : MonoBehaviour
{
    public GameObject playerStanding, playerSitting, intText, standText;
    public bool interactable, sitting;
    Vector3 p;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        p = playerSitting.transform.position;
        //intText.SetActive(false);
        //standText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("?");
        if (interactable == true)
        {
            Debug.Log("can sit");
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("sit");
                //intText.SetActive(false);
                //standText.SetActive(true);
                //playerSitting.SetActive(true);
                sitting = true;
                playerStanding.transform.position = p;
                interactable = false;
            }
        }
        else if (sitting == true)
        {
            Debug.Log("already sitting");
            if(Input.GetKeyDown(KeyCode.F))
            {
                playerSitting.SetActive(false);
                //standText.SetActive(false);
                playerStanding.SetActive(true);
                sitting = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("hi chair");
            //intText.SetActive(true);
            interactable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("bye chair");
            //intText.SetActive(false);
            interactable = false;
        }
    }
}
