using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public UIDocument uiDocument;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var root = uiDocument.rootVisualElement;
        root.Q<Button>("PauseButton").clicked += () =>
        {
            root.Q<Button>("ContinueButton").clicked += () =>
            {
                root.Q<VisualElement>("PauseForm").style.display = DisplayStyle.None;
            };
            root.Q<Button>("QuitButton").clicked += () =>
            {
                SceneManager.LoadScene("Start");
            };
            root.Q<VisualElement>("PauseForm").style.display = root.Q<VisualElement>("PauseForm").style.display == DisplayStyle.None ? DisplayStyle.Flex : DisplayStyle.None ;
        };    
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
