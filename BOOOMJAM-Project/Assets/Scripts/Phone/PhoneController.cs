using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneController : MonoBehaviour
{
    public GameObject phoneScreen; // 手机屏幕对象
    public PlayerController playerController; // 玩家控制器

    private bool phoneOpen = false; // 手机是否打开

    // 每帧检查是否按下 I 键打开或关闭手机
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (phoneOpen)
                ClosePhone();
            else
                OpenPhone();
        }
    }

    // 打开手机
    void OpenPhone()
    {
        phoneOpen = true;
        phoneScreen.SetActive(true); // 显示手机屏幕
        playerController.canMove = false; // 禁用玩家移动
    }

    // 关闭手机
    void ClosePhone()
    {
        phoneOpen = false;
        phoneScreen.SetActive(false); // 隐藏手机屏幕
        playerController.canMove = true; // 启用玩家移动
    }
}
