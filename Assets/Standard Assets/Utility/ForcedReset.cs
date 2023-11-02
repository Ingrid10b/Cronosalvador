using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

#pragma warning disable 618
[RequireComponent(typeof (Image))]
public class ForcedReset : MonoBehaviour
{
    private void Update()
    {
        // if we have forced a reset ...
<<<<<<< HEAD
        if (CrossPlatformInputManager.GetButtonDown("ResetObject"))
=======
        //if (CrossPlatformInputManager.GetButtonDown("ResetObject"))
>>>>>>> develop
        {
            //... reload the scene
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        }
    }
}
