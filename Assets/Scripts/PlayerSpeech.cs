using TMPro;
using UnityEngine;

public class PlayerSpeech : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI monologueText;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private float _monologueTimeSeconds;
    private float _dialogueTimeSeconds;

    // Update is called once per frame
    void Update()
    {
        
        if (_monologueTimeSeconds > 0)
            _monologueTimeSeconds -= Time.deltaTime;
        else if (monologueText.text != "")
            monologueText.text = "";
        
        if (_dialogueTimeSeconds > 0)
            _dialogueTimeSeconds -= Time.deltaTime;
        else if (dialogueText.text != "")
            dialogueText.text = "";
        
    }

    public void SetMonologue(string text, float displayTimeSeconds = 5)
    {
        monologueText.text = text;
        _monologueTimeSeconds = displayTimeSeconds;
    }

    public void SetDialogue(string sender, string text, float displayTimeSeconds = 5)
    {
        // this will be dealt with at some point
    }
    
    public void SetDialogue(string sender, string text, params string[] options)
    {
        // this will be dealt with after we figure out if dialogue options will be a thing
    }
}
