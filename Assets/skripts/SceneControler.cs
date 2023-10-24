using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControler : MonoBehaviour
{

    public void Gotoscene()
    {
        SceneManager.LoadScene(0);
    }

}
