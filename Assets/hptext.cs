using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class hptext : MonoBehaviour
{
    // Start is called before the first frame update
     [SerializeField]
    GameObject  boss;
 
    void  Start()
    {
            GetComponent<TMP_Text>().enabled = false;
            GetComponentInChildren<TMP_Text>().enabled = false;

    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (boss.activeInHierarchy == false) 
    //     {
    //         GetComponent<TMP_Text>().enabled = false;
    //         GetComponentInChildren<TMP_Text>().enabled = false;
    //     // gameObject.SetActive(false);
    //     }
    //     else
    //      {
    //         GetComponent<TMP_Text>().enabled = true;
    //         GetComponentInChildren<TMP_Text>().enabled = true;

    //      }
    // }
}
