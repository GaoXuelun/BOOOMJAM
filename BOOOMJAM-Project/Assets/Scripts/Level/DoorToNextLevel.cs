using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToNextLevel : MonoBehaviour
{
    void Start()
    {
        // Initialization code if needed
    }

    void Update()
    {
        // Update code if needed
    }

    // This method gets called when another collider enters the trigger collider attached to this object
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Door triggered by: " + collider.gameObject.name);
        if (collider.CompareTag("Player") && collider is CapsuleCollider)
        {
            // Load the next scene by incrementing the current scene's build index
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
