using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnButtonClick : MonoBehaviour, IPointerDownHandler
{
    public AudioSource audioSource;
    public Button button;

    public void OnPointerDown(PointerEventData eventData)
    {
        if(button.IsInteractable())
        {
            audioSource.Play();
        }
    }
}
