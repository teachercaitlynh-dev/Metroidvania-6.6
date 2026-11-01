using UnityEngine;
using UnityEngine.InputSystem;    // directory for mouse functions

public class ObjectFollowCursorScript : MonoBehaviour
{

    void Start()
    {
        Cursor.visible = true;
    }

    void Update()
    {

        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());   // converts mouse on 2D screen to gameworld coordinates via camera
        transform.position = new Vector3(cursorPosition.x, cursorPosition.y, Camera.main.transform.position.z);
    }
}