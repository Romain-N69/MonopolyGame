using System;
//using Gtk;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;

namespace test_monoploy
{
    public class game
    {
        //Case[] cases;
        //Propriete[] proprietes;
        //Taxe[] taxes;


    }

    // classes de joueurs -----------------------------------
    public class Joueur
    {
        string _name;
        string _item;
        int _money;
        int _position;
        int[] _ownedPlace;
        int _jailRemaining;
        bool _isInGame;

        public Joueur(string name, string item)
        {
            this._name = name;
            this._item = item;
            this._money = 1500;
            this._position = 0;
            this._ownedPlace = new int[1];
            this._jailRemaining = 0;
            this._isInGame = true;
        }

        public string Name { get { return _name; } }

        public string Item { get { return _item; } }

        public int Money { get { return _money; } set { _money = value; } }//Money possédés par le joueur

        public int Position { get { return _position; } set { _position = value; } }//Position du joueur

        public int[] OwnedPlace { get { return _ownedPlace; } set { _ownedPlace = value; } }//Place possédée du joueur

        public int JailRemaining { get { return _jailRemaining; } set { _jailRemaining = value; } }//Tour restant pour sortir de prison

        public bool IsInGame { get { return _isInGame; } set { _isInGame = value; } }// est ce que le joueur est dans la partie.

    }

    // classes de cases -------------------------------------
    public abstract class Case
    {
        string _name;
        string _type;

        public Case(string name, string type) //Ctor
        {
            this._name = name;
            this._type = type;
        }

        public string Name { get { return _name; } set { _name = value; } }//getseter name

        public string Type { get { return _type; } } //getseter type
    }

    public class BasicCase : Case
    {
        public BasicCase(string name, string type) : base(name, type)//Ctor
        {

        }
    }

    public class Propriete : Case
    {
        public string _name;
        public string _type;
        public string _family;
        public int _loyer;
        public bool _isByable;
        public bool _isHypoteque;
        public string _owner;
        public int _price;
        //add maison

        public Propriete(string name, string type, string family, int loyer, int price) : base(name, type)
        {
            this._family = family;
            this._loyer = loyer;
            this._price = price;
            this._isByable = true;
            this._isHypoteque = false;
        }

        public Propriete(string name, string type, int loyer) : base(name, type)
        {
            this._loyer = loyer;
            this._isByable = false;
            this._isHypoteque = false;
        }

        public Propriete(string name, string type) : base(name, type)
        {
            this._isByable = false;
            this._isHypoteque = false;
        }

        public string Family { get { return _family; } } //getseter family

        public int Loyer { get { return _loyer; } set { _loyer = value; } } // getseter loyer

        public int Price { get { return _price; } } // getseter price

        public bool IsByable { get { return _isByable; } set { _isByable = value; } } // getseter isByable

        public bool IsHypoteque { get { return _isHypoteque; } set { _isHypoteque = value; } } // getseter isHypoteque

        public string Owner { get { return _owner; } set { _owner = value; } } // getseter owner
    }
    /*
    public class Taxe : Case
    {
        string _name;
        string _type;
        int _loyer;
        bool _isByable;
        public int Loyer { get { return _loyer; } } // getseter loyer

        public Taxe(string name, string type, int loyer) : base(name, type)
        {
            this._loyer = loyer;
        }

       

    }
    */

    // classes de plateau -----------------------------------
    public class Plateau
    {
        //public object[] Cases { get; private set; }
        public Propriete[] Cases { get; private set; }
        public List<Joueur> Joueurs { get; }
        public int ParcGratuit { get; set; }


        public Plateau(List<Joueur> joueur)
        {
            Joueurs = joueur;
            Cases = generateCases();
        }

        public Propriete[] generateCases()
        //public object[] generateCases()
        {
            Cases = new Propriete[40];
            //object[] Cases = new object[40];
            Cases[0] = new Propriete("start", "start");
            Cases[1] = new Propriete("boulevard de belleville", "propriete", "maron", 30, 60);
            Cases[2] = new Propriete("caisse de communaute", "card");
            Cases[3] = new Propriete("rue lecourbe", "propriete", "maron", 30, 60);
            Cases[4] = new Propriete("impot sur le revenu", "taxe", 200);

            Cases[5] = new Propriete("gare montparnasse", "propriete", "gare", 100, 200);
            Cases[6] = new Propriete("rue vaugirard", "propriete", "cyan", 50, 100);
            Cases[7] = new Propriete("chance", "card");
            Cases[8] = new Propriete("rue de courcelles", "propriete", "cyan", 50, 100);
            Cases[9] = new Propriete("avenue de la republique", "propriete", "cyan", 60, 120);


            Cases[10] = new Propriete("visite simple", "jailStanding");
            Cases[11] = new Propriete("boulevard de la villette", "propriete", "rose", 70, 140);
            Cases[12] = new Propriete("compagnie de distribution d'electricite", "propriete", "compagnie", 75, 150);
            Cases[13] = new Propriete("avenue de neuilly", "propriete", "rose", 70, 140);
            Cases[14] = new Propriete("rue de paradis", "propriete", "rose", 80, 160);

            Cases[15] = new Propriete("gare de lyon", "propriete", "gare", 100, 200);
            Cases[16] = new Propriete("avenue mozart", "propriete", "orange", 90, 180);
            Cases[17] = new Propriete("caisse de communaitee", "card");
            Cases[18] = new Propriete("boulevard saint-michel", "propriete", "orange", 90, 180);
            Cases[19] = new Propriete("place pigalle", "propriete", "orange", 100, 200);


            Cases[20] = new Propriete("parc gratuit", "parc");
            Cases[21] = new Propriete("avenue matignon", "propriete", "rouge", 112, 220);
            Cases[22] = new Propriete("chance", "card");
            Cases[23] = new Propriete("boulevard maleserbes", "propriete", "rouge", 110, 220);
            Cases[24] = new Propriete("avenue henri-martin", "propriete", "rouge", 120, 240);

            Cases[25] = new Propriete("gare du nord", "propriete", "gare", 100, 200);
            Cases[26] = new Propriete("faubourg saint-honore", "propriete", "jaune", 130, 260);
            Cases[27] = new Propriete("place de la boursse", "propriete", "jaune", 130, 260);
            Cases[28] = new Propriete("compagnie de distribution des eaux", "propriete", "compagnie", 75, 150);
            Cases[29] = new Propriete("rue la fayette", "propriete", "jaune", 140, 280);


            Cases[30] = new Propriete("allez en prizon", "jail");
            Cases[31] = new Propriete("avenue de breteuil", "propriete", "vert", 150, 300);
            Cases[32] = new Propriete("avenue foch", "propriete", "vert", 100, 300);
            Cases[33] = new Propriete("caisse de communaute", "card");
            Cases[34] = new Propriete("boulevard des capucines", "propriete", "vert", 160, 320);

            Cases[35] = new Propriete("gare saint-lazare", "propriete", "gare", 100, 200);
            Cases[36] = new Propriete("chance", "card");
            Cases[37] = new Propriete("avenue des champs-elizes", "propriete", "bleu", 175, 350);
            Cases[38] = new Propriete("taxe de luxe", "taxe", 100);
            Cases[39] = new Propriete("rue de la paix", "propriete", "bleu", 200, 400);
            return Cases;
        }
    }


    // classe programm -------------------------------------- 
    class MainClass
    {
        public static List<Joueur> CreateAllPlayers()
        {
            int nbPlayers = 0;
            while (nbPlayers < 1) {
                Console.Clear();
                Console.Write("Saisissez le nombre de joueurs : ");
                nbPlayers = Int32.Parse(Console.ReadLine()); //getnbPlayers
            }


                List<Joueur> players = new List<Joueur>();
            for (int i = 0; i < nbPlayers; i++)
            {
                Console.Write("nom du joueur " + (i + 1) + " : ");
                string name = Console.ReadLine(); //get name
                Console.Write("item du joueur " + (i + 1) + " : ");
                string item = Console.ReadLine(); //get name
                Joueur tmp = new Joueur(name, item);
                players.Add(tmp);
            }
            Console.Clear();
            return players;
        }

        
        public static void printMapStats(Plateau myPlateau, List<Joueur> players)
        {
            foreach(Propriete item in myPlateau.Cases)
            {
                if (item.Owner != null) {
                    Console.WriteLine(item.Name + " own: '" + item.Owner + "'");
                }
            }
        }

        public static int InGamePlayer(List<Joueur> players)
        {
            int i = 0;
            foreach (Joueur item in players)
            {
                if (item.IsInGame == true) { i++; }
            }
            return i;
        }

        public static List<Joueur> ShuffleListOfJoueur(List<Joueur> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Joueur value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return (list);
        }

        public static void DisplayInfoPreRound(Plateau myPlateau, List<Joueur> players, int index)
        {
            Console.Clear();
            Console.WriteLine("Nom : " + players[index].Name);
            Console.WriteLine("Argent : " + players[index].Money + "$");
            if (players[index].JailRemaining <= 0) {
                Console.WriteLine("Position : " + myPlateau.Cases[players[index].Position].Name);
            } else {
                Console.WriteLine("Position : Prison");
            }
        }

        public static void DisplayInfoPostRound(Plateau myPlateau, List<Joueur> players, int index)
        {
            Console.WriteLine("Argent : " + players[index].Money + "$");
            if (players[index].JailRemaining < 0)
            {
                Console.WriteLine( players[index].JailRemaining + " carte libere de prison en stock");
            }
        }

        public static (Plateau _myPlateau, List<Joueur> _players) InteractWithCurrentPosition(Plateau myPlateau, List<Joueur> players, int index)
        {
            switch (myPlateau.Cases[players[index].Position].Type)
            {
                case "propriete":
                    if (myPlateau.Cases[players[index].Position].IsByable == true && players[index].Money < myPlateau.Cases[players[index].Position].Price) // pas assez de sous pour acheter..
                    {
                        Console.WriteLine("Vous n'avez pas assez de sous pour acheter");
                    }
                    else if (myPlateau.Cases[players[index].Position].IsByable == true && players[index].Money >= myPlateau.Cases[players[index].Position].Price) // assez de sous pour acheter!
                    {
                        Console.Write(myPlateau.Cases[players[index].Position].Name + " coute : " + myPlateau.Cases[players[index].Position].Price + "$. Acheter ?  [Enter/n]");
                        ConsoleKeyInfo cki = Console.ReadKey();

                        if (cki.Key.ToString() != "Enter") // ne veux pas acheter
                        {
                            Console.WriteLine("Vous n'avez pas acheter :" + myPlateau.Cases[players[index].Position].Name);
                        }
                        else // veux acheter
                        {
                            Console.WriteLine("Vous avez acheter : " + myPlateau.Cases[players[index].Position].Name);
                            players[index].Money -= myPlateau.Cases[players[index].Position].Price;
                            players[index].OwnedPlace = players[index].OwnedPlace.Concat(new int[] { players[index].Position }).ToArray();
                            myPlateau.Cases[players[index].Position].Owner = players[index].Name;
                            myPlateau.Cases[players[index].Position].IsByable = false;
                        }
                    }

                    else if (myPlateau.Cases[players[index].Position].IsByable == false &&
                        myPlateau.Cases[players[index].Position].Owner != players[index].Name)
                    {// case deja acheter mais pas proprio.
                        players[index].Money -= myPlateau.Cases[players[index].Position].Loyer; // prend le loyé au locataire
                        int tmpIndex = players.FindIndex(a => a.Name == myPlateau.Cases[players[index].Position].Owner);
                        players[tmpIndex].Money += myPlateau.Cases[players[index].Position].Loyer;//done le loyé au proprio
                        Console.WriteLine("vous donnez " + myPlateau.Cases[players[index].Position].Loyer + "$ a " + myPlateau.Cases[players[index].Position].Owner);
                        if (players[index].Money < 0) { players[index].IsInGame = false; Console.WriteLine("Faillite. Vous etes elimine"); }


                    }
                    else // deja acheté et proprio 
                    {
                        Console.WriteLine("Vous etes chez vous.");
                        //ajouter possibilité de construire des maison.
                    }

                    break;
                case "taxe":
                    players[index].Money -= myPlateau.Cases[players[index].Position].Loyer;
                    myPlateau.ParcGratuit += myPlateau.Cases[players[index].Position].Loyer;
                    Console.WriteLine("Vous devez payer :" + myPlateau.Cases[players[index].Position].Loyer + "$");
                    if (players[index].Money < 0) { players[index].IsInGame = false; Console.WriteLine("Faillite. Vous etes elimine"); }
                    break;
                case "card":
                    //random carte
                    break;
                case "start":
                    players[index].Money += 0;///zizi
                    Console.WriteLine("Vous etes sur la case depart. +200$ suplementaire");
                    break;
                case "jail":
                    Console.WriteLine("Vous allez directement en prison");
                    players[index].Position = 10;
                    if (players[index].JailRemaining >= 0) { players[index].JailRemaining = 3; } else if (players[index].JailRemaining < 0) { players[index].JailRemaining += 1; Console.WriteLine("Vous venez d'etre libere de prison"); }
                    break;
                case "parc":
                    players[index].Money += myPlateau.ParcGratuit;
                    Console.WriteLine("Parc gratuit. Vous gagnez :" + myPlateau.ParcGratuit + "$");
                    myPlateau.ParcGratuit = 0;
                    break;
                case "jailStanding":
                    if (players[index].JailRemaining > 0) { players[index].JailRemaining -= 1; }
                    break;
                default:
                    break;
            }
            return (myPlateau, players);
        }

        

        public static int RunMonopoly()
        {
            List<Joueur> players = CreateAllPlayers(); // create all the players 
            Plateau myPlateau = new Plateau(players); // initiate the plateau
            Random rnd = new Random();

            players = ShuffleListOfJoueur(players);
            Console.Write("\nAppuyer sur un touche pour commencer...");
            Console.ReadKey();
            while (InGamePlayer(players) > 1) {
                for (int index = 0; index < players.Count; index++) {
                    if(players[index].IsInGame == true) {
                        int rnd1 = rnd.Next(1, 7);
                        int rnd2 = rnd.Next(1, 7);
                        //printMapStats(myPlateau, players);
                        DisplayInfoPreRound(myPlateau, players, index);
                        Console.WriteLine("Des : " + rnd1 + " & " + rnd2);

                        if (players[index].JailRemaining > 0 && rnd1 == rnd2)
                        { // release prisoner if dices double.
                            Console.Write("Double. Libere de prison. ");
                            players[index].JailRemaining = 0;
                        }
                        else if (players[index].JailRemaining > 0 && rnd1 != rnd2)
                        { //say to the prisoners that he stay in jail for X more rounds
                            Console.WriteLine("Bloque en prison, deplacement impossible." + players[index].JailRemaining + "tour(s) restant.");
                        }
                        if (players[index].JailRemaining <= 0)
                        { // move player only if he is not in jail
                            players[index].Position = ((rnd1 + rnd2 + players[index].Position));
                            if (players[index].Position >= 40)
                            { // give and display 200$ to player if he pass at the start
                                players[index].Money += 0;//zizi
                                players[index].Position = players[index].Position % 40;
                                Console.Write("Passage par la case depart : +200$. ");
                            }
                            Console.WriteLine("Deplacement en : " + myPlateau.Cases[players[index].Position].Name);

                        }  // display the player its new possition

                        var (_myPlateau, _players) = InteractWithCurrentPosition(myPlateau, players, index); // interact with the player location.
                        myPlateau = _myPlateau; // interact with the player location.
                        players = _players; // interact with the player location.

                        DisplayInfoPostRound(myPlateau, players, index);

                        //Console.WriteLine(myPlateau.Cases[players[i].Position].Name);///////////////////

                        Console.Write("\nPress any key to end your turn...");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }

                //endGame = true;
            }
            return (0);
        }

        public static void Main(string[] args)
        {
            //Application.Init();
            //MainWindow win = new MainWindow();
            //win.Show();
            //Application.Run();
            RunMonopoly();
            Console.Write("\nAppuyer sur un touche pour terminer le programme...");
            Console.ReadKey();
        }
    }
}