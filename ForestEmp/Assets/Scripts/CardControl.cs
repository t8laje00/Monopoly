using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardControl : MonoBehaviour {


    
    public Text Text_Name;
    public Text Text_Info2;
    public Text Text_Info;
    public GameObject Propertyname;
    public GameObject Info;
    public GameObject Info2;
    public GameObject Buy;
    public Button BuyButton;
    public GameObject Skip;
    public Button SkipButton;
    public Button OkButton;

    public GameObject Ok;
    public GameObject Dice;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject PinkCard;
    public GameObject PurpleCard;
    public GameObject RedCard;
    public GameObject BlueCard;
    public GameObject YellowCard;
    public GameObject BrownCard;
    public GameObject OrangeCard;
    public GameObject GreenCard;
    public GameObject BlankCard;

    public string player;

    public int active_player;


    
    void Start()
    {
        SkipButton.onClick.AddListener(Reset);
        MoneyHandle moneyHandle = GameObject.FindObjectOfType(typeof(MoneyHandle)) as MoneyHandle;
        // MoneyHandle.AddMoney(1, 100000);
        // MoneyHandle.AddMoney(2, 1000);
        Reset();

       // int Rent = MoneyHandle.GetTavernRent(1);
        //Debug.Log("for player 1 tavern = " + Rent);

        //int Rent2 = MoneyHandle.GetTavernRent(2);
        //Debug.Log("for player 2 tavern = " + Rent2);

    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
         if (Player1.GetComponent<FollowThePath>().moveAllowed==false && Player2.GetComponent<FollowThePath>().moveAllowed == false)
          {
            Player1.GetComponent<Collider2D>().enabled = false;
            Player2.GetComponent<Collider2D>().enabled = false;

            if (collision.gameObject.tag == "Tax")
            {

                player = gameObject.name;


                if (player == "Player1")
                {
                    active_player = 1;
                }
                if (player == "Player2")
                {
                    active_player = 2;
                }

                BlankCard.SetActive(true);
                Propertyname.SetActive(true);
                Debug.Log("VEROKARHU!");
                Text_Name.text = "Tax bear!";
                Tax(active_player);
            }

            if (collision.gameObject.tag == "Chance")
            {

            player = gameObject.name;


            if (player == "Player1")
            {
                active_player = 1;
            }
            if (player == "Player2")
            {
                active_player = 2;
            }

            BlankCard.SetActive(true);
            Propertyname.SetActive(true);
            Debug.Log("CHANCE TIEM!");
            Text_Name.text = "Chance";
            Chance(active_player);
            }

            
            if (collision.gameObject.tag == "Tavern1")
            {
                int i = 0;
                BlankCard.SetActive(true);
                Text_Name.text = "Tavern 1";
                TavernCardLogic(i);
            }
            if (collision.gameObject.tag == "Tavern2")
            {
                int i = 1;
                BlankCard.SetActive(true);
                Text_Name.text = "Tavern 2";
                TavernCardLogic(i);
            }
            if (collision.gameObject.tag == "Tavern3")
            {
                int i = 2;
                BlankCard.SetActive(true);
                Text_Name.text = "Tavern 3";
                TavernCardLogic(i);
            }
            if (collision.gameObject.tag == "Tavern4")
            {
                int i = 3;
                BlankCard.SetActive(true);
                Text_Name.text = "Tavern 4";
                TavernCardLogic(i);
            }


            if (collision.gameObject.tag == "Property1")
            {
                int i = 0;
                BrownCard.SetActive(true);
                Text_Name.text = "Mud Village";
                PropertyCardLogic(i);
            }               //MUD  RUSK.   0-1
            if (collision.gameObject.tag == "Property2")
            {
                int i = 1;
                BrownCard.SetActive(true);
                Text_Name.text = "Mud Village";
                PropertyCardLogic(i);
            }
            if (collision.gameObject.tag == "Property3")
            {
                int i = 2;
                BlueCard.SetActive(true);
                Text_Name.text = "Ice Village";
                PropertyCardLogic(i);
            }               //ICE  SIN.    2-4
            if (collision.gameObject.tag == "Property4")
            {
                int i = 3;
                BlueCard.SetActive(true);
                Text_Name.text = "Ice Village";
                PropertyCardLogic(i);
            }
            if (collision.gameObject.tag == "Property5")
            {
                int i = 4;
                BlueCard.SetActive(true);
                Text_Name.text = "Ice Village";
                PropertyCardLogic(i);
            }
            if (collision.gameObject.tag == "Property6")
            {
                int i = 5;
                PinkCard.SetActive(true);
                Text_Name.text = "Candy Village";
                PropertyCardLogic(i);
            }               //CANDY  PINK.  5-7
            if (collision.gameObject.tag == "Property7")
            {
                int i = 6;
                PinkCard.SetActive(true);
                Text_Name.text = "Candy Village";
                PropertyCardLogic(i);
            }
            if (collision.gameObject.tag == "Property8")
            {
                int i = 7;
                PinkCard.SetActive(true);
                Text_Name.text = "Candy Village";
                PropertyCardLogic(i);
            }
            if (collision.gameObject.tag == "Property9")
            {
                int i = 8;
                OrangeCard.SetActive(true);
                Text_Name.text = "Sand Village";
                PropertyCardLogic(i);
            }               //UNDEAD  ORAN.  8-10
            if (collision.gameObject.tag == "Property10")
            {
                int i = 9;
                OrangeCard.SetActive(true);
                Text_Name.text = "Sand Village";
                PropertyCardLogic(i);
            }
            if (collision.gameObject.tag == "Property11")
            {
                int i = 10;
                OrangeCard.SetActive(true);
                Text_Name.text = "Sand Village";
                PropertyCardLogic(i);
            }
            if (collision.gameObject.tag == "Property12")
            {
                int i = 11;
                RedCard.SetActive(true);
                Text_Name.text = "Lava Village";
                PropertyCardLogic(i);
            }               //LAVA PUN.     11-13
            if (collision.gameObject.tag == "Property13")
            {
                int i = 12;
                RedCard.SetActive(true);
                Text_Name.text = "Lava Village";
                PropertyCardLogic(i);
            }
            if (collision.gameObject.tag == "Property14")
            {
                int i = 13;
                RedCard.SetActive(true);
                Text_Name.text = "Lava Village";
                PropertyCardLogic(i);
            }
            if (collision.gameObject.tag == "Property15")
            {
                int i = 14;
                YellowCard.SetActive(true);
                Text_Name.text = "Sand Village";
                PropertyCardLogic(i);
            }               //SAND KELT.    14-16
            if (collision.gameObject.tag == "Property16")
            {
                int i = 15;
                YellowCard.SetActive(true);
                Text_Name.text = "Sand Village";
                PropertyCardLogic(i);
            }
            if (collision.gameObject.tag == "Property17")
            {
                int i = 16;
                YellowCard.SetActive(true);
                Text_Name.text = "Sand Village";
                PropertyCardLogic(i);
            }
            if (collision.gameObject.tag == "Property18")                   //???? VIHR.
            {
                int i = 17;
                GreenCard.SetActive(true);
                Text_Name.text = "Jungle Village";
                PropertyCardLogic(i);
            }               //Vihreä?!      17-19
            if (collision.gameObject.tag == "Property19")
            {
                int i = 18;
                GreenCard.SetActive(true);
                Text_Name.text = "Jungle Village";
                PropertyCardLogic(i);
            }
            if (collision.gameObject.tag == "Property20")
            {
                int i = 19;
                GreenCard.SetActive(true);
                Text_Name.text = "Jungle Village";
                PropertyCardLogic(i);
            }
            if (collision.gameObject.tag == "Property21")
            {
                int i = 20;
                PurpleCard.SetActive(true);
                Text_Name.text = "Dream Village";
                PropertyCardLogic(i);
            }               //DREAM PURP.    20-21
            if (collision.gameObject.tag == "Property22")
            {
                int i = 21;
                PurpleCard.SetActive(true);
                Text_Name.text = "Dream Village";
                PropertyCardLogic(i);
            }
        
    }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Tax")
        {
            Reset();
        }

        if (collision.gameObject.tag == "Chance")
        {
            Reset();
        }

        if (collision.gameObject.tag == "Tavern1")
        {
            Reset();
        }
        if (collision.gameObject.tag == "Tavern2")
        {
            Reset();
        }
        if (collision.gameObject.tag == "Tavern3")
        {
            Reset();
        }
        if (collision.gameObject.tag == "Tavern4")
        {
            Reset();
        }

        if (collision.gameObject.tag == "Property1")
        {
            Reset();
        }
        if (collision.gameObject.tag == "Property2")
        {
            Reset();
        }
        if (collision.gameObject.tag == "Property3")
        {
            Reset();
        }
        if (collision.gameObject.tag == "Property4")
        {
            Reset();
        }
        if (collision.gameObject.tag == "Property5")
        {
            Reset();
        }
        if (collision.gameObject.tag == "Property6")
        {
            Reset();
        }
        if (collision.gameObject.tag == "Property7")
        {
            Reset();
        }
        if (collision.gameObject.tag == "Property8")
        {
            Reset();
        }
        if (collision.gameObject.tag == "Property9")
        {
            Reset();
        }
        if (collision.gameObject.tag == "Property10")
        {
            Reset();
        }
        if (collision.gameObject.tag == "Property11")
        {
            Reset();
        }
        if (collision.gameObject.tag == "Property12")
        {
            Reset();
        }
        if (collision.gameObject.tag == "Property13")
        {
            Reset();
        }
        if (collision.gameObject.tag == "Property14")
        {
            Reset();
        }
        if (collision.gameObject.tag == "Property15")
        {
            Reset();
        }
        if (collision.gameObject.tag == "Property16")
        {
            Reset();
        }
        if (collision.gameObject.tag == "Property17")
        {
            Reset();
        }
        if (collision.gameObject.tag == "Property18")
        {
            Reset();
        }
        if (collision.gameObject.tag == "Property19")
        {
            Reset();
        }
        if (collision.gameObject.tag == "Property20")
        {
            Reset();
        }
        if (collision.gameObject.tag == "Property21")
        {
            Reset();
        }
        if (collision.gameObject.tag == "Property22")
        {
            Reset();
        }
        
    }

                                                                    
    public void BuyProperty(int i)
    {
  
        bool success = MoneyHandle.BuyProperty(active_player, i);
        if (success == true)
        {
            Debug.Log("Successful buy - "+active_player);
            Buy.SetActive(false);
            Ok.SetActive(true);
            Skip.SetActive(false);
            Text_Info.text = "Property is yours!";
            OkButton.onClick.AddListener(Reset); }

        else if (success == false)
        {
            Debug.Log("NOT ENOUGH MONEH BOIII- " + active_player);
            Text_Info2.text = "No money!";
           
           // Text_Info2.text = "Price: " + MoneyHandle.GetPrice(i);
            SkipButton.onClick.AddListener(Reset);
        }

    }
    
    public void BuyTavern(int i)
    {

        bool success = MoneyHandle.BuyTavern(active_player, i);
        if (success == true)
        {
            Debug.Log("Successful buy (tavern) - " + active_player);
            Buy.SetActive(false);
            Ok.SetActive(true);
            Skip.SetActive(false);
            Text_Info.text = "Tavern is yours!";
            OkButton.onClick.AddListener(Reset);
        }

        else if (success == false)
        {
            Debug.Log("NOT ENOUGH MONEH BOIII- " + active_player);
            Text_Info2.text = "No money!";
            
            //Text_Info2.text = "Price: 200";
            SkipButton.onClick.AddListener(Reset);
        }




    }

    public void Buyhouse(int player, int index)
    {
        int level = MoneyHandle.GetPropertyLevel(index);
        if (level == 5)
        {
            Text_Info2.text = "Max amount!";
            Buy.SetActive(false);    
        }
        else if (level < 5)
        {
            bool success = MoneyHandle.BuyHouse(active_player, index);
            if (success == true)
            {
                Text_Info2.text = "House bought!";
            }
            else if (success == false)
            {
                Text_Info2.text = "Not Enough money.";
            }
        }
    }

    public void Payrent(int player, int i)
    {

       bool success = MoneyHandle.PayPropertyRent(active_player, i);

        if (success == true)
        {
            Debug.Log("Payment successful (PropertyRent). player: " + active_player);
            Reset();
        }


    }

    public void PayTavernRent(int player, int i)
    {

        bool success = MoneyHandle.PayTavernRent(active_player, i);

        if (success == true)
        {
            Debug.Log("Payment successful (tavern). player: " + active_player);
            Reset();
        }


    }

    public void Tax(int player)
    {
        Dice.SetActive(false);
        Ok.SetActive(true);
        Info.SetActive(true);
        Info2.SetActive(true);
        Text_Info.text = "You were caught by the tax bear!";
        Text_Info2.text = "Pay 200 coins!";
        OkButton.onClick.RemoveAllListeners();
        OkButton.onClick.AddListener(() => MoneyHandle.SubtractMoney(player, 200));
        OkButton.onClick.AddListener(() => Reset());
    }

    public void PropertyCardLogic(int i)
    {
       // if (Player1.GetComponent<FollowThePath>().moveAllowed == false && Player2.GetComponent<FollowThePath>().moveAllowed == false)
        //{
            SkipButton.onClick.RemoveAllListeners();
            BuyButton.onClick.RemoveAllListeners();
            OkButton.onClick.RemoveAllListeners();

            Propertyname.SetActive(true);

            player = gameObject.name;
            // Debug.Log(player);


            if (player == "Player1")
            {
                active_player = 1;
            }
            if (player == "Player2")
            {
                active_player = 2;
            }
            // Debug.Log(active_player);

            int owner = MoneyHandle.GetPropertyOwner(i);


            Info.SetActive(true);
            Info2.SetActive(true);

            if (owner == 0)
            {
                Buy.SetActive(true);
                Skip.SetActive(true);
                BuyButton.onClick.AddListener(() => BuyProperty(i));
                SkipButton.onClick.AddListener(Reset);
                Text_Info2.text = "Price: " + MoneyHandle.GetPrice(i);
                Text_Info.text = "This property is for sale. Would you like to buy? ";

            }

            else if (owner == active_player)
            {
                Buy.SetActive(false);

            bool GroupOwner = MoneyHandle.CheckGroup(active_player, i);

            if (GroupOwner == true)
            {
                Text_Info.text = "You own this village. Would you like to buy a house?";
                Text_Info2.text = "Price: " + MoneyHandle.GetHousePrice(i);
                Buy.SetActive(true);
                Skip.SetActive(true);
                
                BuyButton.onClick.AddListener(() => Buyhouse(active_player, i));
                SkipButton.onClick.AddListener(() => Reset());
            }
                else if (GroupOwner == false)
            {
                Info2.SetActive(false);
                Text_Info.text = "You own this property! You need all village properties to buy houses.";
                OkButton.onClick.AddListener(() => Reset());
                Ok.SetActive(true);
            }

            }

            else
            {
                Dice.SetActive(false);
                Buy.SetActive(false);
                Skip.SetActive(false);
                Debug.Log("PAY UP SON! RENT IS: " + MoneyHandle.GetPropertyRent(i));
                Text_Info.text = "PAY UP SON! Property is owned by player " + owner;
                Text_Info2.text = "Rent: " + MoneyHandle.GetPropertyRent(i);
                // bool success =  MoneyHandle.PayRent(active_player, i);
                Ok.SetActive(true);
                OkButton.onClick.AddListener(() => Payrent(active_player, i));

          //  }
        }
    }

    public void TavernCardLogic(int i)
    {

        SkipButton.onClick.RemoveAllListeners();
        BuyButton.onClick.RemoveAllListeners();
        OkButton.onClick.RemoveAllListeners();

        Propertyname.SetActive(true);

        player = gameObject.name;
        // Debug.Log(player);


        if (player == "Player1")
        {
            active_player = 1;
        }
        if (player == "Player2")
        {
            active_player = 2;
        }
        // Debug.Log(active_player);

        int owner = MoneyHandle.GetTavernOwner(i);


        Info.SetActive(true);
        Info2.SetActive(true);

        if (owner == 0)
        {
            Buy.SetActive(true);
            Skip.SetActive(true);
            BuyButton.onClick.AddListener(() => BuyTavern(i));
            SkipButton.onClick.AddListener(Reset);
            Text_Info2.text = "Price: 200 ";
            Text_Info.text = "This tavern is for sale. Would you like to buy? ";

        }

        else if (owner == active_player)
        {
            Ok.SetActive(true);
            Text_Info.text = "You are the owner of this tavern!";
            Text_Info2.text = ""  ;
            OkButton.onClick.AddListener(() => Reset());
        }

        else
        {
            Dice.SetActive(false);
            Buy.SetActive(false);
            Skip.SetActive(false);
            Debug.Log("PAY UP SON! RENT IS: " + MoneyHandle.GetTavernRent(i));
            Text_Info.text = "PAY UP SON! Tavern is owned by player " + owner;
            Text_Info2.text = "Rent: " + MoneyHandle.GetTavernRent(active_player);
            //bool success =  MoneyHandle.PayRent(active_player, i);
            Ok.SetActive(true);
            OkButton.onClick.AddListener(() => PayTavernRent(active_player, i));

        }

    }

    public void Chance(int player)
    {
        int Rand = Random.Range(0, 9);
        //Debug.Log("sattumana tuli: " + Rand);
        SkipButton.onClick.RemoveAllListeners();
        BuyButton.onClick.RemoveAllListeners();
        OkButton.onClick.RemoveAllListeners();
        Dice.SetActive(false);
        Ok.SetActive(true);
        Info.SetActive(true);
        Info2.SetActive(true);

        switch (Rand)
        {
            case 0:
                Debug.Log("Chance (-100)");
                Text_Info.text="You were robbed by forest bandits!";
                Text_Info2.text = "Lost 100 coins.";
                OkButton.onClick.AddListener(() => MoneyHandle.SubtractMoney(player, 100));
                OkButton.onClick.AddListener(() => Reset());
                break;

            case 1:
                Debug.Log("Chance (-75)");
                Text_Info.text = "You were robbed by forest bandits!";
                Text_Info2.text = "Lost 75 coins.";
                OkButton.onClick.AddListener(() => MoneyHandle.SubtractMoney(player, 75));
                OkButton.onClick.AddListener(() => Reset());
                break;

            case 2:
                Debug.Log("Chance (-50)");
                Text_Info.text = "You were robbed by forest bandits!";
                Text_Info2.text = "Lost 50 coins.";
                OkButton.onClick.AddListener(() => MoneyHandle.SubtractMoney(player, 50));
                OkButton.onClick.AddListener(() => Reset());
                break;

            case 3:
                Debug.Log("Chance (-25)");
                Text_Info.text = "You found a hole in your pocket!";
                Text_Info2.text = "Lost 25 coins.";
                OkButton.onClick.AddListener(() => MoneyHandle.SubtractMoney(player, 25));
                OkButton.onClick.AddListener(() => Reset());
                break;

            case 4:
                Debug.Log("Chance (nothing happens)");
                Text_Info.text = "Nothing happens.";
                Info2.SetActive(false);
                OkButton.onClick.AddListener(() => Reset());
                break;

            case 5:
                Debug.Log("Chance (+25)");
                Text_Info.text = "You found a small pouch of money!";
                Text_Info2.text = "Gain 25 coins.";
                OkButton.onClick.AddListener(() => MoneyHandle.AddMoney(player, 25));
                OkButton.onClick.AddListener(() => Reset());
                break;

            case 6:
                Debug.Log("Chance (+50)");
                Text_Info.text = "You won a travelling merchant in dice!";
                Text_Info2.text = "Gain 50 coins.";
                OkButton.onClick.AddListener(() => MoneyHandle.AddMoney(player, 50));
                OkButton.onClick.AddListener(() => Reset());
                break;

            case 7:
                Debug.Log("Chance (+75)");
                Text_Info.text = "You found a large sack of money!";
                Text_Info2.text = "Gain 75 coins.";
                OkButton.onClick.AddListener(() => MoneyHandle.AddMoney(player, 75));
                OkButton.onClick.AddListener(() => Reset());
                break;

            case 8:
                Debug.Log("Chance (+100)");
                Text_Info.text = "You found a pot of leprechauns gold at the end of a rainbow!";
                Text_Info2.text = "Gain 100 coins.";
                OkButton.onClick.AddListener(() => MoneyHandle.AddMoney(player, 100));
                OkButton.onClick.AddListener(() => Reset());
                break;
        }

    }



    public void Reset()
    {
        BrownCard.SetActive(false);
        PinkCard.SetActive(false);
        PurpleCard.SetActive(false);
        RedCard.SetActive(false);
        BlueCard.SetActive(false);
        YellowCard.SetActive(false);
        OrangeCard.SetActive(false);
        GreenCard.SetActive(false);
        BlankCard.SetActive(false);

        Propertyname.SetActive(false);
        Info.SetActive(false);
        Info2.SetActive(false);

        Buy.SetActive(false);
        Skip.SetActive(false);
        Ok.SetActive(false);
        SkipButton.onClick.RemoveAllListeners();
        BuyButton.onClick.RemoveAllListeners();
        OkButton.onClick.RemoveAllListeners();
        Dice.SetActive(true);
    }

                                                                                           

}
