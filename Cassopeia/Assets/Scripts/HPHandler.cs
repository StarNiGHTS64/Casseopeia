using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPHandler : MonoBehaviour
{
    public int hp = 100;
    public int alert;

    public TextMeshProUGUI textAlert;
    public GameObject icon;

    public Sprite incognito;
    public Sprite spotted;

    private void Start()
    {
        alert = 0;
        CurrentState();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentState();
        
    }

    void CurrentState(){
        switch(alert){
            case 0:
            textAlert.text = "Incognito";
            icon.GetComponent<Image>().sprite = incognito;
            break;

            case 1:
            textAlert.text = "Low Profile";
            icon.GetComponent<Image>().sprite = incognito;
            break;

            case 2:
            textAlert.text = "Suspicious";
            icon.GetComponent<Image>().sprite = spotted;
            break;

            case 3:
            textAlert.text = "Spotted";
            icon.GetComponent<Image>().sprite = spotted;
            break;
        }
    }
}
