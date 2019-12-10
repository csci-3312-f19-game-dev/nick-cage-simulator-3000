using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalOutputManager : MonoBehaviour
{
    public Text line1;
    public Text line2;
    public Text line3;
    public Text line4;
    public Text line5;
    public Text line6;
    public Text line7;
    public Text line8;
    public Text line9;
    public Text line10;
    public Text line11;
    public Text line12;
    private string[] outputs;
    private int numOutputs;
    public static JournalOutputManager Journal;
    private void Awake()
    {
        Journal = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        outputs = new string[12];
        numOutputs = 0;
        updateOutputs();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addOutput(string output)
    {
        if (numOutputs < 12)
        {
            //we don't need to deal with overflow
            outputs[numOutputs] = output;
            numOutputs++;
        }
        else
        {
            shiftOutputsUp();
            outputs[10] = output;
            numOutputs--;
        }
        updateOutputs();
    }

    private void shiftOutputsUp()
    {
        for (int i = 1; i < 11; i++)
        {
            outputs[i - 1] = outputs[i];
            outputs[i] = "";
        }
        updateOutputs();
    }

    private Text getCorrectField(int number)
    {
        switch (number)
        {
            case 0: return line1;
            case 1: return line2;
            case 2: return line3;
            case 3: return line4;
            case 4: return line5;
            case 5: return line6;
            case 6: return line7;
            case 7: return line8;
            case 8: return line9;
            case 9: return line10;
            case 10: return line11;
            case 11: return line12;
            default: return null;
        }
    }

    private void updateOutputs()
    {
        for (int i = 0; i < 12; i++)
        {
            Text field = getCorrectField(i);
            field.text = outputs[i];
        }
    }
}
