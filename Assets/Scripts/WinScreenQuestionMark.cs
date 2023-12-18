using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreenQuestionMark : MonoBehaviour
{
    // please don't beat me I'm having exams week;
    // P.S. ignore infinite jump bug;


     [SerializeField] private GameObject _winScreen;
      private void OnCollisionEnter2D(Collision2D collision)
    {
        
        _winScreen.SetActive(true);
        
    }


}
