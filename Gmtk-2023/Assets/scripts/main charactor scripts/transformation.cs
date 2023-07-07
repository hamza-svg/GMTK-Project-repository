using UnityEngine;

public class transformation : MonoBehaviour
{

    public GameObject humanSprite;
    public GameObject WolfSprite;

    public bool isdayTime = true;

    public bool isWarewolf = false;
    SpriteRenderer spriteRenderer;

    public float time = 10;
    public float ReSetTime = 10;

    private void Awake()
    {
        humanSprite.GetComponent<SpriteRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
       

        if (time <= 0 && !isdayTime)
        {
            DuringDay();
            time = ReSetTime;
        }
        else if (time <= 0 && isdayTime)
        {
            DuringNight();
            time = ReSetTime;
        }
        else
        {
            time -= Time.deltaTime;
        }

        if (isWarewolf)
        {
            WhenWarewolf();
        }
        else
        {
            WhenHuman();
        }
    }

    void DuringDay()
    {
        isdayTime = true;
        isWarewolf = false;

    }
    void DuringNight()
    {
        isdayTime = false;
        isWarewolf = true;
    }
    void WhenHuman()
    {
        spriteRenderer.sprite = humanSprite.GetComponent<SpriteRenderer>().sprite;
    }
    void WhenWarewolf()
    {
        spriteRenderer.sprite = WolfSprite.GetComponent<SpriteRenderer>().sprite;
    }
}