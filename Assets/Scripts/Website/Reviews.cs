using UnityEngine;
using TMPro;

public class Reviews : MonoBehaviour
{
    public string[] badReviews;
    public string[] midReviews;
    public string[] goodReviews;
    public string[] names;
    public TextMeshProUGUI[] Name;

    public TextMeshProUGUI[] ReviewTxt;
    public GameObject[] Review;


    public void BadReview()
    {
        int Ran;
        Ran = Random.Range(1, Review.Length);
        
        Review[Ran].SetActive(true);
        ReviewTxt[Ran].text = badReviews[Ran];
        Name[Ran].text = names[Ran];
    }

    public void MidReview()
    {
        int Ran;
        Ran = Random.Range(1, Review.Length);
        
        Review[Ran].SetActive(true);
        ReviewTxt[Ran].text = midReviews[Ran];
        Name[Ran].text = names[Ran];
    }

    public void GoodReview()
    {
        int Ran;
        Ran = Random.Range(1, Review.Length);
        
        Review[Ran].SetActive(true);
        ReviewTxt[Ran].text = goodReviews[Ran];
        Name[Ran].text = names[Ran];
    }
}
