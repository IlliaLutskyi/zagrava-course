using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
public class UI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        root.Q<Button>("startButton").clicked += () =>
        {
            SceneManager.LoadScene("Game");
        };

        root.Q<Button>("exitButton").clicked += () =>
        {  
            Application.Quit();
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
