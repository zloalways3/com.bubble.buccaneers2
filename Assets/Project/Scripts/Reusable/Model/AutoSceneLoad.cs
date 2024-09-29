using UnityEngine;

public class AutoSceneLoad : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    private void Awake()
    {
        SceneLoad.Load(_sceneName);
    }
}