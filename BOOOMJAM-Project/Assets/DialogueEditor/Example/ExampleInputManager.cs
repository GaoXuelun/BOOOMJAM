using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueEditor
{
    public class ExampleInputManager : MonoBehaviour
    {
        public KeyCode m_UpKey;
        public KeyCode m_DownKey;
        public KeyCode m_SelectKey;
        private PlayerController playerController; //修改添加对 PlayerController 的引用

        //修改获取 PlayerController 组件
        private void Awake()
        {
            playerController = FindObjectOfType<PlayerController>(); //修改获取 PlayerController 组件
        }
        private void Update()
        {
            if (ConversationManager.Instance != null)
            {
                UpdateConversationInput();
            }
        }

        private void UpdateConversationInput()
        {
            if (ConversationManager.Instance.IsConversationActive)
            {
                //修改禁止人物移动交互
                if (playerController != null)
                {
                    playerController.canMove = false;
                }
                
                if (Input.GetKeyDown(m_UpKey))
                    ConversationManager.Instance.SelectPreviousOption();
                else if (Input.GetKeyDown(m_DownKey))
                    ConversationManager.Instance.SelectNextOption();
                else if (Input.GetKeyDown(m_SelectKey))
                    ConversationManager.Instance.PressSelectedOption();
                    
            }
            //修改允许人物移动交互
            else
            {
                
                if (playerController != null)
                {
                    playerController.canMove = true;

                }
            }
        }
    }
}
