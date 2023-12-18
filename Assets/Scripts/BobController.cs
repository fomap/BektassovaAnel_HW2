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

public class BobController : MonoBehaviour, IPlayer
{
    public event Action OnKilled;
    public BobData bobData = new BobData();





    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private KeyCode _JumpButton;
    [SerializeField] private float _jumpForce;
    [SerializeField] private SpriteRenderer _spriteBob;
    [SerializeField] private Camera _camera; 
    [SerializeField] private float _dampingSpeed;
    public void MakeDamage()
    {
        // Debug.Log("Death has come");
        _rb.AddForce(Vector2.up * _jumpForce);
        GetComponent<Collider2D>().isTrigger = true;
        OnKilled?.Invoke();
        enabled = false;
    }

    void Update()
    {
        CharacterMovement();
    }

    private void FixedUpdate()
    {
        _camera.transform.position = Vector3.Lerp(new Vector3(_camera.transform.position.x,  _camera.transform.position.y,  -10), transform.position, Time.deltaTime * _dampingSpeed);

        




    }
    private void CharacterMovement()
    {
        float inputDir = Input.GetAxis("Horizontal");

        _spriteBob.flipX = inputDir < 0;

        _animator.SetFloat("MoveSpeed", Mathf.Abs(inputDir));

        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + inputDir, transform.position.y, 0), Time.deltaTime * _moveSpeed);

        if (Input.GetKeyDown(_JumpButton))
        {
            _rb.AddForce(Vector2.up * _jumpForce);
        }
    }

public void SaveData()
    {
        bobData = new BobData(transform.position, gameObject.name, SceneManager.GetActiveScene().buildIndex);
        // this.bobData = bobData; 

        string json = JsonUtility.ToJson(bobData);

        PlayerPrefs.SetString(gameObject.name, json);

        var p = "D:/projects/BDL/HW2/Assets/StreamingAssets/GAMEDATA.json"; 
        string path = Path.Combine(Application.streamingAssetsPath, "GAMEDATA.json");

        // if(!Directory.Exists(p))
        // {
        //     Directory.CreateDirectory(p);
        // }


        File.WriteAllText(p , json);



         Debug.Log("Saved new pos" + json);

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

[Serializable]

public class BobData
{
    public Vector3 Position;
    public string Name;
    public int SceneID;


    public BobData()
    {

    }

    public BobData(Vector3 position, string name, int sceneID)
    {
        Position = position;
        Name = name;
        SceneID = sceneID;
    }



}















