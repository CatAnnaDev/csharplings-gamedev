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
    };

    public static Exercise Find(string id) =>
        All.FirstOrDefault(e => string.Equals(e.Id, id, StringComparison.OrdinalIgnoreCase));
}
