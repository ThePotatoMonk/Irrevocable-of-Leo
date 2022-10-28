using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject textBox;
    public Text signText;
    public string text;
    private bool textActive;
    private bool inRange;


    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && inRange)
        {
            if (textBox.activeInHierarchy)
            {
                textBox.SetActive(false);
            }
            else
            {
                textBox.SetActive(true);
                signText.text = text;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            inRange = false;
            textBox.SetActive(false);
        }
    }

}
