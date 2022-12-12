using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnNextLevel : MonoBehaviour
{
    [SerializeField] AudioSource myBtn;

    public void ClickkSound()
    {
        myBtn.Play();
    }
}
