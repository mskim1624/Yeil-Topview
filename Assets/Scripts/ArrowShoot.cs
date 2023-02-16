using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShoot : MonoBehaviour
{
    public float shootSpeed = 12.0f; // 화살 속도
    public float shootDelay = 0.25f; // 발사 간격
    public GameObject bowPrefab;
    public GameObject arrowPrefab;

    GameObject bowObj;
    bool inAttack = false;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = transform.position;
        bowObj = Instantiate(bowPrefab, pos, Quaternion.identity);
        bowObj.transform.SetParent(transform);
    }

    // Update is called once per frame
    void Update()
    {
        float bowZ = -1.0f;
        PlayerController player = GetComponent<PlayerController>();
        if (player.angleZ > 30 && player.angleZ < 150)
        {
            // 캐릭터 위로 방향인데 
            bowZ = 1;
        }

        // 활의 회전
        bowObj.transform.rotation = Quaternion.Euler(0, 0, player.angleZ);
        bowObj.transform.position = new Vector3(transform.position.x, transform.position.y, bowZ);

        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    public void Attack()
    {
        if (ItemKeeper.hasArrows > 0 && inAttack == false)
        {
            ItemKeeper.hasArrows -= 1;
            inAttack = true;

            SoundManager.soundManager.SEPlay(SEType.Shoot);

            PlayerController player = GetComponent<PlayerController>();
            float angleZ = player.angleZ;

            Quaternion r = Quaternion.Euler(0, 0, angleZ);
            GameObject arraowObj = Instantiate(arrowPrefab, transform.position, r);

            float x = Mathf.Cos(angleZ * Mathf.Deg2Rad);
            float y = Mathf.Sin(angleZ * Mathf.Deg2Rad);

            Vector3 vFly = new Vector3(x, y, 0) * shootSpeed;

            Rigidbody2D rbody = arraowObj.GetComponent<Rigidbody2D>();
            rbody.AddForce(vFly, ForceMode2D.Impulse);

            Invoke("StopAttack", shootDelay);
        }
    }

    public void StopAttack()
    {
        inAttack = false;
    }
}
