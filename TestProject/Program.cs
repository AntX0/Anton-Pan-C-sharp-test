using System;

namespace TestProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandCheckTaskOne = "1";
            const string CommandCheckTaskTwo = "2";
            const string CommandExitProgram = "3";

            bool isWorking = true;
            TestTaskOne taskOne = new TestTaskOne();
            TestTaskTwo taskTwo = new TestTaskTwo();

            while (isWorking)
            {
                Console.WriteLine($"\n{CommandCheckTaskOne} - Проверить первое задание\n" +
                   $"{CommandCheckTaskTwo} - Проверить второе задание\n" +
                   $"{CommandExitProgram} - выйти");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandCheckTaskOne:
                        taskOne.RunTask();
                        break;

                    case CommandCheckTaskTwo:
                        taskTwo.RunTask();
                        break;

                    case CommandExitProgram:
                        isWorking = false;
                        break;
                }
            }
        }
    }
}

public class TestTaskOne
{
    private string _userInputName;
    private int _userInputNumber;
    private int _verificationNumber;
    private string _verificationName;

    public TestTaskOne()
    {
        _verificationNumber = 7;
        _verificationName = "Вячеслав";
    }

    public void RunTask()
    {
        Console.Clear();

        const string CommandRunTask = "1";
        const string CommandExitTask = "2";

        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine($"\n{CommandRunTask} - Запустить задание\n" +
                  $"{CommandExitTask} - выйти");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case CommandRunTask:
                    ExecuteTask();
                    break;

                case CommandExitTask:
                    isRunning = false;
                    break;
            }
        }
    }

    private void ExecuteTask()
    {
        Console.WriteLine("Введите имя");
        _userInputName = Console.ReadLine();

        Console.WriteLine("Введите число");
        _userInputNumber = ConverterToInt.GetInt();

        Console.Clear();

        ShowAnswer(_userInputName, _userInputNumber);
    }

    private void ShowAnswer(string userInputName, int userInputNumber)
    {
        if (userInputName == _verificationName)
        {
            Console.WriteLine($"Привет, {_verificationName}");
        }
        else
        {
            Console.WriteLine("Нет такого имени");
        }

        if (userInputNumber > _verificationNumber)
        {
            Console.WriteLine("Привет!");
        }
    }
}

public class TestTaskTwo
{
    private int[] _numbers;
    private int _number;

    public TestTaskTwo()
    {
        _number = 3;
    }

    public void RunTask()
    {
        Console.Clear();

        const string CommandRunTask = "1";
        const string CommandExitTask = "2";

        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine($"\n{CommandRunTask} - Запустить задание\n" +
                  $"{CommandExitTask} - выйти");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case CommandRunTask:
                    ExecuteTask();
                    break;

                case CommandExitTask:
                    isRunning = false;
                    break;
            }
        }
    }

    private void ExecuteTask()
    {
        Console.Clear();

        Console.WriteLine("Введите размер массива");
        _numbers = new int[ConverterToInt.GetInt()];
        FillArray(_numbers);

        FindMultiplesOfNumber(_numbers, _number);
    }

    private void FillArray(int[] array)
    {
        int minNumber = 0;
        int maxNumber = 100;

        Random randomNumber = new Random();

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = randomNumber.Next(minNumber, maxNumber);
        }
    }

    private void FindMultiplesOfNumber(int[] array, int number)
    {
        Console.WriteLine("Содержимое массива");
        Array.ForEach(array, Console.WriteLine);

        Console.WriteLine("Числа кратные 3");

        foreach (int num in array)
        {
            if (num % number == 0 && num != 0)
            {
                Console.Write($"{num} ");
            }
        }
    }
}

public static class ConverterToInt
{
    public static int GetInt()
    {
        int result;
        bool isCorrectInput;

        do
        {
            if ((isCorrectInput = int.TryParse(Console.ReadLine(), out result)) == false)
                Console.WriteLine("Неверный ввод, повторите");
        }
        while (isCorrectInput == false);

        return result;
    }
}
