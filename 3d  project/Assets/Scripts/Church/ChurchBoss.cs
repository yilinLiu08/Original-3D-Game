using UnityEngine;
using System.Collections.Generic;
using System;

public class ChurchBoss : MonoBehaviour
{
    public bool IsActive;
    public MaterialChange[] spheres;

    [SerializeField] MiniBossController bossController;
    void Start()
    {
        //StartCoroutine(ChangeMaterialsRandomly());
    }
    void Awake()
    {
        MiniBossController.onStun += ActivateSpheres;
    }

    private void Update()
    {
        if (!IsActive)
            return;
        int count = 0;
        for (int i = 0; i < spheres.Length; i++)
        {
            if (spheres[i].isPurple)
            {
                count++;
            }
        }
        //Debug.Log(count);
        if (count == spheres.Length)
        {
            //damage boss
            bossController.DamageTrueHealth(1);
            //reset orbs
            foreach (var sphere in spheres)
            {
                sphere.ResetOrb();
                sphere.canChange = false;
            }
            IsActive = false;
        }
    }

    void ActivateSpheres()
    {
        IsActive = true;
        foreach (var sphere in spheres)
        {
            sphere.canChange = true;
        }
    }

    //IEnumerator<WaitForSeconds> ChangeMaterialsRandomly()
    //{
    //    while (true)
    //    {

    //        yield return new WaitForSeconds(10);


    //        List<int> indexes = new List<int> { 0, 1, 2, 3 };
    //        int purpleIndex = Random.Range(0, indexes.Count);
    //        for (int i = 0; i < indexes.Count; i++)
    //        {
    //            if (i == purpleIndex)
    //            {

    //                objectsToChange[i].GetComponent<Renderer>().material = objectsToChange[i].PurpleMaterial;
    //            }
    //            else
    //            {

    //                objectsToChange[i].GetComponent<Renderer>().material = objectsToChange[i].BlueMaterial;
    //            }
    //        }
    //    }
    //}


}
