using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScene : MonoBehaviour
{
    public float delayForAnyKey = 2f;
    public GameObject anyKeyPress;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(delayForAnyKey > 0)
        {
            delayForAnyKey -= Time.deltaTime;
            if (delayForAnyKey <= 0)
            {
                anyKeyPress.SetActive(true);
            }
        }
        else
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("Start");
            }
        }
    }
}
