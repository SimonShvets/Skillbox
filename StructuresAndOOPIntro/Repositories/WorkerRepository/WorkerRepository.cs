using StructuresAndOOPIntro.Models;
namespace StructuresAndOOPIntro.Repositories.WorkerRepository
{
    sealed class WorkerRepository: IWorkerRepository
    {
        public Worker[] GetAllWorkers()
        {
            // здесь происходит чтение из файла
            // и возврат массива считанных экземпляров
            throw new NotImplementedException(); 
        }

        public Worker GetWorkerById(int id)
        {
            // происходит чтение из файла, возвращается Worker
            // с запрашиваемым ID
            throw new NotImplementedException();
        }

        public void DeleteWorker(int id)
        {
            // считывается файл, находится нужный Worker
            // происходит запись в файл всех Worker,
            // кроме удаляемого
            throw new NotImplementedException();
        }

        public void AddWorker(Worker worker)
        {
            // присваиваем worker уникальный ID,
            // дописываем нового worker в файл
            throw new NotImplementedException();
        }

        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            // здесь происходит чтение из файла
            // фильтрация нужных записей
            // и возврат массива считанных экземпляров
            throw new NotImplementedException(); 
        }
    }
}
