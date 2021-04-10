using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseCursor : MonoBehaviour
{
    private SpriteRenderer rend;
    public Sprite handCursor;

    void Start()
    {
        Cursor.visible = false;
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;
        rend.sprite = handCursor;
    }
}
