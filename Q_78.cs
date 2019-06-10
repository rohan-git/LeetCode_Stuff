public class Solution 
{
    public IList<IList<int>> Subsets(int[] nums) 
	{
		List<IList<int>> list = new List<IList<int>>();
        list.Add(new List<int>());
        
        Queue<List<int>> q = new Queue<List<int>>();
        q.Enqueue(new List<int>());
        
        Array.Sort(nums);
        
		RecursiveBFS(list, q, nums); //, 0);
		
		return list;
	}
    
    private void RecursiveBFS(List<IList<int>> list, Queue<List<int>> q, int[] nums) //, int start)
	{
        
        while(q.Count > 0)
        {
            
            List<int> tmpList = q.Dequeue();
            
            int lastItem = 0;
            if(tmpList.Count > 0){
                 lastItem = tmpList[tmpList.Count - 1];
            }
            
            //Console.WriteLine("num to be processed: " + (lastItem));
 
            
            for(int i = lastItem; i < nums.Length; i++)
            {
                List<int> tmp = new List<int>(tmpList);
                tmp.Add(nums[i]);

                list.Add(tmp);
                q.Enqueue(tmp);

                // Console.Write("Subset looks like: ["); for (int k = 0; k < tmp.Count; k++)  { Console.Write(tmp[k] + ", "); } Console.WriteLine("]");

            }
            
            BFS(list, q, nums); //, start + 1);
        }
        

		//Console.WriteLine("Returning from recursion ..."); 
	}
    
    
    

	private void BacktrackDFS(List<IList<int>> list, 
                           List<int> tempList, int[] nums, int start)
	{
        
		list.Add(new List<int>(tempList));
		
		for(int i = start; i < nums.Length; i++)
		{
			tempList.Add(nums[i]);
			Console.WriteLine("Added: " + nums[i] + " to subset"); 
			
			BacktrackDFS(list, tempList, nums, i + 1);
			
			Console.Write("Subset looks like: ["); for (int k = 0; k < tempList.Count; k++)  { Console.Write(tempList[k] + ", "); } Console.WriteLine("]");
				
			Console.WriteLine("Removed: " + tempList[tempList.Count-1] + " from subset"); 
			tempList.RemoveAt(tempList.Count-1);
		}
		Console.WriteLine("Returning from recursion ..."); 
	}
}