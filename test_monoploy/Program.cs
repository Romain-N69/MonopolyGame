using System;
using Gtk;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;

namespace test_monoploy
{

    public class Plateau
    {
        public Plateau()
        {
        }
    }

    public class Joueur
    {
        string _name;
        int _money;
        int _position;
        int[] _ownedPlace;
        int _jailRemaining;

        public Joueur(string name)
        {
            this._name = name;
            this._money = 1500;
            this._position = 0;
            this._ownedPlace = null;
            this._jailRemaining = 0;

        }
    }

    public class Case
    {
        string _name;
        string _type;

        public Case(string name, string type) //Ctor
        {
            this._name = name;
            this._type = type;
        }

        public string Name //getseter name
        {
            get { return _name; }
            set { _name = value; } // if rename posibility
        }

        public string Type //getseter type
        {
            get { return _type; }
        }
    }

    class Propriete : Case
    {
        public string _name;
        public string _type;
        public string _family;
        public int _loyer;
        public bool _isByable;
        public bool _isHypoteque;
        public string _owner;

        public Propriete(string name, string type, string family, int loyer) : base(name, type)
        {
            this._family = family;
            this._loyer = loyer;
            this._isByable = true;
            this._isHypoteque = false;
        }

        public string Family //getseter family
        {
            get { return _family; }
        }

        public int Loyer // getseter loyer
        {
            get { return _loyer; }
            set { _loyer = value; }
        }

        public bool IsByable // getseter isByable
        {
            get { return _isByable; }
            set { _isByable = value; }
        }

        public bool IsHypoteque // getseter isHypoteque
        {
            get { return _isHypoteque; }
            set { _isHypoteque = value; }
        }

        public string Owner // getseter owner
        {
            get { return _owner; }
            set { _owner = value; }
        }
    }

    class Taxe : Case
    {
        string _name;
        string _type;
        int _loyer;
        bool _isByable;

        public Taxe(string name, string type, int loyer) : base (name, type)
        {
                this._loyer = loyer;
                this._isByable = false; 
        }

        public int Loyer // getseter loyer
        {
            get { return _loyer; }
        }
    }

    class MainClass
    {
        public static int runMonopoly()
        {
            while (1 != 2)
            {
                //
            }
        }
        public static void Main(string[] args)
        {
            Application.Init();
            MainWindow win = new MainWindow();
            win.Show();
            Application.Run();
            runMonopoly();
        }
    }
}


/*
interagiraveclacase(int numerodecase, player) {
    switch ()
        case: type = propritete:
            est ce que çe est acheté 
            est ce quon veux acheter 
            a qui on doit un loyer
        case: type = taxe
            tu paye
        case: type = chance
            tu pioche une chance
        case: type = comunoté
            tu pioche une comunoté
        case: type = depart
            tu gagne 200$
        case: type = prison
            tu va en prison
        case: null
            fin du tours
        case: type = parc gratuit
            tu gagne le parc gratuit
}

turn (player) {
    lancerledes()
    deplacer()
    interagiraveclacase(numerodecase, player)
}

jeu {
    while (partie en cour) {
        while(joureurs.lenht && inInGame)
            turn(joureur[i])
        }
    }
}
*/