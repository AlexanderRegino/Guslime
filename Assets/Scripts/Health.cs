using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    private bool deathDebounce = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int amount)
    {

        currentHealth -= amount;
        if (currentHealth <= 0 && deathDebounce == false )
        {
            deathDebounce = true;
            print("Entity Died as health went below 0 ");
            var deathComponent = gameObject.GetComponent<Death>();
            print(deathComponent);
            if (deathComponent != null) 
            {
                print("Executing Death Sequence");
                deathComponent.DeathSequence();
            }

        }
    }
}
