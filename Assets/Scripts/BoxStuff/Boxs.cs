using UnityEngine;
using UnityEngine.InputSystem;

public class Boxs : MonoBehaviour
{
    public Vector3 point1;
    public Vector3 point2;
    public Vector3 point3;
    public Vector3 point4;
    public Vector3 point5;

    public bool num1 = true;
    public bool num2;
    public bool num3;
    public bool num4;
    public bool num5;

    public bool atNum1;
    public bool atNum2;
    public bool atNum3;
    public bool atNum4;
    public bool atNum5;

    public int miniGame;

    private bool atPos;

    private GameObject player;

    private Minigame_1 minigame1;
    private Minigame_2 minigame2;
    private Minigame_3 minigame3;
    private MinigameManager minigameManager;
    public Money money;
    public EndingScripts endingScript;
    public Reviews reviews;
    
    [SerializeField] public GameObject pressE;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        minigame1 = GameObject.Find("MinigameManager").GetComponent<Minigame_1>();
        minigame2 = GameObject.Find("MinigameManager").GetComponent<Minigame_2>();
        minigame3 = GameObject.Find("MinigameManager").GetComponent<Minigame_3>();
        minigameManager = GameObject.Find("MinigameManager").GetComponent<MinigameManager>();
        money = GameObject.Find("Money").GetComponent<Money>();
        endingScript = GameObject.Find("EndingManager").GetComponent<EndingScripts>();
        reviews = GameObject.Find("Canvas").GetComponent<Reviews>();
    }

    void LateUpdate()
    {

        if (miniGame == 0 && minigameManager.hasMac1)
        {
            int cheese = Random.Range(0, 1);
            float pickle;
            if (cheese > 0)
            {
               pickle = 1f;
            }
            else pickle = .5f;

            num1 = true;
            num2 = true;
            minigame1.doneMinigame = false;
            minigameManager.AddStars(pickle);
            miniGame = 1;
        }

        if (miniGame == 1 && minigameManager.hasMac2)
        {
            int cheese = Random.Range(0, 1);
            float pickle;
            if (cheese > 0)
            {
               pickle = 1f;
            }
            else pickle = .5f;
            
            num3 = true;
            minigame1.doneMinigame = false;
            minigameManager.AddStars(pickle);
            miniGame = 2;
        }

        if (miniGame == 2 && minigameManager.hasMac3)
        {
            int cheese = Random.Range(0, 1);
            float pickle;
            if (cheese > 0)
            {
               pickle = 1f;
            }
            else pickle = .5f;

            num4 = true;
            minigame1.doneMinigame = false;
            minigameManager.AddStars(pickle);
            miniGame = 3;
        }

        if (miniGame == 3 && minigameManager.hasMac4)
        {
            int cheese = Random.Range(0, 1);
            float pickle;
            if (cheese > 0)
            {
               pickle = 1f;
            }
            else pickle = .5f;

            minigame1.doneMinigame = false;
            minigameManager.AddStars(pickle);
            miniGame = 0;
            if (minigameManager.Stars == 0.5f)
            {
                money.money += 3;
                minigameManager.ResetStars();
            }
            else if (minigameManager.Stars == 1f)
            {
                money.money += 5;
                minigameManager.ResetStars();
            }
            else if (minigameManager.Stars == 1.5f)
            {
                money.money += 7;
                minigameManager.ResetStars();
            }
            else if (minigameManager.Stars == 2f)
            {
                money.money += 10;
                minigameManager.ResetStars();
            }
            else if (minigameManager.Stars == 2.5f)
            {
                money.money += 12;
                minigameManager.ResetStars();
            }
            else if (minigameManager.Stars == 3f)
            {
                money.money += 15;
                minigameManager.ResetStars();
            }

            Destroy(this.gameObject);
            endingScript.boxsDone += 1;
            endingScript.BeatGameMaybe();
        }

        if (Keyboard.current[Key.E].wasPressedThisFrame && Vector2.Distance(this.gameObject.transform.position, player.transform.position) < 4 && atPos && !minigameManager.inMinigame)
        {
            miniGame += 1;
            if (miniGame == 1)
            {
                minigame1.StartedMinigame = true;
                if (!atNum2 && minigame1.doneMinigame)
                {
                    num1 = true;
                    num2 = true;
                    minigame1.doneMinigame = false;
                }
            }

            if (miniGame == 2)
            {
                Debug.Log("Start Minigame 2");
                minigame2.StartedMinigame = true;
                minigame2.amountToFill = Random.Range(1f, 100f);
                minigame2.fillToText.text = "Box Filled To:" + minigame2.amountToFill.ToString("0.00") + "%";
                minigame2.cheese = true;
                //minigame2.popcorn.transform.position = new Vector3(minigame2.popcorn.transform.position.x, -2.5f, minigame2.popcorn.transform.position.z);
                minigame2.cheese = false;

            }

            if (miniGame == 3)
            {
                Debug.Log("Start Minigame 3");
                minigame2.StartedMinigame = false;
                minigame3.StartedMinigame = true;
            }

            if (miniGame == 4)
            {
                miniGame = 0;
            if (minigameManager.Stars == 0.5f)
            {
                money.money += 3;
                minigameManager.ResetStars();
                reviews.BadReview();
            }
            else if (minigameManager.Stars <= 1f)
            {
                money.money += 5;
                minigameManager.ResetStars();
                reviews.BadReview();
            }
            else if (minigameManager.Stars == 1.5f)
            {
                money.money += 7;
                minigameManager.ResetStars();
                reviews.MidReview();
            }
            else if (minigameManager.Stars == 2f)
            {
                money.money += 10;
                minigameManager.ResetStars();
                reviews.MidReview();
            }
            else if (minigameManager.Stars == 2.5f)
            {
                money.money += 12;
                minigameManager.ResetStars();
                reviews.GoodReview();
            }
            else if (minigameManager.Stars == 3f)
            {
                money.money += 15;
                minigameManager.ResetStars();
                reviews.GoodReview();
            }

            Destroy(this.gameObject);
            endingScript.boxsDone += 1;
            endingScript.BeatGameMaybe();
            }

            if (miniGame == 5)
            {
                
            }
        }


        if (num1 && !num2)
        {
        transform.position = Vector3.MoveTowards(transform.position, point1, 2 * Time.deltaTime);
        }
        else if (num2 && !num3)
        {
        transform.position = Vector3.MoveTowards(transform.position, point2, 2 * Time.deltaTime);
        }
        else if (num3 && !num4)
        {
        transform.position = Vector3.MoveTowards(transform.position, point3, 2 * Time.deltaTime);
        }
        else if (num4 && !num5)
        {
        transform.position = Vector3.MoveTowards(transform.position, point4, 2 * Time.deltaTime);
        }
        else if (num5)
        {
        transform.position = Vector3.MoveTowards(transform.position, point5, 2 * Time.deltaTime);
        }

        if (this.transform.position == point1)
        {
            atNum1 = true;
        }
        else 
        atNum1 = false;
        
        if (this.transform.position == point2)
        {
            atNum2 = true;
            atNum1 = false;
        }
        else
        atNum2 = false;
        
        if (this.transform.position == point3)
        {
            atNum3 = true;
            atNum2 = false;
        }
        else
        atNum3 = false;
        
        if (this.transform.position == point4)
        {
            atNum4 = true;
            atNum3 = false;
        }
        else
        atNum4 = false;
        
        if (this.transform.position == point5)
        {
            atNum5 = true;
            atNum4 = false;
        }
        else
        atNum5 = false;
        
        

        if (Vector2.Distance(this.gameObject.transform.position, player.transform.position) < 4 )
        {
            if (atNum1 || atNum2 || atNum3 || atNum4 || atNum5)
            {
            pressE.SetActive(true);
            atPos = true;
            }
            else
            {
                pressE.SetActive(false);
                atPos = false;
            }
        }
        else
        {
            pressE.SetActive(false);
        }
    }
}