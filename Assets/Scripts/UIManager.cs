using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image life;
    public Text txtArrow;
    public Text txtKey;

    public Sprite life_0;
    public Sprite life_1;
    public Sprite life_2;
    public Sprite life_3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txtKey.text = ItemKeeper.hasKeys.ToString();
        txtArrow.text = ItemKeeper.hasArrows.ToString();

        if (PlayerController.hp == 1)
        {
            life.sprite = life_1;
        }
        else if (PlayerController.hp == 2)
        {
            life.sprite = life_2;
        }
        else if (PlayerController.hp == 3)
        {
            life.sprite = life_3;
        }
        else
        {
            life.sprite = life_0;
        }
            
        
    }
}
