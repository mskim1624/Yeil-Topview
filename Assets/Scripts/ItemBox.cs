using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public Sprite openBoxImg;
    public Sprite closeBoxImg;
    public GameObject itemPrefab;
    public bool isClosed = true;

    public GameObject[] itemPrefabs;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && isClosed)
        {
            GetComponent<SpriteRenderer>().sprite = openBoxImg;
            isClosed = false;

            int iRand = Random.Range(0, itemPrefabs.Length - 1);
            if (itemPrefabs[iRand] != null)
            {
                Instantiate(itemPrefabs[iRand], transform.position, Quaternion.identity);
            }
            else
            {
                Invoke("CloseBox", 1.0f);
            }
        }
    }

    void CloseBox()
    {
        isClosed = true;
        GetComponent<SpriteRenderer>().sprite = closeBoxImg;
    }
}
