using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Module4Controller : MonoBehaviour
{


    public GameObject cell;
    private GameObject newCell;
    private GameObject[] nonStemCells;
    private GameObject[] stemCells;
    public Text totalCellNumber;

    // Use this for initialization
    void Start()
    {
        cell.GetComponent<MeshRenderer>().enabled = true;
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

