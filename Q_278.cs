public class Solution
{
  public static readonly int FirstBadVersion = 10;
  
  public static int firstBadVersion(int totalVersions) {
      for (int i = 1; i < totalVersions; i++) {
          if (isBadVersion(i)) {
              return i;
          }
      }
      return n;
  }
  
  public static bool isBadVersion(int i){
    return i < 10;
  }
  
  public static void main(string[] args)
  {
    int totalVersions = 100;
    int result = firstBadVersion(totalVersions);
    Console.WriteLine(string.Format("First bad version after {0} is {1}", FirstBadVersion, result));
  }
}
