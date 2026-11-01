using UnityEngine;

public class DamageModulatorScript : MonoBehaviour
{
    [Range(0f, 10f)]
    public int damageMultiplier;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")   // on collider2D vs collider2D with Damage tagged objects...
        {
            HealthScript.GetInstance().damageMultiplier = damageMultiplier;
        }
    }

}
