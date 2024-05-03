using System.Collections;
using System.Collections.Generic;
using DialogueEditor;
using UnityEngine;

public class FirstConversationTrigger : MonoBehaviour
{
    public NPCConversation myConversation;

    // 检查是否是第一次进入场景
    private bool isFirstTimeEntering = true;

    private void Start()
    {
        // 在 Start 方法中检查是否是第一次进入场景
        if (isFirstTimeEntering)
        {
            // 如果是第一次进入，触发对话
            ConversationManager.Instance.StartConversation(myConversation);
            isFirstTimeEntering = false;
        }
    }
}