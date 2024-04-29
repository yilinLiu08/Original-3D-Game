using UnityEngine;
using UnityEngine.UI;
public class starvation : MonoBehaviour
{
    public float hunger = 100f;
    private float decreaseRate;
    public Image HungerBar;
    private bool shouldDecrease = true;
    private float pauseTimer = 0f;

    void Start()
    {
        decreaseRate = 100f / (2f * 60f); // 每2分钟降低100点饥饿值
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
    }

    public void PauseHungerDecrease(float duration)
    {
        shouldDecrease = false;
        pauseTimer = duration;
    }

    void DecreaseHunger()
    {
        hunger -= decreaseRate * Time.deltaTime;
        HungerBar.fillAmount = hunger / 100f;
        hunger = Mathf.Max(hunger, 0);

        if (hunger <= 0)
        {
            //Debug.Log("You are dead");
        }
    }
}





