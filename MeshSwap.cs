
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeshController : MonoBehaviour
{
    [Tooltip("The same list of mesh-containing scene names used by HeightScanner")]
    public List<string> meshSceneNames;

    [Tooltip("Where to place each model in world space")]
    public Transform spawnPoint;

    private int currentIndex = 0;
    private GameObject currentMesh;

  
    public void SwitchToNextModel()
    {
        currentIndex = (currentIndex + 1) % meshSceneNames.Count;
        StartCoroutine(LoadModelFromScene(meshSceneNames[currentIndex]));
    }

    private IEnumerator LoadModelFromScene(string sceneName)
    {
        
        if (currentMesh != null) Destroy(currentMesh);

        var loadOp = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        while (!loadOp.isDone) yield return null;

        Scene s = SceneManager.GetSceneByName(sceneName);
        foreach (var root in s.GetRootGameObjects())
        {
            if (root.CompareTag("MeshModel"))
            {
                currentMesh = Instantiate(root, spawnPoint.position, spawnPoint.rotation);
                SceneManager.MoveGameObjectToScene(currentMesh, SceneManager.GetActiveScene());
                break;
            }
        }

        
        yield return null;
        SceneManager.UnloadSceneAsync(sceneName);
    }
}

