using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnButtonClick : MonoBehaviour, IPointerDownHandler
{
    public AudioSource audioSource;
    public AudioSource badAudioSource;
    public Button button;
    /// <summary>
    /// plays audio when clicking a button
    /// </summary>
    /// <param name="eventData">if it hits or not</param>
    public void OnPointerDown(PointerEventData eventData)
    {
        if(button.IsInteractable())
        {
            audioSource.Play();
        }
        else
        {
            badAudioSource.Play();
        }
    }

    
}
