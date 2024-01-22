
using UnityEngine;


namespace Progression
{
    [CreateAssetMenu(fileName = "New Dialogue", menuName = "FOLC/Dialogue")]
    public class Dialogue : ScriptableObject
    {
        
        [SerializeField] [TextArea] private string mainText;

        [SerializeField] private DialogueOption[] options;

        public string MainText => mainText;
        public DialogueOption[] Options => options;
        
    }

}