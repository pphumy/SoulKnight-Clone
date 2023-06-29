using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Room : MonoBehaviour


{
    public bool iSClose, canOpen;
    public GameObject[] doors;
    public List<GameObject> enemies = new List<GameObject>();
    private bool roomActive;
    public GameObject mapHider;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OpenDoor();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            CameraController.instance.ChangeTarget(transform);
            if (iSClose)
            {
                foreach(GameObject door in doors)
                {
                    door.SetActive(true);
                }
            }
            roomActive = true;
            mapHider.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            roomActive = false;
        }
    }
    void OpenDoor()
    {
        if(enemies.Count > 0 && roomActive && canOpen)
        {
            for( int i =0; i < enemies.Count; i++)
            {
                if (enemies[i] == null)
                {
                    enemies.RemoveAt(i);
                    i--;
                }
                if(enemies.Count == 0)
                {
                    foreach (GameObject door in doors)
                    {
                        door.SetActive(false);
                        iSClose = false;
                    }
                }
            }
        }
    }
}
