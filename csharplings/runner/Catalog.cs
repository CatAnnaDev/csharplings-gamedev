namespace Csharplings.Runner;

public sealed record Exercise(
    string Id,
    string Section,
    string ClassName,
    string Title,
    string Instructions,
    string Hint);

public static class Catalog
{
    public static readonly IReadOnlyList<Exercise> All = new List<Exercise>
    {
        new("intro1", "00_intro", "Intro1", "Comment ca marche",
            "Rien a corriger dans le code : il tourne deja.\nOuvre le fichier, mets 'NotDone' a false, sauvegarde.\nC'est la boucle que tu repeteras 38 fois.",
            "La ligne est 'public const bool NotDone = true;'. Remplace true par false."),

        new("intro2", "00_intro", "Intro2", "Lire une erreur de compilation",
            "Le fichier ne compile pas. Lis le message d'erreur au-dessus : il te donne\nle fichier, la ligne, la colonne et la cause. Corrige, puis passe NotDone a false.",
            "En C# chaque instruction se termine par un point-virgule."),

        new("variables1", "01_variables", "Variables1", "Declarer une variable",
            "Une variable, c'est un type + un nom + une valeur.\nDeclare les variables manquantes pour que les verifications passent.",
            "La syntaxe est : int age = 30;"),

        new("variables2", "01_variables", "Variables2", "var et types explicites",
            "'var' laisse le compilateur deviner le type a partir de la valeur.\nCe n'est PAS un type dynamique : le type est fige a la compilation.",
            "var x = 5; donne un int. Tu ne peux plus ecrire x = \"texte\"; ensuite."),

        new("variables3", "01_variables", "Variables3", "const et readonly",
            "'const' : valeur figee a la compilation, jamais modifiable.\n'readonly' : fixee une fois au demarrage, plus modifiable ensuite.",
            "Un const doit etre initialise sur la meme ligne que sa declaration."),

        new("types1", "02_types", "Types1", "Les types de base",
            "int, float, double, bool, char, string.\nAttention aux suffixes : 1.5 est un double, 1.5f est un float.",
            "float vitesse = 1.5f; le 'f' est obligatoire."),

        new("types2", "02_types", "Types2", "Conversions et cast",
            "int / int donne un int : la partie decimale est jetee.\nPour garder les decimales il faut convertir AVANT la division.",
            "(float)a / b convertit a en float, puis divise. (float)(a / b) est trop tard."),

        new("types3", "02_types", "Types3", "Texte vers nombre",
            "int.Parse plante si le texte n'est pas un nombre.\nint.TryParse renvoie true/false et ne plante jamais : prefere-le.",
            "if (int.TryParse(texte, out int valeur)) { ... }"),

        new("flow1", "03_flow", "Flow1", "if / else",
            "Complete la logique de conditions pour que la fonction renvoie le bon rang.",
            "L'ordre des if compte : teste d'abord le cas le plus restrictif."),

        new("flow2", "03_flow", "Flow2", "switch expression",
            "Le switch moderne renvoie une valeur au lieu de faire des breaks.\nLe '_' est le cas par defaut, il est obligatoire s'il manque des cas.",
            "return mood switch { Mood.Happy => \"content\", _ => \"?\" };"),

        new("flow3", "03_flow", "Flow3", "Boucles for et while",
            "'for' quand tu connais le nombre de tours. 'while' quand tu attends une condition.",
            "for (int i = 0; i < 10; i++) fait 10 tours, de 0 a 9."),

        new("flow4", "03_flow", "Flow4", "foreach, break, continue",
            "'foreach' parcourt une collection sans index.\n'continue' saute au tour suivant, 'break' sort de la boucle.",
            "continue quand tu veux ignorer un element, break quand tu as trouve ce que tu cherchais."),

        new("methods1", "04_methods", "Methods1", "Ecrire une methode",
            "Une methode : type de retour, nom, parametres, corps.\n'void' veut dire qu'elle ne renvoie rien.",
            "public static int Double(int x) { return x * 2; }"),

        new("methods2", "04_methods", "Methods2", "Parametres optionnels et nommes",
            "Un parametre avec une valeur par defaut devient optionnel.\nA l'appel, on peut nommer les arguments pour la lisibilite.",
            "public static float Damage(float baseDamage, float multiplier = 1f)"),

        new("methods3", "04_methods", "Methods3", "out et ref",
            "'out' : la methode DOIT remplir la variable, elle sert de second retour.\n'ref' : la methode recoit la vraie variable et peut la modifier.",
            "public static bool TryDivide(int a, int b, out int result)"),

        new("strings1", "05_strings", "Strings1", "Interpolation",
            "Le $ devant une chaine permet d'y injecter des expressions entre accolades.\nOn peut aussi formater : {valeur:0.00}",
            "$\"Score : {score}\" est plus lisible que \"Score : \" + score"),

        new("strings2", "05_strings", "Strings2", "Manipuler du texte",
            "Split, Trim, ToUpper, Contains, StartsWith, string.Join.\nUne string est immuable : chaque methode renvoie une NOUVELLE string.",
            "texte.Trim() ne modifie pas texte, il faut recuperer le resultat."),

        new("collections1", "06_collections", "Collections1", "Les tableaux",
            "Un tableau a une taille figee. Les index vont de 0 a Length - 1.",
            "Un tableau de 3 cases a les index 0, 1, 2. Il n'y a PAS d'index 3.\nRegarde les conditions de boucle et le dernier element."),

        new("collections2", "06_collections", "Collections2", "List<T>",
            "Une liste grandit et retrecit. Add, Remove, Contains, Count, indexation.",
            "On ne peut PAS retirer d'une liste pendant qu'on la parcourt avec foreach.\nSoit RemoveAll(condition), soit une boucle for qui descend de la fin vers 0."),

        new("collections3", "06_collections", "Collections3", "Dictionary<K,V>",
            "Un dictionnaire associe une cle a une valeur, avec une recherche instantanee.\nTryGetValue evite de planter sur une cle absente.",
            "inventaire[\"potion\"] = 3; puis inventaire.TryGetValue(\"potion\", out int n)"),

        new("classes1", "07_oop", "Classes1", "Classe et constructeur",
            "Une classe regroupe des donnees et le comportement qui va avec.\nLe constructeur porte le nom de la classe et n'a pas de type de retour.",
            "public Player(string name) { Name = name; }"),

        new("classes2", "07_oop", "Classes2", "Proprietes",
            "Une propriete ressemble a un champ mais peut controler lecture et ecriture.\n{ get; private set; } : lisible par tous, modifiable seulement de l'interieur.",
            "public int Health { get; private set; } puis une methode publique pour la changer."),

        new("classes3", "07_oop", "Classes3", "Heritage et override",
            "'virtual' autorise une classe fille a redefinir la methode.\n'override' effectue cette redefinition. 'base.X()' appelle la version du parent.",
            "public override string Describe() => ... ; sans 'virtual' cote parent ca ne compile pas."),

        new("interfaces1", "07_oop", "Interfaces1", "Interfaces",
            "Une interface est un contrat : elle dit CE QU'ON PEUT FAIRE, pas comment.\nUne classe peut implementer plusieurs interfaces, mais n'heriter que d'une classe.",
            "Il faut implementer TOUS les membres de l'interface, en public."),

        new("structs1", "07_oop", "Structs1", "struct contre class",
            "Un struct est copie quand on l'assigne ou qu'on le passe a une methode.\nUne class est partagee : deux variables pointent le meme objet.",
            "Modifier une copie de struct ne change pas l'original. C'est tout le piege."),

        new("enums1", "07_oop", "Enums1", "Enums",
            "Un enum remplace les nombres et les chaines magiques par des noms.\nIl se marie tres bien avec le switch.",
            "public enum State { Idle, Run, Jump } puis State s = State.Idle;"),

        new("generics1", "08_advanced", "Generics1", "Generiques",
            "Le <T> permet d'ecrire du code une fois pour tous les types.\nLa contrainte 'where T : ...' limite les types acceptes.",
            "public static T First<T>(List<T> items) => items[0];"),

        new("null1", "08_advanced", "Null1", "Gerer le null",
            "?. n'appelle que si l'objet n'est pas null.\n?? donne une valeur de repli. ??= assigne seulement si c'est null.",
            "player?.Weapon?.Name ?? \"aucune\" ne plante jamais."),

        new("exceptions1", "08_advanced", "Exceptions1", "Exceptions",
            "try/catch attrape une erreur au lieu de laisser le programme mourir.\nOn attrape le type le plus precis possible, jamais 'Exception' a l'aveugle.",
            "catch (DivideByZeroException) { ... } et finally s'execute toujours."),

        new("linq1", "08_advanced", "Linq1", "LINQ",
            "LINQ decrit ce qu'on veut au lieu d'ecrire la boucle.\nWhere filtre, Select transforme, OrderBy trie, Sum/Count/Any agregent.",
            "scores.Where(s => s > 10).Select(s => s * 2).ToList()"),

        new("delegates1", "08_advanced", "Delegates1", "Lambdas, Action et Func",
            "Une lambda est une fonction anonyme : x => x * 2\nAction ne renvoie rien, Func renvoie quelque chose (dernier type = le retour).",
            "Func<int, int, int> add = (a, b) => a + b;"),

        new("events1", "08_advanced", "Events1", "Evenements et desabonnement",
            "Un event previent plusieurs auditeurs. C'est l'emetteur qui garde\nl'auditeur en vie : sans -= tu as une fuite memoire.",
            "emetteur.Truc += Handler; puis emetteur.Truc -= Handler; quand on s'en va."),

        new("async1", "08_advanced", "Async1", "async et await",
            "'await' attend sans bloquer le thread.\nUne methode qui contient await doit etre 'async' et renvoyer Task ou Task<T>.",
            "public static async Task<int> LoadAsync() { await Task.Delay(10); return 42; }"),

        new("records1", "08_advanced", "Records1", "record et immuabilite",
            "Un record compare ses VALEURS au lieu de son adresse memoire.\n'with' fabrique une copie modifiee sans jamais toucher l'original.",
            "Transforme la classe en 'public sealed record WeaponStats(string Name, int Damage, float Weight)'.\nUn record positionnel donne l'egalite, le ToString, la deconstruction et 'with' d'un coup."),

        new("patterns1", "08_advanced", "Patterns1", "Pattern matching",
            "Les motifs remplacent des cascades de if : type, propriete, intervalle, liste.\nIls sont testes DANS L'ORDRE : le plus precis passe en premier.",
            "Motif de propriete : Hero { Health: 0 }. Intervalle : < 100. Liste : [1, .., 3].\n'when' ajoute une condition libre, 'is' declare une variable au passage.\n\nAttention : les motifs de LISTE sont du C# 11. Godot 4 les accepte, Unity non\n(il est fige en C# 9). Le reste de l'exercice passe partout."),

        new("tuples1", "08_advanced", "Tuples1", "Tuples et deconstruction",
            "Un tuple renvoie plusieurs valeurs sans inventer une classe pour ca.\nUne methode Deconstruct rend n'importe quelle classe destructurable.",
            "(int Min, int Max) MinMax(...) puis return (min, max);\npublic void Deconstruct(out string name, out int health)"),

        new("operators1", "08_advanced", "Operators1", "Surcharge d'operateurs",
            "Un type de degats qui s'additionne et se compare comme un nombre.\nSi tu ecris ==, tu DOIS ecrire !=, Equals et GetHashCode avec.",
            "public static Damage operator +(Damage a, Damage b) => ...\n> et < vont toujours par paire, sinon ca ne compile pas."),

        new("extensions1", "08_advanced", "Extensions1", "Methodes d'extension",
            "Ajouter des methodes a un type que tu ne possedes pas : Vector2, int, List.\nLe mot-cle est 'this' devant le premier parametre, dans une classe statique.",
            "public static Vector2 WithY(this Vector2 value, float y)\nUne extension s'appelle meme sur null : c'est son corps qui doit gerer le cas."),

        new("iterators1", "08_advanced", "Iterators1", "yield et evaluation paresseuse",
            "'yield return' fabrique une sequence morceau par morceau.\nRien ne s'execute tant que personne ne parcourt le resultat.",
            "yield return i; dans une boucle. Une suite infinie est permise : c'est Take qui l'arrete."),

        new("disposable1", "08_advanced", "Disposable1", "IDisposable et using",
            "Textures, fichiers, sockets : ce qui s'ouvre doit se fermer, meme si ca plante.\n'using' garantit la liberation a la sortie du bloc, dans l'ordre inverse.",
            "class Texture : IDisposable avec public void Dispose().\nPuis 'using var t = new Texture(...);'. Dispose doit etre sans effet la deuxieme fois."),

        new("linq2", "08_advanced", "Linq2", "LINQ : regrouper, trier, replier",
            "GroupBy range, ToDictionary indexe, Aggregate replie, Zip apparie.\nEt le piege du siecle : une requete se REJOUE a chaque parcours.",
            "OrderByDescending(...).ThenBy(...) pour departager les ex aequo.\nAggregate(0, (total, item) => total + item.Weight)"),

        new("async2", "08_advanced", "Async2", "Paralleliser et annuler",
            "Lancer deux chargements puis attendre les deux, c'est WhenAll.\nUn CancellationToken permet d'arreter proprement ce qui traine.",
            "Garde les Task dans des variables AVANT de les attendre, sinon tu enchaines.\ntoken.ThrowIfCancellationRequested() au debut de chaque tour de boucle."),

        new("spans1", "08_advanced", "Spans1", "Span et zero allocation",
            "Un Span est une fenetre sur de la memoire deja la : pas de copie, pas de dechet.\nC'est ce qui evite les micro-saccades du ramasse-miettes en plein jeu.",
            "ReadOnlySpan<int> accepte un tableau tel quel. text.Slice(0, n) ne copie rien.\nstackalloc int[4] pose le tableau sur la pile."),

        new("godot1", "09_godot", "Godot1", "Le cycle de vie d'un Node",
            "Ordre reel : constructeur, _EnterTree, _Ready, puis _Process a chaque frame,\net _ExitTree a la destruction. GetNode ne marche qu'a partir de _Ready.",
            "Le constructeur s'execute AVANT que le noeud soit dans l'arbre."),

        new("godot2", "09_godot", "Godot2", "Le delta time",
            "Sans delta, la vitesse depend du nombre d'images par seconde.\nAvec delta, elle est identique sur toutes les machines.",
            "Position += direction * vitesse * (float)delta;"),

        new("godot3", "09_godot", "Godot3", "GetNode et validite",
            "On recupere les noeuds dans _Ready et on les stocke.\nApres un QueueFree, seul IsInstanceValid dit la verite.",
            "GetNodeOrNull renvoie null au lieu de planter. IsInstanceValid(n) verifie l'objet natif."),

        new("godot4", "09_godot", "Godot4", "Signaux et evenements",
            "Un composant previent le reste du jeu sans savoir qui ecoute.\nC'est ce qui evite d'avoir des references croisees partout.",
            "Declare l'event, invoque-le quand la valeur change, abonne-toi de l'autre cote."),

        new("godot5", "09_godot", "Godot5", "Singleton et static",
            "Le comportement va en static, l'etat va en instance.\nUn singleton expose une instance unique derriere une propriete statique.",
            "Instance se pose a l'entree dans l'arbre et se remet a null a la sortie."),

        new("vectors1", "10_gamedev", "Vectors1", "Vecteurs : direction et distance",
            "Le calcul que tu ecriras le plus souvent de toute ta vie de gamedev :\naller d'un point vers un autre. Cible moins position, normalise.",
            "(cible - position).Normalized() donne une direction de longueur 1.\nSans Normalized, plus la cible est loin plus tu vas vite. DistanceTo evite la racine a la main."),

        new("timers1", "10_gamedev", "Timers1", "Cooldowns et temps de recharge",
            "Tir automatique, dash, potion, invulnerabilite : c'est toujours le meme compteur.\nOn descend a chaque frame, on agit quand il touche zero.",
            "Descendre : _remaining = Mathf.Max(_remaining - delta, 0);\nUtiliser : si _remaining > 0 on refuse, sinon on agit et on recharge a Cooldown."),

        new("smoothing1", "10_gamedev", "Smoothing1", "Suivi de camera et lissage",
            "Suivre le joueur avec la camera, tourner vers une cible, remonter une barre de vie.\nLe piege : le lissage naif depend du nombre d'images par seconde.",
            "MoveToward avance d'un pas fixe et ne depasse jamais.\nPour un lissage stable : Lerp(actuel, cible, 1 - Mathf.Exp(-force * delta))."),

        new("pool1", "10_gamedev", "Pool1", "Recycler au lieu de creer",
            "Creer une balle 600 fois par seconde fait ramer le jeu.\nOn en fabrique un stock une fois, on les reutilise ensuite.",
            "Take : depiler s'il en reste, sinon en creer une nouvelle.\nGive : remettre dans la pile apres avoir remis l'objet a zero."),

        new("grid1", "10_gamedev", "Grid1", "Grilles et coordonnees monde",
            "Tilemap, inventaire, pathfinding, jeu de plateau : convertir entre\nla case (colonne, ligne) et la position en pixels.",
            "Case vers monde : case * tailleCase. Monde vers case : division ENTIERE (FloorToInt).\nCase vers index d'un tableau plat : ligne * largeur + colonne."),

        new("states1", "11_patterns", "States1", "Machine a etats",
            "Idle, Run, Jump, Fall, Dead. Le bug classique n'est pas l'etat courant,\nc'est d'autoriser une transition qui ne devrait pas exister.",
            "Un switch sur le couple (Current, next) dit ce qui est permis.\nMort est un puits : on y entre depuis partout, on n'en sort jamais."),

        new("command1", "11_patterns", "Command1", "Commandes, annuler et refaire",
            "Une action qui sait se defaire elle-meme devient annulable gratuitement.\nDeux piles suffisent : ce qui est fait, ce qui est annule.",
            "Undo depile 'fait', appelle Undo, empile dans 'annule'. Redo fait l'inverse.\nUne nouvelle action efface la pile 'annule' : la branche du futur n'existe plus."),

        new("bus1", "11_patterns", "Bus1", "Bus de messages type",
            "Le score, les quetes et le son reagissent au meme evenement sans se connaitre.\nLe TYPE du message sert d'adresse : un dictionnaire Type vers abonnes.",
            "Dictionary<Type, List<Delegate>> puis _handlers[typeof(T)].\nA la publication, il faut recaster : ((Action<T>)handler)(message).\n\nAttention : 'record struct' est du C# 10, donc Godot oui, Unity non (fige en C# 9).\nCote Unity, ecris un 'readonly struct' classique : le bus, lui, ne change pas."),

        new("components1", "11_patterns", "Components1", "Composition plutot qu'heritage",
            "Au lieu d'une classe EnnemiVolantQuiTireEtExplose, on assemble des composants.\nC'est le modele de Unity, de Godot, et de tous les moteurs modernes.",
            "Get<T>() cherche dans la liste : _components.OfType<T>().FirstOrDefault().\nUn composant doit survivre a l'absence de ses voisins : verifie le null."),

        new("locator1", "11_patterns", "Locator1", "Services et interfaces",
            "Le code de jeu appelle IAudio, pas RealAudio. On peut donc le remplacer\npar une version muette dans les tests sans toucher a une ligne du jeu.",
            "Registry[typeof(T)] = service; puis (T)Registry[typeof(T)].\nUn service absent doit dire lequel manque, pas planter avec une cle introuvable."),

        new("data1", "11_patterns", "Data1", "Donnees partagees et etat propre",
            "500 gobelins a l'ecran, UNE seule fiche de stats en memoire.\nCe qui est commun est partage, ce qui change est propre a l'instance.",
            "L'instance garde une REFERENCE vers sa definition, elle ne la recopie pas.\nPoints de vie et position sont par instance ; degats et vitesse sont dans la fiche."),

        new("angles1", "12_math", "Angles1", "Angles et rotations",
            "Viser, tourner vers une cible, savoir si l'ennemi est dans le champ de vision.\nLe piege : de 350 a 10 degres, il n'y a que 20 degres, pas 340.",
            "L'angle d'un vecteur : (cible - position).Angle(). Ecart le plus court : Mathf.AngleDifference.\nPour ramener un angle dans 0..7 : Mathf.PosMod."),

        new("easing1", "12_math", "Easing1", "Interpolation et courbes",
            "InverseLerp est le Lerp a l'envers : il rend le pourcentage.\nEt un lissage exponentiel donne le meme resultat a 30 ou 144 images par seconde.",
            "InverseLerp(from, to, value) = (value - from) / (to - from), avec garde-fou.\nLissage stable : Lerp(actuel, cible, 1 - Exp(-force * delta))."),

        new("collision1", "12_math", "Collision1", "Collisions",
            "Cercle contre cercle, rectangle contre rectangle, cercle contre rectangle.\nEt surtout : de combien repousser pour sortir d'un mur.",
            "Cercles : compare les distances au CARRE, ca evite une racine.\nCercle-rectangle : trouve le point du rectangle le plus proche (un Clamp par axe)."),

        new("rays1", "12_math", "Rays1", "Rayons et ligne de vue",
            "Projeter un point sur un segment, croiser deux segments, savoir si un garde\nvoit le joueur. Un segment n'est pas une droite : il s'arrete.",
            "Projection : Clamp du produit scalaire divise par la longueur au carre, entre 0 et 1.\nCroisement : le produit vectoriel donne t et u, et les DEUX doivent tenir dans 0..1."),

        new("random1", "12_math", "Random1", "Aleatoire maitrise",
            "Un aleatoire a graine rejoue exactement le meme donjon.\nEt un tirage pondere fait tomber l'epique une fois sur cent, pas une fois sur trois.",
            "Range doit ramener dans [min, max[ : min + valeur % (max - min).\nTirage pondere : additionne les poids, tire dans le total, soustrais jusqu'a passer sous zero."),

        new("curves1", "12_math", "Curves1", "Beziers et trajectoires",
            "La courbe d'une fleche, d'un saut, d'une camera qui suit un rail.\nUne Bezier, ce ne sont que des Lerp de Lerp.",
            "Quadratique : lerp(lerp(a,b,t), lerp(b,c,t), t).\nUn saut : la ligne droite, plus une hauteur en 4 * h * t * (1 - t)."),

        new("inventory1", "13_systems", "Inventory1", "Inventaire et piles",
            "On remplit d'abord les piles existantes, ensuite les cases vides.\nEt ce qui ne rentre pas doit etre RENDU, pas avale silencieusement.",
            "Add renvoie ce qui n'a pas pu etre range. Deux passes : d'abord empiler, puis poser.\nRemove verifie le total AVANT de commencer, sinon il retire a moitie."),

        new("damage1", "13_systems", "Damage1", "Calcul de degats",
            "L'ordre des operations change tout : le critique double avant l'armure.\nEt un coup fait toujours au moins un point, sinon on soigne l'ennemi.",
            "Critique d'abord, puis armure (soustraction) ou resistance (multiplication).\nApply ne compte que ce qu'il restait de points de vie, et ignore les morts."),

        new("pathfinding1", "13_systems", "Pathfinding1", "Trouver un chemin",
            "Un parcours en largeur trouve toujours le chemin le plus court sur une grille.\nUne file d'attente, une table 'je viens d'ou', et on remonte a la fin.",
            "Queue pour les cases a visiter, Dictionary pour retenir d'ou on vient.\nLa table sert AUSSI de liste des cases deja vues : pas besoin d'un second ensemble."),

        new("fixed1", "13_systems", "Fixed1", "Pas de temps fixe",
            "La physique doit avancer par pas constants, sinon elle change avec les FPS.\nOn accumule le temps ecoule et on consomme les pas entiers.",
            "while (accumulateur >= pas) { accumulateur -= pas; pas++; }\nEt on plafonne : sans limite, une frame lente en genere 200 et le jeu se noie."),

        new("spatial1", "13_systems", "Spatial1", "Grille spatiale",
            "1000 entites, ca fait 500 000 paires a tester. Avec une grille, une poignee.\nRegle absolue : le filtrage grossier peut proposer trop, jamais oublier.",
            "Un Dictionary de (colonne, ligne) vers la liste des ids.\nUne requete balaie toutes les cases touchees par le cercle, pas seulement la case du centre."),

        new("input1", "13_systems", "Input1", "Buffer d'entree et coyote time",
            "Les deux astuces qui font qu'un jeu de plateforme est agreable :\ngarder l'appui juste trop tot, et pardonner le saut juste trop tard.",
            "Deux compteurs : depuis quand on a appuye, depuis quand on a quitte le sol.\nSi les deux sont dans leur fenetre, on saute, et on remet les deux a l'infini."),

        new("save1", "13_systems", "Save1", "Sauvegarder et recharger",
            "Ecrire l'etat en texte, le relire, et surtout survivre a un fichier incomplet\nou abime. Une sauvegarde qui plante, c'est une partie perdue.",
            "TryGetValue et TryParse partout : un champ absent ou illisible prend sa valeur par defaut.\nEcris les flottants avec CultureInfo.InvariantCulture, sinon la virgule casse tout."),

        new("order1", "14_engine", "Order1", "_Process contre _PhysicsProcess",
            "Deux boucles, pas une : le rendu suit les FPS, la physique avance a pas fixe.\nEt la camera doit passer APRES ce qu'elle suit, sinon elle a une frame de retard.",
            "Le deplacement va dans _PhysicsProcess, l'affichage dans _Process.\nProcessPriority ordonne les _Process : plus grand veut dire plus tard (le LateUpdate de Unity)."),

        new("cache1", "14_engine", "Cache1", "Chercher une fois, pas soixante",
            "GetNode et GetComponent coutent cher. On les appelle dans _Ready et on garde\nle resultat. Meme idee pour un calcul de stats : on ne recalcule que si ca a change.",
            "Un champ prive rempli dans _Ready, utilise ensuite dans _Process.\nPour les stats : un booleen '_dirty' remis a true par tout ce qui modifie l'entree."),

        new("actions1", "14_engine", "Actions1", "Appui, maintien, relachement",
            "'enfoncee' et 'vient d'etre enfoncee' ne sont pas la meme chose : sans la difference,\ntenir la touche tire en rafale. Il faut garder l'etat de la frame precedente.",
            "just_pressed = enfoncee maintenant ET pas a la frame d'avant.\nEt le vecteur de deplacement doit etre normalise, sinon la diagonale va 41 pour cent plus vite."),

        new("movement1", "14_engine", "Movement1", "Gravite, friction, hauteur de saut",
            "On ne regle pas un saut en tatonnant sur une vitesse : on choisit une hauteur\net on en DEDUIT la vitesse. Et une chute doit avoir une vitesse terminale.",
            "Hauteur h avec gravite g : vitesse initiale = -sqrt(2 * g * h).\nAcceleration et friction passent par MoveToward : il ne depasse jamais la cible."),

        new("layers1", "14_engine", "Layers1", "Couches et masques de collision",
            "Une couche par bit, un masque qui dit ce qu'on ecoute. C'est le systeme de Godot,\nde Unity, et de a peu pres tous les moteurs.",
            "Les valeurs doivent etre des puissances de deux : 1, 2, 4, 8, 16.\nAjouter : |. Retirer : & ~. Tester au moins un : (mask & layers) != 0."),

        new("camera1", "14_engine", "Camera1", "Camera : zone morte, bornes, secousse",
            "Une camera collee au joueur tremble. Une camera sans bornes montre le vide.\nEt une secousse qui s'arrete net se voit tout de suite.",
            "Zone morte : on ne bouge que de (distance - zone morte).\nBornes : Clamp entre position + demi-ecran et fin - demi-ecran, par axe.\nSecousse : amplitude en trauma AU CARRE, trauma qui redescend lineairement."),

        new("coroutines1", "14_engine", "Coroutines1", "Coroutines maison",
            "Une coroutine, c'est un IEnumerator qu'on fait avancer d'un cran par frame.\nC'est exactement le modele de Unity, et il tient en trente lignes.",
            "MoveNext fait avancer jusqu'au prochain yield. Current dit ce qu'on attend.\nOn parcourt la liste a l'envers pour pouvoir en retirer pendant l'iteration."),

        new("tween1", "14_engine", "Tween1", "Tween et callback de fin",
            "Interpoler une valeur dans le temps, finir EXACTEMENT sur la cible,\net ne prevenir qu'une seule fois. Les trois pieges d'un tween maison.",
            "Clamp le temps normalise a 1 avant d'interpoler, puis pose Value = _to a la fin.\nUn booleen 'Finished' empeche le callback de partir a chaque frame suivante."),

        new("alloc1", "15_perf", "Alloc1", "Zero allocation dans la boucle chaude",
            "Ici les verifications COMPTENT les octets alloues. Une boucle for sur une List\nne doit rien allouer. LINQ, si : et 60 fois par seconde, ca se voit.",
            "Remplace Sum, Count et OrderBy par des boucles a la main.\nPour trouver le plus proche, compare les distances au CARRE : pas de racine."),

        new("boxing1", "15_perf", "Boxing1", "Boxing : l'allocation invisible",
            "Une structure sans IEquatable utilisee comme cle de dictionnaire s'emballe dans un\nobjet a CHAQUE comparaison. Idem pour un foreach derriere IEnumerable<T>.",
            "Implemente IEquatable<CellKey> : Equals(CellKey), Equals(object) et GetHashCode.\nEt declare le parametre en List<int> plutot qu'en IEnumerable<int>."),

        new("text1", "15_perf", "Text1", "Texte et HUD sans dechets",
            "Un $\"PV {x}\" par frame, c'est 60 chaines par seconde pour rien.\nOn ne reconstruit que si la valeur a change, et on colle avec un StringBuilder.",
            "Garde la derniere valeur affichee et la derniere chaine produite : si rien n'a change, renvoie-la.\nPour assembler : un StringBuilder, Append, puis un seul ToString."),

        new("loops1", "15_perf", "Loops1", "Supprimer sans tout casser",
            "Retirer d'une liste en la parcourant vers l'avant saute des elements.\nEt quand l'ordre n'a pas d'importance, on peut retirer en temps constant.",
            "Parcours de la fin vers zero, ou RemoveAll.\nSuppression par echange : on ecrase la case avec le dernier element, puis on retire le dernier."),

        new("memory1", "15_perf", "Memory1", "Structures, tableaux et reutilisation",
            "1000 objets recrees chaque frame, ce sont 1000 allocations. Un tableau de structures\nreutilise, c'est zero. Et list[i] rend une COPIE, pas l'element.",
            "Un tableau de structures se modifie EN PLACE : particles[i].Life -= delta.\nUn foreach sur des structures ne donne que des copies, il faut une boucle for."),

        new("budget1", "15_perf", "Budget1", "Etaler le travail et doser la distance",
            "On ne met pas a jour 1000 ennemis a chaque frame. On en fait un quart par frame,\net ceux qui sont loin se contentent d'une mise a jour par seconde.",
            "Tranche : index % tranches == frame % tranches, avec PosMod pour les negatifs.\nLoin du joueur, on augmente l'intervalle entre deux mises a jour."),

        new("stack1", "16_memory", "Stack1", "Ce que contient vraiment une variable",
            "Une structure EST la valeur. Un objet n'est qu'une adresse vers le tas.\nEt un parametre objet passe cette adresse... par copie. C'est la source de la moitie des bugs.",
            "Choisis 'struct' ou 'class' pour que chaque verification dise la verite.\nUn tableau d'objets ne contient que des adresses nulles : aucun objet n'existe tant qu'on n'a pas fait 'new'."),

        new("refs1", "16_memory", "Refs1", "ref, out et in",
            "'ref' passe la variable elle-meme. 'out' impose de la remplir. 'in' passe l'adresse\nsans droit d'ecriture, pour eviter de recopier une grosse structure.",
            "Un 'ref' local est un ALIAS : 'ref int slot = ref Slot(tab, 1);' puis 'slot = 99;' ecrit dans le tableau.\nUne methode peut renvoyer 'ref' : c'est ce qui permet de modifier un element de tableau sans le recopier."),

        new("delegates2", "16_memory", "Delegates2", "Delegates, multicast et fuites",
            "Un delegate garde son objet en vie. Se desabonner avec une NOUVELLE lambda\nne desabonne rien : c'est la fuite memoire la plus repandue en gamedev.",
            "Pour pouvoir faire '-=', abonne-toi avec un groupe de methodes, pas une lambda ecrite sur place.\nGetInvocationList() donne les abonnes un par un : c'est comme ca qu'on isole celui qui plante."),

        new("gc1", "16_memory", "Gc1", "Le tas, l'en-tete et les generations",
            "Ici on MESURE : un objet vide coute 24 octets d'en-tete, 1000 structures tiennent\nen une seule allocation, et 200 000 objets jetables declenchent de vraies pauses.",
            "Reutilise un seul tampon alloue avant la boucle au lieu d'en creer un a chaque tour.\nUne collection gen0 est rapide, mais c'est une PAUSE : dans 16 millisecondes de budget, ca se voit."),

        new("copies1", "16_memory", "Copies1", "Copies defensives",
            "Appeler une methode sur un champ 'readonly' de type structure travaille sur une COPIE.\nLe code compile, tourne, et ne fait rien. Personne ne trouve ce bug du premier coup.",
            "La parade : rends la structure 'readonly struct' et renvoie une nouvelle instance au lieu de modifier.\nlist[0].Methode() modifie un temporaire ; array[0].Methode() modifie l'original."),
    };

    public static Exercise Find(string id) =>
        All.FirstOrDefault(e => string.Equals(e.Id, id, StringComparison.OrdinalIgnoreCase));
}
