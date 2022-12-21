using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnStart : MonoBehaviour
{
    [SerializeField] AudioSource myBtn;

    public void ClickkSound()
    {
        myBtn.Play();
    }

}
