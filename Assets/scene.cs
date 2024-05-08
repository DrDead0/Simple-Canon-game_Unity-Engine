using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplosionManager : MonoBehaviour
{
    public GameObject[] objectsToDestroy;
    public string nextSceneName;

    void Update()
    {
        // Check if all explosion-related objects are destroyed
        bool allDestroyed = true;
        foreach (GameObject obj in objectsToDestroy)
        {
            if (obj != null) // Check if object still exists
            {
                allDestroyed = false;
                break;
            }
        }

        // If all objects are destroyed, switch the scene
        if (allDestroyed)
        {
            SceneManager.LoadScene(1);
        }
    }
}
