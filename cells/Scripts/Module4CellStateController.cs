using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Module4CellStateController : MonoBehaviour
{

    public int cellDivisionCyclePeriod; // cell division cycle length
    public int cellDeathAge;  // cell death age
    public GameObject cell;
    public Slider cellVelocitySDSlider;
    public Slider cellDivisionMeanSlider;
    public Slider cellDivisionSDSlider;
    public Slider cellDeathAgeMeanSlider;
    public Slider cellDeathAgeSDSlider;
    public Slider contactForApoptosis;

    private int age;  // cell age
    private bool readyToMove;
    private bool readyToDivide;
    private bool readyToDie;
    private string eventOccurred;
    private string cellState;
    private int contactCount;
    public int numberCellDivision;
    private float xRandomNumber, yRandomNumber, zRandomNumber;
    private double mean;
    private double standardDeviation;
    private Gaussian gRandom = new Gaussian();

    // Use this for initialization
    void Start()
    {
        age = 0;
        //cellDivisionCycleLength = (int)gRandom.NextGaussian(cellDivisionMeanSlider.value, cellDivisionSDSlider.value);
        cellState = "Move";
        contactCount = 0;
        cellDivisionCyclePeriod = (int)gRandom.NextGaussian(cellDivisionMeanSlider.value, cellDivisionSDSlider.value);
        cellDeathAge = (int)gRandom.NextGaussian(cellDeathAgeMeanSlider.value, cellDeathAgeSDSlider.value);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (cellDivisionCyclePeriod < 1) cellDivisionCyclePeriod = 1; // Minimum cell division cycle period = 1
        if (cellDeathAge < 1) cellDeathAge = 1; // Minimum cell death age = 1

        if (age % (cellDivisionCyclePeriod + 1) == cellDivisionCyclePeriod)
        {
            readyToDivide = true;
            eventOccurred = "readyToDivide";
        }

        else if (((age == cellDeathAge) || contactCount == contactForApoptosis.value) && gameObject.name != "Cell")
        {
            readyToDie = true;
            eventOccurred = "readyToDie";
        }
        else
        {
            readyToMove = true;
            eventOccurred = "readyToMove";
        }

        switch (eventOccurred)
        {
            case "readyToMove": ReadyToMove(); break;
            case "readyToDivide": ReadyToDivide(); break;
            case "readyToDie": ReadyToDie(); break;
        }

        age++; // increase age at every frame (iteration)
    }

    void OnCollisionEnter(Collision other)
    {
        contactCount++;
    }

    void OnCollisionStay(Collision other)
    {
        contactCount++;
    }

    void OnCollisionExit(Collision other)
    {

    }

    void ReadyToMove()
    {
        if (cellState == "Move" || cellState == "Divide") GoStateMove();
    }

    void ReadyToDivide()
    {
        if (cellState == "Move" || cellState == "Divide") GoStateDivide();

    }

    void ReadyToDie()
    {
        if (cellState == "Move") GoStateDie();

    }

    void GoStateMove()
    {
        cellState = "Move";
        Move();

    }
    void GoStateDivide()
    {
        cellState = "Divide";
        Divide();

    }

    void GoStateDie()
    {
        Die();
    }

    void Move()
    {
        if (gameObject.name != "Cell")
        {
            mean = 0;
            standardDeviation = cellVelocitySDSlider.value;

            xRandomNumber = (float)gRandom.NextGaussian(mean, standardDeviation); // Generate a random number in x direction
            yRandomNumber = (float)gRandom.NextGaussian(mean, standardDeviation); // Generate a random number in y direction
            zRandomNumber = (float)gRandom.NextGaussian(mean, standardDeviation); // Generate a random number in z direction
            GetComponent<Transform>().position += new Vector3(xRandomNumber, yRandomNumber, zRandomNumber);
            //GetComponent<Rigidbody>().AddForce(new Vector3(xRandomNumber, yRandomNumber, zRandomNumber)*0.001f);
        }
    }

    void Divide()
    {
        float randomX, randomY, randomZ;
        float randomNumber = Random.Range(0f, 1f);
        if (randomNumber > 0.5)
        {
            randomX = Random.Range(0.5f, 0.6f);
        }
        else
        {
            randomX = Random.Range(-0.5f, -0.6f);
        }
        randomNumber = Random.Range(0f, 1f);
        if (randomNumber > 0.5)
        {
            randomY = Random.Range(0.5f, 0.6f);
        }
        else
        {
            randomY = Random.Range(-0.5f, -0.6f);
        }
        randomNumber = Random.Range(0f, 1f);
        if (randomNumber > 0.5)
        {
            randomZ = Random.Range(0.5f, 0.6f);
        }
        else
        {
            randomZ = Random.Range(-0.5f, -0.6f);
        }
        numberCellDivision++;
        GameObject newCell = (GameObject)Instantiate(cell, GetComponent<Transform>().position + new Vector3(randomX, randomY, randomZ), Quaternion.identity);
        newCell.tag = "NonStemCell";

        //Show differentiation state (green (stem cell) --> red (differentiated cell)

        if (gameObject.name == "Cell") // Stem cell
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(1f, 1f, 0f, 1f); // yellow
            newCell.GetComponent<Renderer>().material.color = new Color(0f, 1f, 0f, 0.2f); // green
        }
        else // Non-stem cell
        {
            newCell.GetComponent<Module4CellStateController>().numberCellDivision = numberCellDivision;
            gameObject.GetComponent<Renderer>().material.color = new Color(numberCellDivision * 0.1f, 1 - numberCellDivision * 0.1f, 0, 0.2f); // becomes more red
            newCell.GetComponent<Renderer>().material.color = new Color(numberCellDivision * 0.1f, 1 - numberCellDivision * 0.1f, 0, 0.2f); // becomes more red
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }


}
