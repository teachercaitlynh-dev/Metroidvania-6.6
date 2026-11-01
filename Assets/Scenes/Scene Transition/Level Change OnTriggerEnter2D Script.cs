using UnityEngine;
using System.Collections;

public class LevelChangeOnTriggerEnter2DScript : MonoBehaviour
{
    public int loadSceneNumber;
    public AudioSource audioSource;
    public AudioClip soundClip;
    public GameObject objectToAppear;
    public int secondsToWaitBeforeSceneChange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))   // triggers on collision with "Player" tag
        {
            objectToAppear.SetActive(true);
            //audioSource.PlayOneShot(soundClip);
            
            StartCoroutine(waitAnimation());
        }
    }

    public IEnumerator waitAnimation()
    {
        yield return new WaitForSeconds(secondsToWaitBeforeSceneChange);
        UnityEngine.SceneManagement.SceneManager.LoadScene(loadSceneNumber);
    }
        
}
