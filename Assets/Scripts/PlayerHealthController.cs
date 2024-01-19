using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;
    public int currentHealth;
    public int maxHealth;
    

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
        UIController.instance.healthSlider.maxValue = maxHealth;
        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void DamagePlayer()
    {
        AudioManager.instance.PLaySFX(11);
        currentHealth--;
        if(currentHealth <= 0)
        {
            PlayerController.instance.gameObject.SetActive(false);
            UIController.instance.deathScreen.SetActive(true);
            AudioManager.instance.PlayGameOver();
        }

        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }

}
