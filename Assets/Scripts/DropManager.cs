using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DropManager : MonoBehaviour
{
    public Dictionary<string, GameObject> enemyDropTypes = new Dictionary<string, GameObject>();
    public GameObject SinglePointDrop;
    public GameObject QuadruplePointDrop;
    public GameObject OctuplePointDrop;

    private void Start()
    {
        // Fill the dictionary with predefined drop types.
        InitializeDropTypes();
    }

    private void InitializeDropTypes()
    {
        // Add enemy types and their corresponding drop items to the dictionary.
        // For example, if "Sentry" is an enemy type, assign a drop item for it.
        enemyDropTypes["Sentry(Clone)"] = SinglePointDrop; /* Your sentry-specific drop item */
        enemyDropTypes["WaveSentry(Clone)"] = OctuplePointDrop; /* Your sentry-specific drop item */
        enemyDropTypes["SpreadSentry(Clone)"] = QuadruplePointDrop; /* Your sentry-specific drop item */
        enemyDropTypes["BurstSentry(Clone)"] = QuadruplePointDrop; /* Your sentry-specific drop item */
        enemyDropTypes["HomingSentry(Clone)"] = SinglePointDrop; /* Your sentry-specific drop item */
        enemyDropTypes["PlusSentry(Clone)"] = QuadruplePointDrop; /* Your sentry-specific drop item */
        enemyDropTypes["MobileSentry(Clone)"] = QuadruplePointDrop; /* Your sentry-specific drop item */
        enemyDropTypes["ShotgunSentry(Clone)"] = OctuplePointDrop; /* Your sentry-specific drop item */
        enemyDropTypes["CannonSentry(Clone)"] = QuadruplePointDrop; /* Your sentry-specific drop item */
        enemyDropTypes["RotationSentry(Clone)"] = OctuplePointDrop; /* Your sentry-specific drop item */
    }

    public void HandleDrops(string enemyName, GameObject Enemy)
    {
        Debug.Log(enemyName);
        GameObject itemToDrop;

        if (enemyDropTypes.TryGetValue(enemyName, out itemToDrop))
        {
            // Instantiate the chosen item at the enemy's position.
            Instantiate(itemToDrop, Enemy.transform.position, Quaternion.identity);
        }
        else
        {
            // Instantiate the default drop if the enemy's name is not in the dictionary.
            Debug.LogWarning("Enemy type not found in the dictionary");
            Debug.LogWarning("Under Most cases this is just the player");
            SceneManager.LoadScene("MainMenu");
        }
    }
}
