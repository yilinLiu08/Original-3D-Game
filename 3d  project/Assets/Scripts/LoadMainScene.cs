using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainScene : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
        if (Input.anyKeyDown)
        {
            
            SceneManager.LoadScene("StartingScene");
        }
    }
}
