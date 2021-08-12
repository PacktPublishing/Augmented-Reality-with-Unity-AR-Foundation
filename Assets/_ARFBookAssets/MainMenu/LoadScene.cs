using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private string sceneName;
    Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => { SceneManager.LoadScene(sceneName);  });
    }
}
