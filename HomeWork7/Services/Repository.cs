using HomeWork7.Models;

namespace HomeWork7.Services;

class Repository
{
    private readonly string _file = string.Empty;
    
    private readonly string _template = "{0}#{1}#{2}#{3}#{4}#{5}";

    private int id;

    public Repository()
    {
        _file = Path.Combine(Directory.GetCurrentDirectory(), "_db.txt");

        if (!File.Exists(_file))
        {
            File.Create(_file).Dispose();
        }
    }

    public Worker[] GetAllWorkers()
    {
        return ReadAll();
    }

    public Worker GetWorkerById(int id)
    {
        return ReadAll().FirstOrDefault(x => x.Id == id);
    }

    public void DeleteWorker(int id)
    {
        var workers = GetAllWorkers();

        File.WriteAllText(_file, string.Empty);

        Write(workers.Where(s => s.Id != id).ToArray());

    }

    public void AddWorker(Worker worker)
    {
        Write(new Worker[] { worker });
    }

    public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
    {
        return GetAllWorkers().Where(s => s.Time > dateFrom && s.Time < dateTo).ToArray();
    }

    private void Write(Worker[] workers)
    {
        if (File.Exists(_file))
        {
            int Id = ReadAll().Length == 0 ? 1 : (ReadAll().Max(s => s.Id) + 1);

            foreach (var worker in workers)
            {
                File.AppendAllLines(_file, new string[] { string.Format(_template, Id, worker.Time, worker.FullName, worker.Age, worker.Height, worker.BornPlace) });
                Id++;
            }
        }
    }

    private Worker[] ReadAll()
    {
        List<Worker> workers = new();

        if (File.Exists(_file))
        {
            string[] lines = File.ReadAllLines(_file);
            if (lines.Length != 0)
            {
                foreach (var line in lines)
                {
                    string[] data = line.Split('#');

                    Worker worker = new Worker
                    {
                        Id = int.Parse(data[0]),
                        Time = DateTime.Parse(data[1]),
                        FullName = data[2],
                        Age = int.Parse(data[3]),
                        Height = int.Parse(data[4]),
                        BornPlace = data[5],
                    };

                    workers.Add(worker);
                }
            }
        }

        return workers.ToArray();
    }
   
}