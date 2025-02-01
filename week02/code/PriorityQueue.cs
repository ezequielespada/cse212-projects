public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority.  The
    /// node is always added to the back of the queue regardless of 
    /// the priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    public string Dequeue()
    {
        if (_queue.Count == 0) // Verificar si la cola está vacía
        {
            throw new InvalidOperationException("The queue is empty.");
        }
    
        // Buscar el índice del elemento con la mayor prioridad
        var highPriorityIndex = 0;
        for (int index = 1; index < _queue.Count; index++) 
        {
            // Si hay elementos con la misma prioridad, seleccionamos el primero añadido
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority ||
                (_queue[index].Priority == _queue[highPriorityIndex].Priority && index < highPriorityIndex))
            {
                highPriorityIndex = index;
            }
        }
    
        // Eliminar el elemento con la mayor prioridad y devolver su valor
        var value = _queue[highPriorityIndex].Value;
        _queue.RemoveAt(highPriorityIndex); // Eliminar el elemento de la cola
        return value;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}