using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToNextLevel : MonoBehaviour
{
    void Start()
    {}
    void Update()
    {}
    void EnterNextLevel(Collider collider)
    {
        Debug.Log("Door");
        if (collider.gameObject.CompareTag("Player") 
            && collider.GetType().ToString() == "UnityEngine.CapsuleCollider")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}