// See https://aka.ms/new-console-template for more information

https://leetcode.com/problems/remove-duplicates-from-sorted-list/description/


var input = new LinkedList<int>([1, 2, 3, 3, 5, 6, 7, 7, 8, 9, 9]);

foreach (var item in RemovesDuplicates(input))
{
    Console.WriteLine(item);
}

return;

static LinkedList<int> RemovesDuplicates(LinkedList<int> input)
{
    var dups = new Dictionary<int, bool>();
    var results = new LinkedList<int>();

    foreach (var item in input.Where(item => !dups.ContainsKey(item)))
    {
        dups.Add(item, true);
    }

    foreach (var item in dups)
    {
        results.AddLast(item.Key);
    }

    return results;    
}