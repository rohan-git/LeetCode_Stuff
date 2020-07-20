public class Solution {
    public bool IsAlienSorted(string[] words, string order) {
        
        if(words == null) return false;
        if(words.Length == 0) return false;
        if(order == null) return false;
        
        if(words.Length == 1) return true;
        
        // using the 'order' string, convert a
        // word from alien ordering to regular ordering
        
        Dictionary<int, int> actualPos = new Dictionary<int, int>();
        
        for(int x = 0; x < order.Length; x++)
        {
            actualPos.Add(order[x] - 'a', x);
        }
                
        for(int x = 1; x < words.Length; x++)
        {
            int l1 = words[x-1].Length;
            int l2 = words[x].Length;
            
            //if(l1 > l2) return false;
            //Console.WriteLine("comparing: " + words[x-1] + " , " + words[x]);

            for(int y = 0, z = 0; y < l1 && z < l2; y++, z++)
            {
                int w1 = words[x-1][y] - 'a';
                int w2 = words[x][z] - 'a';
                
                //Console.Write("x: " + x + ", ");
                //Console.WriteLine("comparing: " + w1 + " , " + w2);
                
                if(actualPos[w1] > actualPos[w2])
                {
                    return false;
                }
                else if(actualPos[w1] < actualPos[w2] && (x == words.Length-1))
                {
                    return true;
                }
            }
            
            //Console.WriteLine("h: " + words[x-1] + " , " + words[x]);
            if(l1 > l2) return false;
            
        }
        
        return true;
    }
}
