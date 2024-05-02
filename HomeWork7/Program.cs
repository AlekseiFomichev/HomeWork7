using HomeWork7.Models;
using HomeWork7.Services;

Console.WriteLine("СОТРУДНИКИ \nВведите 1 для вовыда списка сотрудников " +
    "\nВведите 2 для добавления нового сотрудника" + "\nВведите 3 для удаления сотрудника" +
    "\nВведите 4 для поиска сотрудника по его ID"
    );

var repository = new Repository();

int inputNumber = int.Parse(Console.ReadLine());
switch (inputNumber)
{
    case 1:
        Console.Clear();
        var workers = repository.GetAllWorkers();

        foreach (var worker in workers)
        {
            Console.WriteLine(worker.ToString());
        }
        
        break;
    case 2:
        Console.Clear();
        
        Console.WriteLine("ФИО сотрудника:");
        string fullName = Console.ReadLine();

        Console.WriteLine("Возраст сотрудника:");
        int age = int.Parse(Console.ReadLine());

        Console.WriteLine("Рост сотрудника:");
        int height = int.Parse(Console.ReadLine());

        Console.WriteLine("Дата рождения сотрудника:");
        DateTime time = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Место рождения сотрудника:");
        string bornPlace = Console.ReadLine();


        repository.AddWorker(new Worker
        {
            FullName = fullName,
            Age = age,
            Height = height,
            Time = time,
            BornPlace = bornPlace,
        });
        
        break;

    case 3:
        Console.Clear();
        Console.WriteLine("Введите id сотрудника для удаления");
        repository.DeleteWorker(int.Parse(Console.ReadLine()));
        break;
    case 4:
        Console.Clear();
        Console.WriteLine("Введите id сотрудника для его поиска");
        var workerById = repository.GetWorkerById(int.Parse(Console.ReadLine()));           
        Console.WriteLine($"{workerById.Id}, ФИО: {workerById.FullName}");      
        break;


}


