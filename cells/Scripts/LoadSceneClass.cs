// Collective Robustness of Cells(2016)
// Yong-Jun Shin 
// Computational and Systems Medicine Lab, University of Connecticut 

using UnityEngine;

public class LoadSceneClass : MonoBehaviour {

    public int moduleSceneNumber;
    public void LoadScene(int moduleSceneNumber)
    {
        Application.LoadLevel(moduleSceneNumber);
        Time.timeScale = 1;
    }
}
