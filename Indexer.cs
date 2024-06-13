using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketGoogle;

public class Indexer : IIndexer
{
    private readonly Dictionary<string, Dictionary<int, List<int>>> Data;

    public Indexer()
    {
        Data = new Dictionary<string, Dictionary<int, List<int>>>();        
    }

    public void Add(int id, string documentText)
    {
        var position = 0;
        foreach (var word in documentText.Split(new char[] { ' ', '.', ',', '!', '?', ':', '-', '\r', '\n' }))
        {
            if (!Data.ContainsKey(word))
                Data[word] = new Dictionary<int, List<int>>() { { id, new List<int>() { position } } };
            else
            {
                if (!Data[word].ContainsKey(id))
                    Data[word][id] = new List<int> { position };
                else
                    Data[word][id].Add(position);
            }
            position += word.Length + 1;
        }
    }

    public List<int> GetIds(string word)
    {
        if (Data.ContainsKey(word))
            return Data[word].Keys.ToList();
        return new List<int>();
    }

    public List<int> GetPositions(int id, string word)
    {
        if (Data.ContainsKey(word) && Data[word].ContainsKey(id))
            return Data[word][id];
        return new List<int>();
    }

    public void Remove(int id)
    {
        foreach (var word in Data.Keys)
            if (Data[word].ContainsKey(id))
                Data[word].Remove(id);
    }
}