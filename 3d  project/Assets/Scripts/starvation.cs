using UnityEngine;
using UnityEngine.UI;

public class starvation : MonoBehaviour
{
    public float hunger = 100f; 
    private float decreaseRate;
    public Image HungerBar;

    void Start()
    {
       
        decreaseRate = 100f / (2f * 60f);
    }

    void Update()
    {
        
        DecreaseHunger();
    }

    void DecreaseHunger()
    {
        
        hunger -= decreaseRate * Time.deltaTime;
        HungerBar.fillAmount = hunger / 100f;

        hunger = Mathf.Max(hunger, 0);

        
        Debug.Log("Hunger: " + hunger);

       
        if (hunger <= 0)
        {
            //Debug.Log("You are dead");
            
        }
    }
}





