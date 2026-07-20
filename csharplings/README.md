# csharplings

Apprendre le C# en reparant du code cassé. 43 exercices, du premier point-virgule
jusqu'aux patterns qu'on écrit tous les jours en gamedev.

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
| `08_advanced` | génériques, null, exceptions, LINQ, lambdas, events, async |
| `09_godot` | cycle de vie, delta time, GetNode, signaux, singleton |
| `10_gamedev` | vecteurs, cooldowns, lissage, pooling, grilles |

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

## Et après

- `../demos/CHEATSHEET.md` — le condensé Godot en tableaux
- `../demos/GODOT-UNITY.md` — la table de traduction Godot ↔ Unity et le 80/20 du métier
- `../demos/` — du vrai code Godot 4, à attacher à des nœuds

## Si quelque chose casse

- `.sandbox/` est régénéré à chaque lancement, tu peux le supprimer
- pour repartir de zéro sur un exercice, recopie-le depuis `solutions/` et re-casse-le
- les fichiers de `csharplings/` sont exclus du projet Godot, ils ne peuvent pas casser ton jeu
