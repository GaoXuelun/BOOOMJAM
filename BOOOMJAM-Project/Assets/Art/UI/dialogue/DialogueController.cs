using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;


public class DialogueController : MonoBehaviour
{

    public TextAsset dialogDataFile;
    public Text dialogText1;
    public Text dialogText2;
    public int dialogIndex; //保存当前对话索引值
    public string[] dialogRows; //对话文本按行分割
    public Button buttonNext;//S
    public GameObject buttonOption;//C
    public GameObject Reminder;
    public Transform buttonGroup;//选项集合
    public string sceneFrom;
    public string sceneTo;
    public GameObject showPic;
    public GameObject hidePic;
    public List<Person> people = new List<Person>();

    //private void OnEnable()
    //{
    //    EventHandler.ShowDialogEvent += OnShowDialogEvent;
    //}

    //private void OnDisable()
    //{
    //    EventHandler.ShowDialogEvent -= OnShowDialogEvent;
    //}
    private void Awake()
    {
        Person dead = new Person();
        dead.name = "A";
        people.Add(dead);

        Person player = new Person();
        player.name = "B";
        people.Add(player);
    }


    private void Start()
    {
        ReadText(dialogDataFile);
        OnShowDialogEvent();
    }

    private void Update()
    {
        if(buttonNext.gameObject.activeSelf && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            OnShowDialogEvent();

            Reminder.gameObject.SetActive(false);

        }
    }

    //public void UpdateText(string _text)
    //{
    //    dialogText1.text = _text;
    //    dialogText2.text = _text;

    //}


    public void ReadText(TextAsset _textAsset)
    {
        dialogRows = _textAsset.text.Split('\n');
    }

    public void OnShowDialogEvent()
    {
        for (int i = 0; i < dialogRows.Length; i++)
        {
            string[] cells = dialogRows[i].Split(',');
            //对话S
            if (cells[0] == "S" && int.Parse(cells[1]) == dialogIndex)
            {
                buttonNext.gameObject.SetActive(true);

                if (cells[2] == "A")
                {
                    if (Language.Instance.LanguageID == 1)
                    {
                        dialogText1.text = cells[4];
                    }
                    else if (Language.Instance.LanguageID == 2)
                    {
                        dialogText1.text = cells[9];
                    }
                    dialogText2.text = "";
                }

                else if (cells[2] == "B")
                {
                    if (Language.Instance.LanguageID == 1)
                    {
                        dialogText2.text = cells[4];
                    }
                    else if (Language.Instance.LanguageID == 2)
                    {
                        dialogText2.text = cells[9];
                    }
                    dialogText1.text = "";

                    if (cells[8] == "ShowPic")
                    {
                        ShowPic();
                    }
                }

                dialogIndex = int.Parse(cells[5]); //更新至跳转ID
                buttonNext.gameObject.SetActive(true);
                break;
            }
            //选项C
            else if (cells[0] == "C" && int.Parse(cells[1]) == dialogIndex)
            {
                buttonNext.gameObject.SetActive(false);
                GernerateOption(i);

            }

            //end或跳转
            else if (cells[0] == "END" && int.Parse(cells[1]) == dialogIndex)
            {
                Teleport();

            }

            

            //提示区域
            
        }
    }

    public void OnClickNext()
    {
        OnShowDialogEvent();
        Reminder.gameObject.SetActive(false); 
    }

    public void GernerateOption(int _index)
    {
        string[] cells = dialogRows[_index].Split(',');
        if (cells[0] =="C")
        {
            GameObject button = Instantiate(buttonOption, buttonGroup);
            //绑定按钮事件
            if (Language.Instance.LanguageID == 1)
            {
                button.GetComponentInChildren<Text>().text = cells[4];
            }
            else if (Language.Instance.LanguageID == 2)
            {
                button.GetComponentInChildren<Text>().text = cells[9];
            }
           
            button.GetComponent<Button>().onClick.AddListener
                (

                delegate
                {
                   
                    if (cells[6] != "")
                    {
                        string[] effect = cells[6].Split('@'); //divde effect from number
                        OptionEffect(effect[0], int.Parse(effect[1]), cells[7]);
                       
                    }
                    OnOptionClick(int.Parse(cells[5]));
                }
                );
            GernerateOption(_index + 1); //需要if语句的原因，作此处的判断

        }

       
    }

    public void OnOptionClick(int _id)
    {
        dialogIndex = _id;

        OnShowDialogEvent();
        for (int i = 0; i < buttonGroup.childCount; i++)
        {
            Destroy(buttonGroup.GetChild(i).gameObject);
        }

    }

    public void OptionEffect(string _effect, int _param, string _target)
    {
        if (_effect == "眷恋值加")
        {
            foreach (var dead in people)
            {
                if (dead.name == _target)
                {
                    dead.likeValue += _param;
                }
            }
        }
    }


    public void Teleport()
    {

        TransitionManager.Instance.Transition(sceneFrom, sceneTo);

    }

    public void ShowPic()
    {
        showPic.SetActive(true);
        hidePic.SetActive(false);
    }

    
}












//public class DialogueController : MonoBehaviour
//{
//    public DialogueData_SO dialogueEmpty;

//    public DialogueData_SO dialogueFinish;

//    private bool isTalking;

//    private Stack<string> dialogueEmptyStack;

//    private Stack<string> dialogueFinishStack;



//    private void Awake()
//    {
//        FillDialogueStack();
//    }


//    private void FillDialogueStack()
//    {
//        dialogueEmptyStack = new Stack<string>();
//        dialogueFinishStack = new Stack<string>();

//        for (int i = dialogueEmpty.dialogueList.Count - 1; i > -1; i--)
//        {

//            dialogueEmptyStack.Push(dialogueEmpty.dialogueList[i]);
//        }
//        for (int i = dialogueFinish.dialogueList.Count - 1; i > -1; i--)
//        {

//            dialogueFinishStack.Push(dialogueFinish.dialogueList[i]);
//        }


//    }

//    public void ShowDialogueEmpty()
//    {
//        if (!isTalking)
//            StartCoroutine(DialogueRoutine(dialogueEmptyStack));
//    }

//    public void ShowDialogueFinish()
//    {
//        if (!isTalking)
//            StartCoroutine(DialogueRoutine(dialogueFinishStack));
//    }

//    private IEnumerator DialogueRoutine(Stack<string> data)
//    {
//        isTalking = true;
//        if (data.TryPop(out string result))
//        {
//            EventHandler.CallShowDialogueEvent(result);
//            yield return null;
//            isTalking = false;
//            EventHandler.CallSGameStateChangeEvent(GameState.Pause);
//        }
//        else
//        {
//            EventHandler.CallShowDialogueEvent(string.Empty);
//            FillDialogueStack();
//            isTalking = false;
//            EventHandler.CallSGameStateChangeEvent(GameState.Gameplay);
//        }

//    }
//}
