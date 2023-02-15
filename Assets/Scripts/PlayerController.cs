using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static int hp = 3;
    // 이동 속도
    public float speed = 3.0f;
    // 애니메이션 이름 ( 만든것 )
    public string upAni = "PlayerUp";
    public string downAni = "PlayerDown";
    public string leftAni = "PlayerLeft";
    public string rightAni = "PlayerRight";
    public string deadAni = "PlayerDead";
    // 애니메이션 상태
    string nowAnimation = "";
    string oldAnimation = "";

    // 이동 키 관련
    float axisH; // (x= -1, 0, 1)
    float axisV; // (y= -1, 0, 1)
    public float angleZ = -90.0f;

    Rigidbody2D rBody;
    bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        nowAnimation = downAni;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving == false)
        {
            axisH = Input.GetAxisRaw("Horizontal");
            axisV = Input.GetAxisRaw("Vertical");
        }

        Vector2 fromPt = this.transform.position;
        Vector2 toPt = new Vector2(fromPt.x + axisH, fromPt.y + axisV);
        Debug.Log("X : " + toPt.x + " Y : " + toPt.y);

        angleZ = GetAngle(fromPt, toPt);

        if (angleZ >= -45 && angleZ < 45)
        {
            nowAnimation = rightAni;
        }
        else if (angleZ >= 45 && angleZ <= 135)
        {
            nowAnimation = upAni;
        }
        else if (angleZ >= -135 && angleZ <= -45)
        {
            nowAnimation = downAni;
        }
        else
        {
            nowAnimation = leftAni;
        }
        
        if (nowAnimation != oldAnimation)
        {
            oldAnimation = nowAnimation;
            GetComponent<Animator>().Play(nowAnimation);
        }

        //rBody.velocity = new Vector2(axisH, axisV) * speed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        rBody.velocity = new Vector2(axisH, axisV) * speed;
    }

    float GetAngle(Vector2 p1, Vector2 p2)
    {
        float angle = angleZ;

        if (axisH != 0 || axisV != 0)
        {
            float dx = p2.x - p1.x;
            float dy = p2.y - p1.y;

            float rad = Mathf.Atan2(dy, dx);
            angle = rad * Mathf.Rad2Deg;
        }

        return angle;
    }
}
