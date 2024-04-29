using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    // public hitBox healthBar;
    public int number;
    public Image[] hearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;
    public HitboxScript health;


    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            if (i < health.health)
            {
                hearts[i].sprite = FullHeart;
            }
            else
            {
                hearts[i].sprite = EmptyHeart;
            }

            if (i < number)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
