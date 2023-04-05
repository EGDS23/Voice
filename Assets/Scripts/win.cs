using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win : MonoBehaviour
{
    public GameObject victoryScreen; 

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            victoryScreen.SetActive(true);
        }
    }
}
