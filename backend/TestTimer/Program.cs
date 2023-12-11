using System.Text;

public class Prog
{
    public static void Main()
    {
        string groupName = "Footbal";
        int Lengthstr = groupName.Length;
        StringBuilder builder = new StringBuilder(groupName);

        builder.Insert(Lengthstr,"ChatAvatar");
        Console.WriteLine(builder);
    }
}