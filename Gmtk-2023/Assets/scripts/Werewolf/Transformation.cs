using UnityEngine;

public class transformation : MonoBehaviour
{

    public GameObject humanSprite;
    public GameObject WolfSprite;

    public bool isDayTime = false;

    public bool isWerewolf = false;
    SpriteRenderer spriteRenderer;

    public float time = 10;
    public float ResetTime = 10;

    private void Awake()
    {
        humanSprite.GetComponent<SpriteRenderer>();
        WolfSprite.GetComponent<SpriteRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
       

        if (time <= 0 && !isDayTime)
        {
            DuringDay();
            time = ResetTime;
        }
        else if (time <= 0 && isDayTime)
        {
            DuringNight();
            isWerewolf = true;
            time = ResetTime;
        }
        else
        {
            time -= Time.deltaTime;
        }

        if (isWerewolf)
        {
            WhenWerewolf();
            spriteRenderer.sprite = WolfSprite.GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            WhenHuman();
        }
    }

    void DuringDay()
    {
        isDayTime = true;
        isWerewolf = false;

    }
    void DuringNight()
    {
        isDayTime = false;
        isWerewolf = true;
    }
    void WhenHuman()
    {
        spriteRenderer.sprite = humanSprite.GetComponent<SpriteRenderer>().sprite;
    }
    void WhenWerewolf()
    {
        spriteRenderer.sprite = WolfSprite.GetComponent<SpriteRenderer>().sprite;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Clowd"))
        {
            isWerewolf = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Clowd"))
        {
            if (isDayTime)
            {
                isWerewolf = false;
            }
            else
            {
                isWerewolf = true;
            }
        }
    }
}
