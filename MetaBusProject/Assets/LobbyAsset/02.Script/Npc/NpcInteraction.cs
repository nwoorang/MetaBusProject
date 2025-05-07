using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcInteraction : MonoBehaviour,IInteractable
{
    public GameObject dialoguePanel;

    public GameObject keyButton;

    public GameObject npcIllust;
    private bool isPlayerInRange = false;

    public void Interact()
    {
        if (isPlayerInRange)
        {
            dialoguePanel.SetActive(!dialoguePanel.activeSelf);
            npcIllust.SetActive(!npcIllust.activeSelf);
            keyButton.SetActive(false);
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
            dialoguePanel.SetActive(false);
            npcIllust.SetActive(false);
            keyButton.SetActive(false);
        }
    }
}
