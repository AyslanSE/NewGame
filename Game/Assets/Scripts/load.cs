using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml.Linq;
using System.Text;
using System.IO;

[DataContract]
public class save1
{
    [DataMember] private GameObject _save;

    public GameObject save
    {
        get { return _save; }
        set { _save = value; }
    }
    [DataMember] public string scene;
}
[DataContract]
public class save2
{
    [DataMember] private GameObject _save;

    public GameObject save
    {
        get { return _save; }
        set { _save = value; }
    }
    [DataMember] public string scene;
}
[DataContract]
public class save3
{
    [DataMember] private GameObject _save;

    public GameObject save
    {
        get { return _save; }
        set { _save = value; }
    }
    [DataMember] public string scene;
}
[Serializable]
public class load : MonoBehaviour
{
    [SerializeField] private Button loadButton;
    private string localsave1, localsave2, localsave3;

    public GameObject Mysave;
    public string _scene;
    public void Start()
    {
        localsave1 = Application.persistentDataPath + "/save1.dat";
        localsave2 = Application.persistentDataPath + "/save2.dat";
        localsave3 = Application.persistentDataPath + "/save3.dat";

        if (File.Exists(localsave1) || File.Exists(localsave2) || File.Exists(localsave3))
            loadButton.interactable = true;
        else
            loadButton.interactable = false;
    }
    public void loadgame(int save)
    {
        if (File.Exists(localsave1) && save == 1)
        {
            FileStream file = File.Open(localsave1, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(save1));
            save1 data;

            using (Stream reader = new FileStream(localsave1, FileMode.Open))
            {
                data = (save1)serializer.Deserialize(reader);
                Mysave = data.save;
            }
        }
    }
    public void save(int save)
    {
        if (save == 1)
        {
            FileStream file = File.Create(localsave1);
            save1 data = new save1();

            data.save = Mysave;
            data.scene = _scene;

            DataContractSerializer bf = new DataContractSerializer(data.GetType());
            MemoryStream streamer = new MemoryStream();

            bf.WriteObject(streamer, data);
            streamer.Seek(0, SeekOrigin.Begin);

            file.Write(streamer.GetBuffer(), 0, streamer.GetBuffer().Length);

            file.Close();

            string result = XElement.Parse(Encoding.ASCII.GetString(streamer.GetBuffer()).Replace("\0", "")).ToString();
            Debug.Log("Serialized Result: " + result);
        }
        else if (save == 2)
        {
            FileStream file = File.Create(localsave2);
            save2 data = new save2();

            data.save = Mysave;
            data.scene = _scene;

            DataContractSerializer bf = new DataContractSerializer(data.GetType());
            MemoryStream streamer = new MemoryStream();

            bf.WriteObject(streamer, data);
            streamer.Seek(0, SeekOrigin.Begin);

            file.Write(streamer.GetBuffer(), 0, streamer.GetBuffer().Length);

            file.Close();

            string result = XElement.Parse(Encoding.ASCII.GetString(streamer.GetBuffer()).Replace("\0", "")).ToString();
            Debug.Log("Serialized Result: " + result);
        }
        else if (save == 3)
        {
            FileStream file = File.Create(localsave3);
            save3 data = new save3();

            data.save = Mysave;
            data.scene = _scene;

            DataContractSerializer bf = new DataContractSerializer(data.GetType());
            MemoryStream streamer = new MemoryStream();

            bf.WriteObject(streamer, data);
            streamer.Seek(0, SeekOrigin.Begin);

            file.Write(streamer.GetBuffer(), 0, streamer.GetBuffer().Length);

            file.Close();

            string result = XElement.Parse(Encoding.ASCII.GetString(streamer.GetBuffer()).Replace("\0", "")).ToString();
            Debug.Log("Serialized Result: " + result);
        }
    }
}