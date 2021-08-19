using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "state")]
public class State : ScriptableObject
{
    [TextArea(10, 14)] [SerializeField] string storyText;
    [SerializeField] State[] nextState;
    public string GetText()
    {
        return storyText;
    }
    public State[] GetNextState()
    {
        return nextState;
    }
}
