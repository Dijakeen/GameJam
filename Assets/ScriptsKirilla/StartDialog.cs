using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartDialog : MonoBehaviour
{
    [SerializeField] Text textComponent;
    [SerializeField] State startingstate;

    State state;
    [SerializeField] GameObject canvas;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if(Input.GetKey(KeyCode.E))
        {
            canvas.SetActive(true);            
        }
        Debug.Log("Work");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canvas.SetActive(false);
        state = startingstate;
    }

    void Start()
    {
        state = startingstate;
        textComponent.text = state.GetText();

    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        var nextState = state.GetNextState();

        for (int i = 0; i < nextState.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                state = nextState[i];
            }
        }
        textComponent.text = state.GetText();
    }
}
