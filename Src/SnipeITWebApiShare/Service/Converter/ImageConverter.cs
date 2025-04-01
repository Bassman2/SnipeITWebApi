namespace SnipeITWebApi.Service.Converter;

internal static class ImageConverter
{
    public static string? ConvertImageToBase64(string? imagePath)
    {
        if (string.IsNullOrWhiteSpace(imagePath))
        {
            return null;
        }
        

        byte[] fileBytes = File.ReadAllBytes(imagePath);
        string base64File = Convert.ToBase64String(fileBytes);
        string fileName = Path.GetFileName(imagePath);
        string fileExt = Path.GetExtension(imagePath).Trim('.').ToLower();
        string image = $"data:image/{fileExt};name={fileName};base64,{base64File}";
        return image;        
    }
}
