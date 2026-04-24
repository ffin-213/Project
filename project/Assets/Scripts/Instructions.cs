using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;

public class Instructions : MonoBehaviour
{
    public List<GameObject> instructions = new List<GameObject> ();
    public Transform currentPos;
    Player player;

    [SerializeField] private CanvasGroup[] instructionTexts;
    [SerializeField] private float displayTime = 5f;
    [SerializeField] private float fadeDuration = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindAnyObjectByType<Player>();
        StartCoroutine(RunSequence());
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

    private IEnumerator RunSequence()
    {

        foreach (CanvasGroup text in instructionTexts)
        {
            text.alpha = 0;
            text.gameObject.SetActive(false);
        }

        foreach (CanvasGroup text in instructionTexts)
        {
            text.gameObject.SetActive(true);

            yield return StartCoroutine(Fade(text, 0, 1, fadeDuration));
            yield return new WaitForSeconds(displayTime);
            yield return StartCoroutine(Fade(text, 1, 0, fadeDuration));

            text.gameObject.SetActive(false);
        }
    }

    private IEnumerator Fade(CanvasGroup cg, float start, float end, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            cg.alpha = Mathf.Lerp(start, end, elapsed / duration);
            yield return null;
        }
        cg.alpha = end;
    }
}