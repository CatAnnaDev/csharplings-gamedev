# Ce qu'on utilise vraiment en gamedev — et la traduction Godot ↔ Unity

Deux moteurs, le même C#. Ce qui change, c'est le vocabulaire et une différence
d'architecture qu'il faut comprendre une bonne fois.

---

## 1. La différence de fond

| | Godot | Unity |
|---|---|---|
| Brique de base | un **Node**, qui EST déjà quelque chose (Sprite2D, Area2D…) | un **GameObject** vide, qui n'est rien |
| On ajoute du comportement | en héritant (`class Player : CharacterBody2D`) ou en ajoutant des nœuds enfants | en accrochant des **components** (`MonoBehaviour`) |
| Composition | possible, recommandée | obligatoire, c'est le seul modèle |
| Un script | hérite d'un type de nœud | hérite de `MonoBehaviour` |

En clair : sous Godot tu **es** un `CharacterBody2D`. Sous Unity tu es un GameObject
qui **a** un `Rigidbody` et un `PlayerController`.

Conséquence pratique : le pattern composant de `demos/gameplay/Components.cs`
(`HealthComponent` en nœud enfant) est la façon d'écrire du Godot qui ressemble à
Unity — et c'est en général la meilleure façon d'écrire du Godot tout court.

---

## 2. La table de traduction

### Cycle de vie

| Godot | Unity |
|---|---|
| `_EnterTree()` | `Awake()` |
| `_Ready()` | `Start()` |
| `_Process(double delta)` | `Update()` + `Time.deltaTime` |
| `_PhysicsProcess(double delta)` | `FixedUpdate()` + `Time.fixedDeltaTime` |
| `_ExitTree()` | `OnDestroy()` / `OnDisable()` |
| `_Input(InputEvent e)` | `Update()` + `Input.*`, ou le New Input System |

Piège : sous Godot `delta` est un **`double`**, il faut caster en `(float)`.
Sous Unity `Time.deltaTime` est déjà un `float`.

### Trouver et créer des choses

| Godot | Unity |
|---|---|
| `GetNode<Label>("UI/Score")` | `transform.Find("UI/Score").GetComponent<Text>()` |
| `GetNodeOrNull<T>(path)` | `GetComponent<T>()` (rend `null` si absent) |
| `[Export] private Label _score;` | `[SerializeField] private Text _score;` |
| `_prefab.Instantiate()` | `Instantiate(prefab)` |
| `AddChild(node)` | `transform.SetParent(parent)` |
| `node.QueueFree()` | `Destroy(gameObject)` |
| `IsInstanceValid(node)` | `node != null` (Unity surcharge `==`) |

### Le reste

| Godot | Unity |
|---|---|
| `GD.Print(x)` | `Debug.Log(x)` |
| `Position`, `GlobalPosition` | `transform.localPosition`, `transform.position` |
| `[Signal]` + `EmitSignal` | `UnityEvent`, ou un `event Action` C# |
| Autoload | singleton `MonoBehaviour` + `DontDestroyOnLoad` |
| `Resource` (`.tres`) | `ScriptableObject` |
| `Area2D` + `BodyEntered` | `Collider` en `isTrigger` + `OnTriggerEnter` |
| `CharacterBody2D.MoveAndSlide()` | `CharacterController.Move()` |
| `CreateTween()` | coroutine, ou DOTween |
| `await ToSignal(timer, ...)` | `yield return new WaitForSeconds(...)` |
| `Input.IsActionPressed("jump")` | `Input.GetButton("Jump")` |
| `GetTree().ChangeSceneToFile(...)` | `SceneManager.LoadScene(...)` |

`Mathf.Lerp`, `Mathf.Clamp`, `Vector2`, `Vector3` : **identiques** des deux côtés.

Une vraie différence : en 2D, **Godot a Y qui descend**, Unity a Y qui monte.
`Vector2.Up` vaut `(0, -1)` sous Godot et `(0, 1)` sous Unity.

---

## 3. Le 80/20 : ce que tu écris tous les jours

Par ordre de fréquence réelle. C'est ça qu'il faut maîtriser, le reste attendra.

| Ce que tu écris tout le temps | Où l'apprendre |
|---|---|
| `float`, casts, division entière | `csharplings` 02_types |
| `Vector2` : direction, distance, portée | `csharplings` vectors1 |
| Tout multiplier par `delta` | `csharplings` godot2, `demos/gameplay/DeltaTime.cs` |
| `Lerp` / `MoveToward` pour lisser | `csharplings` smoothing1 |
| Cooldowns et timers | `csharplings` timers1 |
| `List<T>` et `Dictionary<K,V>` | `csharplings` 06_collections |
| `enum` + `switch` pour les états | `csharplings` enums1, `demos/gameplay/StateMachine.cs` |
| Classes, propriétés, interfaces | `csharplings` 07_oop |
| Events pour découpler | `csharplings` events1, `demos/gameplay/SignalsVsEvents.cs` |
| Grilles et tilemaps | `csharplings` grid1 |
| Object pooling | `csharplings` pool1, `demos/gameplay/ObjectPool.cs` |

### Ce qui sert nettement moins qu'on croit

- **L'héritage profond.** `Enemy : Character : Entity : ...` est un piège classique.
  En pratique : composition + interfaces. Deux niveaux d'héritage maximum.
- **LINQ dans une boucle de jeu.** Parfait pour du setup ou de l'UI, mais chaque
  `Where().Select()` alloue. Dans un `_Process`, écris la boucle.
- **`async`/`await`.** Utile sous Godot. Sous Unity, la culture est aux coroutines
  (ou UniTask). Ne t'y attaque pas en premier.
- **Les génériques compliqués.** Savoir lire `List<T>` suffit longtemps.
- **Les design patterns du livre.** Tu as besoin de trois choses : composant,
  machine à états, et un singleton ou deux. Le reste viendra si le besoin arrive.

### Les erreurs qui coûtent le plus cher en gamedev

1. Oublier `delta` → le jeu va deux fois plus vite sur un écran 120 Hz.
2. `GetNode` / `GetComponent` dans `_Process` / `Update` → chute de framerate.
3. `Instantiate` en boucle sans pool → à-coups du garbage collector.
4. `+=` sur un event sans `-=` → fuite mémoire, et des callbacks sur des objets morts.
5. Comparer des `float` avec `==` → la condition ne se déclenche jamais.
6. Mettre l'état de la partie en `static` → rien ne se réinitialise entre deux parties.

Les six sont couverts, avec le code faux et le code juste côte à côte, dans
`demos/pieges/Pieges.cs` et `demos/CHEATSHEET.md`.

---

## 4. Si tu passes de l'un à l'autre

**Unity → Godot** : ta réaction sera « où sont les components ? ». Réponse : les
nœuds enfants les remplacent. Garde ton réflexe de composition, c'est le bon.

**Godot → Unity** : ta réaction sera « pourquoi mon GameObject ne fait rien ? ».
Parce qu'il est vide. Tout comportement vient d'un component que tu ajoutes.
Et pense à `Time.deltaTime`, il n'arrive pas en paramètre.

Dans les deux sens, le C# ne change pas. C'est pour ça que `csharplings` sert quel
que soit le moteur que tu choisis.
