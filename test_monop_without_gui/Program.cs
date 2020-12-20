using System;
//using Gtk;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;

namespace test_monop_without_gui
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
        int _previousMoney;
        int _previousPosition;
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

        public int PreviousMoney { get { return _previousMoney; } set { _previousMoney = value; } }//previousMoney possédés par le joueur

        public int PreviousPosition { get { return _previousPosition; } set { _previousPosition = value; } }//previousPosition du joueur

        public int[] OwnedPlace { get { return _ownedPlace; } set { _ownedPlace = value; } }//Place possédée du joueur

        public int JailRemaining { get { return _jailRemaining; } set { _jailRemaining = value; } }//Tour restant pour sortir de prison

        public bool IsInGame { get { return _isInGame; } set { _isInGame = value; } }// est ce que le joueur est dans la partie.

    }

    // classes de cases -------------------------------------
    public abstract class Case
    {
        string _name;
        string _type;
        int _corner;

        public Case(int corner, string name, string type) //Ctor
        {
            this._name = name;
            this._type = type;
            this._corner = corner;
        }

        public string Name { get { return _name; } set { _name = value; } }//getseter name

        public string Type { get { return _type; } } //getseter type

        public int Corner { get { return _corner; } } // geter corner
    }

    public class BasicCase : Case
    {
        public BasicCase(int corner, string name, string type) : base(corner, name, type)//Ctor
        {

        }
    }

    public class Propriete : Case
    {
        public string _name;
        public string _type;
        public string _family;
        public bool _isByable;
        public bool _isHypoteque;
        public string _owner;
        public int _price;
        public int _house;
        public int[] _loyers = new int[7];
        //add maison

        public Propriete(int corner, string name, string type, string family, int[] loyers, int price) : base(corner, name, type)
        {
            this._family = family;
            this._loyers = loyers;
            this._price = price;
            this._isByable = true;
            this._isHypoteque = false;
            this._owner = null;
            this._house = 0;
        }

        public Propriete(int corner, string name, string type, int[] loyers) : base(corner, name, type)
        {
            this._loyers = loyers;
            this._isByable = false;
            this._isHypoteque = false;
            this._owner = null;
        }

        public Propriete(int corner, string name, string type) : base(corner, name, type)
        {
            this._isByable = false;
            this._isHypoteque = false;
            this._owner = null;
        }

        public string Family { get { return _family; } } //getseter family

        public int House { get { return _house; } set { _house = value; } } // getseter loyer

        public int[] Loyer { get { return _loyers; } set { _loyers = value; } } // getseter loyers

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
        public int[] Des { get; set; }
    public Propriete[] Cases { get; private set; }
        public List<Joueur> Joueurs { get; }
        public int ParcGratuit { get; set; }


        public Plateau(List<Joueur> joueur)
        {
            Joueurs = joueur;
            Cases = generateCases();
            Des = new int[2];
        }

        public Propriete[] generateCases()
        //public object[] generateCases()
        {
            Cases = new Propriete[40];
            //object[] Cases = new object[40];
            Cases[0] = new Propriete(1, "start", "start");
            Cases[1] = new Propriete(1, "boulevard de belleville", "propriete", "maron", new int[] { 2, 10, 30, 90, 160, 250, 30 }, 60);
            Cases[2] = new Propriete(1, "caisse de communaute", "card");
            Cases[3] = new Propriete(1, "rue lecourbe", "propriete", "maron", new int[] { 4, 20, 60, 180, 320, 450, 30 }, 60);
            Cases[4] = new Propriete(1, "impot sur le revenu", "taxe", new int[] { 200 });

            Cases[5] = new Propriete(1, "gare montparnasse", "propriete", "gare", new int[] { 0, 50, 100, 150 , 200, 0, 100}, 200);
            Cases[6] = new Propriete(1, "rue vaugirard", "propriete", "cyan", new int[] { 6, 30, 90, 270, 400, 550, 50 }, 100);
            Cases[7] = new Propriete(1, "chance", "card");
            Cases[8] = new Propriete(1, "rue de courcelles", "propriete", "cyan", new int[] { 6, 30, 90, 270, 400, 550, 50 }, 100);
            Cases[9] = new Propriete(1, "avenue de la republique", "propriete", "cyan", new int[] { 8, 40, 100, 300, 450, 600, 60 }, 120);


            Cases[10] = new Propriete(2, "visite simple", "jailStanding");
            Cases[11] = new Propriete(2, "boulevard de la villette", "propriete", "rose", new int[] { 10, 50, 150, 450, 625, 750, 70 }, 140);
            Cases[12] = new Propriete(2, "compagnie de distribution d'electricite", "propriete", "compagnie", new int[] { 0, 0, 0, 0, 0, 0, 75 }, 150); //electricité
            Cases[13] = new Propriete(2, "avenue de neuilly", "propriete", "rose", new int[] { 10, 50, 150, 450, 625, 750, 70 }, 140);
            Cases[14] = new Propriete(2, "rue de paradis", "propriete", "rose", new int[] { 12, 60, 180, 500, 700, 900, 80 }, 160);

            Cases[15] = new Propriete(2, "gare de lyon", "propriete", "gare", new int[] { 0, 50, 100, 150, 200, 0, 100 }, 200);
            Cases[16] = new Propriete(2, "avenue mozart", "propriete", "orange", new int[] { 14, 70, 200, 550, 700, 900, 90 }, 180);
            Cases[17] = new Propriete(2, "caisse de communaitee", "card");
            Cases[18] = new Propriete(2, "boulevard saint-michel", "propriete", "orange", new int[] { 14, 70, 200, 550, 700, 950, 90 }, 180);
            Cases[19] = new Propriete(2, "place pigalle", "propriete", "orange", new int[] { 16, 80, 220, 600, 800, 1000, 100 }, 200);


            Cases[20] = new Propriete(3, "parc gratuit", "parc");
            Cases[21] = new Propriete(3, "avenue matignon", "propriete", "rouge", new int[] { 18, 90, 250, 700, 875, 1050, 110 }, 220);
            Cases[22] = new Propriete(3, "chance", "card");
            Cases[23] = new Propriete(3, "boulevard maleserbes", "propriete", "rouge", new int[] { 18, 90, 250, 700, 875, 1050, 110 }, 220);
            Cases[24] = new Propriete(3, "avenue henri-martin", "propriete", "rouge", new int[] { 20, 100, 300, 750, 925, 1100, 120 }, 240);

            Cases[25] = new Propriete(3, "gare du nord", "propriete", "gare", new int[] { 0, 50, 100, 150, 200, 0, 100 }, 200);
            Cases[26] = new Propriete(3, "faubourg saint-honore", "propriete", "jaune", new int[] { 22, 110, 330, 800, 975, 1150, 130 }, 260);
            Cases[27] = new Propriete(3, "place de la boursse", "propriete", "jaune", new int[] { 22, 110, 330, 800, 975, 1150, 130 }, 260);
            Cases[28] = new Propriete(3, "compagnie de distribution des eaux", "propriete", "compagnie", new int[] { 0, 0, 0, 0, 0, 0, 75 }, 150);//  eau
            Cases[29] = new Propriete(3, "rue la fayette", "propriete", "jaune", new int[] { 24, 120, 360, 850, 1025, 1200, 140 }, 280);


            Cases[30] = new Propriete(4, "allez en prizon", "jail");
            Cases[31] = new Propriete(4, "avenue de breteuil", "propriete", "vert", new int[] { 26, 130, 390, 900, 1100, 1275, 150 }, 300);
            Cases[32] = new Propriete(4, "avenue foch", "propriete", "vert", new int[] { 26, 130, 390, 900, 1100, 1275, 150 }, 300);
            Cases[33] = new Propriete(4, "caisse de communaute", "card");
            Cases[34] = new Propriete(4, "boulevard des capucines", "propriete", "vert", new int[] { 28, 150, 450, 1000, 1200, 1400, 160 }, 320);

            Cases[35] = new Propriete(4, "gare saint-lazare", "propriete", "gare", new int[] {0, 50, 100, 150, 200, 0, 100 }, 200);
            Cases[36] = new Propriete(4, "chance", "card");
            Cases[37] = new Propriete(4, "avenue des champs-elizes", "propriete", "bleu", new int[] { 35, 175, 500, 1100, 1300, 1500, 175 }, 350);
            Cases[38] = new Propriete(4, "taxe de luxe", "taxe", new int[] { 100 });
            Cases[39] = new Propriete(4, "rue de la paix", "propriete", "bleu", new int[] { 50, 200, 600, 1400, 1700, 2000, 200 }, 400);
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
            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Nom : " + players[index].Name);
            Console.WriteLine("Solde au debut du tour : " + players[index].PreviousMoney + "$");
            if (players[index].JailRemaining <= 0) {
                Console.WriteLine("Position au debut du tour : " + myPlateau.Cases[players[index].PreviousPosition].Name);
                if (myPlateau.Cases[players[index].PreviousPosition].Owner == players[index].Name) {
                    Console.WriteLine("Vous etiez chez vous." );
                } else if (myPlateau.Cases[players[index].PreviousPosition].Owner == null) {
                    Console.WriteLine("Vous etiez sur une cases n'apartenant a personne.");
                } else if (myPlateau.Cases[players[index].PreviousPosition].Owner != null && myPlateau.Cases[players[index].PreviousPosition].Owner != players[index].Name){
                    Console.WriteLine("Vous etiez chez : " + myPlateau.Cases[players[index].PreviousPosition].Owner);
                }
            } else {
                Console.WriteLine("Anciene position : Prison");
            }
            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
        }

        public static void DisplayInfoPostRound(Plateau myPlateau, List<Joueur> players, int index)
        {
            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Nouveau solde : " + players[index].Money + "$");
            if (players[index].IsInGame == true)
            {
                if (players[index].JailRemaining <= 0)
                {
                    Console.WriteLine("Nouvelle position : " + myPlateau.Cases[players[index].Position].Name);
                    if (myPlateau.Cases[players[index].Position].Owner == players[index].Name)
                    {
                        Console.WriteLine("Vous etes chez vous.");
                    }
                    else if (myPlateau.Cases[players[index].Position].Owner == null)
                    {
                        Console.WriteLine("Vous etes sur une cases n'apartenant a personne.");
                    }
                    else if (myPlateau.Cases[players[index].Position].Owner != null && myPlateau.Cases[players[index].Position].Owner != players[index].Name)
                    {
                        Console.WriteLine("Vous etes chez : " + myPlateau.Cases[players[index].Position].Owner);
                    }
                }
                else
                {
                    Console.WriteLine("Nouvelle position : Prison");
                }
                if (players[index].JailRemaining < 0)
                {
                    Console.WriteLine("Vous avez " + players[index].JailRemaining + " carte(s) libere de prison en stock");
                }
            } else
            {
                Console.WriteLine("Faillite. Vous etes elimine");
            }
            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            
        }

        public static (Plateau _myPlateau, List<Joueur> _players) InteractWithCurrentPosition(Plateau myPlateau, List<Joueur> players, int index)
        {
            switch (myPlateau.Cases[players[index].Position].Type)
            {
                case "propriete":
                    if (myPlateau.Cases[players[index].Position].IsByable == true && players[index].Money < myPlateau.Cases[players[index].Position].Price) // chez personne & pas assez de sous pour acheter..
                    {
                        Console.WriteLine("\nVous n'avez pas assez de sous pour acheter");
                    }
                    else if (myPlateau.Cases[players[index].Position].IsByable == true && players[index].Money >= myPlateau.Cases[players[index].Position].Price) // chez personne & assez de sous pour acheter!
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
                    else if (myPlateau.Cases[players[index].Position].IsByable == false && myPlateau.Cases[players[index].Position].Owner != players[index].Name)
                    {// chez quelqun d'autre
                        if (myPlateau.Cases[players[index].Position].IsHypoteque == true)
                        {
                            Console.WriteLine("La propriete est hypotequee, vous ne payez pas de loyer.");
                        }
                        else
                        {
                            if (myPlateau.Cases[players[index].Position].Family == "gare")
                            {
                                int nbrOfGare = 0;
                                foreach (Propriete caseI in myPlateau.Cases)
                                {
                                    if (caseI.Family == "gare" && caseI.Owner == myPlateau.Cases[players[index].Position].Owner) { nbrOfGare++; }
                                }
                                players[index].Money -= myPlateau.Cases[players[index].Position].Loyer[nbrOfGare]; // prend le loyé au locataire
                                int destLoyer = players.FindIndex(a => a.Name == myPlateau.Cases[players[index].Position].Owner);
                                players[destLoyer].Money += myPlateau.Cases[players[index].Position].Loyer[nbrOfGare];//done le loyé au proprio
                                Console.WriteLine("vous donnez " + myPlateau.Cases[players[index].Position].Loyer[nbrOfGare] + "$ a " + myPlateau.Cases[players[index].Position].Owner + " car il possede " + nbrOfGare + " gare(s)");
                            }
                            else if (myPlateau.Cases[players[index].Position].Family == "compagnie")
                            {
                                int nbrOfCompagnie = 0;
                                foreach (Propriete caseI in myPlateau.Cases)
                                {
                                    if (caseI.Family == "gare" && caseI.Owner == myPlateau.Cases[players[index].Position].Owner) { nbrOfCompagnie++; }
                                }
                                if (nbrOfCompagnie == 1)
                                {
                                    players[index].Money -= (myPlateau.Des[0]+myPlateau.Des[1])*4; // prend le loyé au locataire
                                    int destLoyer = players.FindIndex(a => a.Name == myPlateau.Cases[players[index].Position].Owner);
                                    players[destLoyer].Money += (myPlateau.Des[0] + myPlateau.Des[1]) * 4;//done le loyé au proprio
                                    Console.WriteLine("vous donnez " + ((myPlateau.Des[0] + myPlateau.Des[1]) * 4) + "$ a " + myPlateau.Cases[players[index].Position].Owner + " car il possede 1 compagnie");
                                }
                                if (nbrOfCompagnie == 2)
                                {
                                    players[index].Money -= (myPlateau.Des[0] + myPlateau.Des[1]) * 10; // prend le loyé au locataire
                                    int destLoyer = players.FindIndex(a => a.Name == myPlateau.Cases[players[index].Position].Owner);
                                    players[destLoyer].Money += (myPlateau.Des[0] + myPlateau.Des[1]) * 10;//done le loyé au proprio
                                    Console.WriteLine("vous donnez " + ((myPlateau.Des[0] + myPlateau.Des[1]) * 10) + "$ a " + myPlateau.Cases[players[index].Position].Owner + " car il possede 2 compagnies");
                                }
                            }
                            else
                            {
                                players[index].Money -= myPlateau.Cases[players[index].Position].Loyer[myPlateau.Cases[players[index].Position].House]; // prend le loyé au locataire
                                int destLoyer = players.FindIndex(a => a.Name == myPlateau.Cases[players[index].Position].Owner);
                                players[destLoyer].Money += myPlateau.Cases[players[index].Position].Loyer[myPlateau.Cases[players[index].Position].House];//done le loyé au proprio
                                Console.WriteLine("vous donnez " + myPlateau.Cases[players[index].Position].Loyer[myPlateau.Cases[players[index].Position].House] + "$ a " + myPlateau.Cases[players[index].Position].Owner);
                            }
                            if (players[index].Money < 0) { players[index].IsInGame = false; Console.WriteLine("Faillite. Vous etes elimine"); }
                        }
                    }
                    else //chez sois
                    {
                        (myPlateau, players) = InteractWithProperty(myPlateau, players, index); // interact with the player property.
                        
                    }
                    DisplayInfoPostRound(myPlateau, players, index);
                    break;
                case "taxe":
                    players[index].Money -= myPlateau.Cases[players[index].Position].Loyer[0];
                    myPlateau.ParcGratuit += myPlateau.Cases[players[index].Position].Loyer[0];
                    Console.WriteLine("Vous devez payer :" + myPlateau.Cases[players[index].Position].Loyer[0] + "$");
                    if (players[index].Money < 0) { players[index].IsInGame = false; Console.WriteLine("Faillite. Vous etes elimine"); }
                    DisplayInfoPostRound(myPlateau, players, index);
                    break;
                case "card":
                    //random carte
                    DisplayInfoPostRound(myPlateau, players, index);
                    break;
                case "start":
                    players[index].Money += 200;
                    Console.WriteLine("Vous etes sur la case depart. +200$ suplementaire");
                    DisplayInfoPostRound(myPlateau, players, index);
                    break;
                case "jail":
                    Console.WriteLine("Vous allez directement en prison");
                    players[index].Position = 10;
                    if (players[index].JailRemaining >= 0) { players[index].JailRemaining = 3; } else if (players[index].JailRemaining < 0) { players[index].JailRemaining += 1; Console.WriteLine("Vous venez d'etre libere de prison"); }
                    DisplayInfoPostRound(myPlateau, players, index);
                    break;
                case "parc":
                    players[index].Money += myPlateau.ParcGratuit;
                    Console.WriteLine("Parc gratuit. Vous gagnez :" + myPlateau.ParcGratuit + "$");
                    myPlateau.ParcGratuit = 0;
                    DisplayInfoPostRound(myPlateau, players, index);
                    break;
                case "jailStanding":
                    if (players[index].JailRemaining > 0) { players[index].JailRemaining -= 1; }
                    DisplayInfoPostRound(myPlateau, players, index);
                    break;
                default:
                    break;
            }
           //DisplayInfoPostRound(myPlateau, players, index);
            return (myPlateau, players);
        }

        public static (Plateau _myPlateau, List<Joueur> _players) InteractWithProperty(Plateau myPlateau, List<Joueur> players, int index)
        {
            bool EndOfWhile = false;
            while (EndOfWhile != true)
            {
                Console.Clear();
                DisplayInfoPreRound(myPlateau, players, index);
                DisplayMoveInfo(myPlateau, players, index);
                Console.WriteLine("Vous etes chez vous. que voulez vous faire : [A/B/C/D/Enter]");
                if (myPlateau.Cases[players[index].Position].House < 5 && myPlateau.Cases[players[index].Position].IsHypoteque == false && players[index].Money >= (myPlateau.Cases[players[index].Position].Corner * 50) && myPlateau.Cases[players[index].Position].Family != "gare" && myPlateau.Cases[players[index].Position].Family != "compagnie") { Console.WriteLine("A : Acheter une ou plusieurs maisons/hotel (" + (myPlateau.Cases[players[index].Position].Corner * 50) + "$)"); }
                if (myPlateau.Cases[players[index].Position].House > 0 && myPlateau.Cases[players[index].Position].IsHypoteque == false) { Console.WriteLine("B : Vendre une maisons/hotel (" + (myPlateau.Cases[players[index].Position].Corner * 25) + "$)"); }
                if (myPlateau.Cases[players[index].Position].IsHypoteque == false && myPlateau.Cases[players[index].Position].House == 0) { Console.WriteLine("C : Hypotequer"); }
                if (myPlateau.Cases[players[index].Position].IsHypoteque == true && players[index].Money >= (myPlateau.Cases[players[index].Position].Loyer[6] + Convert.ToInt32(myPlateau.Cases[players[index].Position].Loyer[6] * 0.1))) { Console.WriteLine("D : Lever l'hypoteque"); }
                Console.WriteLine("Enter : Ne rien faire");
                ConsoleKeyInfo cki = Console.ReadKey();
                switch (cki.Key.ToString())
                {
                    case "Enter":
                        EndOfWhile = true;
                        break;
                    case "A": // acheter une maison
                        if (myPlateau.Cases[players[index].Position].House < 5
                            && myPlateau.Cases[players[index].Position].IsHypoteque == false
                            && players[index].Money >= (myPlateau.Cases[players[index].Position].Corner * 50)
                            && myPlateau.Cases[players[index].Position].Family != "gare"
                            && myPlateau.Cases[players[index].Position].Family != "compagnie")
                        {
                            myPlateau.Cases[players[index].Position].House += 1;
                            players[index].Money -= (myPlateau.Cases[players[index].Position].Corner * 50);
                        }
                        break;
                    case "B": // vendre une maison
                        if (myPlateau.Cases[players[index].Position].House > 0
                            && myPlateau.Cases[players[index].Position].IsHypoteque == false)
                        {
                            myPlateau.Cases[players[index].Position].House -= 1;
                            players[index].Money += (myPlateau.Cases[players[index].Position].Corner * 25);
                        }
                        break;
                    case "C": //hypotequer
                        if (myPlateau.Cases[players[index].Position].IsHypoteque == false && myPlateau.Cases[players[index].Position].House == 0)
                        {
                            myPlateau.Cases[players[index].Position].IsHypoteque = true;
                            players[index].Money += myPlateau.Cases[players[index].Position].Loyer[6]; // ajoute la valeur de l'hypoteque
                        }
                        break;
                    case "D": // lever une hypoteque
                        if (myPlateau.Cases[players[index].Position].IsHypoteque == true
                            && players[index].Money >= (myPlateau.Cases[players[index].Position].Loyer[6] + Convert.ToInt32(myPlateau.Cases[players[index].Position].Loyer[6] * 0.1)))
                        {
                            myPlateau.Cases[players[index].Position].IsHypoteque = false;
                            players[index].Money -= (myPlateau.Cases[players[index].Position].Loyer[6] + Convert.ToInt32(myPlateau.Cases[players[index].Position].Loyer[6]* 0.1)); // preleve la valeur de la levée d'hypoteque.
                        }
                        break;
                    default:
                        break;
                }
            }
            return (myPlateau, players);
        }

        public static (Plateau _myPlateau, List<Joueur> _players) MoovePlayer(Plateau myPlateau, List<Joueur> players, int index)
        {
            if (players[index].JailRemaining > 0 && myPlateau.Des[0] == myPlateau.Des[1])
            { // release prisoner if dices double.
                players[index].JailRemaining = 0;
            }
            if (players[index].JailRemaining <= 0)
            { // move player only if he is not in jail
                players[index].Position = ((myPlateau.Des[0] + myPlateau.Des[1] + players[index].Position));
                if (players[index].Position >= 40)
                { // give and display 200$ to player if he pass at the start
                    players[index].Money += 200;
                    players[index].Position = players[index].Position % 40;
                }
            }
            return (myPlateau, players);
        }

        public static void DisplayMoveInfo(Plateau myPlateau, List<Joueur> players, int index)
        {
            Console.WriteLine("Des : " + myPlateau.Des[0] + " & " + myPlateau.Des[1]);
            if (players[index].JailRemaining > 0 && myPlateau.Des[0] == myPlateau.Des[1])
            { // release prisoner if dices double.
                Console.Write("Double. Libere de prison. ");
            }
            else if (players[index].JailRemaining > 0 && myPlateau.Des[0] != myPlateau.Des[1])
            { //say to the prisoners that he stay in jail for X more rounds
                Console.WriteLine("Bloque en prison, deplacement impossible. " + players[index].JailRemaining + " tour(s) restant.");
            }
            if (players[index].JailRemaining <= 0)
            { // move player only if he is not in jail
                if (players[index].Position >= 40)
                { // give and display 200$ to player if he pass at the start
                    Console.WriteLine("Passage par la case depart : +200$. ");
                }
                Console.WriteLine("Deplacement en : " + myPlateau.Cases[players[index].Position].Name);

            }  // display the player its new possition
        }

        public static int RunMonopoly()
        {
            List<Joueur> players = ShuffleListOfJoueur(CreateAllPlayers()); // create all the players 
            Plateau myPlateau = new Plateau(players); // initiate the plateau
            Random rnd = new Random();

            Console.Write("\nAppuyer sur une touche pour commencer...");
            Console.ReadKey();
            Console.Clear();
            while (InGamePlayer(players) > 1) {
                for (int index = 0; index < players.Count; index++) {
                    players[index].PreviousPosition = players[index].Position; players[index].PreviousMoney = players[index].Money;
                    if (players[index].IsInGame == true) {
                        myPlateau.Des = new int[] { rnd.Next(1, 7), rnd.Next(1, 7) };
                        //printMapStats(myPlateau, players);
                        DisplayInfoPreRound(myPlateau, players, index);
                        (myPlateau, players) = MoovePlayer(myPlateau, players, index);
                        DisplayMoveInfo(myPlateau, players, index);
                        (myPlateau, players) = InteractWithCurrentPosition(myPlateau, players, index); // interact with the player location.
                        //Console.WriteLine(myPlateau.Cases[players[i].Position].Name);///////////////////
                        Console.Write("\nAppuyer sur une touche pour terminer votre tour...");
                        Console.ReadKey();
                        Console.Clear();
                        
                    }
                }

                //endGame = true;
            }
            foreach (Joueur item in players) {
                if (item.IsInGame == true) {
                    Console.Clear();
                    Console.Write(item.Name + " A gagner la partie.Bravo !");
                }
            }
            Console.Write("\nAppuyer sur Q pour terminer le programme...");
            for (ConsoleKeyInfo cki = Console.ReadKey(); cki.Key.ToString() != "Q"; cki = Console.ReadKey()) {
                //Console.Clear();
                //Console.Write("\nAppuyer sur Q pour terminer le programme...");
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
           
        }
    }
}