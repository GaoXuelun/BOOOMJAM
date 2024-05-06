using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;   //修改

public class Switch : MonoBehaviour, InteractableInterface
{
    [SerializeField] private NPCConversation myConversation;
    [SerializeField] private string interactText;
    [SerializeField] private Light pointLight;

    private const string SCRIPT_ENABLED_KEY = "SwitchScriptEnabled";

    private void Awake()
    {
        // 检查脚本是否应该被禁用
        if (PlayerPrefs.GetInt(SCRIPT_ENABLED_KEY, 1) == 0)
        {
            this.enabled = false;
        }
    }

    private void Start()
    {
        // 确保灯光初始时是关闭的
        pointLight.enabled = false;
    }

    public void TriggerAction()
    {
        BoxCollider box = GetComponent<BoxCollider>();

        if (!pointLight.enabled)
        {
            pointLight.enabled = true;
            Debug.Log("Light has been turned on.");
        }

        if (myConversation != null)
        {
            ConversationManager.Instance.StartConversation(myConversation);
        }

        box.size = new Vector3(0, 0, 0);

        // 执行完操作后禁用此脚本并保存状态
        this.enabled = false;
        PlayerPrefs.SetInt(SCRIPT_ENABLED_KEY, 0);
        PlayerPrefs.Save();
    }

    public string GetInteractText()
    {
        return interactText;
    }

    public Transform GetTransform()
    {
        return transform;
    }


}
