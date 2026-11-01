using UnityEngine;

public class ObjectMovesPlayerScript : MonoBehaviour
{

    [Header("CUSTOMIZE FORCE VALUES")]
    [Space(10)]
    public float forceThisAddsToPlayerX;
    public float forceThisAddsToPlayerY;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")   // on collider2D vs collider2D with Damage tagged objects...
        {
            Rigidbody2D triggeringObjectsRB = collision.attachedRigidbody;   // gets triggering game object, the player
            triggeringObjectsRB.AddForce(Vector2.right * forceThisAddsToPlayerX, ForceMode2D.Impulse);
            triggeringObjectsRB.AddForce(Vector2.up * forceThisAddsToPlayerY, ForceMode2D.Impulse);
        }
    }

}
