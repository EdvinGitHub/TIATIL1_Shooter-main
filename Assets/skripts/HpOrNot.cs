using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpOrNot : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject  boss;
    void Start()
    {
            GetComponent<Image>().enabled = false;
            GetComponentInChildren<Image>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        // if (boss.activeInHierarchy == false) 
        // {
        // // gameObject.SetActive(false);
        // }
        // if (boss.activeInHierarchy == true)
        // {
        //     print("gh");
        //     GetComponent<Image>().enabled = true;
        //     GetComponentInChildren<Image>().enabled = true;

        // }
    }
}
