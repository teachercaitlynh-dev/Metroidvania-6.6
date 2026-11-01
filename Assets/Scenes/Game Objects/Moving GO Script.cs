using UnityEngine;

public class MovingGOScript : MonoBehaviour
{
    public float posX1, posX2;
    bool moveRight = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector2(posX1, +0);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.position.x >= posX2)
        {
            moveRight = false;
        }
        else if (transform.position.x < posX1)
        {
            moveRight = true;
        }

        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + 0.001f, transform.position.y);
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); //flips horizontally
        }
        else
        {
            transform.position = new Vector2(transform.position.x - 0.001f, transform.position.y);
            transform.localScale = new Vector3(0.5f, -0.5f, 0.5f); //flips horizontally
        }
    }
}
