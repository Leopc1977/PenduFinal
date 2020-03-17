using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Newtonsoft.Json;

namespace Pendu
{

    class Game
    {

        List<string> Letters = new List<string>();
        string motMystere;
        int cmpCoup;

        public void Load()
        {
            Console.Clear();

            //Présentation
            string ligne = "<---------------------------------------------------------------------------------------------------------------------->";
            string un = "Bienvenue sur le pendu ";
            string deux = "Le principe du jeu est simple, vous disposez d\'un nombre de coup pour trouver le mot qui se cache derriere les *";
            string trois = "Veuillez choisir le niveau de difficulté ";
            string quatre = "Facile : 1 - Normal : 2 - Difficile : 3";

            Console.WriteLine(ligne);
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (un.Length / 2)) + "}", un));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (deux.Length / 2)) + "}", deux));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (trois.Length / 2)) + "}", trois));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (quatre.Length / 2)) + "}", quatre));
            Console.WriteLine(ligne);
            //Choix du nombre de coup
            Console.Write("Votre choix : ");
            ConsoleKeyInfo difficulté = Console.ReadKey(true);
            string difficultéString = difficulté.Key.ToString();
            switch (difficultéString)
            {
                case "NumPad1":
                    Console.Write("1\n");
                    cmpCoup = 10;
                    break;
                case "NumPad2":
                    Console.Write("2\n");
                    cmpCoup = 10;
                    break;
                case "NumPad3":
                    Console.Write("3\n");
                    cmpCoup = 10;
                    break;
                default:
                    Console.Write(" Le nombre n'est pas entre 1 et 3 : coup autorisé : 10\n");
                    cmpCoup = 10;
                    break;
            }
            Letters.Clear();
        }

        public void Update()
        {
            char[,] motMystereLettre = ToChar();
            string motMystere = ChooseWord();
            int motTrouve = motMystere.Length;
            bool lettreTrouve = false;
            //Boucle du jeu
            do
            {
                lettreTrouve = false;
                //Mots utilisés
                Console.WriteLine("Il vous reste " + cmpCoup + " coups à jouer !");
                PenduDraw(cmpCoup);
                Console.Write("Lettre_s utilisée_s : ");
                foreach (string letter in Letters)
                {
                    Console.Write(letter + " ");
                }

                //Ecris le mot mystere avec les *
                Console.WriteLine("");
                Console.Write("Le mot mystère : ");
                for (int i = 0; i < motMystere.Length; i++)
                {
                    if (motMystereLettre[i, 1] == '0')
                    {
                        Console.Write("*");
                    }
                    else if (motMystereLettre[i, 1] == '1')
                    {
                        Console.Write(motMystereLettre[i, 0]);
                    }
                }
                //Remplace les * par les lettres
                Console.WriteLine("\n Choisissez une lettre : \n");
                ConsoleKeyInfo saisie = Console.ReadKey(true);
                string saisieString;
                for (int i = 0; i < motMystere.Length; i++)
                {
                    saisieString = saisie.Key.ToString().ToUpper();
                    string motMystereLettreString = motMystereLettre[i, 0].ToString().ToUpper();
                    if (saisieString == motMystereLettreString)
                    {
                        motMystereLettre[i, 1] = '1';
                        lettreTrouve = true;
                        motTrouve--;
                    }
                    if (!Letters.Contains(saisieString))
                    {
                        Letters.Add(saisieString);
                    }
                }

                //Vérification 
                if (lettreTrouve == false)
                {
                    cmpCoup--;
                }
                if (motTrouve == 0)
                {
                    Console.WriteLine("Bravo vous avez trouve le mot mystere : " + motMystere);
                    break;
                }
                else if (cmpCoup == 0 || cmpCoup < 0)
                {
                    Console.WriteLine("Dommage vous n'avez pas trouve le mot mystere" + motMystere);
                    PenduDraw(cmpCoup);
                    Replay();
                }
            } while (motTrouve > 0 || cmpCoup > 0);
            Replay();
        }

        public string ChooseWord()
        {
            //Initialisation du choix du mot mystère
            string motMystere;
            Random random = new Random(DateTime.Now.Second);
            string[] listeMot = new string[] { "ANGLETERRE", "AUSTRALIE","AFGHANISTAN", "ALBANIE", "ALGERIE", "ALLEMAGNE", "ANDORRE" };
            motMystere = listeMot[random.Next(0, listeMot.Length)];
            return motMystere;
        }

        public char[,] ToChar()
        {
            //Conversion du mot mystère en char
            motMystere = ChooseWord();
            char[,] motMystereLettre = new char[motMystere.Length, 2];
            for (int i = 0; i < motMystere.Length; i++)
            {
                motMystereLettre[i, 1] = '0';
                motMystereLettre[i, 0] = motMystere[i];
            }
            return motMystereLettre;
        }

        public void PenduDraw(int pNbCoup)
        {
            string cmpCoup0;
            string cmpCoup1;
            string cmpCoup2;
            string cmpCoup3;
            string cmpCoup4;
            string cmpCoup5;
            string cmpCoup6;
            string cmpCoup7;
            string cmpCoup8;
            string cmpCoup9;

            cmpCoup9 = @"{  'cmpCoup9': [
            '',
            '',
            '',
            '',
            '',
            '',
            '',
            '',
            '',
            '',
            '',
            '',
            '',
            '',
            '',
            '',
            '',
            '',
            '',
            '',
            '',
            '',
            '',
            '',
            '',
            '..',
            '*************+-.',
            '%%%%%%%%%%%%%#w.'
          ]}";

            cmpCoup8 = @"{  'cmpCoup8': [
            '\t *#%M+ ',
            '\t *#%M+  ',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t +#%M-      ..',
            '\'*****G&%#G***+-.',
            '\'%%%%%%%%%%%%%#w.'
          ]}";

            cmpCoup7 = @"{  'cmpCoup7': [
            '    +M%%%%%%%%%%%%%%%G-',
            '\t +#%%%%%%%%%%%%%%&G-    ',
            '\'\t *#%#G************-.',
            '\'\t *#%M-              ..',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t +#%M-      ..',
            '\'*****G&%#G***+-.',
            '\'%%%%%%%%%%%%%#w.'
          ]}";

            cmpCoup6 = @"{  'cmpCoup6': [
            '\t +M%%%%%%%%%%%%%%&G-',
            '\t +#%%%%%%%%%%%%%%&G-    ',
            '\'\t *#%#G*******+*M%%H-',
            '\'\t *#%M-         *M#G.',
            '\'\t *#%M+         .---.',
            '\'\t *#%M+      ..      ..',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t +#%M-      ..',
            '\'*****G&%#G***+-.',
            '\'%%%%%%%%%%%%%#w.'
          ]}";

            cmpCoup5 = @"{  'cmpCoup5': [
            '\t +M%%%%%%%%%%%%%%%%%#w.',
            '\t +#%%%%%%%%%%%%%%%%%#w.     ',
            '\'\t *#%#G*********++*M%&w    .',
            '\'\t *#%M-          .+H%%H+..',
            '\'\t *#%M+        .*M&%%%%&H+',
            '\'\t *#%M+        .w&%&MM%%#*',
            '\'\t *#%M+        .w&%G.-M%#*',
            '\'\t *#%M+        .w&%#GH&%#*',
            '\'\t *#%M+        .w#%%%%%%M+',
            '\'\t *#%M+        .-+*wwww*+.',
            '\'\t *#%M+      ..            .',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t +#%M-      ..',
            '\'*****G&%#G***+-.',
            '\'%%%%%%%%%%%%%#w.'
          ]}";

            cmpCoup4 = @"{  'cmpCoup4': [
            '\t +M%%%%%%%%%%%%%%%%%#w.',
            '\t +#%%%%%%%%%%%%%%%%%#w.    ',
            '\'\t *#%#G*********++*M%&w    .',
            '\'\t *#%M-          .+H%%H+..',
            '\'\t *#%M+        .*M&%%%%&H+',
            '\'\t *#%M+        .w&%&MM%%#*',
            '\'\t *#%M+        .w&%G.-M%#*',
            '\'\t *#%M+        .w&%#GG&%&*',
            '\'\t *#%M+        .*#%%%%%%M+',
            '\'\t *#%M+        .-+w#%%M*+.',
            '\'\t *#%M+      ..   .G%&w    .',
            '\'\t *#%M+           .H%&w.',
            '\'\t *#%M+           -H%&w.',
            '\'\t *#%M+           -H%&w.',
            '\'\t *#%M+           -H%&w.',
            '\'\t *#%M+           -H%&w.',
            '\'\t *#%M+           -H%&w.',
            '\'\t *#%M+           -H%&w.',
            '\'\t *#%M+           -H%%G.',
            '\'\t *#%M+           .wMH*.',
            '\'\t *#%M+           .....',
            '\'\t *#%M+         ..      ..',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t +#%M-      ..',
            '\'*****G&%#G***+-.',
            '\'%%%%%%%%%%%%%#w.'
          ]}";

            cmpCoup3 = @"{  'cmpCoup3': [
            '\t +M%%%%%%%%%%%%%%%%%#w.',
            '\t +#%%%%%%%%%%%%%%%%%#w.   ',
            '\t *#%#G*********++*M%&w    .    ',
            '\'\t *#%M-          .+H%%H+..',
            '\'\t *#%M+        .*M&%%%%&H+',
            '\'\t *#%M+        .w&%&MM%%#*',
            '\'\t *#%M+        .w&%G.-M%#*',
            '\'\t *#%M+        .w&%#GG&%&*',
            '\'\t *#%M+   .... .*#%%%%%%M+',
            '\'\t *#%M+   -G#H-  -*M%%M*+.',
            '\'\t *#%M+   +H&#w-..+H%&w    .',
            '\'\t *#%M+   ..-wM%%&&%%#w.',
            '\'\t *#%M+      -G####%%&w.',
            '\'\t *#%M+      .... -H%&w.',
            '\'\t *#%M+    .      .G%&w.',
            '\'\t *#%M+           -H%&w.',
            '\'\t *#%M+           -H%&w.',
            '\'\t *#%M+           -H%&w.',
            '\'\t *#%M+           -H%%G.',
            '\'\t *#%M+           .wMH*.',
            '\'\t *#%M+           .....',
            '\'\t *#%M+         ..      ..',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t *#%M+',
            '\'\t +#%M-      ..',
            '\'*****G&%#G***+-.',
            '\'%%%%%%%%%%%%%#w.'
          ]}";

            cmpCoup2 = @"{'cmpCoup2': [
                '    +M%%%%%%%%%%%%%%%%%#w.',
                '\t +#%%%%%%%%%%%%%%%%%#w.  ',
                '\t *#%#G*********++*M%&w    .',
                '\t *#%M-          .+H%%H+.. ',
                '\t *#%M+        .*M&%%%%&H+',
                '\'\t *#%M+        .w&%&MM%%#*',
                '\'\t *#%M+        .w&%G.-M%#*',
                '\'\t *#%M+        .w&%#GG&%&*',
                '\'\t *#%M+   .... .*#%%%%%%M+',
                '\'\t *#%M+   -G#H-  -*M%%H*-    ..',
                '\'\t *#%M+   +H&#w-..+H%&G-.-+-.',
                '\'\t *#%M+   ..-wM%%&&%%%%&&%&G-   ..',
                '\'\t *#%M+      -G####&%%&####HG*-    .',
                '\'\t *#%M+      .... -H%&G.  .G&%G.   .',
                '\'\t *#%M+    .      .G%&w    -wHHHG+.',
                '\'\t *#%M+           -H%&w.     .G%&w.',
                '\'\t *#%M+           -H%&w.      +**-.',
                '\'\t *#%M+           -H%&w.   ..      ..',
                '\'\t *#%M+           -H%%G.',
                '\'\t *#%M+           .wMH*.',
                '\'\t *#%M+           .....',
                '\'\t *#%M+         ..      ..',
                '\'\t *#%M+',
                '\'\t *#%M+',
                '\'\t *#%M+',
                '\'\t +#%M-      ..',
                '\'*****G&%#G***+-.',
                '\'%%%%%%%%%%%%%#w.'
              ]}";

            cmpCoup1 = @"{'cmpCoup1': [
            '+M%%%%%%%%%%%%%%%%%#w.',
            '+#%%%%%%%%%%%%%%%%%#w.',
            '\'*#%#G*********++*M%&w    .',
            '\'*#%M-          .+H%%H+..',
            '\'*#%M+        .*M&%%%%&H+',
            '\'*#%M+        .w&%&MM%%#*',
            '\'*#%M+        .w&%G.-M%#*',
            '\'*#%M+        .w&%#GG&%&*',
            '\'*#%M+   .... .*#%%%%%%M+',
            '\'*#%M+   -G#H-  -*M%%H*-    ..',
            '\'*#%M+   +H&#w-..+H%&G-.-+-.',
            '\'*#%M+   ..-wM%%&&%%%%&&%&G-   ..',
            '\'*#%M+      -G####&%%&####HG*-    .',
            '\'*#%M+      .... -H%&G.  .G&%G.   .',
            '\'*#%M+    .      .G%&w    -wHHHG+.',
            '\'*#%M+           -H%&w.     .G%&w.',
            '\'*#%M+           -H%&w.      +**-.',
            '\'*#%M+           .H%&w.   ..      ..',
            '\'*#%M+      ..   .H%%G.',
            '\'*#%M+    .    -+wHMH*.',
            '\'*#%M+    .    w&%H-',
            '\'*#%M+      -wHHHG+    ..',
            '\'*#%M+     .*#%M-',
            '\'*#%M+   -G#MG*+.   ..',
            '\'*#%M+   -H&M+   ..',
            '\'+#%M-    -+-.',
            '*****G&%#G***+.',
            '.',
            '%%%%%%%%%%%%%#w.'
          ]}";

            cmpCoup0 = @"{
          'cmpCoup0': [
            '\t +M%%%%%%%%%%%%%%%%%#w.',
            '\t +#%%%%%%%%%%%%%%%%%#w.',
            '\t *#%#G*********++*M%&w    .             ',
            '\t *#%M-          .+H%%H+..               ',
            '\t *#%M+        .*M&%%%%&H+               ',
            '\t *#%M+        .w&%&MM%%#*               ',
            '\t *#%M+        .w&%G.-M%#*               ',
            '\t *#%M+        .w&%#GG&%&*               ',
            '\t *#%M+   .... .*#%%%%%%M+               ',
            '\t *#%M+   -G#H-  -*M%%H*-    ..          ',
            '\t *#%M+   +H&#w-..+H%&G-.-+-.            ',
            '\t *#%M+   ..-wM%%&&%%%%&&%&G-   ..       ',
            '\t *#%M+      -G####&%%&####HG*-    .     ',
            '\t *#%M+      .... -H%&G.  .G&%G.   .     ',
            '\t *#%M+    .      .G%&w    -wHHHG+.     ',
            '\t *#%M+           -H%&w.     .G%&w.     ',
            '\t *#%M+           -H%&w.      +**-.      ',
            '\t *#%M+           .H%&w.   ..      ..    ',
            '\t *#%M+      ..   .H%%w    ..            ',
            '\t *#%M+    .    -+wHMMGw+.   ..          ',
            '\t *#%M+    .    w&%G--M%#*               ',
            '\t *#%M+      -wHHHG+ .*GHHH*.   ..      ',
            '\t *#%M+     .*#%M-      *#%M+           ',
            '\t *#%M+   -G#MG*+.      .+wH#Mw.         ',
            '\t *#%M+   -H&M+   ..  .    *#&G-         ',
            '\t +#%M-    -+-.            .---.         ',
            '*****G&%#G***+.    .       ..      ..       ',
            '%%%%%%%%%%%%%#w.                             '
          ]
        }";
            string json = "";

            switch (pNbCoup)
            {
                case 0:
                    json = cmpCoup0;
                    break;
                case 1:
                    json = cmpCoup1;
                    break;
                case 2:
                    json = cmpCoup2;
                    break;
                case 3:
                    json = cmpCoup3;
                    break;
                case 4:
                    json = cmpCoup4;
                    break;
                case 5:
                    json = cmpCoup5;
                    break;
                case 6:
                    json = cmpCoup6;
                    break;
                case 7:
                    json = cmpCoup7;
                    break;
                case 8:
                    json = cmpCoup8;
                    break;
                case 9:
                    json = cmpCoup9;
                    break;
                default:
                    break;
            }

            JsonTextReader reader = new JsonTextReader(new StringReader(json));
            while (reader.Read())
            {
                if (reader.Value != null)
                {
                    Console.WriteLine(reader.Value);
                }
            }
        }

        public void Replay()
        {
            Console.WriteLine("Voulez vous rejouer ?");
            Console.WriteLine("Oui : 1 - Non : 2");
            Console.WriteLine("Votre choix : ");
            ConsoleKeyInfo choix = Console.ReadKey(true);
            string choixString = choix.Key.ToString();
            switch (choixString)
            {
                case "NumPad1":
                    Load();
                    Update();
                    break;

                default:
                    Console.WriteLine("Fermeture de la fenetre dans 2 secondes...");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
