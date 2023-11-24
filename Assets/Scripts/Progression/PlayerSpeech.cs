using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;


namespace Progression
{
    public class PlayerSpeech : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI monologueText;
        [SerializeField] private TextMeshProUGUI dialogueText;
        [SerializeField] private TextMeshProUGUI[] dialogueOptionsText;
        [SerializeField] private RectTransform pointyGuy; // pointy guy my beloved

        private float _monologueTimeSeconds;
        
        private DialogueOption[] _dialogueOptions;
        private int _selectedOption;

        private void Awake()
        {
            dialogueText.text = "";
            monologueText.text = "";

            _dialogueOptions = new DialogueOption[3];
            
            foreach (TextMeshProUGUI t in dialogueOptionsText)
            {
                t.text = "";
            }
            
            pointyGuy.gameObject.SetActive(false);
            
        }

        // Update is called once per frame
        void Update()
        {
        
            if (_monologueTimeSeconds > 0)
                _monologueTimeSeconds -= Time.deltaTime;
            else if (monologueText.text != "")
                monologueText.text = "";
            
            

            if (Input.GetKeyDown(KeyCode.Return))
            {
                DialogueOption selectedOption = _dialogueOptions[_selectedOption];
                Dialogue? nextDialogue = selectedOption.FollowingDialogue;

                if (selectedOption.TriggersNextStage)
                    StageManager.CurrentStage++;
                
                // no further questions your honor
                if (nextDialogue == null)
                {
                    ResetOptions();
                    return;
                }

                _selectedOption = 0;
                SetPointyGuy();
                SetDialogue(nextDialogue.Value);
                
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                // wrapping
                _selectedOption += (_selectedOption >= dialogueOptionsText.Length - 1 || dialogueOptionsText[_selectedOption + 1].text == "") ? 0 : 1;
                SetPointyGuy();
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                // wrapping again
                _selectedOption -= (_selectedOption <= 0 || dialogueOptionsText[_selectedOption - 1].text == "") ? 0 : 1;
                SetPointyGuy();
            }

        }

        private void ResetOptions()
        {
            dialogueText.text = "";
            _dialogueOptions = new DialogueOption[3];
            
            foreach (TextMeshProUGUI t in dialogueOptionsText)
            {
                t.text = "";
            }
            
            pointyGuy.gameObject.SetActive(false);
        }

        private void SetPointyGuy()
        {
            TextMeshProUGUI currentOption = dialogueOptionsText[_selectedOption];
            RectTransform optionTransform = currentOption.rectTransform;

            pointyGuy.SetParent(optionTransform);
            Vector3 pointyPos = pointyGuy.localPosition;
            
            pointyPos.x = -200;
            pointyPos.y = 0;

            pointyGuy.localPosition = pointyPos;
        }

        public void SetMonologue(string text, float displayTimeSeconds = 5)
        {
            monologueText.text = text;
            _monologueTimeSeconds = displayTimeSeconds;
        }

        public void SetDialogue(Dialogue dialogue)
        {
            pointyGuy.gameObject.SetActive(true);
            
            dialogueText.text = dialogue.MainText;

            DialogueOption[] options = dialogue.Options;
            

            for (int i = 0; i < dialogueOptionsText.Length; i++)
            {
                if (i < options.Length)
                    _dialogueOptions[i] = options[i];

                dialogueOptionsText[i].text = i < options.Length ? options[i].Text : "";
 
            }
        }
        
    }
}
