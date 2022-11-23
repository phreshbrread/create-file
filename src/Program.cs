static void InvalidUsage()
{
    Console.WriteLine("Usage: create-file [size] [unit] [path/filename]");
}

// ----- //

if (args.Length != 3)
{
    InvalidUsage();
    return;
}

long size;
try
{
    size = long.Parse(args[0]);
}
catch (FormatException)
{
    InvalidUsage();
    return;
}

long displaySize = size;
string unit = args[1].ToLower();
string path = args[2];

switch (unit)
{
    case "b":
        break;
    case "kb":
        size *= 1024;
        break;
    case "mb":
        size *= 1048576;
        break;
    case "gb":
        size *= 1073741824;
        break;
    case "tb":
        size *= 1099511627776;
        break;
    default:
        InvalidUsage();
        return;
}

var fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
fileStream.SetLength(size);

Console.WriteLine("Created {0}{1} file at {2}", displaySize, unit, path);