using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Search : MonoBehaviour
{

    public Text output;
    public Text input;
    public Text delete;
    public Text search;


    public Text charOutput;
    public Text charInput;
    public Text charDelete;
    public Text charSearch;

    public Text generateWord;
    public Text generateOut;

    public Text consol;

    private List<string> text = new List<string>() { };
    private List<string> search1 = new List<string>() { };
    private List<char> charTXT = new List<char>() { };
    private List<char> charGenerate = new List<char>() { };
    private List<string> generateTxt = new List<string>() { };
    private List<string> generateTxt2 = new List<string>() { };

    void Start()
    {
        StreamReader f = new StreamReader("Assets/Book.txt");
        StreamReader g = new StreamReader("Assets/charBook.txt");
        string s;
        while ((s = f.ReadLine()) != null)
          text.Add(s);
        while ((s = g.ReadLine()) != null)
           charTXT.Add(s[0]);
        f.Close();
        g.Close();
        consolLog("\n");
        CharOnUpgradeOutText();
        OnupgradeOutText();
    }
    void consolLog(string h)
    {
        consol.text += "\t"+ h + ", "; 
    }
    public void checkChar()
    {
        List<string> textre = new List<string>() { };
        bool flag1 = true;
        string g = "";
        foreach (char f1 in charTXT)
            g += f1;
        foreach (string s1 in text)
        {
            flag1 = true;
            foreach (char c1 in s1)
            {
                if (g.IndexOf(c1) < 0)
                {
                    flag1 = false;
                    break;
                }
            }
            if (flag1)
            {
                textre.Add(s1);
            }
        }
        foreach(string s1 in textre)
          
        text.Clear();
        text.AddRange(textre);
        textre.Clear();
    }
    public void OnGenerate()
    {
        bool flag1 = true;
        if (generateWord)
            foreach (string s1 in text)
            {
                flag1 = true;
                foreach (char c1 in s1)
                {
                    if (generateWord.text.IndexOf(c1) < 0)
                    {
                        flag1 = false;
                        break;
                    }
                }
                if (flag1)
                {
                    //consolLog(s1);
                    generateTxt.Add(s1);
                }
            }
        generateOut.text = "";


        foreach (string s1 in generateTxt)
        {
            flag1 = true;
            foreach (char c1 in generateWord.text)
            {
                if (s1.IndexOf(c1) < 0)
                {
                    flag1 = false;
                    break;
                }
            }
            if (flag1)
            {
                consolLog("123  " + s1);
                generateTxt2.Add(s1);
            }
        }



        if (generateTxt2.Count <= 0)
            generateOut.text = "Невозможно сгенерировать слово из этих символов";
        else
        {
            consolLog("000");
            foreach (string t1 in generateTxt2)
            {
                generateOut.text = generateOut.text + t1 + "\n";
                consolLog("111");
            }
        }
        generateTxt2.Clear();
        generateTxt.Clear();

    }
    public void OnupgradeOutText()
    {
        checkChar();
        output.text = "";
        foreach (string t1 in text)
            output.text = output.text + t1 + "\n";
    }
    public void OnAddButton()
    {
        if (input)
            text.Add(input.text);
        OnupgradeOutText();
    }
    public void OnDeleteButton()
    {
        string h;
        h = delete.text;
        text.Remove(h);
        OnupgradeOutText();       
    }
    public void SearchText()
    {
            foreach (string s1 in text)
            {
            consolLog(search.text);
                if (s1.StartsWith(search.text))
                    {        
                        search1.Add(s1);
                    }
                }
            SearchOut();
    }
   

    public void SearchOut()
    {
        output.text = "";
        if(search1.Count<=0)
            output.text = "Не найденно такого слова";
        else
            foreach (string t1 in search1)
                output.text = output.text + t1 + "\n";
        search1.Clear();
    }
    public void CharOnUpgradeOutText()
    {
        charOutput.text = "";
        foreach (char t1 in charTXT)
            charOutput.text = charOutput.text + t1 + "\n";
    }
    public void CharOnAddButton()
    {
        if (input)
           if(charTXT.IndexOf(charInput.text[0]) < 0)
            {
                char h = charInput.text[0];
                charTXT.Add(h);
            }
        CharOnUpgradeOutText();
    }
    public void CharOnDeleteButton()
    {
        char h = charDelete.text[0];
        charTXT.Remove(h);
        CharOnUpgradeOutText();
        OnupgradeOutText();
    }
}
