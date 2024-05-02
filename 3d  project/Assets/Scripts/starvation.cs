using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using System.Collections;
using System.Collections.Generic;

public class starvation : MonoBehaviour
{
    public float hunger = 100f;
    private float decreaseRate;
    public Image HungerBar;
    private bool shouldDecrease = true;
    private float pauseTimer = 0f;

    public Volume hungerVolume;
    public AudioSource hungerAudioSource;
    private Coroutine hungerSoundCoroutine;

    void Start()
    {
        decreaseRate = 100f / (2f * 60f);
        hungerAudioSource.loop = false; 
    }

    void Update()
    {
        if (pauseTimer > 0)
        {
            pauseTimer -= Time.deltaTime;
            if (pauseTimer <= 0)
            {
                shouldDecrease = true;
            }
        }
        else if (shouldDecrease)
        {
            DecreaseHunger();
        }

        if (hunger > 0)
        {
            nohunger();
        }
    }

    public void PauseHungerDecrease(float duration)
    {
        shouldDecrease = false;
        pauseTimer = duration;
    }

    public void stopHungerDecrease()
    {
        shouldDecrease = false;
    }

    public void continueHungerDecrease()
    {
        shouldDecrease = true;
    }

    void DecreaseHunger()
    {
        hunger -= decreaseRate * Time.deltaTime;
        HungerBar.fillAmount = hunger / 100f;
        hunger = Mathf.Max(hunger, 0);

        if (hunger <= 0 && hungerSoundCoroutine == null)
        {
            hungerSoundCoroutine = StartCoroutine(PlayHungerSound());
            StartCoroutine(FadeInVolumeWeight(2.0f));
        }
    }

    IEnumerator FadeInVolumeWeight(float duration)
    {
        float currentTime = 0;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            hungerVolume.weight = Mathf.Lerp(0, 1, currentTime / duration);
            yield return null;
        }
        hungerVolume.weight = 1;
    }

    void nohunger()
    {
        hungerVolume.weight = 0;
        if (hungerSoundCoroutine != null)
        {
            StopCoroutine(hungerSoundCoroutine);
            hungerSoundCoroutine = null;
        }
    }

    IEnumerator PlayHungerSound()
    {
        while (true)
        {
            hungerAudioSource.Play();
            yield return new WaitForSeconds(15f); 
        }
    }
}
