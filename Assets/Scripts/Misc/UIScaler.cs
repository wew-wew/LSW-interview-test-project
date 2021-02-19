using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScaler : MonoBehaviour
{
    public RectTransform coins_panel_rekt;

    // Start is called before the first frame update
    void Start()
    {
        // figuring out the size of in-game "unit" which is 64 pixels compared to screen coordinates
        Vector3 screen_point_0 = GetComponent<Canvas>().worldCamera.WorldToScreenPoint(Vector3.zero);
        Vector3 screen_point_1 = GetComponent<Canvas>().worldCamera.WorldToScreenPoint(new Vector3(1,0,0));

        // camera space unit
        float csu = screen_point_1.x - screen_point_0.x;

        coins_panel_rekt.anchoredPosition = new Vector2(-csu/2f, csu/2f);
        coins_panel_rekt.sizeDelta = new Vector2(3 * csu, csu)/coins_panel_rekt.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
