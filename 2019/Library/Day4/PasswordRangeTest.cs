namespace Library.Day4
{
    public static class PasswordChecker
    {

        public static int PasswordCheck(int rangeStart, int rangeEnd, bool exludeLargerMatches = false)
        {
            //brute force check for passwords that meet the rule set 
            int count = 0;
            for (int i = rangeStart; i <= rangeEnd; i++)
            {
                if (IsValid(i, exludeLargerMatches))
                {
                    count++;
                }
            }
            return count;
        }

        public static bool IsValid(int password, bool exludeLargerMatches = false)
        {
            var chars = password.ToString().ToCharArray();
            const int MAXLEN = 6;

            bool subsequent = false;
            for (int i = 0; i < MAXLEN-1; i++)
            {
                if (chars[i + 1] < chars[i])
                    return false;

                if (chars[i + 1] == chars[i])
                {
                    if(exludeLargerMatches)
                    {
                        // ensure the left and right bound of this character match are not matches
                        if(i > 0 && chars[i-1] == chars[i])
                            continue;
                        if(i < MAXLEN-2 && chars[i+2] == chars[i])
                            continue;
                    }
                    subsequent = true;
                }
            }

            return subsequent;
        }

    }
}
