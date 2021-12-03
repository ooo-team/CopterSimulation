using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;
using System.IO;

public class TransformTracker : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeout = 0f;
    public float period = 0.01f;

    public Boolean collect = true;
    Transform tm;

    Rigidbody rb;
    string fname;
    StreamWriter writer;
    StreamReader reader;
    void Start()
    {
      tm = GetComponent<Transform>(); 
      rb = GetComponent<Rigidbody>();
      fname = String.Format("Assets/Resources/" + gameObject.name + ".json");
      
      if (collect) {
        writer = new StreamWriter(fname, false);  
        writer.AutoFlush = true;
        InvokeRepeating("CollectData", timeout, period);
      } else {
        reader = new StreamReader(fname);
        string first = reader.ReadLine();
        Debug.Log(first);
        InvokeRepeating("RestoreData", timeout, period);
      }
    }
    [Serializable]
    public class Info {
      public Vector3 coords;
      public Quaternion rotation;
    }


    void CollectData()
    {
      Info info = new Info();
      info.coords = tm.position;
      info.rotation = tm.rotation;
      string json = JsonUtility.ToJson(info);
      writer.WriteLine(json);
    }

    void RestoreData()
    {
      if (!reader.EndOfStream) {
        Info info = new Info();
        string json = reader.ReadLine();
        info = JsonUtility.FromJson<Info>(json);
        tm.SetPositionAndRotation(info.coords, info.rotation);
      } else {
        rb.velocity = new Vector3(0, 0, 0);
      }
      
    }
    void Update () {
    }

    void OnDestroy() {
      if (collect) {
        writer.Close();
      } else {
        reader.Close();
      }
    }

}
