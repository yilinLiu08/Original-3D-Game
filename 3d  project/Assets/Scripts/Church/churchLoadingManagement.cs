using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class churchLoadingManagement : MonoBehaviour
{
    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();
        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (collision.gameObject.tag == "Player")
        {
            if (sceneName == "ChurchScene")
            {
                SceneManager.LoadScene("SampleScene");
            }
            if (sceneName == "SampleScene")
            {
                SceneManager.LoadScene("ChurchScene");
            }
        }
    }
}
