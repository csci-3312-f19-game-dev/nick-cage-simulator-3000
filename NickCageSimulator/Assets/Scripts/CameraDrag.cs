using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    public float panSpeed;
    public float panBorderThickness = 50f;
    public float xLimit, yLimit, xMin, yMin, zLimit, zMin;
    public float scrollSpeed = 20f;

    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.y += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.y -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.z += scroll * scrollSpeed * Time.deltaTime;
        //-240 and 718

        pos.x = Mathf.Clamp(pos.x, xMin, xLimit);
        pos.y = Mathf.Clamp(pos.y, yMin, yLimit);
        pos.z = Mathf.Clamp(pos.z, zMin, zLimit);

        transform.position = pos;
    }
}
