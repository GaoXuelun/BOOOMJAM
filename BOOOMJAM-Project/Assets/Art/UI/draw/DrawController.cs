<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawController : MonoBehaviour
{
   
    public float polespeed = 1f;
    public float boardspeed = 50f;
    public Transform center; //Ğı×ªÖĞĞÄ
    public Transform board; //×ªÅÌ±³¾°°å
    public GameObject ball; //³é½±Ğ¡Çò
    public bool isFinished = false;
    public Animation ballfall;
   
    void Update()
    {
        if(Input.GetMouseButton(0) && !isFinished)
        {
            

            transform.RotateAround( new Vector3(center.position.x, center.position.y,center.position.z), Vector3.forward * polespeed , 1f);

            RotateBoard();

            StartCoroutine(BallFall());


        }
    }

    public void RotateBoard()
    {
        board.transform.Rotate(Vector3.forward*Time.deltaTime*boardspeed);
    }

    IEnumerator BallFall()
    {
        yield return new WaitForSeconds(2f);
        ball.SetActive(true);
        isFinished = true;
        ballfall.Play();

        ballfall.Stop();

    }

}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawController : MonoBehaviour
{
   
    public float polespeed = 1f;
    public float boardspeed = 50f;
    public Transform center; //Ğı×ªÖĞĞÄ
    public Transform board; //×ªÅÌ±³¾°°å
    public GameObject ball; //³é½±Ğ¡Çò
    public bool isFinished = false;
    public Animation ballfall;
   
    void Update()
    {
        if(Input.GetMouseButton(0) && !isFinished)
        {
            

            transform.RotateAround( new Vector3(center.position.x, center.position.y,center.position.z), Vector3.forward * polespeed , 1f);

            RotateBoard();

            StartCoroutine(BallFall());


        }
    }

    public void RotateBoard()
    {
        board.transform.Rotate(Vector3.forward*Time.deltaTime*boardspeed);
    }

    IEnumerator BallFall()
    {
        yield return new WaitForSeconds(2f);
        ball.SetActive(true);
        isFinished = true;
        ballfall.Play();

        ballfall.Stop();

    }

}
>>>>>>> 5966b8b0f30ae9222c2c55427bea8e3a6a4e94f8
