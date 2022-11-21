using StructuresAndOOPIntro;
using System.Text;

try
{
    Console.WriteLine("Press:" +
        "\n'r' to read all employees. " +
        "\n'q' to read employee by id." +
        "\n'w'to write employee" +
        "\n'd'to delete employee");

    var key = Console.ReadKey().Key;

    switch (key) 
    {
        case ConsoleKey.R:
            break;
        case ConsoleKey.Q:
            break;
        case ConsoleKey.W:
            break;
        case ConsoleKey.D:
            break;
    }

    using (var fileStream = new FileStream(Consts.FilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
    {
        using var streamReader = new StreamReader(fileStream, Encoding.Unicode);
        var sb = new StringBuilder();

        var line = default(string);
        //используется в качестве инкремента для автоматического добавления Id новой записи
        var counter = 1;

        while ((line = streamReader.ReadLine()) != null)
        {
            counter++;
            sb.AppendLine(string.Join(' ', line.Split(Consts.Separator)));
        }

        Console.WriteLine(string.IsNullOrEmpty(sb?.ToString()) ? "File is empty" : sb);


        Console.WriteLine("Press 'enter' to write employee information or any other key to exit:\n");
        var keyValue = Console.ReadKey().Key;

        //очищаем stringBuilder от старых значений для переиспользования в дальнейшем коде
        sb.Clear();
        while (keyValue is ConsoleKey.Enter)
        {
            Console.WriteLine("Insert employee first name");
            var firstName = Console.ReadLine();

            Console.WriteLine("Insert employee last name");
            var lastName = Console.ReadLine();

            Console.WriteLine("Insert employee age");
            var age = int.TryParse(Console.ReadLine(), out var ageResult)
                ? ageResult
                : throw new FormatException("Invalid age format, numeric format is expected");

            Console.WriteLine("Insert height of the employee");
            var height = int.TryParse(Console.ReadLine(), out var heightResult)
                ? heightResult
                : throw new FormatException("Invalid height format, nuawdmeric format is expected");

            Console.WriteLine("Insert employee date of birth in format MM/dd/yyyy");
            var dateOfBirth = DateTime.TryParse(Console.ReadLine(), out var dateResult)
                ? dateResult.ToShortDateString()
                : throw new FormatException("Invalid date of birth format, date MM/dd/yyyy format is expected");

            Console.WriteLine("Insert employee place of birth");
            var placeOfBirth = Console.ReadLine();

            sb.AppendLine($"{counter}#{DateTime.Now}#{firstName}#{lastName}#{age}#{height}#{dateOfBirth}#{placeOfBirth}");
            counter += counter;

            Console.WriteLine("Press 'enter' to write employee information or any other key to exit:\n");
            keyValue = Console.ReadKey().Key;
        }

        using var streamWriter = new StreamWriter(fileStream, Encoding.Unicode);
        streamWriter.Write(sb);
    }

    Console.Clear();

    //выводим результат добавления
    using var fileStreamToView = new FileStream(Consts.FilePath, FileMode.Open);
    using var stream = new StreamReader(fileStreamToView, Encoding.Unicode);

    var fileinfo = string.Join(' ', stream.ReadToEnd().Split(Consts.Separator));
    Console.WriteLine(fileinfo);
}
catch (FormatException ex)
{
    Console.WriteLine($"{nameof(FormatException)}:{ex.Message}");
}
catch
{
    Console.WriteLine("An error occurred while executing process on your local machine.");
}
