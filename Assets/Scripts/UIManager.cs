using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public CanvasGroup speech_bubble_cg;
    public Text speech_bubble_text;

    public static UIManager instance;

    void Awake()
    {
        instance = this;
        speech_bubble_cg.alpha = 0f;
    }

    // fade coroutine for ui elements (canvas groups)
    public IEnumerator UIFade(CanvasGroup canvas_group, float starting_alpha = 0f, float target_alpha = 1f, float fade_time = 1f)
    {
        float current_fade_time = fade_time;

		while (current_fade_time > 0)
		{
            current_fade_time -= Time.deltaTime;
            canvas_group.alpha = Mathf.Lerp(starting_alpha, target_alpha, (fade_time - current_fade_time)/fade_time);
            yield return null;
		}

        canvas_group.alpha = target_alpha;
    }
}
