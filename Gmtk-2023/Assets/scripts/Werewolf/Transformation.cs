using UnityEngine;

public class Transformation : MonoBehaviour
{

    public GameObject humanSprite;
    public GameObject WolfSprite;

    public bool isDayTime = false;

    public bool isWerewolf = false;
    SpriteRenderer spriteRenderer;

    public float time = 10;
    public float ResetTime = 10;

    void Start()
    {
        Instantiate(WolfSprite, transform);
    }

    void Update()
    {
       

        if (time <= 0 && !isDayTime)
        {
            DuringDay();
            isWerewolf = false;
            time = ResetTime;
            Check();
        }
        else if (time <= 0 && isDayTime)
        {
            DuringNight();
            isWerewolf = true;
            time = ResetTime;
            Check();
        }
        else
        {
            time -= Time.deltaTime;
        }
    }

    void Check()
    {
        if (isWerewolf)
        {
            Object.Destroy(transform.GetChild(0).gameObject);
            Instantiate(WolfSprite, transform);
        } else {
            Object.Destroy(transform.GetChild(0).gameObject);
            Instantiate(humanSprite, transform);
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cloud"))
        {
            isWerewolf = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Cloud"))
        {
            if (isDayTime)
            {
                isWerewolf = false;
            }
            else
            {
                isWerewolf = true;
            }
            Check();
        }
    }
}
