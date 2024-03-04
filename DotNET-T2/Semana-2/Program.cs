﻿//region  Foreach examples
string[] people = { "Ana", "Alan", "Alana", "Maria", "João", "José", "Pedro" };

foreach (string person in people)
{
    Console.WriteLine(person);
}

//Exercicio 1 

for (int i = 0; i <= 30; i++)
{
    if (i % 3 == 0 || i % 4 == 0)
    {
        Console.WriteLine(i);
    }
}

//Exercicio 2 region Fibonacci


int a = 0, b = 1, c = 0;

while (c <= 100)
{
    Console.WriteLine(c);
    a = b;
    b = c;
    c = a + b;
}

// Exercicio 3

int n = 8;

for (int i = 1; i <= n; i++)
{
    for (int j = 1; j <= i; j++)
    {
        Console.Write(i * j + " ");
    }
    Console.WriteLine();
}

//region String examples

Console.WriteLine("What's your name?");
string name = Console.ReadLine();
Console.WriteLine($"Hello {name}");

string[] names = name.Split(' ');
foreach (var item in names)
{
    Console.WriteLine(item);
}

