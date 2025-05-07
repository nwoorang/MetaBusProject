using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // ← 씬 관리용 using 문
public class FlappyPlanePortal : MonoBehaviour,IInteractable
{
    public GameObject keyButton;
    private bool isPlayerInRange = false;

    public void Interact()
    {
        if (isPlayerInRange)
        {
            keyButton.SetActive(false);
            LoadFlappyScene();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            keyButton.SetActive(!keyButton.activeSelf);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            keyButton.SetActive(false);
        }
    }

        public void LoadFlappyScene()
    {
        SceneManager.LoadScene("FlappyScene");  // 씬 이름으로 이동
    }
}
