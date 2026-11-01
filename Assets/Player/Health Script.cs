using UnityEngine;
using UnityEngine.SceneManagement;   // directory for scene management
using UnityEngine.UI;   // directory for user interface
using TMPro;    // directory for text canvas
using System.Collections;   // directory for IEnumerator functions

public class HealthScript : MonoBehaviour
{

    [Header("CUSTOMIZABLE PLAYER HEALTH & DAMAGE VALUES")]
    [Space(10)]

    public int startingPlayerHealthValue;
    private int playerHealthValue;
    public int standardPlayerDamageIncrement;
    public int damageMultiplier = 1;
    [Space(15)]

    [Header("HEALTHBAR VISUAL CUES REFERENCED")]
    [Space(10)]
    public GameObject playerHealthGUIPrefab;
    public Slider healthBar;
    public TMP_Text healthText; 
    
    // lines 24-36 instantiate this as THE static playerhealth script so other scripts can call its public functions & modify its public values
    private static HealthScript instance;
    private void Awake()
    {
        if (instance != null)   // if there is already an instance of this script...
        {
            Debug.LogWarning("HealthScript instance count > 1: WARNING DUPLICATE HEALTHBAR IN SCENE.");   // warning log in console
        }
        instance = this;   // sets this script as the gettable player health script instance
    }
    public static HealthScript GetInstance()
    {
        return instance;   // returns this instance of the script including its values
    }
    // other scripts can reference this static via "HealthScript.GetInstance().insert public value or public function call with parameters here;"

    private void Start()
    {
        playerHealthValue = startingPlayerHealthValue;   // sets current player health to max health
        updatePlayerHealthUI();   // updates health ui to match the current health
    }
    public void updatePlayerHealthUI()
    {
        healthText.text = playerHealthValue + " / " + startingPlayerHealthValue;   //  updates healthbar text display
        healthBar.value = (float)playerHealthValue / (float)startingPlayerHealthValue;   // updates healthbar values
        damageMultiplier = 1;   // resets damage multiplier after calculation

        if (playerHealthValue == 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   // reloads the current scene on player death
        }


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Damage")   // on collider2D vs collider2D with Damage tagged objects...
        {
            StartCoroutine(playerHealthChanges(standardPlayerDamageIncrement));   // runs playerHealthChanges function with the standard damage increment parameter's value
        }
    }

    public IEnumerator playerHealthChanges(int amountOfChange)   // allows customization of the amount of damage when calling this function from other scripts
    {
        yield return new WaitForSeconds(0.017f);   // waits for damage modulator script to modify damageMultiplier before running damage calculation
        playerHealthValue = (playerHealthValue + (amountOfChange * damageMultiplier));
        updatePlayerHealthUI();
    }

}
