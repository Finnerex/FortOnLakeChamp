using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text textComponent; // Reference to the Text component in the Inspector

    // Call this method to activate the text
    public void ActivateText(string newText)
    {
        textComponent.text = newText;
        textComponent.enabled = true;
    }

    // Call this method to deactivate the text
    public void DeactivateText()
    {
        textComponent.enabled = false;
    }
}