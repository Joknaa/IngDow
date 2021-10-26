using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Proto_LevelSwap : MonoBehaviour {

    [SerializeField] private List<GameObject> LevelDimensions;

    private int currentDimensionID = 0;

    public void SwapLevelDimensions() {
        if (currentDimensionID == 0) {
            currentDimensionID = 1;
            LevelDimensions[0].SetActive(false);
            LevelDimensions[1].SetActive(true);
        } else if (currentDimensionID == 1) {
            currentDimensionID = 0;
            LevelDimensions[1].SetActive(false);
            LevelDimensions[0].SetActive(true);
        }
    }

    public void LoadLevel01() {
        currentDimensionID = 0;
        SceneManager.LoadScene(0);
    }
    
    public void LoadLevel02() {
        currentDimensionID = 1;
        SceneManager.LoadScene(1);
    }
}