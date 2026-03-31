using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject box;

    void Update()
    {
        if (!GameObject.FindGameObjectWithTag("Box"))
        {
            Instantiate(box, spawnPos.position, Quaternion.identity);
        }
    }
}
