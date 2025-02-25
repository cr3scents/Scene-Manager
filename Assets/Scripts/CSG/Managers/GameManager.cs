/*
* COPYRIGHT       : 2025
* PROJECT         : Scene Manager Assignment
* FILE NAME       : GameManager.cs
* DESCRIPTION     : Manages
*                    
* REVISION HISTORY:
* Date          Author              Comments
* ---------------------------------------------------------------------------
* 02.19.25      Julia Gaskin        Created script, all the programming.
* 02.25.25      Julia Gaskin        Debugging.
*/

using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.XR;
using SceneManager = CSG.Managers.SceneManager;

/*** GAME STATES ***/
public enum GameState {
    Default,
    MainMenu,
    Paused,
    Playing,
    GameOver,
    Idle,
    Restart,
    QuitGame
}

namespace CSG.Managers {
    public class GameManager : General.Singleton<GameManager> {
        
        /*** public variables ***/
        public GameState currentState = GameState.Idle;
        
        // START //
        void Start() {
            // set game state to Main Menu
            ChangeState(GameState.MainMenu);
        }

        // UPDATE //
        void Update() {
            // only expensive if GS is Main Menu or GameOver bc
            // SceneManager's OnSceneChangeRequest is expensive
            ManageGameState();
        }

        // MANAGE GAME STATE //
        void ManageGameState() {
            switch (currentState) {
                case GameState.Default:
                    currentState = GameState.Idle;
                    break;
                    
                case GameState.MainMenu:
                    SceneManager.Instance.OnSceneChangeRequest("MainMenu");
                    break;
                
                case GameState.Paused:
                    break;
                
                case GameState.Playing:
                    break;
                
                case GameState.GameOver:
                    SceneManager.Instance.OnSceneChangeRequest("GameOver");
                    break;
                
                case GameState.Idle:
                    ChangeState(GameState.MainMenu);
                    break;
                
                case GameState.Restart:
                    SceneManager.Instance.UnloadAllScenes();
                    ChangeState(GameState.Idle);
                    break;
                
                case GameState.QuitGame:
                    QuitGame();
                    break;
            }
        }

        // CHANGE GAME STATE //
        public void ChangeState(GameState newState) {
            currentState = newState;
            ManageGameState();
        }
        
        // START GAME //
        
        // START LEVEL //
        void StartLevel(string levelName = null) {
            SceneManager.Instance.GetGameLevel(levelName);
            ChangeState(GameState.Playing);
        }
        
        // TOGGLE PAUSE //
        public void TogglePause() {
            if (currentState == GameState.Paused) {
                ChangeState(GameState.Playing);
                Time.timeScale = 1;
                SceneManager.Instance.UnloadScene("PauseMenu");
            } else {
                ChangeState(GameState.Paused);
                Time.timeScale = 0;
                SceneManager.Instance.OnSceneChangeRequest("PauseMenu", true);
            }
        }
        
        // QUIT GAME //
        void QuitGame() {
            
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
            
            Application.Quit();
        }
    }
    
}
