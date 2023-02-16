using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [HideInInspector]
    public int hp = 1;
    public float speed = 0.5f;
    [HideInInspector]
    public float reactionDistance = 4.0f;

    public string idleAnime = "EnemyIdle";
    public string upAnime = "EnemyUp";
    public string downAnime = "EnemyDown";
    public string leftAnime = "EnemyLeft";
    public string rightAnime = "EnemyRight";
    public string deadAnime = "EnemyDead";

    string nowAnimation = "";
    string oldAnimation = "";

    [SerializeField]
    float axisH;
    float axisV;
    Rigidbody2D rbody;

    [SerializeField]
    bool isActive = false;


    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            isActive = false;
            rbody.velocity = Vector2.zero;
            return;
        }

        float dist = Vector2.Distance(transform.position, player.transform.position);
        if (dist < reactionDistance)
        {
            isActive = true;
        }
        else
        {
            isActive = false;
        }

        if (isActive)
        {
            float dx = player.transform.position.x - transform.position.x;
            float dy = player.transform.position.y - transform.position.y;
            
            float rad = Mathf.Atan2(dy, dx);
            float angle = rad * Mathf.Rad2Deg;

            Debug.Log("DX : " + dx + " DY : " + dy + " RAD : " + rad + " ANGLE : " + angle);

            if (angle > -45.0f && angle <= 45.0f)
            {
                nowAnimation = rightAnime;
            }
            else if (angle > 45.0f && angle <= 135.0f)
            {
                nowAnimation = upAnime;
            }
            else if (angle >= -135.0f && angle <= -45.0f)
            {
                nowAnimation = downAnime;
            }
            else
            {
                nowAnimation = leftAnime;
            }

            axisH = Mathf.Cos(rad) * speed;
            axisV = Mathf.Sin(rad) * speed;

        }
    }

    private void FixedUpdate()
    {
        if (isActive && hp > 0)
        {
            rbody.velocity = new Vector2(axisH, axisV);
            if (nowAnimation != oldAnimation)
            {
                oldAnimation = nowAnimation;
                Animator animator = GetComponent<Animator>();
                animator.Play(nowAnimation);
            }
        }
        else
        {
            rbody.velocity = Vector2.zero;
            nowAnimation = idleAnime;
            oldAnimation = nowAnimation;
            Animator animator = GetComponent<Animator>();
            animator.Play(nowAnimation);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            hp--;
            if (hp <= 0)
            {
                GetComponent<CircleCollider2D>().enabled = false;
                rbody.velocity = Vector2.zero;
                Animator animator = GetComponent<Animator>();
                animator.Play(deadAnime);

                Destroy(this.gameObject, 0.5f);
            }
        }
    }
}
