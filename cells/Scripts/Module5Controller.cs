using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Module5Controller : MonoBehaviour
{

    public GameObject cell;
    public Text totalCellNumber;
    public GameObject wallPrefab;
    public float wallSize;

    private GameObject[] cells;
    private GameObject newCell;
    private GameObject[] nonStemCells;
    private GameObject[] stemCells;
    private GameObject[] walls;


    // Use this for initialization
    void Start()
    {
        walls = new GameObject[6];
        cell.GetComponent<MeshRenderer>().enabled = true;
        //  Create a new graph named "TotalCellNumber", with a range of 0 to 600, colour red at position 20,80
        //PlotManager.Instance.PlotCreate("TotalCellNumber", 0, 600, Color.red, new Vector2(20, 80));

        walls[0] = (GameObject) Instantiate(wallPrefab, new Vector3(0, 0, wallSize / 2 ), Quaternion.identity);
        walls[0].GetComponent<Transform>().localScale = new Vector3(wallSize, wallSize, 1f);
        walls[1] = (GameObject)Instantiate(wallPrefab, new Vector3(0, 0, -wallSize / 2 ), Quaternion.identity);
        walls[1].GetComponent<Transform>().localScale = new Vector3(wallSize, wallSize, 1f);
        walls[2] = (GameObject)Instantiate(wallPrefab, new Vector3(0, wallSize / 2, 0), Quaternion.identity);
        walls[2].GetComponent<Transform>().localScale = new Vector3(wallSize, 1f, wallSize);
        walls[3] = (GameObject)Instantiate(wallPrefab, new Vector3(0, -wallSize / 2, 0), Quaternion.identity);
        walls[3].GetComponent<Transform>().localScale = new Vector3(wallSize, 1f, wallSize);
        walls[4] = (GameObject)Instantiate(wallPrefab, new Vector3(wallSize / 2, 0, 0 ), Quaternion.identity);
        walls[4].GetComponent<Transform>().localScale = new Vector3(1f, wallSize, wallSize);
        walls[5] = (GameObject)Instantiate(wallPrefab, new Vector3(-wallSize / 2, 0, 0), Quaternion.identity);
        walls[5].GetComponent<Transform>().localScale = new Vector3(1f, wallSize, wallSize);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        stemCells = GameObject.FindGameObjectsWithTag("StemCell");
        nonStemCells = GameObject.FindGameObjectsWithTag("NonStemCell");
        totalCellNumber.text = (nonStemCells.Length + stemCells.Length).ToString(); // Show the number on the screen
        if (nonStemCells.Length + stemCells.Length > 500) Time.timeScale = 0; // If the number of cells is more than 500 pause the simulation
    }
    public void AddCell()
    {
        if (stemCells.Length > 0)
        {
            newCell = (GameObject)Instantiate(cell, new Vector3(0, 0, 0), Quaternion.identity);
            newCell.tag = "NonStemCell";
        }

    }

    public void RemoveCell()
    {
        nonStemCells = GameObject.FindGameObjectsWithTag("NonStemCell");
        if (nonStemCells.Length > 0) Destroy(nonStemCells[0]);
    }
}

