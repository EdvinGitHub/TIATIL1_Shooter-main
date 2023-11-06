
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class OverButton : MonoBehaviour
{
    // Start is called before the first frame update
 

    // Update is called once per frame
    void Start()
    {
    
        
    }
    public void LoadScene(int sceneNumbur)
    {
        SceneManager.LoadScene(sceneNumbur);
    }
}
