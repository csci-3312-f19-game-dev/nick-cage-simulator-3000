using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMouseHandler : MonoBehaviour
{
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver()
    {
        Debug.Log("mouse over");
        if (Input.GetMouseButtonDown(0))
        {
            sr.color = new Color(1, 0, 0, 1);
            Debug.Log("Mouse button down");
        }
    }
}
