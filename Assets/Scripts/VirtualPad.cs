using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualPad : MonoBehaviour
{
    public float MaxLength = 70.0f;
    public bool is4DPad = false;
    GameObject player;
    Vector2 defPos;
    Vector2 downPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        defPos = GetComponent<RectTransform>().localPosition;
    }

    public void Attack()
    {
        ArrowShoot shoot = player.GetComponent<ArrowShoot>();
        shoot.Attack();
    }

    public void PadDown()
    {
        downPos = Input.mousePosition;
    }

    public void PadUp()
    {
        GetComponent<RectTransform>().localPosition = defPos;
        PlayerController playerCont = player.GetComponent<PlayerController>();
        playerCont.SetAxis(0, 0);
    }

    public void PadDrag()
    {
        Vector2 mousePosition = Input.mousePosition;

        Vector2 newTabPos = mousePosition - downPos;
        Vector2 axis = newTabPos.normalized;

        float len = Vector2.Distance(defPos, newTabPos);
        if (len > MaxLength)
        {
            newTabPos.x = axis.x * MaxLength;
            newTabPos.y = axis.y * MaxLength;
        }

        GetComponent<RectTransform>().localPosition = newTabPos;

        PlayerController playerController = player.GetComponent<PlayerController>();
        playerController.SetAxis(axis.x, axis.y);
    }
}
