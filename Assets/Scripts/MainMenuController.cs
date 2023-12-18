using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;
using System;
using UnityEngine.TextCore.Text;
using System.Linq.Expressions;
using System.IO;
using UnityEngine.SceneManagement;


public class MainMenuController : MonoBehaviour
{

    public BobData bobData = new BobData();

    void Start()
    {
       
    }


    public void StartGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        


    }


    public void LoadData()
    {
        var pp = "D:/projects/BDL/HW2/Assets/StreamingAssets/GAMEDATA.json"; 

         string path = Path.Combine(Application.streamingAssetsPath, "GAMEDATA.json");


        bobData = JsonUtility.FromJson<BobData>(File.ReadAllText(pp));
       
       if(SceneManager.GetActiveScene().buildIndex == bobData.SceneID)
       {
         transform.position = bobData.Position;
        //  Debug.Log("Loaded old pos name of " + bobData.Name);
         
       }
       else
       { 
            SceneManager.LoadScene(bobData.SceneID);
             transform.position = bobData.Position;
            
        
       }
       


       
    }

    
    




    
}
