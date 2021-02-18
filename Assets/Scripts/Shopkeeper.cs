using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour, IInteractable
{
    public static Shopkeeper instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        StartCoroutine(ShowDialogue("Welcome!", 0.5f));

        StartCoroutine(ShowVariousPhrasesPeriodically());
    }

    public void OnInteract()
    {
        Debug.Log("yep?");
    }

    public IEnumerator ShowDialogue(string phrase, float initial_delay = 0f)
    {
        UIManager.instance.speech_bubble_text.text = phrase;

        yield return new WaitForSeconds (initial_delay);
        yield return StartCoroutine(UIManager.instance.UIFade(UIManager.instance.speech_bubble_cg, 0f, 1f, 0.25f));
        yield return new WaitForSeconds (3f);
        yield return StartCoroutine(UIManager.instance.UIFade(UIManager.instance.speech_bubble_cg, 1f, 0f, 0.25f));
    }

    public IEnumerator ShowVariousPhrasesPeriodically()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            yield return StartCoroutine(ShowDialogue("Check our new stuff!"));
            yield return new WaitForSeconds(10f);
            yield return StartCoroutine(ShowDialogue("The latest fashion!"));            
            yield return new WaitForSeconds(10f);
            yield return StartCoroutine(ShowDialogue("Highest quality!"));                 
        }
    }

}
