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
        // TODO Problem 1 Start
        // 1. Let's create an array of doubles with the size of 'length'.
        // 2. Then using a for loop to iterate 'length' number of times, starting from 0.
        // 3. For each index 'i' in the array, we will calculate the multiple: number * (i + 1).
        // 4. Then, we will assign the calculated multiple to the array at index 'i'.
        // 5. Finally, we will return the array of multiples.

        double[] multiples = new double[length];
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

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
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        // 1. We will first determine the starting index for the slice that needs to be moved to the front.
        //    This is calculated as data.Count - amount.
        // 2. Then, we will use GetRange to create a temporary list of the elements that will be moved.
        //    The range starts at the calculated index and goes for 'amount' elements.
        // 3. Next, we will use RemoveRange to remove those same elements from the end of the original list.
        // 4. Finally, we will use InsertRange to place the temporary list of elements at the beginning (index 0)
        //    of the original list.

        int startIndex = data.Count - amount;
        List<int> rotatedPart = data.GetRange(startIndex, amount);
        data.RemoveRange(startIndex, amount);
        data.InsertRange(0, rotatedPart);
    }
}
