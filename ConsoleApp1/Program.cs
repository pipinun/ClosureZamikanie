var fn = Outer(); // fn = Inner, так как метод Outer возвращает функцию Inner
// вызываем внутреннюю функцию Inner
fn();
fn();
fn();

Action Outer()// метод или внешняя функция
{
    int x = 5;// лексическое окружение - локальная переменная

    void Inner()// локальная функция
    {
        x++;// операции с лексическим окружением
        Console.WriteLine(x);
    }

    return Inner; // возвращаем локальную функцию
}

#region Реализация с помощью лямбда-выражений
//С помощью лямбд можно сократить определение замыкания:
var outerFn = () =>
{
    int x = 10;
    var innerFn = () => Console.WriteLine(++x);
    return innerFn;
};
var fnn = outerFn();   // fnn = innerFn, так как outerFn возвращает innerFn
// вызываем innerFn
fnn();   // 11
fnn();   // 12
fnn();   // 13

#endregion

#region Применение параметров

var fnnn = Multiply(5);  
 
Console.WriteLine(fnnn(5));   // 25
Console.WriteLine(fnnn(6));   // 30
Console.WriteLine(fnnn(7));   // 35
 
Operation Multiply(int n)
{
    int Inner(int m)
    {
        return n * m;
    }
    return Inner;
}
delegate int Operation(int n);

#endregion