using Newtonsoft.Json;

namespace E_Commerce.Api.Utils;

public class Util
{
    public static string ImageRetrieve(string imageName)
    {
        var path = $@"C:\Users\user\Desktop\Images\{imageName}";
        var b = File.ReadAllBytes(path);
        return "data:/image/png;base64," + Convert.ToBase64String(b);
    }

    public static async Task<string> ImageByPath(string path)
    {
        var file = await File.ReadAllBytesAsync(path);
        return "data:/image/png;base64," + Convert.ToBase64String(file);
    }

    public List<string> ConvertStringToList(string s)
    {
        return JsonConvert.DeserializeObject<List<string>>(s) ?? throw new InvalidOperationException();
    }
}