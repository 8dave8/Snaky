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
        player.GetComponent<PlayerMovement>().rundpeed = 32;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        Physics2D.gravity = new Vector2(0f,-12f);
    }
    public void checkAnsver(int index)
    {
        if(helyes == valaszok[index].text)
        {
            if(kerdesi == 1 && player.GetComponent<HealthConroller>().health != 3)
            {
                player.GetComponent<HealthConroller>().addHealth();
                Destroy(gameObject);
            }
            if(kerdesi == 2)
            {
                player.GetComponent<PlayerMovement>().rundpeed = 50;
                StartCoroutine("stopBonuses");
            }
            if(kerdesi == 3 || kerdesi == 4)
            {
                Physics2D.gravity = new Vector2(0f,-3f);
                StartCoroutine("stopBonuses");
            }
            if(kerdesi == 5)
            {
                var enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (var e in enemies)
                {
                    try
                    {
                        e.GetComponent<EnemyController>().receiveDamage();
                    }
                    catch (System.Exception)
                    {
                        break;
                        throw;
                    }
                }
                StartCoroutine("stopBonuses");
            }
            if(kerdesi == 6)
            {
                player.GetComponent<HealthConroller>().kerdesdmg = true;
                StartCoroutine("stopBonuses");
            }
            if(kerdesi == 7)
            {
                StartCoroutine("jump");
                StartCoroutine("stopBonuses");
            }
            if(kerdesi == 8)
            {
                player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
                player.GetComponent<Rigidbody2D>().freezeRotation = true;
                StartCoroutine("stopBonuses");
            }
            if(kerdesi == 9)
            {
                player.GetComponent<PlayerMovement>().rundpeed = 25;
                StartCoroutine("stopBonuses");
            }
            if(kerdesi == 10)
            {
                player.GetComponent<PlayerMovement>().rundpeed = 50;
                StartCoroutine("stopBonuses");
            }
        }
        else if(kerdesi != 1) Destroy(gameObject);
        GetComponent<bookController>().closeBookMenu();
    }
    IEnumerator jump()
    {
        player.GetComponent<Rigidbody2D>().AddForce(new Vector2(10,60),ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5f);
        player.GetComponent<Rigidbody2D>().AddForce(new Vector2(800,-20),ForceMode2D.Impulse);
    }
    public IEnumerator stopBonuses()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(15f);
        player.GetComponent<PlayerMovement>().rundpeed = 32;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        Physics2D.gravity = new Vector2(0f,-12f);
        Destroy(gameObject);
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
        k1.kerdes = "Mikor halt meg József Attila?";
        k1.valasz1 = "1937";
        k1.valasz2 = "1892";
        k1.valasz3 = "1924";
        k1.valasz4 = "1925";
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
        k3.kerdes = "Ki volt Churchill";
        k3.valasz1 = "Politikus";
        k3.valasz2 = "Szinesz";
        k3.valasz3 = "Tanár";
        k3.valasz4 = "Tábornok";
        gameData.kerdes.Add(k3);

        Questions k4 = new Questions();
        k4.id = 4;
        k4.kerdes = "Melyik Shakespeare műve?";
        k4.valasz1 = "Ahogy tetszik";
        k4.valasz2 = "Tartuffe";
        k4.valasz3 = "A tóték";
        k4.valasz4 = "Város a tengerben";
        gameData.kerdes.Add(k4);

        Questions k5 = new Questions();
        k5.id = 5;
        k5.kerdes = "Hol született Mátyás király?";
        k5.valasz1 = "Kolozsvár";
        k5.valasz2 = "Székesfehérvár";
        k5.valasz3 = "Bécs";
        k5.valasz4 = "Székelyudvarhely";
        gameData.kerdes.Add(k5);

        Questions k6 = new Questions();
        k6.id = 6;
        k6.kerdes = "Melyik a helyes Pitagorasz tétel?";
        k6.valasz1 = "c^2 = a^2 + b^2";
        k6.valasz2 = "b^2 = a^2 + c^2";
        k6.valasz3 = "a^2 = b^2 + c^2";
        k6.valasz4 = "c^2 = a^3 + b^2";
        gameData.kerdes.Add(k6);

        Questions k7 = new Questions();
        k7.id = 7;
        k7.kerdes = "Hogyan folytatódik? 'Sehonnani bitang ember,'";
        k7.valasz1 = "Ki most, ha kell, halni nem mer,";
        k7.valasz2 = "Máltó régi nagy hiréhez,";
        k7.valasz3 = "Unokáink leborulnak,";
        k7.valasz4 = "Kárhozottak ősapáink,";
        gameData.kerdes.Add(k7);

        Questions k8 = new Questions();
        k8.id = 8;
        k8.kerdes = "Melyik Arany János verse?";
        k8.valasz1 = "Mátyás anyja";
        k8.valasz2 = "Szeptemer végén";
        k8.valasz3 = "Arany Lacinak";
        k8.valasz4 = "A föl-földobott kő";
        gameData.kerdes.Add(k8);

        Questions k9 = new Questions();
        k9.id = 9;
        k9.kerdes = "Minek az istennője Aphrodité";
        k9.valasz1 = "A szerelemé";
        k9.valasz2 = "A halottaké";
        k9.valasz3 = "A tavaszé";
        k9.valasz4 = "A termés";
        gameData.kerdes.Add(k9);

        Questions k10 = new Questions();
        k10.id = 10;
        k10.kerdes = "Hány éle van egy deltoidnak?";
        k10.valasz1 = "4";
        k10.valasz2 = "3";
        k10.valasz3 = "5";
        k10.valasz4 = "6";
        gameData.kerdes.Add(k10);
        //kerdesek mentese
        JsoWrapper wrapper = new JsoWrapper();
        wrapper.gameData = gameData;

        string contents = JsonUtility.ToJson(wrapper, true);
        File.WriteAllText(path, contents);
    }
}
