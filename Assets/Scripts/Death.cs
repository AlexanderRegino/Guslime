using System.Collections;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Awake()
    {

    }
    public void DeathSequence()
    {
        StartCoroutine(DeathEffect());
    }

    private IEnumerator DeathEffect()
    {
        // Change the sprite color to red
        spriteRenderer.color = Color.red;

        if (gameObject != null)
        {
            // Get the name of the object's parent
            string parentName = gameObject.name;

            // Find the DropManager in the scene
            DropManager dropManager = FindObjectOfType<DropManager>();
            if (dropManager != null)
            {
                Debug.Log("Invoking DropManager");
                dropManager.HandleDrops(parentName, gameObject);
            }
            else
            {
                Debug.Log("DropManager is null");
            }
        }

        // Wait for half a second
        yield return new WaitForSeconds(0.1f);

        // Destroy the game object

        Destroy(gameObject);
    }


}
