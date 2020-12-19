using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DropHandler : MonoBehaviour
{
    List<string> levels = new List<string>() { "Select Level", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
    public Dropdown Levels;
    public int a;
    public GameObject g;
    
    public void IndexChange(int index)
    {
        a = index + 1;
        returnVal();
        Debug.Log(a);
        DontDestroyOnLoad(g);
        SceneManager.LoadScene("Game");
    }

    public int returnVal()
    {
        return a;
    }

    private void Start()
    {
        PopulateList();
    }

    void PopulateList()
    {
        Levels.AddOptions(levels);
    }
}
