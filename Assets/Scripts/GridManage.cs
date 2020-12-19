using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManage : MonoBehaviour
{
    private GameObject[,] grid;
    int vertical, horitontal, columns, rows;
    DropHandler dh;
    public GameObject prefabs;
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        dh = GameObject.FindObjectOfType<DropHandler>();
        rows = dh.returnVal();
        columns = dh.returnVal();
        vertical = (int)Camera.main.orthographicSize;
        horitontal = vertical * (Screen.width / Screen.height);
        grid = new GameObject[columns, rows];

        for(int i = 0; i < columns; i++)
        {
            for(int j = 0; j < rows; j++)
            {
                grid[i, j] = spawnTile(i, j);
            }
        }
        
    }

    public GameObject spawnTile(int x, int y)
    {
        GameObject g = Instantiate(prefabs, new Vector3(x - (horitontal - 0.5f), y - (vertical - 0.5f)), Quaternion.identity);
        var rectTransform = g.GetComponent<RectTransform>();
        rectTransform.SetParent(canvas.transform);
        g.transform.localScale = g.transform.localScale - new Vector3(5.8f, 34.7f, 58.0f);
        g.GetComponent<Button>().onClick.AddListener(() => StartCoroutine(OnSelectt(x,y)));
        return g;
    }

    IEnumerator OnSelectt(int a, int b)
    {
        for(int c = 0; c < columns; c++)
        {
            for(int d = 0; d < rows; d++)
            {
                if (grid[c, d].GetComponent<Button>().interactable == true)
                {
                    if ((a + b) == (c + d) || (a - b) == (c - d))
                    {
                        if (c == a & d == b)
                        {
                            grid[c, d].GetComponent<Image>().color = Color.yellow;
                            grid[c, d].GetComponent<Button>().interactable = false;
                        }
                        else
                        {
                            grid[c, d].GetComponent<Image>().color = Color.blue;
                            grid[c, d].GetComponent<Button>().interactable = false;
                        }
                        Debug.Log(c + "," + d);
                    }
                }
            }
        }

        yield return new WaitForSeconds(1.0f);

        for (int c = 0; c < columns; c++)
        {
            for (int d = 0; d < rows; d++)
            {
                if ((c + d) == (a + b) || (c - d) == (a - b))
                {
                    grid[c, d].GetComponent<Image>().color = Color.red;
                }
            }
        }
    }

}
