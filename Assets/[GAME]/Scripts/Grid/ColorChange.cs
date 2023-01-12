using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public class ColorChange : MonoBehaviour
{
    [SerializeField] Color pressedColor;
    Color defaultColor;
    SpriteRenderer spriteRend;

    private void Awake()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        defaultColor = spriteRend.color;
    }

    private void OnMouseDown()
    {
        spriteRend.color = pressedColor;
    }

    private void OnMouseUp()
    {
        spriteRend.color = defaultColor;
    }
}
