using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//这里创建一个可以重置收集进度的方法
public class AllControl : MonoBehaviour
{
    public class GameManager
    {
        private static GameManager _instance;

        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameManager();
                return _instance;
            }
        }


        // Update is called once per frame
        public int score = 0;
    }
}
