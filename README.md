# csharplings-gamedev

Apprendre le C# pour le jeu vidéo, en réparant du code cassé.

Deux parties, dans cet ordre.

## 1. `csharplings/` — 43 exercices à réparer

```
cd csharplings
dotnet run
```

Le programme s'arrête sur le premier exercice non terminé, affiche la consigne, lance
le code, dit ce qui casse. Tu corriges le fichier, tu sauvegardes, il relance tout seul.

Du premier point-virgule manquant jusqu'au pooling d'objets :

| Section | Contenu |
|---|---|
| `00_intro` | comment marche l'outil, lire une erreur de compilation |
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

Les exercices Godot tournent sur un mini-moteur inclus (`support/MiniGodot.cs`) : un
vrai `Node` avec `_Ready`, `_Process`, `QueueFree`, `IsInstanceValid`, et un `SceneTree`
qui avance image par image. Pas besoin d'installer Godot pour les faire.

Autres commandes : `list`, `hint <id>`, `solution <id>`, `run <id>`, `verify`.

## 2. `demos/` — du vrai code Godot 4

Des scripts à attacher à des nœuds dans un projet Godot 4 en C#. Chaque démo raconte ce
qu'elle fait pendant qu'elle tourne, via `GD.Print`.

- `CHEATSHEET.md` — le condensé : les 7 règles, « je veux X → j'écris Y », les pièges
- `GODOT-UNITY.md` — table de traduction Godot ↔ Unity, et le 80/20 de ce qu'on écrit vraiment
- `README.md` — singletons, `static` vs instance, `WeakReference` en détail
- `bases/`, `gameplay/`, `pieges/`, `singletons/`, `weakrefs/` — le code

## Prérequis

- .NET SDK 8 ou plus, pour `csharplings`
- Godot 4.x en version .NET, pour `demos` (facultatif)

## Note

Le code ne contient volontairement aucun commentaire. Les explications sont dans les
fichiers Markdown et dans les messages que le runner affiche. Les identifiants sont
censés se suffire à eux-mêmes.
