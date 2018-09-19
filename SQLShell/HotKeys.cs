using System;

namespace SQLShell
{
    public class HotKeys
    {
        public bool ExecuteQuery()
        {
            ConsoleKeyInfo input = Console.ReadKey(true);

            if (input.Modifiers == ConsoleModifiers.Control)
            {
                if (input.Key == ConsoleKey.Enter)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
