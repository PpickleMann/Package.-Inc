using UnityEngine;

public class ItemScriptGame1 : MonoBehaviour
{
    public Sprite[] sprites;
    public SpriteRenderer spriteRenderer;
    public bool hasDied;

    void Start()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, 5)];
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MiniGameBox"))
        {
            spriteRenderer.sprite = sprites[Random.Range(0, 5)];
            this.gameObject.SetActive(false);
            hasDied = true;
        }
    }
}
