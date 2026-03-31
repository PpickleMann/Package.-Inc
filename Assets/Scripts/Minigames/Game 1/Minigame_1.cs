using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class Minigame_1 : MonoBehaviour
{
    public bool StartedMinigame;
    public bool doneMinigame;
    public GameObject minigame1;
    public GameObject item;
    public GameObject Box;
    private GameObject box;
    private Boxs boxs;

    public int itemSpeed = 5;

    public GameObject point1;
    public GameObject point2;

    private Vector3 nextPos;

    private bool hasClicked;

    public int deaths;

    public MinigameManager minigameManager;
    public ItemScriptGame1 itemScriptGame1;

    public Minigame_2 minigame_2;

    AudioManager audioManager;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void FixedUpdate()
    {
        //moving Object up and down
        if (minigameManager.inMinigame && !minigame_2.StartedMinigame)
        {
            if (!hasClicked)
            {
            item.transform.position = Vector3.MoveTowards(item.transform.position, nextPos, itemSpeed * Time.deltaTime);

            if (item.transform.position == nextPos)
            {
                nextPos = (nextPos == point1.transform.position) ? point2.transform.position : point1.transform.position;
            }
            }

            if (Keyboard.current.spaceKey.isPressed || Mouse.current.leftButton.isPressed)
            {
                hasClicked = true;
            }
        }

        //Setting Up Minigame
        if (StartedMinigame)
        {

            hasClicked = false;
            minigameManager.inMinigame = true;
            minigame1.SetActive(true);
            itemScriptGame1.gameObject.transform.position = point1.transform.position;
            itemScriptGame1.gameObject.SetActive(true);
            Box.transform.position = new Vector3(Box.transform.position.x, Random.Range(-3f, 3f), Box.transform.position.y);
            nextPos = point2.transform.position;
            StartedMinigame = false;
        }
        if (hasClicked)
        {
            item.transform.Translate(Vector3.right * itemSpeed * Time.deltaTime);
        }

        if (itemScriptGame1.hasDied)
        {
            box = GameObject.FindWithTag("Box");
            boxs = box.GetComponent<Boxs>();
            StartedMinigame = false;
            hasClicked = false;
            minigame1.SetActive(false);
            itemScriptGame1.gameObject.SetActive(false);
            doneMinigame = true;
            boxs.num2 = true;
            minigameManager.inMinigame = false;
            if (deaths == 1)
            {
                deaths = 0;
                if (!minigameManager.hasMac1)
                {
                    audioManager.PlaySFX(audioManager.GoodNoise);
                }
                minigameManager.AddStars(0.5f);
            }
            else if (deaths >= 2)
            {
                deaths = 0;
                if (!minigameManager.hasMac1)
                {
                    audioManager.PlaySFX(audioManager.BadNoise);
                }
            }
            else if (deaths == 0)
            {
                minigameManager.AddStars(1f);
                if (!minigameManager.hasMac1)
                {
                    audioManager.PlaySFX(audioManager.GoodNoise);
                }
            }

            if (boxs.atNum2)
            {
                doneMinigame = false;
            }
            itemScriptGame1.hasDied = false;
            Debug.Log("You Won!");
        }

        if (hasClicked && item.transform.position.x > Box.transform.position.x)
        {
            box = GameObject.FindWithTag("Box");
            boxs = box.GetComponent<Boxs>();
            StartedMinigame = false;
            minigame1.SetActive(false);
            itemScriptGame1.gameObject.SetActive(false);
            doneMinigame = false;
            minigameManager.inMinigame = false;
            itemScriptGame1.hasDied = false;
            deaths += 1;
            boxs.miniGame = 0;
            Debug.Log("You Died!");
            hasClicked = false;
        }

        if (boxs == null)
        {
            doneMinigame = false;
        }
    }
}
