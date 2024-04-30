using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEnabler : MonoBehaviour
{
    public GameObject purplePlatform;
    public GameObject miniBoss;
    public GameObject purpleGlow;
    // Start is called before the first frame update
    void Start()
    {
        purplePlatform.SetActive(false);
        purpleGlow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (miniBoss == null)
        {
            purpleGlow.SetActive(true);
            purplePlatform.SetActive(true);
        }
    }
}
