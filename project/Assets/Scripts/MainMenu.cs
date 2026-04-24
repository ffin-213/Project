using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    Instructions instructions;
    Player player;
    Transform pos;
    private void Start()
    {
        instructions = FindAnyObjectByType<Instructions>();
        player = FindAnyObjectByType<Player>();
        //pos = player.transform;
    }
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);   
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //pos = instructions.currentPos;
            SceneManager.LoadScene(1);
        }
    }
}
