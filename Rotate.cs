using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
  

   
    void Update()
    {
        transform .Rotate (0,0,360*speed *Time .deltaTime);
    }
}
//用动画也可以，但是齿轮自转用Rotate会更方便还省了预制件的制作嘻嘻
