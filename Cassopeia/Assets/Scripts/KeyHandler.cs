using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyHandler : MonoBehaviour
{
    public int quantity = 0;
    public TextMeshProUGUI textKey;

    // Update is called once per frame
    void Update()
    {
        textKey.text = quantity.ToString();
    }
}
