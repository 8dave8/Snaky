    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class JsonData : MonoBehaviour
{
    string filename = "QnADatas.json";
    public Text Kerdes, Valasz1,Valasz2, Valasz3, Valasz4; 
    string path;
    private string helyes;
    GameData gameData = new GameData();
    // Start is called before the first frame update
    void Start()
    {
        path = Application.persistentDataPath +"/"+filename;
        Debug.Log(path);
        saveData();
    }
    public void readData(int kerd)
    {
        if(File.Exists(path))
        {
            string contents = File.ReadAllText(path);
            JsoWrapper wrapper = JsonUtility.FromJson<JsoWrapper>(contents);
            gameData = wrapper.gameData;
            Debug.Log(gameData+" "+gameData);
            foreach (var data in gameData.kerdes)
            {
                if(data.id == kerd)
                {
                    helyes = data.valasz1;
                    Kerdes.text = data.kerdes;
                    Valasz4.text = data.valasz1;
                    Valasz2.text = data.valasz2;
                    Valasz1.text = data.valasz3;
                    Valasz3.text = data.valasz4;
                }
            }
        }
        else
        {
            Debug.Log("unable to read no file");
            gameData = new GameData();
        }
    }
    public void saveData()
    {
        //kerdesek feltoltese

        Questions k1 = new Questions();
        k1.id = 1;
        k1.kerdes = "Mennyi 1 + 1?";
        k1.valasz1 = "1";
        k1.valasz2 = "2";
        k1.valasz3 = "3";
        k1.valasz4 = "4";
        gameData.kerdes.Add(k1);
        
        Questions k2 = new Questions();
        k2.id = 2;
        k2.kerdes = "Mikor ért véget a II.VH?";
        k2.valasz1 = "1945";
        k2.valasz2 = "1944";
        k2.valasz3 = "1946";
        k2.valasz4 = "1960";
        gameData.kerdes.Add(k2);

        Questions k3 = new Questions();
        k3.id = 3;
        k3.kerdes = "Mikor ért véget a II.VH?";
        k3.valasz1 = "1945";
        k3.valasz2 = "1944";
        k3.valasz3 = "1946";
        k3.valasz4 = "1960";
        gameData.kerdes.Add(k3);

        Questions k4 = new Questions();
        k4.id = 4;
        k4.kerdes = "Mikor ért véget a II.VH?";
        k4.valasz1 = "1945";
        k4.valasz2 = "1944";
        k4.valasz3 = "1946";
        k4.valasz4 = "1960";
        gameData.kerdes.Add(k4);

        Questions k5 = new Questions();
        k5.id = 5;
        k5.kerdes = "Mikor ért véget a II.VH?";
        k5.valasz1 = "1945";
        k5.valasz2 = "1944";
        k5.valasz3 = "1946";
        k5.valasz4 = "1960";
        gameData.kerdes.Add(k5);

        Questions k6 = new Questions();
        k6.id = 6;
        k6.kerdes = "Mikor ért véget a II.VH?";
        k6.valasz1 = "1945";
        k6.valasz2 = "1944";
        k6.valasz3 = "1946";
        k6.valasz4 = "1960";
        gameData.kerdes.Add(k6);

        Questions k7 = new Questions();
        k7.id = 7;
        k7.kerdes = "Mikor ért véget a II.VH?";
        k7.valasz1 = "1945";
        k7.valasz2 = "1944";
        k7.valasz3 = "1946";
        k7.valasz4 = "1960";
        gameData.kerdes.Add(k7);
        //kerdesek mentese
        JsoWrapper wrapper = new JsoWrapper();
        wrapper.gameData = gameData;

        string contents = JsonUtility.ToJson(wrapper, true);
        File.WriteAllText(path, contents);
    }
}
