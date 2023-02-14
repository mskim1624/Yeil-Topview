using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{

    public float deleteTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, deleteTime);    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.SetParent(collision.transform);

        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
    }
}
