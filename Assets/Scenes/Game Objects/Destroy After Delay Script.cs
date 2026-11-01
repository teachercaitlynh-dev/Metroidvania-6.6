using UnityEngine;
using System.Collections;   // directory for coroutines

public class DestroyAfterDelayScript : MonoBehaviour
{
    public float delayBeforeDestruction;
    private void Start()
    {
        StartCoroutine(destroyAfterDelay());
    }
    public IEnumerator destroyAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeDestruction);
        Destroy(transform.root.gameObject);
    }
}
