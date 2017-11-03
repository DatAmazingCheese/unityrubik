using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    IEnumerator LoadNewScene(string scene)
    {
        yield return new WaitForSeconds(1);

        AsyncOperation async = SceneManager.LoadSceneAsync(scene);

        while (!async.isDone)
        {
            yield return null;
        }
    }

    public void LoadScene(string scene)
    {
        StartCoroutine(LoadNewScene(scene));
    }
}