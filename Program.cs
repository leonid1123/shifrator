Random r = new Random();
KFS kfc = new KFS();
WorkPathNames workPath = new WorkPathNames();
if (workPath.StrWorkPath_.Equals("-1")) return;
void Rasshifrovanie(String _kniga, String _shifr, String _strWorkPath)
{
    String[] a = _shifr.Split('\u002C');
    for (int i = 0; i < a.Length; i++)
    {
        System.IO.File.AppendAllText(_strWorkPath + @"\fraza.txt", _kniga[int.Parse(a[i])].ToString());
    }
}
void Shifrovanie(String _kniga, String _fraza,String _strWorkPath)
{
    System.IO.File.Delete(_strWorkPath + @"\shifr.txt");
    List<Char> chars = new List<char>(); //список для букв из книги
    List<int> ints = new List<int>(); //список для номеров букв
    for (int i = 0; i < _kniga.Length; i++)
    {
        chars.Add(_kniga[i]);
    }
    for (int i = 0; i < _fraza.Length; i++)
    {
        char c = _fraza[i];
        for (int j = 0; j < chars.Count; j++)
        {
            if (chars[j].Equals(c))
            {
                ints.Add(j);
            }
        }
        int nn = r.Next(0, ints.Count);
        if (i != _fraza.Length - 1)
        {
            System.IO.File.AppendAllText(_strWorkPath + @"\shifr.txt", ints[nn].ToString() + ",");

        } else
        {
            System.IO.File.AppendAllText(_strWorkPath + @"\shifr.txt", ints[nn].ToString());
        }
        ints.Clear();
    }
}
if (kfc.Fraza.Length > 0)
{
    Shifrovanie(kfc.Kniga, kfc.Fraza, workPath.StrWorkPath_);
}
else //расшифровка тут
{
    Rasshifrovanie(kfc.Kniga, kfc.Shifr, workPath.StrWorkPath_);
}
Console.WriteLine("Сделяль!");

class KFS
{
    private String kniga = "";
    private String fraza = "";
    private String shifr = "";
    public String Kniga
    {
        get {
            WorkPathNames workPath = new WorkPathNames();
            return System.IO.File.ReadAllText(workPath.StrWorkPath_ + @"\book.txt"); }
    }
    public String Fraza
    {
        get {
            WorkPathNames workPath = new WorkPathNames();
            return System.IO.File.ReadAllText(workPath.StrWorkPath_ + @"\fraza.txt");
        }
    }
    public String Shifr
    {
        get {
            WorkPathNames workPath = new WorkPathNames();
            return System.IO.File.ReadAllText(workPath.StrWorkPath_ + @"\shifr.txt");
        }
    }
}
class WorkPathNames
{
    private String strWorkPath_ = "";
    public String StrWorkPath_
    {
        get
        {
            var tmp = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            if (tmp != null)
            {
                return tmp;
            }
            else
            {
                return "-1";
            }
        }
    }
}







