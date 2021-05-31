using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
//using TMPro.EditorUtilities;
using UnityEngine;

public class StaticMessage : MonoBehaviour
{
    public string errorText;
    public string otherText;
    [SerializeField] TMP_Text _message;
    [SerializeField] GameObject _panel;
    public bool isError;

    public void setError()
    {
        isError = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<ThirdPersonMover>();
        if (player != null)
        {
            if (isError)
                _message.text = errorText;
            if(!isError)
                _message.text = otherText;
            _panel.SetActive(true);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _panel.SetActive(false);
    }
}
