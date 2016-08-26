using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NyarLog : MonoBehaviour
{

    #region Variables
    public static NyarLog logger = null;

    [Header("Saved Info")]
    public Dictionary<int, Message> messageDictionary = new Dictionary<int, Message>();

    [Header("Required Components")]
    public Text logText;
    #endregion

    #region Initialisation
    void Awake()
    {
        CheckInstance();
        logText.text = "";
        Log("NyarLog Online.\n");
    }

    void CheckInstance()
    {
        if (logger == null)
            logger = this;
        else if (logger != this)
            Destroy(gameObject);

        int index = transform.GetSiblingIndex();
        transform.SetSiblingIndex(index + 15);
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    #region Message Functions
    /// <summary>
    /// Works similar to Debug.Log(). Try to use strings if possible.
    /// </summary>
    public void Log(object message)
    {
        Message newMessage = new Message(message.ToString());
        logText.text += newMessage.text + "\n";
        messageDictionary.Add(newMessage.ID, newMessage);
    }

    public Message GetMessageByID(int ID)
    {
        Message message;
        messageDictionary.TryGetValue(ID, out message);
        return message;
    }
    #endregion
}

[System.Serializable]
public class Message
{
    public string text;
    public int ID;
    [SerializeField]
    static int lastID;

    public Message(string text)
    {
        this.text = text;
        ID = lastID + 1;
        lastID = ID;
    }

    //Not Recommended
    public Message(string text, int ID)
    {
        this.text = text;
        this.ID = ID;
    }

    public int GetLastID()
    {
        return lastID;
    }
}