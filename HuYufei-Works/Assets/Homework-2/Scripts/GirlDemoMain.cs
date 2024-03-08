using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlDemoMain : MonoBehaviour
{
    /// <summary>
    /// 挂载动画组件
    /// </summary>
    public Animator _girlAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // 简单的键位判断
    void Update()
    {
        //----------- 行走动画 ---------------- 
        if (Input.GetKeyDown(KeyCode.W))
        {
            _girlAnimator.SetTrigger("Walk"); // 这里设置走的 trigger 名称
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            _girlAnimator.SetTrigger("Idle"); // 这里设置待机的 trigger 名称
        }

        //----------- 跑步动画 --------------
        if (Input.GetKeyDown(KeyCode.R))
        {
            _girlAnimator.SetTrigger("Run"); // 这里设置跑的 trigger 名称
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            _girlAnimator.SetTrigger("Idle"); // 这里设置待机的 trigger 名称
        }

    }
}
