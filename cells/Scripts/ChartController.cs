using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using CP.ProChart;

public class ChartController : MonoBehaviour {

    public LineChart cellNumberChart;
    ChartData2D dataSet;
    public Text totalCellNumber;
    int totalCellNumberInt;
    int counter;

    // Use this for initialization

    void Start () {
        dataSet = new ChartData2D();
        cellNumberChart.SetValues(ref dataSet);
        counter = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        totalCellNumberInt = GetInt(totalCellNumber.text, 0);
        dataSet[0, counter] = totalCellNumberInt;
        counter++;
        counter = counter % 430;

    }

    int GetInt(string stringValue, int defaultValue)
    {
        int result = defaultValue;
        int.TryParse(stringValue, out result);
        return result;
    }
}
