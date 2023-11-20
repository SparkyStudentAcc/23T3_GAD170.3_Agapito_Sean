using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button resetButton;

    [SerializeField] Button catchButton;
    [SerializeField] Button releaseButton;
    bool gameActive = false;
    bool gameEnd = false;
    int turn = 0;

    [SerializeField] TextMeshProUGUI turntext;
    [SerializeField] TextMeshProUGUI fishInfo;

    List<GameObject> Aquarium = new List<GameObject>();
    public GameObject Fish;

    void Start()
    {
        turn = 0;
        catchButton.gameObject.SetActive(false);
        releaseButton.gameObject.SetActive(false);


        //Debug.Log(Aquarium[0].GetComponent<Fish>().species);
        //The line below is a much faster way of doing this process
        //Debug.Log(GetSpecies(1));
    }

    void GenerateFish()
    {
        //Fish game object is instantiated and added into the aquarium
        GameObject fishy = Instantiate(Fish,Vector3.zero, Quaternion.identity);
        Aquarium.Add(fishy);

        fishInfo.text = GetSpecies(Aquarium.Count - 1) + ", Length: " + GetLength(Aquarium.Count - 1) + "cm , $" + GetValue(Aquarium.Count - 1);
        //Vomit
        //newMessage(GetSpecies(Aquarium.Count - 1)+ ", Length: " + GetLength(Aquarium.Count - 1) + "cm , $" + GetValue(Aquarium.Count - 1));
    }
    //Add fish details
    // newMessage(GetSpecies(), GetLength(), GetValue());


    //no way in hell am i typing all this again
    string GetSpecies(int i)
    {
        return Aquarium[i].GetComponent<Fish>().species;
    }
    int GetValue(int i)
    {
        return Aquarium[i].GetComponent<Fish>().value;
    }
    float GetLength(int i)
    {
        return Mathf.Round(Aquarium[i].GetComponent<Fish>().length * 100f)/100f;
    }

    int Calculate()
    {
        int total = 0;
        int x = 0;

        while (x < Aquarium.Count - 1)
        {
            total = total + GetValue(x);
            x = x + 1;
        }

        return total;
    }

    void Compare()
    {
        
        int x = 0;

        while (x < Aquarium.Count - 2)
        { 
            if (GetLength(Aquarium.Count - 1) > 2* GetLength(x) )
            {
                Aquarium.RemoveAt(x);
                Destroy(messageList[x].textObject);
                messageList.RemoveAt(x);
            }
            x = x + 1;
        }
    }



    void Update()
    {
        turntext.text = turn.ToString();
        //button visibility
        resetButton.gameObject.SetActive(gameEnd);
        startButton.gameObject.SetActive(!gameActive);
        


        // after 10 turns the game ends
        if (turn >= 10)
        {
            gameEnd = true;
            catchButton.gameObject.SetActive(false);
            releaseButton.gameObject.SetActive(false);
            fishInfo.text = "Congratulations! your total is! $" + Calculate();
        }
        

        //debug controls
        //if(Input.GetKeyDown(KeyCode.Space)){
            //gameEnd = true;
            //Destroy(messageList[0].textObject);
            //messageList.Remove(messageList[0]);
            //ResetGame();
        //}
        
    }


    public void StartGame()
    {
        gameActive = true;
        GenerateFish();
        catchButton.gameObject.SetActive(true);
        releaseButton.gameObject.SetActive(true);
        
    }
     public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    public void Catch()
    {
        turn = turn + 1;
        newMessage(GetSpecies(Aquarium.Count - 1) + ", Length: " + GetLength(Aquarium.Count - 1) + "cm , $" + GetValue(Aquarium.Count - 1));
        GenerateFish();
        Compare();
    }

    public void Release()
    {
        turn = turn + 1;

        Aquarium.RemoveAt(Aquarium.Count - 1);
        GenerateFish();
    }


    //this section is from project 1 (UI text)

    [SerializeField]
    List<Message> messageList = new List<Message>();
    public GameObject textAsset, chatpanel;


    public void newMessage(string text)
    {
        
        
            Message interaction = new Message();
            interaction.text = text;


            GameObject newText = Instantiate(textAsset, chatpanel.transform);
            interaction.textObject = newText.GetComponent<TextMeshProUGUI>();
            interaction.textObject.text = text;


            messageList.Add(interaction);
        
    }

    [System.Serializable]
    public class Message
    {
        public string text;
        public TextMeshProUGUI textObject;
    }
}
