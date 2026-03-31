using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PhoneScript : MonoBehaviour
{
    [SerializeField] public GameObject pressE;
    private GameObject player;

    public bool isRinging = true;

    public int orderCounter;

    public int WaitTime;

    public Transform spawnPos;
    public GameObject box;

    public GameObject box1;
    public GameObject box2;
    public GameObject box3;

    public GameObject CallManager;
    public GameObject catCoWeb;
    public CatCoShop catCoShop;
    public GameObject website;
    public GameObject mark;

    public GameObject Words;

    AudioManager audioManager;


    [SerializeField] public Animator animator;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (Vector2.Distance(this.gameObject.transform.position, player.transform.position) < 2.5)
        {
            pressE.SetActive(true);
        }
        else
        {
            pressE.SetActive(false);
        }

        if (isRinging)
        {
            animator.SetBool("isRinging", true);
            mark.SetActive(true);
        }
        else
        {
            animator.SetBool("isRinging", false);
            mark.SetActive(false);
        }
        
        if (!GameObject.FindGameObjectWithTag("Box") && orderCounter < 4 && orderCounter > 0)
            {
                Instantiate(box, spawnPos.position, Quaternion.identity);
                orderCounter -= 1;
            }

        if (Keyboard.current[Key.E].wasPressedThisFrame && Vector2.Distance(this.gameObject.transform.position, player.transform.position) < 2.5)
        {
            CallManager.SetActive(true);
        }
        if (orderCounter == 0)
        {
            box1.SetActive(false);
            box2.SetActive(false);
            box3.SetActive(false);
        }

        if (orderCounter == 1)
        {
            box1.SetActive(true);
            box2.SetActive(false);
            box3.SetActive(false);
        }

        if (orderCounter == 2)
        {
            box1.SetActive(true);
            box2.SetActive(true);
            box3.SetActive(false);
        }

        if (orderCounter == 3)
        {
            box3.SetActive(true);
            box2.SetActive(true);
            box1.SetActive(true);
        }
    }

    public void Call()
    {
        if (isRinging && orderCounter < 3)
        {
        CallManager.SetActive(false);
        isRinging = false;
        orderCounter += 1;
        Debug.Log("Call Was Answered");
        StartCoroutine(StartTalking());


        if (!catCoShop.hasBoughtAd1 && !catCoShop.hasBoughtAd2 && !catCoShop.hasBoughtAd3)
        WaitTime = Random.Range(30, 60);
        else if (catCoShop.hasBoughtAd1 && !catCoShop.hasBoughtAd2 && catCoShop.hasBoughtAd3 || catCoShop.hasBoughtAd2 && !catCoShop.hasBoughtAd1 && catCoShop.hasBoughtAd3 || catCoShop.hasBoughtAd3 && !catCoShop.hasBoughtAd2 && catCoShop.hasBoughtAd1)
        WaitTime = Random.Range(15, 30);
        else if(catCoShop.hasBoughtAd1 && catCoShop.hasBoughtAd2 && !catCoShop.hasBoughtAd3|| catCoShop.hasBoughtAd2 && catCoShop.hasBoughtAd3 && !catCoShop.hasBoughtAd1 || catCoShop.hasBoughtAd1 && catCoShop.hasBoughtAd3 && !catCoShop.hasBoughtAd2)
        WaitTime = Random.Range(10, 20);
        else if(catCoShop.hasBoughtAd1 && catCoShop.hasBoughtAd2 && catCoShop.hasBoughtAd3)
        WaitTime = Random.Range(5, 10);


        if (orderCounter < 3)
        Invoke("TryCall", WaitTime);
        }
    }

    public void Manager(int on)
    {
        if (on == 1)
        CallManager.SetActive(true);
        if(on == 0)
        CallManager.SetActive(false);
    }

    public void catCo(int on)
    {
        if (on == 1)
        catCoWeb.SetActive(true);
        CallManager.SetActive(false);
        if(on == 0)
        catCoWeb.SetActive(false);
    }

    public void web(int on)
    {
        if (on == 1)
        website.SetActive(true);
        CallManager.SetActive(false);
        if(on == 0)
        website.SetActive(false);
    }

    void TryCall()
    {
        isRinging = true;
    }

     IEnumerator StartTalking()
    {
        Words.SetActive(true);
        audioManager.PlaySFX(audioManager.Words);
        yield return new WaitForSeconds(4);
        Words.SetActive(false);
    }
}