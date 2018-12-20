using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyHandle : MonoBehaviour {

    private static MoneyHandle _instance;

    public GameObject Gameover;

    public int Player1Money;
    public int Player2Money;
    
    public Text Player1Coins;
    public Text Player2Coins;

    public int[,] PropertyValues = new int[6, 22] {
                                                  { 2,   4,   6,   6,   8,   10,  10,  12,  14,  14,  16,   18,   18,   20,   22,   22,   22,   26,   26,   28,   35,   50},                      //RENT
                                                  { 10,  20,  30,  30,  40,  50,  50,  60,  70,  70,  80,   90,   90,   100,  110,  110,  120,  130,  130,  150,  175,  200 },                   //RENT + 1 HOUSE 
                                                  { 30,  60,  90,  90,  100, 150, 150, 180, 200, 200, 220,  250,  250,  300,  330,  330,  360,  390,  390,  450,  500,  600},                   //RENT + 2
                                                  { 90,  180, 270, 270, 300, 450, 450, 500, 550, 550, 600,  700,  700,  750,  800,  800,  850,  900,  900,  1000, 1100, 1400},                 //     + 3
                                                  { 160, 360, 400, 400, 450, 625, 625, 700, 750, 750, 800,  875,  875,  925,  975,  975,  1025, 1100, 1100, 1200, 1300, 1700, },              //     + 4
                                                  { 250, 450, 550, 550, 600, 750, 750, 900, 950, 950, 1000, 1050, 1050, 1100, 1150, 1150, 1200, 1275, 1275, 1400, 1500, 2000},               //HOTEL 
                                                  };

    public int[] TavernOwners = new int[4] { 0, 0, 0, 0 };

    public int[] TavernRent = new int[5] { 0, 25, 50, 100, 200 };
    

    public int[] HousePrice = new int[22] { 30, 30, 50, 50, 50, 100, 100, 100, 100, 100, 100, 150, 150, 150, 150, 150, 150, 150, 150, 160, 200, 200 };

    public int[] PropertyOwners = new int[22] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    public int[] PropertyLevels = new int[22] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    public int[] PropertyPrice = new int[22] { 60, 60, 100, 100, 120, 140, 140, 160, 180, 180, 200, 220, 220, 240, 260, 260, 280, 300, 300, 320, 350, 400 };




    private static MoneyHandle instance
    {
        get
        {

            if (_instance == null)
            {
                if (GameObject.Find("MoneyHandle"))
                {
                    GameObject g = GameObject.Find("MoneyHandle");
                    if (g.GetComponent<MoneyHandle>())
                    {
                        _instance = g.GetComponent<MoneyHandle>();
                    }
                    else
                    {
                        _instance = g.AddComponent<MoneyHandle>();
                    }
                }
                else
                {
                    GameObject g = new GameObject();
                    g.name = "MoneyHandle";
                    _instance = g.AddComponent<MoneyHandle>();
                }
            }

            return _instance;
        }


        set
        {
            _instance = value;
        }
    }


    void Start()
    {
        Gameover.SetActive(false);
        Player1Money = 1500;
        Player2Money = 1500;
    }

    void Update()
    {
        UpdateScreen();
    }


    public static bool BuyProperty(int player, int index)
    {

        if (player == 1)
        {
            if (instance.Player1Money - instance.PropertyPrice[index] >= 0)
            {
                instance.Player1Money -= instance.PropertyPrice[index];
                instance.PropertyOwners[index] = player;
                return true;
            }
            else
            {
                return false;
            }
        }

        else if (player == 2)
        {


            if (instance.Player2Money - instance.PropertyPrice[index] >= 0)
            {
                instance.Player2Money -= instance.PropertyPrice[index];
                instance.PropertyOwners[index] = player;
                return true;
            }
            else
            {
                return false;
            }
        }

        else
        {

            Debug.Log("ERROR: MoneyHandler.BuyProperty Return ELSE.");
            return false;
        }
    }

    public static bool BuyTavern(int player, int index)
    {

        if (player == 1)
        {
            if (instance.Player1Money - 200 >= 0)
            {
                instance.Player1Money -= 200;
                instance.TavernOwners[index] = player;
                return true;
            }
            else
            {
                return false;
            }
        }

        else if (player == 2)
        {


            if (instance.Player2Money - 200 >= 0)
            {
                instance.Player2Money -= 200;
                instance.TavernOwners[index] = player;
                return true;
            }
            else
            {
                return false;
            }
        }

        else
        {

            Debug.Log("ERROR: MoneyHandler.BuyTavern Return ELSE.");
            return false;
        }

    }

    public static int GetMoney(int player)
    {
        if (player == 1)
        {
            return instance.Player1Money;
        }
        else if (player == 2)
        {
            return instance.Player2Money;
        }

        else { return -1; }
    }

    public static int GetPrice(int PropertyIndex)
    {
        return instance.PropertyPrice[PropertyIndex];
    }

    public static int GetHousePrice(int index)
    {
        return instance.HousePrice[index];
    }

    public static bool PayPropertyRent(int player, int index)
    {
        int rent=GetPropertyRent(index);

        if (player == 1)
        {
            if (instance.Player1Money - rent >= 0)
            {
                instance.Player1Money -= rent;
                instance.Player2Money += rent;
                return true;
            }
            else
            {
                Debug.Log("OH MY! You are out of moneh. GAME OVER, Player " + player);
                return false;
            }
        }

        else if (player == 2)
        {
            if (instance.Player2Money - rent >= 0)
            {
                instance.Player2Money -= rent;
                instance.Player1Money += rent;
                return true;
            }
            else
            {
                Debug.Log("OH MY! You are out of moneh. GAME OVER, Player " + player);
                return false;
            }

        }

        else
        {

            Debug.Log("ERROR: MoneyHandler.PayRent Return ELSE.");
            return false;
        }

    }

    public static bool PayTavernRent(int player, int index)
    {



        if (player == 1)
        {

            int count = 0;
            for (int i = 0; i < instance.TavernOwners.Length; i++)
            {
                if (instance.TavernOwners[i] == 2) count++;
            }
            //count -= 1;
            if (instance.Player1Money - instance.TavernRent[count] >= 0)
            {
                instance.Player1Money -= instance.TavernRent[count];
                instance.Player2Money += instance.TavernRent[count];
                return true;
            }
            else
            {
                Debug.Log("OH MY! You are out of moneh. GAME OVER, Player " + player);
                return false;
            }
        }

        else if (player == 2)
        {
            int count = 0;
            for (int i = 0; i < instance.TavernOwners.Length; i++)
            {
                if (instance.TavernOwners[i] == 1) count++;
            }
            //count -= 1;
            if (instance.Player2Money - instance.TavernRent[count] >= 0)
            {
                instance.Player2Money -= instance.TavernRent[count];
                instance.Player1Money += instance.TavernRent[count];
                return true;
            }
            else
            {
                Debug.Log("OH MY! You are out of moneh. GAME OVER, Player " + player);
                return false;
            }

        }

        else
        {

            Debug.Log("ERROR: MoneyHandler.PayTavernRent Return ELSE.");
            return false;
        }
    }

    public static int GetTavernRent(int player)
    {
        if (player == 1)
        {

           int count = 0;
            for (int i = 0; i < instance.TavernOwners.Length; i++)
            {
                
                if (instance.TavernOwners[i] == 2) count++;
               
            }
           // count -= 1;
            return instance.TavernRent[count];

        }

        else if (player == 2)
        {
            int count = 0;
            for (int i = 0; i < instance.TavernOwners.Length; i++)
            {
                if (instance.TavernOwners[i] == 1) count++;
            }
            //count -= 1;
            return instance.TavernRent[count];

        }

        else
        {

            Debug.Log("ERROR: MoneyHandler.PayTavernRent Return ELSE.");
            return 666;
        }
    }

    public static int GetPropertyRent(int PropertyIndex)
    {
        return instance.PropertyValues[instance.PropertyLevels[PropertyIndex], PropertyIndex];
    }

    public static void AddMoney(int player, int amount)
    {
        if (player == 1)
        {
            instance.Player1Money += amount;
        }
        else if (player == 2)
        {
            instance.Player2Money += amount;
        }

    }

    public static bool SubtractMoney(int player, int amount)
    {
        if (player == 1)
        {
            if (instance.Player1Money - amount >= 0)
            {
                instance.Player1Money -= amount;
                return true;
            }
            else
            {
                instance.Player1Money -= amount;
                instance.Setgameover();
                Debug.Log("Game over, Player " + player);
                return false;
            }
        }

        else if (player == 2)
        {


            if (instance.Player2Money - amount >= 0)
            {
                instance.Player2Money -= amount;
                return true;
            }
            else
            {
                instance.Setgameover();
                instance.Player2Money -= amount;
                Debug.Log("Game over, Player " + player);
                return false;
            }
        }
        else return false;
    }

    public static int GetTavernOwner(int index)
    {
        return instance.TavernOwners[index];
    }

    public static int GetPropertyOwner(int PropertyIndex)
    {
        return instance.PropertyOwners[PropertyIndex];
    }

    public static bool BuyHouse(int player, int index)
        {

        if (player == 1)
        {
            if (instance.Player1Money - instance.HousePrice[index] >= 0)
            {
                if (instance.PropertyLevels[index] >= 5)
                {
                    Debug.Log("Property at maximum level");
                    
                    return false;
                }
                else
                {
                    instance.Player1Money -= instance.HousePrice[index];
                    instance.PropertyLevels[index]++;
                    return true;
                }
            }
            else
            {
                Debug.Log("Not enough money, player " + player);
                return false;
            }
        }

        else if (player == 2)
        {


            if (instance.Player2Money - instance.HousePrice[index] >= 0)
            {
                if (instance.PropertyLevels[index] >= 5)
                {
                    Debug.Log("Property at maximum level!");
                    return false;
                }
                else
                {
                    instance.Player2Money -= instance.HousePrice[index];
                    instance.PropertyLevels[index]++;
                    return true;
                }
            }
            else
            {
                Debug.Log("Not enough money, player " + player);
                return false;
            }
        }

        else
        {

            Debug.Log("ERROR: MoneyHandler.BuyProperty Return ELSE.");
            return false;
        }

    }

    public static bool CheckGroup(int player, int index)
    {

        if (index == 0 || index == 1)
        {
            if (instance.PropertyOwners[0] == instance.PropertyOwners[1] &&
                instance.PropertyOwners[1] == player)
            {
                return true;
            }
            else return false;
        }

        else if (index == 2 || index == 3 || index == 4)
        {
            if (instance.PropertyOwners[2] == instance.PropertyOwners[3] &&
                instance.PropertyOwners[3] == instance.PropertyOwners[4] &&
                instance.PropertyOwners[4] == player)
            {
                return true;
            }
            else return false;
        }

        else if (index == 5 || index == 6 || index == 7)
        {
            if (instance.PropertyOwners[5] == instance.PropertyOwners[6] &&
                instance.PropertyOwners[6] == instance.PropertyOwners[7] &&
                instance.PropertyOwners[7] == player)
            {
                return true;
            }
            else return false;
        }

        else if (index == 8 || index == 9 || index == 10)
        {
            if (instance.PropertyOwners[8] == instance.PropertyOwners[9] &&
                instance.PropertyOwners[9] == instance.PropertyOwners[10] &&
                instance.PropertyOwners[10] == player)
            {
                return true;
            }
            else return false;
        }

        else if (index == 11 || index == 12 || index == 13)
        {
            if (instance.PropertyOwners[11] == instance.PropertyOwners[12] &&
                instance.PropertyOwners[12] == instance.PropertyOwners[13] &&
                instance.PropertyOwners[13] == player)
            {
                return true;
            }
            else return false;
        }

        else if (index == 14 || index == 15 || index == 16)
        {
            if (instance.PropertyOwners[14] == instance.PropertyOwners[15] &&
                instance.PropertyOwners[15] == instance.PropertyOwners[16] &&
                instance.PropertyOwners[16] == player)
            {
                return true;
            }
            else return false;
        }

        else if (index == 17 || index == 18 || index == 19)
        {
            if (instance.PropertyOwners[17] == instance.PropertyOwners[18] &&
                instance.PropertyOwners[18] == instance.PropertyOwners[19] &&
                instance.PropertyOwners[19] == player)
            {
                return true;
            }
            else return false;
        }

        else if (index == 20 || index == 21)
        {
            if (instance.PropertyOwners[20] == instance.PropertyOwners[21] &&
                instance.PropertyOwners[21] == player)
            {
                return true;
            }
            else return false;
        }

        else return false;
    }
        
    

    public static int GetPropertyLevel(int index)
    {
       return instance.PropertyLevels[index];
    }

    public void UpdateScreen()
    {
        if (Player1Money<=0||Player2Money<=0)
        {
            Setgameover();
        }

        Player1Coins.text = "Coins:" + Player1Money.ToString();
        Player2Coins.text = "Coins:" + Player2Money.ToString();
    }

    public void Setgameover()
    {
        
        Gameover.SetActive(true);
    }

}




