using UnityEngine;
using TMPro;

public class Minigame_3 : MonoBehaviour
{
    public bool StartedMinigame;
    public GameObject minigame3;
    public GameObject[] tapes;

    public int tapeBox;

    public TextMeshProUGUI countDownTxt;
    public float remaingTime;

    public bool inTape;

    public bool doneBox1;
    public bool doneBox2;

    public bool waitedToLong;

    public bool bad1;
    public bool bad2;

    public Sprite boxSprite;

    public bool Cheese;

    public MinigameManager minigameManager;

    private GameObject box;
    private SpriteRenderer SpriteRenderer;
    private Boxs boxs;

    void Update()
    {
        if (StartedMinigame)
        {
            minigame3.SetActive(true);

            if(!inTape && !doneBox2)
            {
                tapeBox = Random.Range(0, tapes.Length);
                tapes[tapeBox].SetActive(true);
                remaingTime = 3f;
                inTape = true;
            }

            if (inTape && remaingTime > 0)
            {
                remaingTime -= Time.deltaTime;
                int seconds = Mathf.FloorToInt(remaingTime % 60);
                countDownTxt.text = seconds.ToString();
            }
            else if (remaingTime < 0)
            {
                waitedToLong = true;
                remaingTime = 3f;
            }

            if (doneBox2)
            {
                if (!bad1 && !bad2)
                {
                    minigameManager.AddStars(1f);
                }
                else if (bad1 && !bad2)
                {
                    minigameManager.AddStars(0.5f);
                }
                else if (bad1 && bad2)
                {
                    minigameManager.NoStars();
                }
                remaingTime = 3f;
                box = GameObject.FindWithTag("Box");
                SpriteRenderer = box.GetComponent<SpriteRenderer>();
                boxs = box.GetComponent<Boxs>();
                SpriteRenderer.sprite = boxSprite;
                minigame3.SetActive(false);
                doneBox1 = false;
                doneBox2 = false;
                inTape = false;
                bad1 = false;
                bad2 = false;
                Cheese = true;
                StartedMinigame = false;
            }

            if (StartedMinigame == false)
            {
                if (boxs.atNum4)
                {
                    Cheese = false;
                }
                else
                {
                    boxs.num4 = true;
                }
            }
        }
    }
}
