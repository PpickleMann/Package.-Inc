using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Minigame_2 : MonoBehaviour
{
    public bool StartedMinigame;
    public bool doneMinigame;
    public GameObject minigame2;
    public GameObject boxForGame;
    public Rigidbody2D rb;
    public GameObject scooper;
    public GameObject particalSystem;
    public MinigameManager minigameManager;
    public float fillAmount;
    public float amountToFill;
    public float Range;
    public float popcornHight;
    public GameObject popcorn;

    private GameObject box;
    private Boxs boxs;

    public bool cheese;

    public TextMeshProUGUI fillToText;
    public TextMeshProUGUI filledToText;

    AudioManager audioManager;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    void LateUpdate()
    {
        if (StartedMinigame)
        {
            filledToText.text = "Box Filled To:" + fillAmount.ToString("0.00") + "%";
            minigame2.SetActive(true);
            minigameManager.inMinigame = true;
            if (Mouse.current.leftButton.isPressed || Keyboard.current.spaceKey.isPressed)
            {
                //Invoke("FillBox", 1f);
                FillBox();
                if (scooper.transform.rotation.z == 0)
                scooper.transform.Rotate(0f, 0f, 60f);
                particalSystem.SetActive(true);
                Range = fillAmount - amountToFill;
            }
            else if (!Mouse.current.leftButton.isPressed)
            {
                if (scooper.transform.rotation.z != 0)
                scooper.transform.Rotate(0f, 0f, -60f);
                particalSystem.SetActive(false);
            }
        }
    }

    public void FillBox()
    {
        fillAmount += (0.04f);
        popcornHight += 0.04f;
        if (fillAmount > 100f)
        {
            fillAmount = 100f;
        }
        filledToText.text = "Box Filled To:" + fillAmount.ToString("0.00") + "%";
        if (popcornHight >= 2f && popcornHight <= 100f && fillAmount < 100f)
        {
            popcorn.transform.position = new Vector3(popcorn.transform.position.x, popcorn.transform.position.y + 0.05f, popcorn.transform.position.z);
            popcornHight = 0f;
        }
    }

    public void Submit()
    {
        box = GameObject.FindWithTag("Box");
        boxs = box.GetComponent<Boxs>();

        if (Range < 5f && Range > -5f && Range > 3f || Range < -3f && Range < 5f && Range > -5f)
        {
            StartedMinigame = false;
            minigame2.SetActive(false);
            minigameManager.inMinigame = false;
            minigameManager.AddStars(0.5f);
            if (!minigameManager.hasMac2)
            {
                audioManager.PlaySFX(audioManager.GoodNoise);
            }
            popcornHight = 0f;
            fillAmount = 0f;
            popcorn.transform.position = new Vector3(popcorn.transform.position.x, -4.5f, popcorn.transform.position.z);
            boxs.num3 = true;
        }

        if (Range > 10f || Range < -10f)
        {
            StartedMinigame = false;
            minigame2.SetActive(false);
            minigameManager.inMinigame = false;
            minigameManager.NoStars();
            if (!minigameManager.hasMac2)
            {
                audioManager.PlaySFX(audioManager.BadNoise);
            }
            popcornHight = 0f;
            fillAmount = 0f;
            popcorn.transform.position = new Vector3(popcorn.transform.position.x, -4.5f, popcorn.transform.position.z);
            boxs.num3 = true;
        }

        if (Range < 5f && Range > -5f)
        {
            StartedMinigame = false;
            minigame2.SetActive(false);
            minigameManager.inMinigame = false;
            minigameManager.AddStars(1f);
            if (!minigameManager.hasMac2)
            {
                audioManager.PlaySFX(audioManager.GoodNoise);
            }
            popcornHight = 0f;
            fillAmount = 0f;
            popcorn.transform.position = new Vector3(popcorn.transform.position.x, -4.5f, popcorn.transform.position.z);
            boxs.num3 = true;
        }
    }
}
