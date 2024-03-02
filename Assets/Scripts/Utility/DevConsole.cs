using System;
using Progression;
using TMPro;
using UnityEngine;

namespace Utility
{
    public class DevConsole : MonoBehaviour
    {
        private bool _enteringCommand = false;
        private string _currentCommand;
        [SerializeField] private TMP_Text text;
        [SerializeField] private Light mainLight;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return) && _enteringCommand)
            {
                ExecuteCommand(_currentCommand);
                _currentCommand = "";

                _enteringCommand = false;
            }

            
            if (_enteringCommand)
            {
                
                if (Input.GetKeyDown(KeyCode.Backspace))
                    _currentCommand = _currentCommand[..^1]; // wizardry
                
                else if (Input.GetKeyDown(KeyCode.Escape))
                {
                    _currentCommand = "";
                    _enteringCommand = false;
                }
                else
                    _currentCommand += Input.inputString;
            }

            text.text = _currentCommand;
            
            if (Input.GetKeyDown(KeyCode.Slash) && !_enteringCommand)
                _enteringCommand = true;

        }

        private void ExecuteCommand(string command)
        {
            string[] args = command.Trim().Split(' ');

            try
            {
                switch (args[0])
                {
                    case "light":
                        mainLight.intensity = float.Parse(args[1]);
                        break;
                    case "stage":
                        StageManager.CurrentStage = (GameStage)int.Parse(args[1]);
                        break;
                    default:
                        Debug.Log("invalid command: \"" + command + "\"");
                        foreach (string arg in args)
                        {
                            Debug.Log("arg: " + arg);
                        }
                        break;
                }
            }
            catch (Exception)
            {
                Debug.Log("Something went wrong with that command");
            }
            
        }
    }
}