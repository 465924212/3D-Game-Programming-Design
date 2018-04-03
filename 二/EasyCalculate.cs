using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    string screen = "0";
    string history = "0";
    bool input = true;
    string last = "";

    float Calculate(string operate, string left, string right)
    {
        input = false;
        if (operate == "")
        {
            return int.Parse(right);
        }
        else
        {
            float l, r;
            l = float.Parse(left);
            r = float.Parse(right);
            if (operate == "+")
            {
                return l + r;
            }
            else if (operate == "-")
            {
                return l - r;
            }
            else if (operate == "*")
            {
                return l * r;
            }
            else
            {
                return l / r;
            }
        }
    }

    void OnGUI()
    {
        GUI.BeginGroup(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200));
        

        GUI.Box(new Rect(0, 0, 200, 30), screen);
        if (GUI.Button(new Rect(0, 30, 50, 30), "CE"))
        {
            screen = "0";
            input = true;
        }
        if (GUI.Button(new Rect(50, 30, 50, 30), "C"))
        {
            screen = "0";
            history = "0";
            last = "";
            input = true;
        }
        if (GUI.Button(new Rect(100, 30, 50, 30), "←"))
        {
            if (input == true)
            {
                if (screen.Length == 2 && screen[0] == '-')
                {
                    screen = "0";
                }
                else if (screen.Length == 1)
                {
                    screen = "0";
                }
                else
                {
                    screen = screen.Substring(0, screen.Length - 1);
                }
            }
            else
            {
                screen = "0";
                history = "0";
                last = "";
                input = true;
            }
        }
        if (GUI.Button(new Rect(150, 30, 50, 30), "/"))
        {
            if (screen == "0")
            {
                screen = "Error!";
                history = "0";
                last = "";
                input = false;
            }
            else
            {
                screen = history = Calculate(last, history, screen).ToString();
                last = "/";
            }
        }
        if (GUI.Button(new Rect(150, 60, 50, 30), "*"))
        {
            screen = history = Calculate(last, history, screen).ToString();
            last = "*";
        }
        if (GUI.Button(new Rect(150, 90, 50, 30), "-"))
        {
            screen = history = Calculate(last, history, screen).ToString();
            last = "-";
        }
        if (GUI.Button(new Rect(150, 120, 50, 30), "+"))
        {
            screen = history = Calculate(last, history, screen).ToString();
            last = "+";
        }

        if (GUI.Button(new Rect(0, 150, 50, 30), "±"))
        {
            if (screen != "0" && input == true)
            {
                screen.Insert(0, "-");
            }
        }
        
        if (GUI.Button(new Rect(100, 150, 50, 30), "."))
        {
            if (input == false)
            {
                screen = "0.";
                input = true;
            }
            else if (screen.IndexOf('.') < 0)
            {
                screen += ".";
            }
        }

        if (GUI.Button(new Rect(150, 150, 50, 30), "="))
        {
            screen = Calculate(last, history, screen).ToString();
            history = "0";
            last = "";
            input = false;
        }

        if (GUI.Button(new Rect(50, 150, 50, 30), "0"))
        {
            if (input)
            {
                if (screen == "0")
                {
                    
                }
                else {
                    screen += "0";
                }
            }
            else
            {
                input = true;
                screen = "0";
            }
        }
        if (GUI.Button(new Rect(0, 60, 50, 30), "1"))
        {
            if (input)
            {
                if (screen == "0")
                {
                    screen = "1";
                }
                else
                {
                    screen += "1";
                }
            }
            else
            {
                input = true;
                screen = "1";
            }
        }
        if (GUI.Button(new Rect(50, 60, 50, 30), "2"))
        {
            if (input)
            {
                if (screen == "0")
                {
                    screen = "2";
                }
                else
                {
                    screen += "2";
                }
            }
            else
            {
                input = true;
                screen = "2";
            }
        }
        if (GUI.Button(new Rect(100, 60, 50, 30), "3"))
        {
            if (input)
            {
                if (screen == "0")
                {
                    screen = "3";
                }
                else
                {
                    screen += "3";
                }
            }
            else
            {
                input = true;
                screen = "3";
            }
        }
        if (GUI.Button(new Rect(0, 90, 50, 30), "4"))
        {
            if (input)
            {
                if (screen == "0")
                {
                    screen = "4";
                }
                else
                {
                    screen += "4";
                }
            }
            else
            {
                input = true;
                screen = "4";
            }
        }
        if (GUI.Button(new Rect(50, 90, 50, 30), "5"))
        {
            if (input)
            {
                if (screen == "0")
                {
                    screen = "5";
                }
                else
                {
                    screen += "5";
                }
            }
            else
            {
                input = true;
                screen = "5";
            }
        }
        if (GUI.Button(new Rect(100, 90, 50, 30), "6"))
        {
            if (input)
            {
                if (screen == "0")
                {
                    screen = "6";
                }
                else
                {
                    screen += "6";
                }
            }
            else
            {
                input = true;
                screen = "6";
            }
        }
        if (GUI.Button(new Rect(0, 120, 50, 30), "7"))
        {
            if (input)
            {
                if (screen == "0")
                {
                    screen = "7";
                }
                else
                {
                    screen += "7";
                }
            }
            else
            {
                input = true;
                screen = "7";
            }
        }
        if (GUI.Button(new Rect(50, 120, 50, 30), "8"))
        {
            if (input)
            {
                if (screen == "0")
                {
                    screen = "8";
                }
                else
                {
                    screen += "8";
                }
            }
            else
            {
                input = true;
                screen = "8";
            }
        }
        if (GUI.Button(new Rect(100, 120, 50, 30), "9"))
        {
            if (input)
            {
                if (screen == "0")
                {
                    screen = "9";
                }
                else
                {
                    screen += "9";
                }
            }
            else
            {
                input = true;
                screen = "9";
            }
        }


        GUI.EndGroup();
    }

}
