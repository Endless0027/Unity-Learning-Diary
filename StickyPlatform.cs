using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision .gameObject .transform .SetParent (transform);
        }
    }
//获取好Player的Transform就可以跟着移动平台一起移动不会定住不动啦

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ( collision.gameObject.name =="Player")
        {
            collision .gameObject .transform .SetParent (null);
        }
    }
}
