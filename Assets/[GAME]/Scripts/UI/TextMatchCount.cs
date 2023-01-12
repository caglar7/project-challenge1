using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextMatchCount : MonoBehaviour
{
    int matchCount = 0;
    TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        EventManager.MatchFound += AddCount;
        EventManager.RebuildGrid += Init;
        Init();
    }

    private void AddCount()
    {
        matchCount++;
        UpdateText();
    }

    private void Init()
    {
        matchCount = 0;
        UpdateText();
    }

    private void UpdateText()
    {
        if (text) text.text = "Match Count: " + matchCount;
    }
}
