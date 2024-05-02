using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawController : MonoBehaviour
{
   
    public float polespeed = 1f;
    public float boardspeed = 50f;
    public Transform center; //Ðý×ªÖÐÐÄ
    public Transform board; //×ªÅÌ±³¾°°å
    public GameObject ball; //³é½±Ð¡Çò
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
