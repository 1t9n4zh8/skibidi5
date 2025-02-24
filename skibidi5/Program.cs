class Program
{
    static int BinarySearchFirst(int[] array, int target)
    {
        int left = 0;
        int right = array.Length - 1;
        int result = -1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (array[mid] == target)
            {
                result = mid;
                right = mid - 1;  
            }
            else if (array[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return result;
    }

    static (int count, List<int> positions) BinarySearchAll(int[] array, int target)
    {
        int firstPosition = BinarySearchFirst(array, target);

        if (firstPosition == -1)
        {
            return (0, new List<int>());
        }

        List<int> positions = new List<int>();
        int count = 0;

        positions.Add(firstPosition);
        count++;

        int left = firstPosition - 1;
        while (left >= 0 && array[left] == target)
        {
            positions.Insert(0, left); 
            count++;
            left--;
        }

        int right = firstPosition + 1;
        while (right < array.Length && array[right] == target)
        {
            positions.Add(right); 
            count++;
            right++;
        }

        return (count, positions);
    }

    static void Main()
    {
        int[] numbers = { 1, 2, 3, 3, 3, 4, 5, 6, 7 }; 
        int target = 3; 

        var result = BinarySearchAll(numbers, target);

        Console.WriteLine($"Намерени са {result.count} елемента със стойност {target}.");
        Console.WriteLine("Позиции на намерените елементи:");
        foreach (int position in result.positions)
        {
            Console.WriteLine(position);
        }
    }
}