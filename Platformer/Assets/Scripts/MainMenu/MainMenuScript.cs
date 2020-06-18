using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{

    [SerializeField] private GameObject levelSelectCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenLevelSelect()
    {
        levelSelectCanvas.SetActive(true);
        gameObject.SetActive(false);
    }
}
