    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class JsonData : MonoBehaviour
{
    public GameObject player;
    private System.Random rng = new System.Random();
    string filename = "QnADatas.json";
    public Text Kerdes, Valasz1,Valasz2, Valasz3, Valasz4;
    public Text[] valaszok; 
    string path;
    private string helyes;
    private int kerdesi;
    GameData gameData = new GameData();
    // Start is called before the first frame update
    void Start()
    {
        valaszok = new Text[4];
        valaszok[0] = Valasz1;
        valaszok[1] = Valasz2;
        valaszok[2] = Valasz3;
        valaszok[3] = Valasz4;
        path = Application.persistentDataPath +"/"+filename;
        saveData();
    }
    public void CheckAnsver(int index)
    {
        if(helyes == valaszok[index].text)
        {
            if(kerdesi == 1 && player.GetComponent<HealthConroller>().health != 3)
                player.GetComponent<HealthConroller>().addHealth();
                Destroy(gameObject);
            if(kerdesi == 2)
            {
                Debug.Log("kerdes2");
                player.GetComponent<PlayerMovement>().rundpeed = 50;
                StartCoroutine("stoprun", player);
                Destroy(gameObject);
            }


            
            GetComponent<bookController>().bezar();
        }
    }
    IEnumerator stoprun(GameObject player)
    {
        Debug.Log("stoprun");
        yield return new WaitForSeconds(3);
        player.GetComponent<PlayerMovement>().rundpeed = 25;
        Debug.Log("stoprun");        
    }
    public void readData(int kerd)
    {
        kerdesi = kerd;
        if(File.Exists(path))
        {
            string contents = File.ReadAllText(path);
            JsoWrapper wrapper = JsonUtility.FromJson<JsoWrapper>(contents);
            gameData = wrapper.gameData;
            foreach (var data in gameData.kerdes)
            {
                if(data.id == kerd)
                {
                    helyes = data.valasz1;
                    Kerdes.text = data.kerdes;
                    string[] datas = new string[4];
                    datas[0] = data.valasz1;
                    datas[1] = data.valasz2;
                    datas[2] = data.valasz3;
                    datas[3] = data.valasz4;
                    int[] tmp = new int[4];
                    for (int i = 0; i < 4; i++) tmp[i] = i;
                    for (int t = 0; t < tmp.Length; t++ )
                    {
                        int tmpp = tmp[t];
                        int r = Random.Range(t, tmp.Length);
                        tmp[t] = tmp[r];
                        tmp[r] = tmpp;
                    }
                    for (int i = 0; i < 4; i++) valaszok[i].text = datas[tmp[i]];
                    /*
                    Valasz4.text = data.valasz1;
                    Valasz2.text = data.valasz2;
                    Valasz1.text = data.valasz3;
                    Valasz3.text = data.valasz4;
                    */
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
        k1.valasz1 = "2";
        k1.valasz2 = "1";
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
