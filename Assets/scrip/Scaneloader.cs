using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaneloader : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadScene(string aSceneToLoad)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(aSceneToLoad);
    }
    
}
