
// var tuple1 = (10, 20);
// Console.WriteLine($"tuple1: {tuple1.Item1}, {tuple1.Item2}"); // 10, 20 (tuple1);

// var tuple2 = (x: 5, y: 50);
// Console.WriteLine($"tuple2: {tuple2.x}, {tuple2.y}");

// var tuple3 = (id: 10, name: "Alan", born: new DateTime(1989, 07, 10));
// Console.WriteLine($"tuple3: {tuple3.id}, {tuple3.name}, {tuple3.born}");

// List<(int id, string name, DateTime born)> list = new List<(int, string, DateTime)>();
// list.Add(tuple3);
// list.Add((11, "Alan", new DateTime(1989, 07, 10)));

// list.ForEach(x => Console.WriteLine($"Tuple 4: {x.id}, {x.name}, {x.born.ToShortDateString()}"));



 // List<int> list = new List<int> { 1, 2, 3, 4, 5 };
 // var squareList = list.Select(x => x * x);
 // Console.WriteLine($"Original List: {string.Join(", ", list)}");
 // Console.WriteLine($"Square List: {string.Join(", ", squareList)}");
 // var summedList = list.Select((x, index) => x + squareList.ElementAt(index));
 // Console.WriteLine($"Summed List: {string.Join(", ", summedList)}");
 // var listMultipleOfThree = list.Where(x => x % 3 == 0).ToList();
 // listMultipleOfThree.AddRange(squareList.Where(x => x % 3 == 0));
 // listMultipleOfThree.AddRange(summedList.Where(x => x % 3 == 0));
 //
 // Console.WriteLine($"List Multiple of Three: {string.Join(", ", listMultipleOfThree)}");
 // Console.WriteLine($"List Multiple of Three Ordered: {string.Join(", ", listMultipleOfThree.OrderBy(x => x))}");
 //

try{
    int result = Divide (10,0);
    Console.WriteLine($"Result: {result}");
}
catch (DivideByZeroException ex){
    Console.WriteLine("Erro : Cannot divide by zero");
    Console.WriteLine(ex.Message);
}
catch (Exception ex){
    Console.WriteLine("An error Ocurred");
    Console.WriteLine(ex.Message);
}
finally{
    Console.WriteLine("Finally block executed");
}
int Divide (int a, int b){
    if (b == 0){
        throw new DivideByZeroException("cannot divide by zero");
    }
    return a/b;
}