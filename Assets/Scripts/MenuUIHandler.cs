using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void StartGame()
    {
        var textInput = gameObject.GetComponentInChildren<TMPro.TMP_InputField>();
        DataManager.PlayerName = textInput.text;
        SceneManager.LoadScene(1);
    }
}
