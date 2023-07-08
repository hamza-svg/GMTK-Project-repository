using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformation : MonoBehaviour
{
    [Header("transformation")]
    public bool isWareWolf = false;
    public GameObject warewolf;
    public GameObject human;

    [Header("Duration of day and night")]
    public bool isDayTime;
    public float time;
    public float resetTime;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (time <= 0 && isDayTime)
        {
            isDayTime = false;
            time = resetTime;
        }
        else if (time <= 0 && !isDayTime)
        {
            isDayTime=true;
            time = resetTime;
        }
        else
        {
            time -= Time.deltaTime;
        }
        tranformationCheck();
        DayAndNightCheck();
    }
    void tranformationCheck()
    {
        if (isWareWolf)
        {
            warewolf.SetActive(true);
            human.SetActive(false);
        }
        else
        {
            warewolf.SetActive(false);
            human.SetActive(true);
        }
    }
    void DayAndNightCheck()
    {
        if (isDayTime)
        {
            isWareWolf = false;
        }
        else { isWareWolf = true; }
    }
}
