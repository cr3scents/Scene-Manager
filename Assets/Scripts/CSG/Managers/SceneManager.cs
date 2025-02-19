/*
* COPYRIGHT       : 2025
* PROJECT         : Scene Manager Assignment
* FILE NAME       : SceneManager.cs
* DESCRIPTION     : Manages scene changes.
*                    
* REVISION HISTORY:
* Date          Author              Comments
* ---------------------------------------------------------------------------
* 02.13.25      Julia Gaskin        Created script.
* 02.19.25      Julia Gaskin        Formatting, all the programming.
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using CSG.General;
using UnityEngine.SceneManagement;

namespace CSG.Managers {

    /*** SCENE MANAGER CLASS ***/
    public class SceneManager : Singleton<SceneManager> {

        /*** public variables ***/
        public string[] gameLevels;

        /*** private variables ***/
        private string gameLevelToLoad;
        private int gameLevelIndex;
        private List<string> loadedScenes; // ???

        // START //
        void Start() {
            // set private variables
            gameLevelToLoad = string.Empty;
            gameLevelIndex = -1;
            loadedScenes = new List<string>();
        }

        // SCENE CHANGE REQUEST //
        public void OnSceneChangeRequest(string sceneName, bool isAdditive = false) {
            LoadSceneMode loadMode;

            // if scene is not already loaded
            if (loadedScenes.Contains(sceneName)) {
                if (isAdditive) {
                    loadMode = LoadSceneMode.Additive;
                }
                else {
                    loadMode = LoadSceneMode.Single;
                }

                StartCoroutine(LoadSceneAsync(sceneName, loadMode));
            }
        }

        // GET NEXT GAME LEVEL //
        public void GetGameLevel(string gameLevelName = null) {
            if (gameLevelName == null) {
                gameLevelIndex++;

                // check if index > the number of levels
                if (gameLevelIndex > gameLevels.Length - 1) {
                    Debug.Log("gameLevelIndex exceeds length of gameLevels.");
                }
                else if (gameLevels.Contains(gameLevelName)) {
                    gameLevelIndex = Array.IndexOf(gameLevels, gameLevelName);
                }
                else {
                    Debug.Log("gameLevelName could not be found in list of gameLevels. Setting gameLevelIndex to 0.");
                    gameLevelIndex = 0;
                }

                gameLevelToLoad = gameLevels[gameLevelIndex];
                OnSceneChangeRequest(gameLevelToLoad);
            }
        }

        // UNLOAD SCENE //
        public void UnloadScene(string sceneName) {
            if (loadedScenes.Contains(sceneName)) {
                StartCoroutine(UnloadSceneAsync(sceneName));
            }
        }

        // LOAD SCENE COROUTINE //
        private IEnumerator LoadSceneAsync(string sceneName, LoadSceneMode loadMode) {
            string currentScene = string.Empty;

            // check if scene is loading properly
            AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName, loadMode);
            if (asyncLoad == null) {
                Debug.Log("Error loading scene.");
                yield break;
            }

            // if only one scene is running
            if (loadMode == LoadSceneMode.Single) {
                currentScene = sceneName;
            }

            // wait for scene to finish loading
            while (!asyncLoad.isDone) {
                yield return null;
            }

            loadedScenes.Add(currentScene);
        }

        // UNLOAD SCENE COROUTINE //
        private IEnumerator UnloadSceneAsync(string sceneName) {

            // check if scene is unloading properly
            AsyncOperation asyncUnload = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName);
            if (asyncUnload == null) {
                Debug.Log("Error unloading scene.");
                yield break;
            }

            // wait for scene to finish unloading
            while (!asyncUnload.isDone) {
                yield return null;
            }

            loadedScenes.Remove(sceneName);
        }

        // UNLOAD ALL SCENES (called on Restart) //
        public void UnloadAllScenes() {
            loadedScenes.Clear();
            gameLevelIndex = -1;
        }

    }

}
