using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiddleCutscene : MonoBehaviour
{
    public void AnimationEnd(){
        SceneManager.LoadScene("HouseDerivative");
    }
}
