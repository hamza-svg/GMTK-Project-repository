using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformation : MonoBehaviour
{
    [Header("transformation")]
    public bool isWerewolf = false;
    public GameObject werewolf;
    public GameObject human;

    [Header("Duration of day and night")]
    public bool isDayTime;
    public float time;
    public float resetTime;
    
    void Start()
    {
        // Create werewolf form
        Instantiate(human, transform);

        //change move speed
        gameObject.GetComponent<PlayerMovement>().moveSpeed = 5;
        human.GetComponent<PlayerMovement>().moveSpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        // if it is night time
        if (time <= 0 && isDayTime)
        {
            isDayTime = false;
            time = resetTime;
            transformationCheck();
        } // if it is daytime
        else if (time <= 0 && !isDayTime)
        {
            isDayTime = true;
            time = resetTime;
            transformationCheck();
        } // always
        else
        {
            time -= Time.deltaTime;
        }
        DayAndNightCheck();
    }
    void transformationCheck()
    {
        // if you are werewolf
        if (isWerewolf)
        {
            //Destroy Human Form
            Destroy(transform.GetChild(1).gameObject);

            // Create werewolf form
            Instantiate(werewolf, transform);

            //change move speed
            gameObject.GetComponent<PlayerMovement>().moveSpeed = 10;
            werewolf.GetComponent<PlayerMovement>().moveSpeed = 10;
        } // if you are human
        
        if (!isWerewolf)
        {
            //Destroy werewolf form
            Destroy(transform.GetChild(1).gameObject);

            //Create Human Form
            Instantiate(human, transform);

            //change move speed
            gameObject.GetComponent<PlayerMovement>().moveSpeed = 5;
            human.GetComponent<PlayerMovement>().moveSpeed = 5;
        }
    }
    void DayAndNightCheck()
    {
        if (isDayTime) { isWerewolf = false; }
        else { isWerewolf = true; }
    }
}
