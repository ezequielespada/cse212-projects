public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan:
        // 1. Create an array of doubles with the size equal to 'length'.
        // 2. Use a loop to fill the array with multiples of 'number'.
        //    - Start with 'number' and calculate each subsequent multiple as: number * (index + 1).
        // 3. Return the filled array.

        // Step 1: Initialize an array with the specified length.
        double[] multiples = new double[length];

        // Step 2: Populate the array with multiples of 'number'.
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1); // Calculate the multiple and store it.
        }

        // Step 3: Return the resulting array.
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan:
        // 1. Validate input: Ensure the list is not null or empty, just in case...
        if (data == null || data.Count == 0) return;

        // 2. Calculate the effective rotation amount.
        //    If the rotation amount exceeds the size of the list, use modulus (%) to reduce it.
        int rotation = amount % data.Count;

        // 3. Check if rotation is needed. If rotation == 0, no changes are necessary.
        if (rotation == 0) return;

        // 4. Slice the list into two parts:
        //    a) The last 'rotation' elements (tail).
        //    b) The rest of the list (head).
        List<int> tail = data.GetRange(data.Count - rotation, rotation);
        List<int> head = data.GetRange(0, data.Count - rotation);

        // 5. Clear the original list and rebuild it:
        //    a) First add the tail (rotated portion).
        //    b) Then add the head (remaining portion).
        data.Clear();
        data.AddRange(tail);
        data.AddRange(head);
    }
}
