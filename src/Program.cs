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
long.TryParse(args[0], out size);
string unit = args[1].ToLower();
string path = args[2];

Console.WriteLine("{0} {1} {2}", size, unit, path);

switch (unit)
{
    case "b":
        break;
    case "kb":
        size = size * 1024;
        break;
    case "mb":
        size = size * 1048576;
        break;
    case "gb":
        size = size * 1073741824;
        break;
    case "tb":
        size = size * 1099511627776;
        break;
    default:
        InvalidUsage();
        break;
}

var fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
fileStream.SetLength(size);