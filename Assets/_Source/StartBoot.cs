using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBoot : MonoBehaviour
{
    [SerializeField] private enumSceneNames _loadScene;
    void Start()
    {
        SceneManager.LoadScene(_loadScene.ToString());
    }
}