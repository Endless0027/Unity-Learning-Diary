using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static AllControl;

public class item_collector : MonoBehaviour
{   
    int cherries=GameManager .Instance .score;
    [SerializeField] private Text cherriesText;
    [SerializeField]private AudioSource collectSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            cherries++;
            cherriesText.text = "Stawberries: " + cherries;
            GameManager .Instance .score = cherries;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            // 销毁与玩家碰撞的物体
            Destroy(gameObject);
        }
    }
}

