using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    AudioSource audioSource;
    Collider2D collision;
    public GameObject Button;

    
    public void OnTriggerExit2D(Collider2D collision)
    {
                
        SceneManager.LoadScene("MainScene"); //Ŭ�������� �ε��� �� �̸�
    }

    public void Press_Play()
    {
        audioSource = Button.gameObject.GetComponent<AudioSource>();
        this.audioSource.Play();
        OnTriggerExit2D(collision);



    }
}
