using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChanger : MonoBehaviour
{
    public bool isDayTime = true;

    SpriteRenderer rend;

    [Range(0f, 1f)]
    public float fadeToBlackAmount = 0f;

    public float fadingSpeed = 0.05f;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();

        Color c = rend.material.color;

        c.g = 1f;
        c.b = 1f;

        rend.material.color = c;

        Camera cam = GetComponent<Camera>();
        GameObject thePlayer = GameObject.Find("Werewolf");
        Transformation playerScript = thePlayer.GetComponent<Transformation>();
        isDayTime = playerScript.isDayTime;
    }

    IEnumerator FadeToBlack()
    {
        for (float i = 1f; i >= fadeToBlackAmount; i -= 0.05f)
        {
            Color c = rend.material.color;
        }

        yield return new WaitForSeconds(fadingSpeed);
    }

    public void StartFadeToBlack()
    {
        StartCoroutine("FadeToBlack");
    }

    void Update()
    {
        if (!isDayTime)
        {
            StartFadeToBlack();
        }
    }
}
