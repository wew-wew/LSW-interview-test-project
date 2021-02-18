using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSpritesOnAwake : MonoBehaviour
{
    void Awake()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
