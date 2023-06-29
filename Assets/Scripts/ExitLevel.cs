using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    public string SceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //SceneManager.LoadScene(SceneToLoad);
            PlayerController.instance.gameObject.SetActive(false);
            UIController.instance.completedScreen.SetActive(true);
            AudioManager.instance.PlayCompletedMusic();
        }
    }
}
