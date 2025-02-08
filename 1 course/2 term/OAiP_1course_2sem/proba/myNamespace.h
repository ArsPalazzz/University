namespace mymath
{
    const double Pi = 3.14;

    int sum(int a, int b)
    {
        return a + b;
    }

    int pow(int base, int powerOf)
    {
        int result = base;

        for (int i = 1; i < powerOf; i++)
        {
            result *= base;
        }

        return result;
    }
}
