using UnityEngine;

public class PlanetsController : MonoBehaviour
{
    public PositionController[] controllers; 
    

    private bool allPositionsAndSizesReached = false;

    void Update()
    {
        CheckAllPositionsAndSizes();
    }

    void CheckAllPositionsAndSizes()
    {
        foreach (PositionController controller in controllers)
        {
            if (!controller.sizeAndPositionReached)
            {
                if (allPositionsAndSizesReached)
                {
                    
                    allPositionsAndSizesReached = false;
                }
                return;
            }
        }

        
        if (!allPositionsAndSizesReached)
        {
            Debug.Log("All planets true!");
            allPositionsAndSizesReached = true;
        }
    }
}
