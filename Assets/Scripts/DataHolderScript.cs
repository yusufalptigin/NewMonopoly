using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataHolderScript : MonoBehaviour
{
    // Start is called before the first frame update

    public string monopolyName;
    public string playerOneName;
    public string playerTwoName;
    public string playerThreeName;

    public TMP_InputField inputOne;
    public TMP_InputField inputTwo;
    public TMP_InputField inputThree;
    public TMP_InputField inputFour;

    private Scene scene;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            monopolyName = inputOne.text;
            playerOneName = inputTwo.text;
            playerTwoName = inputThree.text;
            playerThreeName = inputFour.text;
        }
        
    }
}
