using UnityEngine;

public class DontDestroyOnLoadScript : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);    // gameobject persists on scene change
    }
}
