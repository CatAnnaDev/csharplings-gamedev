namespace Csharplings;

public static class GD
{
    public static void Print(object what) => Console.WriteLine($"      [jeu] {what}");
}

public static class Mathf
{
    public const float Pi = 3.14159265f;

    public static float Max(float a, float b) => a > b ? a : b;
    public static float Min(float a, float b) => a < b ? a : b;
    public static float Abs(float a) => a < 0f ? -a : a;
    public static float Clamp(float value, float min, float max) => value < min ? min : value > max ? max : value;
    public static float Lerp(float from, float to, float weight) => from + (to - from) * weight;
    public static bool IsEqualApprox(float a, float b) => Abs(a - b) < 0.00001f;
    public static bool IsZeroApprox(float a) => Abs(a) < 0.00001f;
    public static float Sqrt(float a) => (float)Math.Sqrt(a);
    public static float Exp(float a) => (float)Math.Exp(a);
    public static int FloorToInt(float a) => (int)Math.Floor(a);

    public static float MoveToward(float from, float to, float delta)
    {
        if (Abs(to - from) <= delta)
            return to;

        return from + Math.Sign(to - from) * delta;
    }
}

public readonly struct Vector2
{
    public float X { get; }
    public float Y { get; }

    public Vector2(float x, float y)
    {
        X = x;
        Y = y;
    }

    public static Vector2 Zero => new(0f, 0f);
    public static Vector2 One => new(1f, 1f);
    public static Vector2 Right => new(1f, 0f);
    public static Vector2 Up => new(0f, -1f);

    public float Length() => Mathf.Sqrt(X * X + Y * Y);

    public Vector2 Normalized()
    {
        float length = Length();
        return Mathf.IsZeroApprox(length) ? Zero : new Vector2(X / length, Y / length);
    }

    public float DistanceTo(Vector2 other) => (other - this).Length();

    public static Vector2 operator +(Vector2 a, Vector2 b) => new(a.X + b.X, a.Y + b.Y);
    public static Vector2 operator -(Vector2 a, Vector2 b) => new(a.X - b.X, a.Y - b.Y);
    public static Vector2 operator *(Vector2 a, float s) => new(a.X * s, a.Y * s);

    public override string ToString() => $"({X:0.##}, {Y:0.##})";
}

public class Node
{
    private readonly List<Node> _children = new();

    public string Name { get; set; } = "Node";
    public Node Parent { get; private set; }
    public Vector2 Position { get; set; }
    public bool IsFreed { get; private set; }
    public bool IsInsideTree { get; private set; }

    internal bool QueuedForDeletion { get; private set; }

    public IReadOnlyList<Node> Children => _children;

    public virtual void _EnterTree() { }
    public virtual void _Ready() { }
    public virtual void _Process(double delta) { }
    public virtual void _ExitTree() { }

    public void AddChild(Node child)
    {
        child.Parent = this;
        _children.Add(child);

        if (IsInsideTree)
            child.EnterTreeRecursive();
    }

    public T GetNodeOrNull<T>(string path)
        where T : Node
    {
        Node current = this;

        foreach (string part in path.Split('/', StringSplitOptions.RemoveEmptyEntries))
        {
            current = current._children.FirstOrDefault(c => c.Name == part);
            if (current is null)
                return null;
        }

        return current as T;
    }

    public T GetNode<T>(string path)
        where T : Node
    {
        T found = GetNodeOrNull<T>(path);
        if (found is null)
            throw new InvalidOperationException($"noeud introuvable : {path}");

        return found;
    }

    public void QueueFree() => QueuedForDeletion = true;

    public static bool IsInstanceValid(Node node) => node is not null && !node.IsFreed;

    internal void EnterTreeRecursive()
    {
        IsInsideTree = true;
        _EnterTree();

        foreach (Node child in _children.ToList())
            child.EnterTreeRecursive();

        _Ready();
    }

    internal void ProcessRecursive(double delta)
    {
        if (IsFreed)
            return;

        _Process(delta);

        foreach (Node child in _children.ToList())
            child.ProcessRecursive(delta);
    }

    internal void FlushDeletionsRecursive()
    {
        foreach (Node child in _children.ToList())
        {
            child.FlushDeletionsRecursive();

            if (!child.QueuedForDeletion)
                continue;

            child._ExitTree();
            child.IsFreed = true;
            child.IsInsideTree = false;
            _children.Remove(child);
        }
    }
}

public sealed class SceneTree
{
    public Node Root { get; } = new() { Name = "root" };

    public void Start()
    {
        Root.EnterTreeRecursive();
    }

    public void Tick(double delta = 1.0 / 60.0)
    {
        Root.ProcessRecursive(delta);
        Root.FlushDeletionsRecursive();
    }

    public void Run(int frames, double delta = 1.0 / 60.0)
    {
        for (int i = 0; i < frames; i++)
            Tick(delta);
    }
}
