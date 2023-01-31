string ssy;


Console.WriteLine("Input: ");
ssy = Console.ReadLine();

int result = Calculate(ssy);
Console.WriteLine(result);
int Calculate(string? s)
{
    if (s == string.Empty || s.Length == 0)
        return 0;

    int j = 0;
    Stack<string>
        rpn = new Stack<string>
            (),
            opt = new Stack<string>
                ();

    s = s.Trim().Replace(" ", string.Empty);

    for (int i = 0; i < s.Length; i++)
        if (s[i] >= '0' && s[i] <= '9')
            continue;
        else
        {
            if (s[i] == '(')
                opt.Push(s[i].ToString());
            else if (s[i] == ')')
            {
                if (i != j)
                    rpn.Push(s.Substring(j, i - j));

                while (opt.Count > 0 && opt.Peek() != "(")
                {
                    string v2 = rpn.Pop(),
                    v1 = rpn.Pop();

                    rpn.Push(Cal(v1, v2, opt.Pop()).ToString());
                }

                opt.Pop();
            }
            else if (s[i] == '+' || s[i] == '-' || s[i] == '*' || s[i] == '/')
            {
                if (i != j)
                    rpn.Push(s.Substring(j, i - j));

                if (opt.Count > 0 && opt.Peek() != "(")
                {
                    string v2 = rpn.Pop(),
                    v1 = rpn.Pop();

                    rpn.Push(Cal(v1, v2, opt.Pop()).ToString());
                }

                opt.Push(s[i].ToString());
            }

            j = i + 1;
        }

    if (s.Length != j)
        rpn.Push(s.Substring(j, s.Length - j));

    while (opt.Count > 0)
    {
        string v2 = rpn.Pop(),
        v1 = rpn.Pop();

        rpn.Push(Cal(v1, v2, opt.Pop()).ToString());
    }
    return Convert(rpn.Peek());
}
int Convert(string s)
{
    int num = 0,
    i = s[0] == '-' ? 1 : 0;

    for (; i < s.Length; i++)
        num = num * 10 + (s[i] - '0');

    return s[0] == '-' ? num * -1 : num;
}
int Cal(string v1, string v2, string opt)
{
    int result = 0;
    Console.WriteLine(v1 + " " + v2 + " " + opt);
    if (opt == "+")
        result = Convert(v1) + Convert(v2);
    else if (opt == "-")
        result = Convert(v1) - Convert(v2);
    else if (opt == "*")
        result = Convert(v1) * Convert(v2);
    else if (opt == "/")
        result = Convert(v1) / Convert(v2);

    return result;
}