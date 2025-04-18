static void factorial(int n){
    int ans = n;
    for (int i = n - 1; i > 0; i--){
        ans *= i;
    }
    Console.WriteLine(ans);
}

Console.WriteLine("Enter a number to calculate its factorial: ");
int n = Convert.ToInt32(Console.ReadLine());
factorial(n);