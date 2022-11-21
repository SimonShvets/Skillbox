using StructuresAndOOPIntro.Models;

namespace StructuresAndOOPIntro.Repositories.WorkerRepository
{
    internal interface IWorkerRepository
    {
        Worker[] GetAllWorkers();

        Worker GetWorkerById(int id);

        void DeleteWorker(int id);

        void AddWorker(Worker worker);

        Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo);
    }
}
