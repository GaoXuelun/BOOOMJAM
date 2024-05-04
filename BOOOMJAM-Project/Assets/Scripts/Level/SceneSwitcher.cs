using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // 定义一个方法，用于切换场景
    public void SwitchScene(string sceneName)
    {
        // 使用场景管理器加载指定名称的场景
        SceneManager.LoadScene(sceneName);
    }
}
