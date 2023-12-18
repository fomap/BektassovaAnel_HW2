using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private BobController _bobController;
    [SerializeField] private GameObject _endScreen;

    [SerializeField] private GameObject _loadMenu;
   

    private void OnEnable()
    {
        _bobController.OnKilled += _bobController_OnKilled;
    }
     private void OnDisavle()
    {
        _bobController.OnKilled -= _bobController_OnKilled;
    }
    
    private void _bobController_OnKilled()
    {
        _endScreen.SetActive(true);
    }   


    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }


    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    public void LvlComplete()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadMenu()
    {
        _loadMenu.SetActive(true);
    }

    public void CloseMenu()
    {
        _loadMenu.SetActive(false);
    }

    


}
