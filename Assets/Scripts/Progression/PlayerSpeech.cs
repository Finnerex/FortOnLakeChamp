using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace Progression
{
    public class PlayerSpeech : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI monologueText;
        [SerializeField] private TextMeshProUGUI dialogueText;
        [SerializeField] private TextMeshProUGUI[] dialogueOptions;
        [SerializeField] private RectTransform pointyGuy; // pointy guy my beloved

        private float _monologueTimeSeconds;

        private Dictionary<string, Dialogue> _dialogueOptionsDict;
        private int _selectedOption;

        private void Awake()
        {
            dialogueText.text = "";
            monologueText.text = "";
            
            foreach (TextMeshProUGUI t in dialogueOptions)
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
                // what a line (this code is a mess already)
                // Dialogue nextDialogue = _dialogueOptionsDict[dialogueOptions[_selectedOption].text];

                bool hasNext = _dialogueOptionsDict.TryGetValue(dialogueOptions[_selectedOption].text, out Dialogue nextDialogue);

                // no further questions your honor
                if (!hasNext)
                {
                    ResetOptions();
                    return;
                }

                _selectedOption = 0;
                SetPointyGuy();
                SetDialogue(nextDialogue);
                
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                // wrapping
                _selectedOption += (_selectedOption >= dialogueOptions.Length - 1 || dialogueOptions[_selectedOption + 1].text == "") ? 0 : 1;
                SetPointyGuy();
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                // wrapping again
                _selectedOption -= (_selectedOption <= 0 || dialogueOptions[_selectedOption - 1].text == "") ? 0 : 1;
                SetPointyGuy();
            }

        }

        private void ResetOptions()
        {
            dialogueText.text = "";
            foreach (TextMeshProUGUI t in dialogueOptions)
            {
                t.text = "";
            }
            
            pointyGuy.gameObject.SetActive(false);
        }

        private void SetPointyGuy()
        {
            TextMeshProUGUI currentOption = dialogueOptions[_selectedOption];
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

            string[] options = dialogue.Options;

            Dialogue[] followingDialogues = dialogue.FollowingDialogues;

            _dialogueOptionsDict = new Dictionary<string, Dialogue>();

            for (int i = 0; i < dialogueOptions.Length; i++)
            {
                if (i < followingDialogues.Length && i < options.Length)
                    _dialogueOptionsDict.Add(options[i], followingDialogues[i]);

                dialogueOptions[i].text = i < options.Length ? options[i] : "";
 
            }
        }
        
    }
}
