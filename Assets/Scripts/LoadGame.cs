using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadGame : MonoBehaviour {

	public void EnterGame(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
