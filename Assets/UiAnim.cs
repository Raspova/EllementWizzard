using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiAnim : MonoBehaviour
{
    // Start is called before the first frame update
    private UnityEngine.UI.Image image;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        image = GetComponent<UnityEngine.UI.Image>();
        image.enabled = true;
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        image.sprite = spriteRenderer.sprite;
    }
}
