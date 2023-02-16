using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    arrow,
    key,
    life,
}

public class ItemData : MonoBehaviour
{
    public ItemType type;
    public int count = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (type == ItemType.key)
            {
                ItemKeeper.hasKeys += count;
            }
            else if (type == ItemType.arrow)
            {
                ItemKeeper.hasArrows += count;
            }
            else if (type == ItemType.life)
            {
                if ( PlayerController.hp < 3 )
                {
                    PlayerController.hp++;
                    PlayerPrefs.SetInt("PlayerHP", PlayerController.hp);
                }
            }

            ItemKeeper.SaveItem();

            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            Rigidbody2D rbody = GetComponent<Rigidbody2D>();

            rbody.gravityScale = 2.5f;
            rbody.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);

            Destroy(this.gameObject, 0.5f);
        }
    }


}
