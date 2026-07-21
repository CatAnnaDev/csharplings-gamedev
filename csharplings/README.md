# csharplings

Apprendre le C# en reparant du code cassé. 91 exercices, du premier point-virgule
jusqu'à ce qui se passe réellement en RAM quand ton jeu tourne.

## Démarrer

```
cd csharplings
dotnet run
```

C'est tout. Le programme s'arrête sur le premier exercice non terminé, affiche la
consigne, lance le code et te dit ce qui ne va pas. **Laisse-le tourner** : dès que tu
sauvegardes le fichier, il relance tout seul.

Ouvre le fichier qu'il t'indique dans un autre onglet, corrige, sauvegarde. Recommence.

## La boucle

1. `dotnet run` t'annonce un exercice et son fichier
2. tu corriges le fichier
3. tu sauvegardes → ça relance
4. quand les vérifications passent, tu mets `NotDone` à `false`
5. il passe automatiquement au suivant

Le `NotDone` sert à ça : le code peut marcher sans que tu aies compris. C'est toi qui
décides quand tu passes à la suite.

## Les autres commandes

```
dotnet run -- list              où j'en suis
dotnet run -- hint variables1   un indice
dotnet run -- solution flow2    la correction
dotnet run -- run godot3        relancer un exercice précis
dotnet run -- verify            vérifier que toutes les solutions passent
```

Regarder la solution n'est pas de la triche, mais lis l'indice d'abord.

## Le programme

| Section | Contenu |
|---|---|
| `00_intro` | comment marche cet outil, lire une erreur de compilation |
| `01_variables` | déclarer, `var`, `const` et `readonly` |
| `02_types` | int/float/double, conversions, texte vers nombre |
| `03_flow` | if/else, switch expression, for/while, foreach |
| `04_methods` | signatures, paramètres optionnels, `out` et `ref` |
| `05_strings` | interpolation, manipulation, immuabilité |
| `06_collections` | tableaux, `List<T>`, `Dictionary<K,V>` |
| `07_oop` | classes, propriétés, héritage, interfaces, struct, enum |
| `08_advanced` | génériques, null, exceptions, LINQ, lambdas, events, async, records, pattern matching, tuples, opérateurs, extensions, `yield`, `IDisposable`, `Span` |
| `09_godot` | cycle de vie, delta time, GetNode, signaux, singleton |
| `10_gamedev` | vecteurs, cooldowns, lissage, pooling, grilles |
| `11_patterns` | machine à états, commandes annulables, bus d'événements, composition, services, données partagées |
| `12_math` | angles, easing, collisions, rayons, aléatoire à graine, béziers |
| `13_systems` | inventaire, calcul de dégâts, pathfinding, pas de temps fixe, grille spatiale, buffer d'entrée, sauvegarde |
| `14_engine` | boucle de rendu vs physique, cache de nœuds, actions d'entrée, gravité et saut, masques de collision, caméra, coroutines, tweens |
| `15_perf` | zéro allocation, boxing, texte et HUD, suppression en boucle, structs et réutilisation, étalement du travail |
| `16_memory` | pile et tas, `ref`/`out`/`in`, delegates et fuites, GC et générations, copies défensives |

## La section Godot

Les 5 derniers exercices tournent sur un mini-moteur maison (`support/MiniGodot.cs`) :
un vrai `Node` avec `_Ready`, `_Process`, `AddChild`, `QueueFree`, `IsInstanceValid` et
un `SceneTree` qui avance image par image.

Pas besoin de lancer Godot, ça tourne dans le terminal en une seconde. Mais le code que
tu écris est celui que tu écriras dans le vrai moteur.

## La section gamedev

`10_gamedev` est la plus utile si tu veux faire des jeux : ce sont les cinq calculs
que tu réécriras dans chaque projet, quel que soit le moteur. Aller vers une cible,
gérer un temps de recharge, lisser un mouvement, recycler des objets, convertir une
case de grille en pixels.

Le code est du C# pur : il marche tel quel sous Unity aussi.

## Faire un vrai jeu

`11_patterns`, `12_math` et `13_systems` sont la partie « on assemble ».
Chaque exercice est un morceau que tu retrouveras tel quel dans ton projet :

- une machine à états qui refuse les transitions impossibles
- un historique annuler/refaire à deux piles
- un bus où le score, les quêtes et le son réagissent sans se connaître
- de quoi viser, tourner par le plus court chemin, savoir ce qu'un garde voit
- un aléatoire à graine qui rejoue exactement le même donjon
- un pathfinding, une grille spatiale, un pas de temps fixe
- le buffer d'entrée et le coyote time, les deux astuces qui rendent un
  platformer agréable
- une sauvegarde qui survit à un fichier incomplet

Ça reste du C# pur, sans Godot : tout tourne dans le terminal.

## Les réflexes moteur

`14_engine` est la section « ce que tu fais tous les jours », valable Godot **et** Unity :

- `_Process` contre `_PhysicsProcess` (= `Update` contre `FixedUpdate`), et pourquoi la
  caméra doit passer après sa cible (`ProcessPriority`, = `LateUpdate`)
- cacher `GetNode` / `GetComponent` au lieu de chercher 60 fois par seconde
- « enfoncée » contre « vient d'être enfoncée », et la diagonale qui va 41 % trop vite
- déduire la vitesse de saut d'une hauteur voulue, friction sans repartir en arrière
- les masques de collision (une couche par bit, et les valeurs sont des puissances de deux)
- caméra : zone morte, bornes du niveau, secousse en trauma²
- des coroutines maison en `IEnumerator` — le modèle exact de Unity, en trente lignes
- un tween qui atterrit pile sur la cible et ne prévient qu'une fois

## Les optimisations

`15_perf` ne se contente pas d'expliquer : **les vérifications comptent les octets alloués.**
`GC.GetAllocatedBytesForCurrentThread()` mesure vraiment, donc un exercice échoue si ton
code alloue dans la boucle chaude.

- une boucle `for` sur une `List` doit rendre **0 octet** ; le même calcul en LINQ, non
- une structure sans `IEquatable` utilisée comme clé de dictionnaire s'emballe dans un
  objet à chaque comparaison — mesurable, et invisible autrement
- un `foreach` derrière `IEnumerable<T>` alloue son énumérateur ; derrière `List<T>`, non
- un HUD qui ne reconstruit son texte que quand la valeur change
- retirer d'une liste sans sauter d'éléments, et la suppression par échange
- 1000 objets recréés par frame contre un tableau de structs réutilisé
- étaler le travail sur plusieurs frames, et en faire moins quand c'est loin

## Ce qui se passe en RAM

`16_memory` est la section « arrête de deviner ». Elle mesure au lieu d'expliquer :

- **un objet vide coûte 24 octets** — l'en-tête que tout objet du tas porte. Un `int` de
  plus est gratuit (il tient dans le remplissage), le quatrième coûte 8 octets.
- **1000 structures de 20 octets = une seule allocation de 20 024 octets**, contiguë.
  1000 objets équivalents, ce sont 1000 allocations éparpillées.
- **une lambda qui ne capture rien : 0 octet** (elle est mise en cache). Dès qu'elle
  capture une variable locale : 96 octets, à chaque passage.
- **200 000 objets jetables → collections gen0 réelles ; le même travail avec un tampon
  réutilisé → zéro.** Une collection gen0 est rapide, mais c'est une *pause*, et le
  budget d'une frame est de 16 ms.
- un objet qui survit à une collection est **promu** en génération supérieure.

Et le langage qui va avec :

- ce que contient vraiment une variable : une structure **est** la valeur, un objet n'est
  qu'une adresse — et un paramètre objet passe cette adresse **par copie**, ce qui explique
  pourquoi réassigner le paramètre ne change rien dehors
- `ref` / `out` / `in`, les `ref` locals et les `ref` returns : modifier un élément de
  tableau **en place**, sans jamais le recopier
- les delegates en vrai : multicast, valeur de retour du dernier seulement, une exception
  qui tue silencieusement le reste de la chaîne, et surtout `-=` avec une nouvelle lambda
  qui **ne désabonne rien** — la fuite mémoire la plus répandue en gamedev
- les copies défensives : appeler une méthode sur un champ `readonly` de type structure
  travaille sur une copie. Le code compile, tourne, et ne fait rien.

## Godot, Unity, et le niveau de C#

Godot 4 tourne en .NET 6 (4.0–4.2) puis .NET 8 (4.3+). **Unity, lui, n'est pas en .NET 6** :
Unity 2021.3 → Unity 6 utilisent Mono/IL2CPP avec l'API .NET Standard 2.1 et un
`LangVersion` figé à **C# 9**. Si tu veux du code qui se colle dans les deux, la contrainte
réelle est donc C# 9, plus stricte que .NET 6.

Presque tout ici tient dans C# 9 : `record`, `init`, `new()`, les patterns relationnels
(`< 100`, `and`, `or`), `Span`, `stackalloc`, `HashCode.Combine`,
`GC.GetAllocatedBytesForCurrentThread`. Deux exceptions, signalées dans leur consigne :

- `patterns1` utilise les **motifs de liste** (`[1, .., 3]`) — C# 11, Godot oui, Unity non
- `bus1` utilise `record struct` — C# 10, Godot oui, Unity non (écris un `readonly struct`)

Les `namespace X;` en fin de ligne sont du C# 10 aussi : c'est le style de l'outil, pas du
code destiné à être collé tel quel dans un projet Unity.

## Et après

- `../demos/CHEATSHEET.md` — le condensé Godot en tableaux
- `../demos/GODOT-UNITY.md` — la table de traduction Godot ↔ Unity et le 80/20 du métier
- `../demos/` — du vrai code Godot 4, à attacher à des nœuds

## Si quelque chose casse

- `.sandbox/` est régénéré à chaque lancement, tu peux le supprimer
- pour repartir de zéro sur un exercice, recopie-le depuis `solutions/` et re-casse-le
- les fichiers de `csharplings/` sont exclus du projet Godot, ils ne peuvent pas casser ton jeu
