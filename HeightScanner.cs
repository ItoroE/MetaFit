// HeightScanner.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeightScanner : MonoBehaviour
{
  
    public List<string> meshSceneNames;

    //my current hieght will be overwritten
    public float userHeightInMeters = 1.68f;

  
    public void ScanUserHeight()
    {
        // get the headset Y-position
        if (Camera.main != null)
            userHeightInMeters = Camera.main.transform.position.y;

        StartCoroutine(ScaleAllMeshesByHeight());
    }

    private IEnumerator ScaleAllMeshesByHeight()
    {
        const float referenceHeight = 1.7f;
        float scaleFactor = userHeightInMeters / referenceHeight;

        foreach (string sceneName in meshSceneNames)
        {
            // Loads scene additively
            var loadOp = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            while (!loadOp.isDone) yield return null;


            Scene s = SceneManager.GetSceneByName(sceneName);
            foreach (var root in s.GetRootGameObjects())
            {
                if (root.CompareTag("MeshModel"))
                {
                    //Instantiate a copy to scale
                    var copy = Instantiate(root);
                    copy.transform.localScale = root.transform.localScale * scaleFactor;
                    SceneManager.MoveGameObjectToScene(copy, SceneManager.GetActiveScene());
                    copy.name = root.name;
                    break;
                }
            }
            yield return null;
            SceneManager.UnloadSceneAsync(sceneName);
        }

        Debug.Log("Height scaling complete for all mesh scenes.");
    }
}

