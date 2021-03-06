﻿using System.Collections;
using System.Xml;
using UnityEngine;

public class scr_Lang: MonoBehaviour {

    public static Hashtable UIS;
    public static string language;
    public static int Op_Leng = 0;

    private void Awake()
    {
        Op_Leng = 0;
        if (Application.systemLanguage == SystemLanguage.Spanish)
            Op_Leng = 1;

        setLanguage();
    }

    public static void setLanguage()
    {
        language = "English";

        if (Op_Leng == 1)
        {
            language = "Spanish";
        }

        if (Op_Leng == 2)
        {
            language = "Esperanto";
        }

        TextAsset textAsset = (TextAsset)Resources.Load("UIStrings");
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(textAsset.text);

        UIS = new Hashtable();
        XmlNodeList elements = xml.SelectNodes("/languages/"+ language + "/string");
        //XmlNodeList element = lngs.SelectNodes("/"+language);
        if (elements != null)
        {
            IEnumerator elemEnum = elements.GetEnumerator();
            while (elemEnum.MoveNext())
            {
                XmlElement xmlItem = (XmlElement)elemEnum.Current;
                UIS.Add(xmlItem.GetAttribute("name"), xmlItem.InnerText);
            }
            
            foreach(scr_UILang lg in GameObject.FindObjectsOfType<scr_UILang>())
            {
                lg.SetMyText();
            }
        }
        else
        {
            Debug.LogError("The specified language does not exist: " + language);
        }
    }

    public static string GetText(string key)
    {
        return UIS[key].ToString();
    }
}
