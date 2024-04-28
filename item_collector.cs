using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static AllControl;
//收集！！！
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
            GameManager .Instance .score = cherries;//这部分可以在游戏关卡刷新时不刷新收集的进度，但是缺一个死亡刷新的部分
        }

        if (collision.gameObject.CompareTag("Player"))
        {
         
            
            Destroy(gameObject);
        }
    }
}

