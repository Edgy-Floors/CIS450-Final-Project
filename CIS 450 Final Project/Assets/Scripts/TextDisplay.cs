using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TextDisplay : MonoBehaviour
{
    public string text;
    private string currentText = "";
    public float scrollSpeed = 0.04f;
    public static string sceneToLoad;

    public AudioSource a;

    private void Start()
    {
        StartCoroutine(ShowText());
    }

    public IEnumerator ShowText()
    {
        for (int i = 0; i < text.Length; i++)
        {
            currentText = text.Substring(0, i);
            this.GetComponent<TextMeshProUGUI>().text = currentText;
            yield return new WaitForSeconds(scrollSpeed);
        }
        StartCoroutine(LoadSpecificScene(sceneToLoad));
    }

    public IEnumerator LoadSpecificScene(string s)
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(s);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            this.StopAllCoroutines();
            a.mute = true;
            this.GetComponent<TextMeshProUGUI>().text = text;
            StartCoroutine(LoadSpecificScene(sceneToLoad));
        }
    }
}
