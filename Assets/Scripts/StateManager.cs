using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    GameObject player;
    FirstPersonLook fpLook;
    FirstPersonMovement fpMove;
    Jump fpJump;
    Crouch fpCrouch;
    GameSettings gameSettings;
    
    bool ingameState;
    bool pausemenuState;
    bool readingState;
    bool optionsState;
    bool canMove;
    bool canLook;

    GameObject ingameUI;
    GameObject pausemenuUI;
    GameObject readingUI;
    GameObject optionsUI;

    //BUG
    bool bugKey;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        fpMove = player.GetComponent<FirstPersonMovement>();
        fpCrouch = player.GetComponent<Crouch>();
        fpJump = player.GetComponent<Jump>();
        fpLook = player.GetComponentInChildren<FirstPersonLook>();
        gameSettings = GetComponent<GameSettings>();
        ingameUI = GameObject.FindGameObjectWithTag("Ingame");
        pausemenuUI = GameObject.FindGameObjectWithTag("Pausemenu");
        readingUI = GameObject.FindGameObjectWithTag("Reading");
        optionsUI = GameObject.FindGameObjectWithTag("Options");
    }
    void Start()
    {
        _pausemenuState();
    }

    void Update()
    {
        #region In-Game State
        if (ingameState) {
            pausemenuState = false;
            readingState = false;
            optionsState = false;
            canMove = true;
            canLook = true;
            fpLook._lockMouse();
            ingameUI.SetActive(true);
            if (Input.GetKeyDown(gameSettings.pauseKey))
            {
                if (ingameState && !bugKey){
                    bugKey = true;
                    _pausemenuState();
                }
            }

        } else {
            ingameUI.SetActive(false);
        }
        #endregion
        #region Pause Menu State
        if (pausemenuState) {
            ingameState = false;
            readingState = false;
            optionsState = false;
            canMove = false;
            canLook = false;
            fpLook._unlockMouse();
            pausemenuUI.SetActive(true);

            if (Input.GetKeyDown(gameSettings.pauseKey))
            {
                if (pausemenuState && !bugKey){
                    _ingameState();
                    bugKey = true;
                }
            }

        } else {
            pausemenuUI.SetActive(false);
        }
        #endregion


        #region Reading State
        if (readingState) {
            pausemenuState = false;
            ingameState = false;
            optionsState = false;
            canMove = false;
            canLook = false;
            readingUI.SetActive(true);
        } else {
            readingUI.SetActive(false);
        }
        #endregion

        #region Options Menu State
        if (optionsState) {
            pausemenuState = false;
            ingameState = false;
            readingState = false;
            canMove = false;
            canLook = false;
            optionsUI.SetActive(true);
            if (Input.GetKeyDown(gameSettings.pauseKey))
            {
                if (optionsState && !bugKey){
                    _pausemenuState();
                    bugKey = true;
                }
            }
        } else {
            optionsUI.SetActive(false);
        }
        #endregion
        
        #region BUG KEY
        if (Input.GetKeyUp(gameSettings.pauseKey)){
            bugKey = false;
        }
        #endregion

        #region canLook, canMove
        if (canLook) {
            fpLook.sensitivity = gameSettings.mouseSensitivity;
        } else {
            fpLook.sensitivity = 0;
        }
        if (canMove) {
            fpMove.speed = gameSettings.playerSpeed;
            fpMove.runSpeed = gameSettings.playerRunSpeed;
            fpCrouch.key = gameSettings.crouchKey;
            fpJump.key = gameSettings.jumpKey;
        } else {
            fpMove.speed = 0;
            fpMove.runSpeed = 0;
            fpCrouch.key = KeyCode.None;
            fpJump.key = KeyCode.None;
        }
        #endregion

        #region DEBUG
        if (Input.GetKeyDown(KeyCode.Keypad7)){
            _ingameState();
        }
        if (Input.GetKeyDown(KeyCode.Keypad8)){
            _pausemenuState();
        }
        if (Input.GetKeyDown(KeyCode.Keypad9)){
            _readingState();
        }
        #endregion
    }

    #region FUNCTIONS
    void _resetStates()
    {
        ingameState = false;
        readingState = false;
        pausemenuState = false;
    }
    
    public void _ingameState()
    {
        _resetStates();
        ingameState = true;
    }
    public void _pausemenuState()
    {
        _resetStates();
        pausemenuState = true;
    }
    public void _readingState()
    {
        _resetStates();
        readingState = true;
    }
    public void _optionsState()
    {
        _resetStates();
        optionsState = true;
    }
    public void _quitApplication(){
        Application.Quit();
    }
    #endregion
}