using System;
using System.Collections.Generic;

public class TakingTurnsQueue 
{
    private readonly Queue<Person> _people = new();  // Usamos Queue<Person> para asegurarnos del orden FIFO.

    public int Length => _people.Count;

    /// <summary>
    /// Add new people to the queue with a name and number of turns
    /// </summary>
    /// <param name="name">Name of the person</param>
    /// <param name="turns">Number of turns remaining</param>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);  // Añadir la persona al final de la cola.
    }

    /// <summary>
    /// Get the next person in the queue and return them. The person should
    /// go to the back of the queue again unless the turns variable shows that they 
    /// have no more turns left. A turns value of 0 or less means the 
    /// person has an infinite number of turns. An error exception is thrown 
    /// if the queue is empty.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.Count == 0)  // Comprobar si la cola está vacía.
        {
            throw new InvalidOperationException("No one in the queue.");
        }
        
        Person person = _people.Dequeue();  // Extraer la persona del frente de la cola.

        // Si tiene turnos finitos, disminuye su número de turnos y vuelve a la cola.
        if (person.Turns > 1)
        {
            person.Turns -= 1;  // Decrementar el número de turnos.
            _people.Enqueue(person);  // Volver al final de la cola.
        }
        // Si tiene turnos infinitos (0 o negativos), vuelve a la cola sin modificar sus turnos.
        else if (person.Turns <= 0)
        {
            _people.Enqueue(person);  // También vuelve al final de la cola sin modificar sus turnos.
        }

        return person;  // Devolver a la persona.
    }

    // Método ToString para depuración si es necesario.
    public override string ToString()
    {
        return string.Join(", ", _people);  // Convertir la cola a una cadena para ver su estado.
    }
}
